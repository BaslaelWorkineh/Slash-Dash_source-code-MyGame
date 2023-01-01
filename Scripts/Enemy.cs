using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.UI.Image;

public class Enemy : MonoBehaviour
{
    public int maXHealth = 100;
    int currentHealth;
    public GameObject effect;
    public GameObject gameObjectsplash;
    public GameObject blood;
    public GameObject Splash;
    public int playerHealth = 90;
    public int damagePlayer = 30;
    public AudioClip Squash;
    public int damage = 100;


    void Start()
    {
        currentHealth = maXHealth;
    }
    public void TakingDamege(int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            Die();
            AudioSource.PlayClipAtPoint(Squash, transform.position);
            
        }


    }
    void Die()
    {



        GameObject clone = (GameObject)Instantiate(gameObjectsplash, transform.position, Quaternion.identity);

        Destroy(clone, 1.0f);
       GameObject Particle = (GameObject)Instantiate(effect, transform.position, Quaternion.identity);
       Destroy(Particle, 3.0f);

        Destroy(gameObject);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            
            playerHealth -= damagePlayer;
            if(playerHealth <= 0)
            {
                // animator.SetBool(name: "isDead", value: collision != 0);
                Instantiate(blood, transform.position, Quaternion.identity);
                Instantiate(Splash, transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
            }

        }
    }

}
