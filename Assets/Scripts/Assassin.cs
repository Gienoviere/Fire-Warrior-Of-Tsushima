using UnityEngine;

public class Assassin : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 100;
    int currentHealth;

    public Transform[] patrolPoints;
    public float moveSpeed;
    public int patrolDestination;

    public Transform playerTransform;
    public bool isChasing;
    public float chaseDistnce;

    public WarriorMovement playerHealth;
    public int damage = 20;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        animator.SetFloat("speed", Mathf.Abs(moveSpeed));
        if (isChasing)
        {
            if(transform.position.x > playerTransform.position.x) 
            {
                transform.localScale = new Vector3(2, 2, 1);
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }

            if (transform.position.x < playerTransform.position.x)
            {
                transform.localScale = new Vector3(-2, 2, 1);
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
        }

        else
        {
            if(Vector2.Distance(transform.position, playerTransform.position) < chaseDistnce)
            {
                isChasing= true;
            }

            if (patrolDestination == 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[0].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[0].position) < 0.2f)
                {
                    transform.localScale = new Vector3(2, 2, 1);
                    patrolDestination = 1;
                }
            }

            if (patrolDestination == 1)
            {
                transform.position = Vector2.MoveTowards(transform.position, patrolPoints[1].position, moveSpeed * Time.deltaTime);
                if (Vector2.Distance(transform.position, patrolPoints[1].position) < 0.2f)
                {
                   transform.localScale = new Vector3(-2, 2, 1);
                   patrolDestination = 0;
                }
            }
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("IsDead", true);

        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            
            animator.SetTrigger("Attack");
            playerHealth.TakeDamage(damage);
        }
        else
        {
            animator.SetBool("IsAttacking", false);
        }
    }
}
