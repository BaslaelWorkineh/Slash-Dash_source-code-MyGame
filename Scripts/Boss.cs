using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{

    public int health = 100;
    public int damage = 25;
    private float timeBtwDamage = 1.5f;
    public GameObject blood;
    public GameObject Splash;
    public GameObject death;
    public Animator camAnim;
    public Slider healthBar;
    private Animator anim;
    public bool isDead;
    public int playerHealth = 100;
    public int damagePlayer = 20;
   
    public GameObject objectToActivate;
    public GameObject tobeDeactivated;
    public GameObject Player;
    public GameObject Player1;
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

        if (health <= 25)
        {
            anim.SetTrigger("stageTwo");
        }

        if (health <= 0)
        {
            anim.SetTrigger("death");
            tobeDeactivated.SetActive(false);
            Player1.SetActive(false);
            objectToActivate.SetActive(true);
            Player.SetActive(true);
        }

        // give the player some time to recover before taking more damage !
        if (timeBtwDamage > 0)
        {
            timeBtwDamage -= Time.deltaTime;
        }

        healthBar.value = health;
    }

    public void TakeDamage()
    {
        health -= damage;
        if (health <= 0)
        {
            Instantiate(death, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            playerHealth -= damagePlayer;

            if (playerHealth <= 0)
            {
                // animator.SetBool(name: "isDead", value: collision != 0);
                Instantiate(blood, transform.position, Quaternion.identity);
                Instantiate(Splash, transform.position, Quaternion.identity);
                Destroy(other.gameObject);
            }
            if (other.CompareTag("Player") && isDead == false)
            {
                if (timeBtwDamage <= 0)
                {
                    camAnim.SetTrigger("shake");
                }
            }
        }
    }
}