using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gamemanager2stage : MonoBehaviour
{

    public int iscatchstage2 = 0;
    public int iscatch2stage2 = 0;
    public int catchscorestg2 = 0;
    public string[] catchscore2stg2 = new string[4];
    [SerializeField] GameObject astage2;
    public int catchscore222stg2 = 0;
    private void Start()
    {
        iscatchstage2 = 0;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.T)) SceneManager.LoadScene("Stage3");
        if (catchscore222stg2 >= 2)
        {
            SceneManager.LoadScene("Stage3");
        }
        if(iscatchstage2 == 0)
        {
            if (iscatchstage2 != iscatch2stage2)
            {
                astage2.gameObject.SetActive(false);
                iscatch2stage2 = 0;
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isMove = true;

            }
        }
        else
        {
            if (iscatchstage2 != iscatch2stage2) { 
                astage2.gameObject.SetActive(true);
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().isMove = false;
                GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>().SetBool("isWalk", false);
                iscatch2stage2 = 1;

                
            }
        }
    }
}
