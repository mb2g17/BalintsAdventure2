using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    private float health = 1;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D boxCollider2D;

    public Image HealthBar;
    public Image HealthBarBG;

    public GameObject Drop;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        HealthBar.fillAmount = health;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Attack"))
            health -= 0.1f;

        if (health <= 0.01f)
        {
            GameObject drop = Instantiate(Drop);
            drop.transform.position = transform.position;

            spriteRenderer.enabled = false;
            boxCollider2D.enabled = false;
            HealthBarBG.enabled = false;
            StartCoroutine("Respawn");
        }
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(6);
        spriteRenderer.enabled = true;
        boxCollider2D.enabled = true;
        HealthBarBG.enabled = true;
        health = 1;
    }
}
