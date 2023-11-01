using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3_Ground : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Monster")
        {
            gameObject.tag = "Unknown";
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            gameObject.tag = "Ground";
        }
    }
}
