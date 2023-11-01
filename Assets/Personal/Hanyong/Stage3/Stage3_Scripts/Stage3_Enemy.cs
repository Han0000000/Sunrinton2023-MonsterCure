using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3_Enemy : Monster
{
    private GameObject player;
    SpriteRenderer player_spr;
    SpriteRenderer monster_spr;
    Rigidbody2D rigid;
    [SerializeField] bool stage3_isAttack_Timing; // 몬스터가 공격할 타이밍인지
    public GameObject Attck_obj;

    public static bool isSearchPlayer; // Player가 근처에 있는지

    public float upwardForce = 1f;
    public float leftwardForce = -1f;

    public static bool isMove = true;

    Transform targetObject;
    Transform baseObject;

    [SerializeField] string targetTag; // 찾을 태그의 이름
    public float searchRadius = 10f; // 주변 탐색 반경

    string IsDir;
    // Left Right

    public static int nextMove;
    public float time;
    [SerializeField] bool isJump = false;
    [SerializeField] bool isMainGround = false;


    public Sprite[] sprites;
    // 스탠드 날기 포효 전
    private void Start()
    {
        targetTag = "Ground";
        baseObject = gameObject.GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("Stage3_Enemy_thinking", 0, 5f);
        player_spr = player.GetComponent<SpriteRenderer>();
        monster_spr = GetComponent<SpriteRenderer>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        time += Time.deltaTime;
        if (isSearchPlayer) speed = 10;
        else speed = 5;
    }
    void FixedUpdate()
    {
        if(isMove) Stage3_Enemy_Act();
    }

    void Stage3_Enemy_thinking()
    {
        nextMove = Random.Range(1, 3);
        if (time >= 4)
        {
            stage3_isAttack_Timing = true;
            time = 0;
        }
        else stage3_isAttack_Timing = false;
    }

    void Stage3_Enemy_Act()
    {
        if(stage3_isAttack_Timing == true)
        {
            Attack_spr();
        }

        else if(stage3_isAttack_Timing == false)
        {
            Stage3_Enemy_Move();
        }
    }

    void Stage3_Enemy_Move()
    {
        int next_move = 0;
        if (nextMove == 1)
        {
            monster_spr.flipX = true;
            next_move = 1; // 오른쪽
        }
        else if(nextMove == 2)
        {
            next_move = -1;
            monster_spr.flipX = false;
        }/// 왼쪽

        rigid.velocity = new Vector2(next_move * speed, rigid.velocity.y);

        Vector2 frontVec = new Vector2(transform.position.x + next_move * 0.8f, transform.position.y);
        RaycastHit2D hit = Physics2D.Raycast(frontVec, Vector2.down, 1, LayerMask.GetMask("Ground"));
        Debug.DrawRay(frontVec, Vector2.down, Color.green);
        if (hit.collider == null && !isJump)
        {
            //Debug.Log("Stage3_Enemy front is NULL");
            targetObject = FindNearestObjectWithTag(gameObject.transform.position).GetComponent<Transform>();
            IsLeftRight();
            isJump = true;
            if (!isMainGround)
            {
                if (IsDir == "Left")
                {
                    Vector3 leftForce = new Vector3(leftwardForce, 0f);
                    rigid.AddForce(leftForce, ForceMode2D.Impulse);
                }
                else if (IsDir == "Right")
                {
                    Vector3 leftForce = new Vector3(leftwardForce * -1, 0f);
                    rigid.AddForce(leftForce, ForceMode2D.Impulse);
                }
                monster_spr.sprite = sprites[1];
                Vector3 upForce = new Vector3(0f, upwardForce);
                rigid.AddForce(upForce, ForceMode2D.Impulse);
            }
        }
        if (isMainGround)
        {
            if (IsDir == "Left")
            {
                Vector3 leftForce = new Vector3(leftwardForce, 0f);
                rigid.AddForce(leftForce, ForceMode2D.Impulse);
            }
            else if (IsDir == "Right")
            {
                Vector3 leftForce = new Vector3(leftwardForce * -1, 0f);
                rigid.AddForce(leftForce, ForceMode2D.Impulse);
            }
            monster_spr.sprite = sprites[1];
            Vector3 upForce = new Vector3(0f, upwardForce + 1);
            rigid.AddForce(upForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground") isJump = false;

        if(collision.gameObject.name == "Main_Ground")
        {
            isMainGround = true;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Unknown")
        {
            monster_spr.sprite = sprites[0];
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Main_Ground")
        {
            monster_spr.sprite = sprites[1];
            isMainGround = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Wall_Left") nextMove = 1;
        else if(collision.gameObject.name == "Wall_Right") nextMove = 2;
    }


    void IsLeftRight()
    {
        if (targetObject.position.x > baseObject.position.x)
        {
            IsDir = "Right";
        }
        else if (targetObject.position.x < baseObject.position.x)
        {
            IsDir = "Left";
        }
    }

    public GameObject FindNearestObjectWithTag(Vector2 position)
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag(targetTag);

        if (taggedObjects.Length == 0)
        {
            Debug.Log("No objects found with tag: " + targetTag);
            return null;
        }

        GameObject nearestObject = null;
        float nearestDistance = Mathf.Infinity;

        foreach (GameObject taggedObject in taggedObjects)
        {
            Vector2 directionToTarget = (Vector2)taggedObject.transform.position - position;
            float distance = directionToTarget.magnitude;

            if (distance < nearestDistance)
            {
                nearestObject = taggedObject;
                nearestDistance = distance;
            }
        }

        return nearestObject;
    }

    void Attack_spr()
    {
        monster_spr.sprite = sprites[2];
        Invoke("Stage3_Enemy_Attack", 0.3f);
    }
    void Stage3_Enemy_Attack()
    {
        monster_spr.sprite = sprites[3];
        Attck_obj.SetActive(true);
        Invoke("Attack_false", 1);
    }

    void Attack_false()
    {
        stage3_isAttack_Timing = false;
        monster_spr.sprite = sprites[1];
    }
}
