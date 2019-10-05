using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Balint character script
/// </summary>
public class BalintScript : MonoBehaviour
{
    private new Rigidbody2D rigidbody2D;
    private Animator animator;
    private SpellCaster spellCaster;

    /// <summary>
    /// How much force we will move
    /// </summary>
    public float MovementForce = 10;

    public float JumpingForce = 5;

    public Animator PauseAnimator;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spellCaster = FindObjectOfType<SpellCaster>();
    }

    // Update is called once per frame
    void Update()
    {
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
