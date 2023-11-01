using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Monster1Controller : Monster
{
    public GameObject[] stateEfects = new GameObject[3];

    public Animator animator;
    public stage1_GameManger gameManger;


    public float DirChangeTime;

    public int FirDir;
    int moveDir=1;

    public bool isMove = true;
    bool isCured = false;

    public string cureCode="";

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        StateEffectSet();
        animator.SetBool("isWalk", true);
        CureCodSet();
        StartCoroutine(DirChange());

    }
    private void Update()
    {
        if(!(state==State.치료된)&&isMove)
        {
            transform.Translate(Vector3.right * moveDir * speed * FirDir * Time.deltaTime);
        }
        if (state == State.치료된 && !isCured)
        {
            isCured = true;
            stateEfects[0].SetActive(false);
            stateEfects[1].SetActive(false);
            stateEfects[2].SetActive(false);
            gameManger.cured_Monster1 += 1;
        }
    }

    void CureCodSet()
    {
        if(state==State.상처입은)
        {
            cureCode = "ACBBB";
        }
        else if(state==State.사나운)
        {
            cureCode = "CABAC";
        }
        else if(state==State.슬픈)
        {
            cureCode = "BAACC";
        }
    }


    void StateEffectSet()
    {
        if(state==State.사나운)
        {
            print("사나운 놈");
            stateEfects[0].SetActive(true);
        }
        else if(state==State.상처입은)
        {
            stateEfects[1].SetActive(true);
        }
        else if (state == State.슬픈)
        {
            stateEfects[2].SetActive(true);
        }
    }
    IEnumerator DirChange()
    {
        while (true)
        {
            yield return new WaitForSeconds(DirChangeTime);
            if (!isMove)
            {
                animator.SetBool("isWalk", false);
                break;
            }
                
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            moveDir *= -1;
        }
        

    }
}
