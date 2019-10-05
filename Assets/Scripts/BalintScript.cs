using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Balint character script
/// </summary>
public class BalintScript : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    /// <summary>
    /// How much force we will move
    /// </summary>
    public float MovementForce = 10;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody2D.AddForce(new Vector2(-MovementForce, 0));
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidbody2D.AddForce(new Vector2(MovementForce, 0));
        }
    }
}
