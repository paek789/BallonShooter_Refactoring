using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
    [SerializeField]
    GameObject obj;
    float cameraOffset;    
    float timer;
    [SerializeField]
    int life;
    int score;
    public float gamespeed;
    bool gameStart;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        timer = 0;
        gameStart = false;
        cameraOffset = 0.0002f;
        gamespeed = 1;
        Time.timeScale = 0;
    }    
    // Update is called once per frame
    void Update()
    {        
        if (gameStart)
        {
            if (transform.position.x < 30f)
            {
                transform.position += new Vector3(2.5f * cameraOffset, cameraOffset, 0);
            }
            timer += (Time.deltaTime * gamespeed);
            if (timer > 1.0f)
            {
                CreateTarget();
                gamespeed += 0.02f;
            }
        }
    }
    public void GameStart()
    {
        Time.timeScale = 1f;
        GameObject.Find("MainUI").SetActive(false);
        GameObject.Find("Canvas").transform.Find("GameUI").gameObject.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameStart = true;
    }
    public void LifeDecrease()
    {
        life--;
        GameObject.Find("GameUI").transform.Find("Life").GetComponent<Text>().text ="" + life;
        if (life == 0)
        {

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0;
            GameObject.Find("GameUI").SetActive(false);
            GameObject.Find("Canvas").transform.Find("GameOverUI").gameObject.SetActive(true);
            GameObject.Find("GameOverScore").GetComponent<Text>().text = "³» Á¡¼ö : " + score;
        }
    }

    public void ScoreIncrease()
    {
        score++;
        GameObject.Find("GameUI").transform.Find("Score").GetComponent<Text>().text = "" + score;
    }
    public void GoToMain()
    {
        SceneManager.LoadScene("BallonShooter");
    }
    void CreateTarget()
    {
        float randomX = Random.Range(0f, 5f);
        if (randomX < 1)
        {
            Instantiate(obj, new Vector3(30f, 1, -4f), Quaternion.identity);
            timer = 0;
        }
        else if (randomX < 2)
        {
            Instantiate(obj, new Vector3(30f, 1, -2f), Quaternion.identity);
            timer = 0;
        }
        else if (randomX < 3)
        {
            Instantiate(obj, new Vector3(30f, 1, 0), Quaternion.identity);
            timer = 0;
        }
        else if (randomX < 4)
        {
            Instantiate(obj, new Vector3(30f, 1, 2f), Quaternion.identity);
            timer = 0;
        }
        else if (randomX < 5)
        {
            Instantiate(obj, new Vector3(30f, 1, 4f), Quaternion.identity);
            timer = 0;
        }

    }
}
