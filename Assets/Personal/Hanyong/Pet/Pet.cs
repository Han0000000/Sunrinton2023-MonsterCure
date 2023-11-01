using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    public Transform player; // 플레이어 Transform 컴포넌트
    public float followDistance = 2f; // 플레이어와의 따라다니는 거리
    public float jump_Power;

    Rigidbody2D rigid;
    SpriteRenderer spr;
    Animator anim;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        jump_Power = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().jumpForce;
        rigid = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        if (player != null)
        {
            // 플레이어와 펫 간의 거리 계산
            Vector2 playerPosition = player.position;
            Vector2 petPosition = (Vector2)transform.position;
            float distanceToPlayer = Vector2.Distance(playerPosition, petPosition);
            // 플레이어와의 거리가 따라다니는 거리보다 큰 경우 플레이어 쪽으로 이동
            if (distanceToPlayer > followDistance)
            {
                // 플레이어 쪽으로 이동하기 위한 방향 계산
                Vector2 moveDirection = (playerPosition - petPosition).normalized;
                transform.position += (Vector3)moveDirection * Time.deltaTime * 3f; // 이동 속도 조절
                anim.SetBool("IsStand", false);
            }
            else
            {
                anim.SetBool("IsStand", true);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid.AddForce(Vector2.up * jump_Power, ForceMode2D.Impulse);
        }

        if (player.position.x > gameObject.transform.position.x)
        {
            spr.flipX = true;
        }
        else if (player.position.x < gameObject.transform.position.x)
        {
            spr.flipX = false;
        }
    }

    public LayerMask passThroughLayer; // 통과 가능한 오브젝트 레이어

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (passThroughLayer == (passThroughLayer | (1 << collision.gameObject.layer)))
        {
            // 충돌한 오브젝트가 passThroughLayer에 해당하는 레이어라면 통과
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }
    }
}
