using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Animator animator;
    //Transform transform;

    public bool isCure = false;
    public bool isMove=true;
    public float speed = 7.0f;
    public float jumpForce = 13.0f;
    float Horizontal;

    public Rigidbody2D rigidbody2d;

    RaycastHit2D hit;
    [SerializeField] public bool isGround = false;
    [SerializeField]bool jumpKey = false;
    public static bool isStun = false;
    [SerializeField]bool isDonMove = false;

    public static float stun_time;
    public GameObject stun_effect;
    private void Awake()
    {
        //transform = GetComponent<Transform>();
        animator = GetComponent<Animator>();
        rigidbody2d = GetComponent<Rigidbody2D>();
        rigidbody2d.gravityScale = 3.0f;
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (isStun)
        {
            isDonMove = true;
            rigidbody2d.velocity = new Vector2(0, rigidbody2d.velocity.y);
            isStun = false;
            Stun();
        }

        if (!isStun && !isDonMove && isMove)
        {
            Move();
        }
        else if(!isMove)
        {
            rigidbody2d.velocity = Vector2.zero;
        }
    }
   
    private void Move()
    {
        jumpKey = Input.GetKey(KeyCode.Space);//����Ű(�����̽�) �Է�
        Horizontal = Input.GetAxisRaw("Horizontal");//�¿��̵�Ű(������ Ű) �Է�
        rigidbody2d.velocity = new Vector2(Horizontal * speed, rigidbody2d.velocity.y);//������ Ű �Է¿� ���� �¿� �̵�.
        if (Horizontal != 0)//������ �̵��� �ִٸ�
        {
            transform.localScale = new Vector3(0.1f * Horizontal, 0.1f, 1);
            animator.SetBool("isWalk", true);
        }
        else
        {
            animator.SetBool("isWalk", false);
        }

        if (jumpKey && isGround)//����
        {
            Debug.Log("����");
            isGround = false;
            rigidbody2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))//���� ���� ��Ҵٸ�
        {
            RaycastHit2D rayHit = Physics2D.Raycast(transform.position,
                                                    Vector3.down, 1,
                                                    LayerMask.GetMask("Ground"));
            //print(rayHit.collider.tag);
            if(rayHit.collider != null) isGround = true;
        }
    }

    public void Stun()
    {
        stun_effect.SetActive(true);
        Invoke("Stun_false", stun_time);
    }

    public void Stun_false()
    {
        isDonMove = false;
    }

}
