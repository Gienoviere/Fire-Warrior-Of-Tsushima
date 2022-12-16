using UnityEngine;
using UnityEngine.SceneManagement;

public class WarriorMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float walkSpeed = 40f;
    public float runSpeed = 20f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    public int health;
    public int maxHealth = 200;

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        
        health -= amount;
        animator.SetTrigger("Hit");
        if (health <= 0)
        {
            animator.SetBool("IsDeath", true);
            RestartLevel();

        }
    }

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * walkSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }

    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "fallDeath")
        {
            RestartLevel();
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
