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
        //마우스 클릭시
        if (Input.GetMouseButtonDown(0))
        {
            //마우스 클릭한 좌표값 가져오기
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //해당 좌표에 있는 오브젝트 찾기
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, 0f,LayerMask.GetMask("Monster"));
            print(hit.transform.gameObject.name);
            GameObject.Find("Gamemanagerstage2").GetComponent<gamemanager2stage>().catchscore2stg2[3 - GameObject.Find("Gamemanagerstage2").GetComponent<gamemanager2stage>().catchscorestg2] = this.name;
            GameObject.Find("Gamemanagerstage2").GetComponent<gamemanager2stage>().catchscorestg2 = 0;
            gameObject.SetActive(false);

        }
    }
}
