using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonScript : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        StartCoroutine("Coroutine");
    }

    private IEnumerator Coroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.25f);
            boxCollider2D.enabled = false;
            yield return new WaitForSeconds(0.25f);
            boxCollider2D.enabled = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
