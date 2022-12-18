using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    float x;
    // Start is called before the first frame update
    void Start()
    {
        x = speed * 4f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(x *900* Time.deltaTime, 0, 0);
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
