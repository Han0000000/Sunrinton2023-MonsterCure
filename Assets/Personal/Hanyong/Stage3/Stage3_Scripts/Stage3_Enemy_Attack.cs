using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3_Enemy_Attack : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerController.isStun = true;
            PlayerController.stun_time = 2.3f;
        }
    }
}
