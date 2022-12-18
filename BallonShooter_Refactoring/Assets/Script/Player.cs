using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float timer;
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
            var cmd = new MoveCommand(gameObject, 1);
            CommandManager.PlayCommand(cmd);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            var cmd = new MoveCommand(gameObject, -1);
            CommandManager.PlayCommand(cmd);            
        }
        else transform.LookAt(transform.position + new Vector3(0, 0, 1));

        if (timer > 0.2f && Input.GetKeyDown(KeyCode.Space))
        {
            var cmd = new ShootCommand(Resources.Load("Bullet") as GameObject, GameObject.Find("BulletStart").GetComponent<Transform>());
            CommandManager.PlayCommand(cmd);
            timer = 0f;
        }
    }
}
public class CommandManager
{
    public interface ICommand
    {
        void Execute();
    }
    public static void PlayCommand(ICommand command)
    {
        command.Execute();
    }
}
public class MoveCommand : CommandManager.ICommand
{
    GameObject player;
    int direction; // 1 = ¿À¸¥ÂÊ , -1 = ¿ÞÂÊ

    public MoveCommand(GameObject obj, int dir)
    {
        player = obj;
        direction = dir;
    }
    public void Execute()
    {
        if ((direction==1 && player.transform.position.z <= 4.5f) || (direction==-1 && player.transform.position.z >= -4.5f))
        {
            player.transform.position += new Vector3(0, 0, 9f * direction * Time.deltaTime);
            player.transform.LookAt(player.transform.position + new Vector3(-1* direction, 0, 1));
        }
    }
}
public class ShootCommand : CommandManager.ICommand
{
    GameObject bullet;
    Transform bulletStart;

    public ShootCommand(GameObject obj, Transform trans)
    {
        bullet = obj;
        bulletStart = trans;
    }
    public void Execute()
    {
        GameObject.Instantiate(bullet, bulletStart.position, Quaternion.identity);
    }
}
