using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Target : MonoBehaviour
{
    public event Action<int,Transform> isHit;
    public event Action passEndLine;

    void Update()
    {
        transform.position += new Vector3(-0.002f * (GameObject.Find("Main Camera").GetComponent<GameManager>().gamespeed * 2f) * 900* Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            isHit(1,transform);
            Destroy(gameObject, 0);
        }
        if(other.tag == "EndLine")
        {
            passEndLine();
            Destroy(gameObject, 0);
        }
    }
}
