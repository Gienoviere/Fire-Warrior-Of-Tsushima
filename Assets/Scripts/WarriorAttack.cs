using UnityEngine;

public class WarriorAttack : MonoBehaviour
{

    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 20;

    public float attackRate = 1f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Attack1();
                nextAttackTime = Time.time + 1f / attackRate;
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                Attack2();
                nextAttackTime = Time.time + 1f / attackRate;
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                Attack3();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void Attack1()
    {
        animator.SetTrigger("Attack1");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Assassin>().TakeDamage(attackDamage);
            Debug.Log("We hit" + enemy.name);
            enemy.GetComponent<Ronin>().TakeDamage(attackDamage);
        }
    }

    void Attack2()
    {
        animator.SetTrigger("Attack2");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Assassin>().TakeDamage(attackDamage);
        }

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy.name);
            enemy.GetComponent<Ronin>().TakeDamage(attackDamage);
        }
    }

    void Attack3()
    {
        animator.SetTrigger("Attack3");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Assassin>().TakeDamage(attackDamage);
        }

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit" + enemy.name);
            enemy.GetComponent<Ronin>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
