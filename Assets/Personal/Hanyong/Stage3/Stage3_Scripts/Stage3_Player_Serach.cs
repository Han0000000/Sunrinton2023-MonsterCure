using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3_Player_Serach : MonoBehaviour
{
    Stage3_Enemy mons_scr;
    public GameObject monster;

    public Transform baseObject;
    public Transform targetObject;
    public int dir;

    private void Start()
    {
        baseObject = gameObject.GetComponent<Transform>();
        mons_scr = monster.GetComponent<Stage3_Enemy>();
        targetObject = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Player가 근처");
            Stage3_Enemy.isSearchPlayer = true;
            IsLeftRight();
            if (dir == 1) Stage3_Enemy.nextMove = 2;
            else if (dir == -1) Stage3_Enemy.nextMove = 1;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("Player가 벗어남");
            Stage3_Enemy.isSearchPlayer = false;
        }
    }

    void IsLeftRight()
    {
        if (targetObject.position.x > baseObject.position.x)
        {
            dir = 1; // 오른쪽
        }
        else if (targetObject.position.x < baseObject.position.x)
        {
            dir = -1; // 왼쪽
        }
    }
}
