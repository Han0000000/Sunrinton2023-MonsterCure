using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PyrCollisonCheck : MonoBehaviour
{
    [SerializeField] stage1_GameManger stage1_gamemanger;
    [SerializeField] GameObject curePanel;
    PlayerController playerController;

    public CmdController cmdController;

    

    private void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();

    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster") && !playerController.isCure && Input.GetKeyDown(KeyCode.E))
        {
            
            print(1);
            if (collision.name=="Monster1")
            {
                print(2);
                playerController.isCure = true;
           
                print(2);

                Monster1Controller monster1Controller = collision.gameObject.GetComponent<Monster1Controller>();
                monster1Controller.isMove = false;
                if (monster1Controller.state != Monster.State.치료된)
                {
                    playerController.isMove = false;
                    cmdController.initPanel(monster1Controller.cureCode, collision.gameObject);//
                    curePanel.SetActive(true);
                }

            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster") && !playerController.isCure&&Input.GetKeyDown(KeyCode.E))
        {
            print(1);
            if (collision.name == "Monster1")
            {
                print(2);
                playerController.isCure = true;
                
                Monster1Controller monster1Controller = collision.gameObject.GetComponent<Monster1Controller>();
                monster1Controller.isMove = false;
                if (monster1Controller.state != Monster.State.치료된)
                {
                    playerController.isMove = false;
                    cmdController.initPanel(monster1Controller.cureCode, collision.gameObject);
                    curePanel.SetActive(true);
                }

            }
        }
    }
}
