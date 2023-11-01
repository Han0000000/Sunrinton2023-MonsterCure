using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CmdController : MonoBehaviour
{   
    public PlayerController playerController;
    public string command;
    GameObject cureMonster;
    [SerializeField] string InputCmd ="";
    [SerializeField] Text InputCmdText;
    // Update is called once per frame
    void Update()
    {
        CmdLimit();
        InputCmdText.text = InputCmd;
        if(playerController.isCure&&command==InputCmd)
        {
            print("커맨드 동일");
            playerController.isMove = true;
            playerController.isCure = false;
            if(cureMonster.name=="Monster1")
            {
                Monster1Controller monster1Controller = cureMonster.GetComponent<Monster1Controller>();
                monster1Controller.state = Monster.State.치료된;
            }
            gameObject.SetActive(false);
            
        }
    }

    public void initPanel(string cmdCode, GameObject curemonster)
    {
        command = cmdCode;
        InputCmd = "";
        cureMonster = curemonster;
    }

    void CmdLimit()
    {
        if (InputCmd.Length > 5)
        {
            InputCmd = "";
        }
    }

    public void cmdA()
    {
        InputCmd += "A";
    }
    public void cmdB()
    {
        InputCmd += "B";
    }
    public void cmdC()
    {
        InputCmd += "C";
    }

    
    
}
