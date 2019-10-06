using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NothingScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Coroutine");
    }

    private IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
