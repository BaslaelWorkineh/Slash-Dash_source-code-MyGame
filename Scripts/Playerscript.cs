using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playerscript : MonoBehaviour
{

    private bool isFacingRight = true;
    private Animator animator;
    public LayerMask enemyLayers;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public Transform attackPointside;
    public float attackRangeside = 0.5f;
    public int attackDamage = 100;
    public int playerDamaged = 100;
    public int maXHealth = 100;
    public GameObject effect;
    public GameObject bloodSplash;
    public int playerHealth;
    public int maxPHealth = 100;
    public AudioSource Slash;
    public Animator Camerass;
    private bool moveLeft;
    private bool moveRight;
    private Rigidbody2D rb;
    private float horizontalMove;
    public float speed = 5;

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        moveLeft = false;
        moveRight = false;
      
    }
    
    public void PointerDownLeft()
    {
        moveLeft = true;

    }
    public void PointerUpLeft()
    {
        moveLeft = false;
    }
    public void PointerDownRight()
    {
        moveRight = true;
    }
    public void PointerUpRight()
    {
        moveRight = false;
    }

    private void movePlayer()
    {
        if (moveLeft)
        {
            horizontalMove = -speed;
        } 
        else if (moveRight)
        {
            horizontalMove = speed;
        }
        else
        {
            horizontalMove = 0;
        }
    }
    private void Update()
    {

        movePlayer();

        if(Input.GetKeyUp(KeyCode.X))
        {
            Attack();
            Slash.Play();
           
        }
        if (Input.GetKeyUp(KeyCode.Z))
        {
            sideAttack();
            Slash.Play();
        }

        Flip();
    }
    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        if (attackPointside == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPointside.position, attackRange);
    }

   public void sideAttack()
    {
        animator.SetTrigger("isAttackingSide");
        Camerass.SetTrigger("Shaking");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPointside.position, attackRangeside, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakingDamege(attackDamage);
            enemy.GetComponent<Boss>().TakeDamage();
        }
    }

   public void Attack()
    {
        animator.SetTrigger("isAttacking");
         Camerass.SetTrigger("Shaking");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().TakingDamege(attackDamage);
            enemy.GetComponent<Boss>().TakeDamage();
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMove, rb.velocity.y);

    }

    private void Flip()
    {
        if (isFacingRight && horizontalMove > 0f || !isFacingRight && horizontalMove < 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

}