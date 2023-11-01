using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class monmovestage2 : MonoBehaviour
{
    private GameObject player;
    Rigidbody2D rigid;

    int next_move = 1;
    bool isgr = false;
    float spd = 1f;
    float spd2 = 3f;
    int dum=0;
    public int ancatch = 0;
    public int sangtae;
    int clear = 0;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rigid = GetComponent<Rigidbody2D>();
        sangtae = Random.RandomRange(0, 5);
        if (sangtae == 0) {
           transform.Find("상처입은").gameObject.SetActive(false);
           transform.Find("슬픈").gameObject.SetActive(false);
        }
        else if (sangtae == 1)
        {
            transform.Find("사나운").gameObject.SetActive(false);
            transform.Find("슬픈").gameObject.SetActive(false);
        }
        else if (sangtae == 2)
        {
            transform.Find("상처입은").gameObject.SetActive(false);
            transform.Find("사나운").gameObject.SetActive(false);
        }
        else
        {
            transform.Find("상처입은").gameObject.SetActive(false);
            transform.Find("사나운").gameObject.SetActive(false);
            transform.Find("슬픈").gameObject.SetActive(false);
        }
        transform.Find("pointstg2").gameObject.SetActive(false);
        transform.Find("pointstg2 1").gameObject.SetActive(false);
        transform.Find("pointstg2 2").gameObject.SetActive(false);
        transform.Find("pointstg2 3").gameObject.SetActive(false);
    }
    void FixedUpdate()
    {
        //player_spr = player.GetComponent<SpriteRenderer>();
        Stage2_Enemy_Move();
        
    }

    


    void Stage2_Enemy_Move()
    {

        if(ancatch == 0) {
            if (transform.position.x > player.transform.position.x)
            {
                transform.localScale = new Vector2(transform.localScale.x * 1, transform.localScale.y);
            }
            else
            {
                transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x) * -1, transform.localScale.y);
            }


            rigid.velocity = new Vector2(next_move*  Mathf.Max(spd, spd2), rigid.velocity.y);

            if (Mathf.Abs(transform.position.x - player.transform.position.x) < 5 && Mathf.Abs(transform.position.y - player.transform.position.y) < 3 && GameObject.Find("Gamemanagerstage2").GetComponent<gamemanager2stage>().iscatchstage2 == 0)
            {
                spd2 = 6f;
                if ((transform.position.x - player.transform.position.x) * next_move < 0)
                {
                    next_move *= -1;
                }
            }
            if (Mathf.Abs(transform.position.x - player.transform.position.x) > 7 && Mathf.Abs(transform.position.y - player.transform.position.y) > 5)
            {
                spd2 = 3f;
            }
            Vector2 frontVec = new Vector2(transform.position.x + next_move * 0.5f, transform.position.y);
            RaycastHit2D hit = Physics2D.Raycast(frontVec, Vector2.down, 10, LayerMask.GetMask("Ground"));
            if (isgr && dum == 0)
            {
                frontVec = new Vector2(transform.position.x + next_move * 0.5f, transform.position.y);
                hit = Physics2D.Raycast(frontVec, Vector2.down, 1, LayerMask.GetMask("Ground"));
                Debug.DrawRay(frontVec, Vector2.down, Color.green);
                if (hit.collider == null)
                {
                    next_move *= -1;
                    dum = Random.RandomRange(0, 2);
                }
            }
            else
            {
                frontVec = new Vector2(transform.position.x + next_move * 0.5f, transform.position.y);
                hit = Physics2D.Raycast(frontVec, Vector2.down, 10, LayerMask.GetMask("Ground"));
                Debug.DrawRay(frontVec, Vector2.down, Color.green);
                if (hit.collider == null)
                {
                    next_move *= -1;
                    dum = Random.RandomRange(0, 2);
                }
            }
            hit = Physics2D.Raycast(transform.position, Vector2.right, next_move, LayerMask.GetMask("Ground"));
            if (hit.collider != null && hit.collider.tag != "jumppoint")
            {
                next_move *= -1;
            }
            rigid.bodyType = RigidbodyType2D.Dynamic;
        }
        else
        {
            rigid.bodyType = RigidbodyType2D.Static;

            if(GameObject.Find("Gamemanagerstage2").GetComponent<gamemanager2stage>().catchscorestg2 == 0)
            {
                clear = 0;
                if (sangtae==0 && !GameObject.Find("Gamemanagerstage2").GetComponent<gamemanager2stage>().catchscore2stg2.Contains("pointstg2 3"))
                {
                    clear = 1;
                }
                if (sangtae == 1 && !GameObject.Find("Gamemanagerstage2").GetComponent<gamemanager2stage>().catchscore2stg2.Contains("pointstg2 1"))
                {
                    clear = 1;
                }
                if (sangtae == 2 && !GameObject.Find("Gamemanagerstage2").GetComponent<gamemanager2stage>().catchscore2stg2.Contains("pointstg2 2"))
                {
                    clear = 1;
                }
                clear = 1;
                GameObject.Find("Gamemanagerstage2").GetComponent<gamemanager2stage>().catchscore222stg2 += 1;
                GameObject.Find("Gamemanagerstage2").GetComponent<gamemanager2stage>().iscatchstage2 = 0;
                if(clear == 1)
                {
                    sangtae = 3;
                    transform.Find("상처입은").gameObject.SetActive(false);
                    transform.Find("사나운").gameObject.SetActive(false);
                    transform.Find("슬픈").gameObject.SetActive(false);
                }
                else
                {
                    PlayerController.isStun = true;
                    PlayerController.stun_time = 1.5f;
                }
                transform.Find("pointstg2").gameObject.SetActive(false);
                transform.Find("pointstg2 1").gameObject.SetActive(false);
                transform.Find("pointstg2 2").gameObject.SetActive(false);
                transform.Find("pointstg2 3").gameObject.SetActive(false);
                ancatch = 0;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "jumppoint" && isgr && Random.RandomRange(0, 4) < 3) {
            rigid.AddForce(Vector2.up * 13, ForceMode2D.Impulse);
            spd = 6f;
        }
        

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isgr = true;
            spd = 1f;
        }

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            isgr = false;
        }

    }
}
