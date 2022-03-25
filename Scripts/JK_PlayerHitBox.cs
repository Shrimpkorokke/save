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
    //OntriggerEnter -> 무엇인가와 부딪혔을 때 
    private void OnTriggerEnter(Collider other)
    {
        // 상대방의 태그가 Monster_Attack 일 때
        // (플레이어가 몬스터 공격 범위 안에 들어왔을때)
        if (other.tag == "Monster_Attack")
        {

            // Player의 태그가 Player_HitBox(노멀 상태)라면
            // 피격 애니메이션을 재생한다.
            if (player.tag == "Player_HitBox")
            {
                JK_Player.instance.ani.Play("Player_Damage");
            }
            // Player의 태그가 Player_Defence (방어 상태) 라면
            // 패링 애니메이션을 재생한다.
            if (player.tag == "Player_Defence")
            {
                Jk_Parrying.instance.Defence_Damage();
            }
           
        }
    }
    

}
