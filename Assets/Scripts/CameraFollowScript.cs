
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public GameObject Target;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(
            Target.transform.position.x,
            Target.transform.position.y,
            transform.position.z
        );
    }
}
