using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public enum Type
    {
        stage1, 
        stage2,
        stage3
    }
    public enum State
    {
        �糪��, 
        ��ó����,
        ����,
        ġ���
    }
    public State state;
    public Type type;
    public float speed;


    private void Update()
    {
        /*
         // state����Ҷ�����ϴ� ���
        if(state == State.��ó����) ~�̶��
         */
    }
}
