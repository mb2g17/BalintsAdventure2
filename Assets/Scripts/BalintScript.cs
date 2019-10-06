using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Balint character script
/// </summary>
public class BalintScript : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    private Animator animator;
    private SpellCaster spellCaster;

    private float health = 1;

    /// <summary>
    /// How much force we will move
    /// </summary>
    public float MovementForce = 10;

    public float JumpingForce = 5;

    public Animator PauseAnimator;

    public Image HealthBar;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spellCaster = FindObjectOfType<SpellCaster>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Update health
        if (HealthBar != null)
            HealthBar.fillAmount = health;

        // If time is moving
        if (Time.timeScale > 0)
        {
            // Moving left and right
            if (Input.GetKey(KeyCode.A))
            {
                rigidbody2D.AddForce(new Vector2(-MovementForce, 0));
                animator.SetBool("Move", true);
                animator.SetBool("Left", true);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                rigidbody2D.AddForce(new Vector2(MovementForce, 0));
                animator.SetBool("Move", true);
                animator.SetBool("Left", false);
            }
            else
            {
                animator.SetBool("Move", false);
            }

            // Jumping
            if (Input.GetKeyDown(KeyCode.W))
            {
                rigidbody2D.AddForce(new Vector2(0, JumpingForce));
            }

            // Animates jumping
            if (System.Math.Abs(rigidbody2D.velocity.y) <= 0.5f)
            {
                animator.SetBool("Jump", false);
            }
            else
            {
                animator.SetBool("Jump", true);
            }

            // Casting
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("Cast");
                spellCaster.CastSpell();
            }
        }

        // Pausing
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetMouseButtonDown(1))
        {
            if (PauseAnimator != null)
            {
                if (PauseAnimator.GetBool("Pause"))
                {
                    PauseAnimator.SetBool("Pause", false);
                    Time.timeScale = 1;
                }
                else
                {
                    PauseAnimator.SetBool("Pause", true);
                    Time.timeScale = 0;
                }
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
            health -= 0.1f;

        // If health is 0, game over
        if (health <= 0.01f)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
