using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    enum GameState
    {
        IsOnUI,
        IsOffUI
    }

    float timer = 0;
    int life = 5;
    int score = 0;
    public float gamespeed;

    GameState state;
    void Start()
    {
        StateUpdate(GameState.IsOnUI);
    }
    void Update()
    {
        if (state == GameState.IsOffUI)
        {
            timer += (Time.deltaTime * gamespeed);
            if (transform.position.x < 30f)
            {
                transform.position += new Vector3(2.5f * 0.0002f, 0.0002f, 0);
            }
            if (timer > 1.0f)
            {
                Debug.Log("생성");
                timer = 0;
                CreateTarget();
                gamespeed += 0.02f;
            }
        }
    }
    void StateUpdate(GameState st)
    {
        state = st;

        switch (state)
        {
            case GameState.IsOnUI:
                GameObject.Find("Canvas").transform.Find("MainUI").gameObject.SetActive(true);
                GameObject.Find("Canvas").transform.Find("GameUI").gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                Time.timeScale = 0;
                break;
            case GameState.IsOffUI:
                GameObject.Find("Canvas").transform.Find("GameUI").gameObject.SetActive(true);
                GameObject.Find("Canvas").transform.Find("MainUI").gameObject.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                Time.timeScale = 1;
                break;
        }
    }
    void CreateTarget()
    {
        GameObject target = Instantiate(Resources.Load("Target") as GameObject, new Vector3(30f, 1, Random.Range(-2, 3) * 2), Quaternion.identity);
        target.GetComponent<Target>().isHit += WhenTargetDestory;
        target.GetComponent<Target>().passEndLine += WhenTargetPassEndLine;
    }
    void WhenTargetPassEndLine()
    {
        life--;
        GameObject.Find("GameUI").transform.Find("Life").GetComponent<Text>().text = "" + life;
        if (life == 0) GameOver();
    }
    void WhenTargetDestory(int num, Transform targetTransform)
    {
        score += num;
        GameObject.Find("GameUI").transform.Find("Score").GetComponent<Text>().text = "" + score;
        MakeParticle(targetTransform);
    }
    void GameOver()
    {
        StateUpdate(GameState.IsOnUI);
        GameObject.Find("MainUI").transform.Find("GameOverUI").gameObject.SetActive(true);
        GameObject.Find("GameOverScore").GetComponent<Text>().text = "내 점수 : " + score;
    }
    void MakeParticle(Transform targetTransform)
    {
        GameObject particle = Instantiate(Resources.Load("particle") as GameObject, targetTransform.position, Quaternion.identity);
        Destroy(particle, 5);
    }
    public void GoToMain()
    {
        SceneManager.LoadScene("BallonShooter");
    }
    public void GameStart()
    {
        GameObject.Find("MainUI").transform.Find("GameStart").gameObject.SetActive(false);
        StateUpdate(GameState.IsOffUI);
    }
}
