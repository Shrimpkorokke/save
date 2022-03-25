using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK_Sword : MonoBehaviour
{
    public static JK_Sword instance;
    public CapsuleCollider attackHitBox_1;
    public CapsuleCollider attackHitBox_2;
    public GameObject hitEffectFactory;
    
    Transform monster; //몬스터 목표 특정
    Animator ani;

    public int damage = 10;
    public int rate = 1;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        ani = GetComponent<Animator>();
        monster = GameObject.FindWithTag("Monster").transform; //몬스터 위치 특정
    }

    // OntriggerEnter -> 무엇인가와 부딪혔을 때 
    private void OnTriggerEnter(Collider other)
    {
        // 상대방의 태그가 Monster라면
        if(other.tag == "Monster" || other.tag == "Monster_Attack")
        {
            // 그리고 이 오브젝트의 태그가 Player_HitBox라면
            //Hp를 깎고 / 슬라이더의 체력을 바꾸고 / 카메라를 흔들고 / 시간을 멈추고 / 오디오를 재생한다 
            
            if(this.tag == "Player_Attack" || this.tag == "Player_SDash" || this.tag == "Player_Skill1")
            {
                //MeleeEnemy에 대한 데미지 처리 및 체력바 조정
                other.GetComponent<HSK_MeleeEnemy01>().HitEnemy(damage);
                HSK_MeleeEnemy01.SingleTonMeleeEnemy01.hp = HSK_MeleeEnemy01.SingleTonMeleeEnemy01.hp - damage;
                other.GetComponent<HSK_MeleeEnemy01>().HpBarDown();

                //히트스탑, 카메라 흔들림, 효과음재생, 히트 이펙트 재생
                GameObject hitEffect = Instantiate(hitEffectFactory); //이펙트 재생
                hitEffect.transform.position = other.transform.position + new Vector3(0, 1, 0); //이펙트 위치
                JK_CameraMove.instance.OnShakeCamera(0.05f, 0.05f);
                JK_HitStop.instance.Stop(0.05f);
                JK_AudioManager.instance.PlayAudio();
                print("Hit");
            }
            
        }
    }
    
    public void AttackHit_1() // Attack 1,2,4 
    {
        StartCoroutine("AttackHitBoxEnable_1");
    } 
    public void AttackHit_2() // Attack3 
    {
        StartCoroutine("AttackHitBoxEnable_2");
    }

    // 공격판정 1의 콜라이더를 키는 함수 (Attack 1,2,4 )
    IEnumerator AttackHitBoxEnable_1()
    {
        // 공격판정 1의 콜라이더를 키고 0.1초 뒤에 끈다
        attackHitBox_1.enabled = true;
        print("attackHitBox_1.enabled = true");
        yield return new WaitForSeconds(0.1f);
        attackHitBox_1.enabled = false;
        print("attackHitBox_1.enabled = false");
    }

    // 공격판정 2의 콜라이더를 키는 함수 (Attack3 )
    IEnumerator AttackHitBoxEnable_2() 
    {
        // 공격판정 2의 콜라이더 키고 0.1초 뒤에 끈다
        attackHitBox_2.enabled = true;
        print("attackHitBox_2.enabled = true");
        yield return new WaitForSeconds(0.02f);
        attackHitBox_2.enabled = false;
        print("attackHitBox_2.enabled = false");
    }

    // 애니메이션 이벤트에 사용되는 함수 -> 태그를 바꿔준다 -> 사용법: 애니메이션 이벤트 추가를 누른 후 Function탭에 이 함수를 쓴다음에 String 칸에 바꾸고 싶은 태그를 적는다 예) Player_Attack
    void ChangeTag(string t)
    {
        this.tag = t;
    }
}
