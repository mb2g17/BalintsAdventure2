﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Balint character script
/// </summary>
public class BalintScript : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private Animator animator;

    /// <summary>
    /// How much force we will move
    /// </summary>
    public float MovementForce = 10;

    public float JumpingForce = 5;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetTrigger("Cast");
        }
    }
}
