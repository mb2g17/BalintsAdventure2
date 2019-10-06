using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    private float health = 1;

    public Image HealthBar;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.fillAmount = health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("HIT");
        if (collision.CompareTag("Attack"))
            health -= 0.1f;

        if (health <= 0.01f)
            Destroy(gameObject);
    }
}
