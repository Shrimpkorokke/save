using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK_PlayerHitBox : MonoBehaviour
{
    public static JK_PlayerHitBox instance;
    public GameObject player;

    private void Awake()
    {
        instance = this;
    }
    //OntriggerEnter -> �����ΰ��� �ε����� �� 
    private void OnTriggerEnter(Collider other)
    {
        // ������ �±װ� Monster_Attack �� ��
        // (�÷��̾ ���� ���� ���� �ȿ� ��������)
        if (other.tag == "Monster_Attack")
        {

            // Player�� �±װ� Player_HitBox(��� ����)���
            // �ǰ� �ִϸ��̼��� ����Ѵ�.
            if (player.tag == "Player_HitBox")
            {
                JK_Player.instance.ani.Play("Player_Damage");
            }
            // Player�� �±װ� Player_Defence (��� ����) ���
            // �и� �ִϸ��̼��� ����Ѵ�.
            if (player.tag == "Player_Defence")
            {
                Jk_Parrying.instance.Defence_Damage();
            }
           
        }
    }
    

}
