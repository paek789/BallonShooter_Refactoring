using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Update()
    {
        transform.position += new Vector3(36f* Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Target")
        {
            Destroy(gameObject, 0);
        }
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
