using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    Gamemanager gamemanager;
    [SerializeField]
    GameObject particle;
    float speed = 0.002f;
    float timer;
    float targetStart;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        gamemanager = GameObject.Find("Main Camera").GetComponent<Gamemanager>();
        targetStart = (speed * -1f);
        targetStart *= (gamemanager.gamespeed * 2f);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        transform.position += new Vector3(targetStart * 900* Time.deltaTime, 0, 0);
        if(timer > 50)
        {
            Destroy(gameObject, 0);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Bullet")
        {
            gamemanager.ScoreIncrease();
            Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(gameObject, 0);
        }
        if(other.tag == "EndLine")
        {
            gamemanager.LifeDecrease();
            Destroy(gameObject, 0);
        }
    }
}
