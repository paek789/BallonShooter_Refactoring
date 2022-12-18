using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float timer;
    [SerializeField]
    GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (transform.position.z <= 4.5f)
            {
                transform.position += new Vector3(0, 0, 9f*Time.deltaTime);
                transform.LookAt(transform.position + new Vector3(-1, 0, 1));
            }
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            if(transform.position.z>= -4.5f)
            {
                transform.position += new Vector3(0, 0, -9f * Time.deltaTime);
                transform.LookAt(transform.position + new Vector3(1, 0, 1));
            }           
        }
        else transform.LookAt(transform.position + new Vector3(0, 0, 1));
        if (timer > 0.2f && Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(obj, GameObject.Find("BulletStart").GetComponent<Transform>().position, Quaternion.identity);
            timer = 0f;
        }
    }
}
