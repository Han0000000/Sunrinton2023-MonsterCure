using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pet : MonoBehaviour
{
    public Transform player; // �÷��̾� Transform ������Ʈ
    public float followDistance = 2f; // �÷��̾���� ����ٴϴ� �Ÿ�
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
            // �÷��̾�� �� ���� �Ÿ� ���
            Vector2 playerPosition = player.position;
            Vector2 petPosition = (Vector2)transform.position;
            float distanceToPlayer = Vector2.Distance(playerPosition, petPosition);
            // �÷��̾���� �Ÿ��� ����ٴϴ� �Ÿ����� ū ��� �÷��̾� ������ �̵�
            if (distanceToPlayer > followDistance)
            {
                // �÷��̾� ������ �̵��ϱ� ���� ���� ���
                Vector2 moveDirection = (playerPosition - petPosition).normalized;
                transform.position += (Vector3)moveDirection * Time.deltaTime * 3f; // �̵� �ӵ� ����
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

    public LayerMask passThroughLayer; // ��� ������ ������Ʈ ���̾�

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (passThroughLayer == (passThroughLayer | (1 << collision.gameObject.layer)))
        {
            // �浹�� ������Ʈ�� passThroughLayer�� �ش��ϴ� ���̾��� ���
            Physics2D.IgnoreCollision(GetComponent<Collider2D>(), collision.collider);
        }
    }
}
