using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointspstg2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //���콺 Ŭ����
        if (Input.GetMouseButtonDown(0))
        {
            //���콺 Ŭ���� ��ǥ�� ��������
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //�ش� ��ǥ�� �ִ� ������Ʈ ã��
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f,LayerMask.GetMask("Monster"));
            print(hit.transform.gameObject.name);
            GameObject.Find("Gamemanagerstage2").GetComponent<gamemanager2stage>().catchscore2stg2[3 - GameObject.Find("Gamemanagerstage2").GetComponent<gamemanager2stage>().catchscorestg2] = this.name;
            GameObject.Find("Gamemanagerstage2").GetComponent<gamemanager2stage>().catchscorestg2 = 0;
            gameObject.SetActive(false);

        }
    }
}
