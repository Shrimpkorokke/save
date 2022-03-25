using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK_Skills : MonoBehaviour
{
    public static JK_Skills instance;
    Animator ani;
    public float addSpeed;
    public float jumpSpeed;
    public float skillOneCoolTime;
    public bool isSkillOne;
    public bool isSkillOne_2;
    public Vector3 skillOneDir;
    public Vector3 skillOneDir_2;

    private void Awake()
    {
        instance = this;
        ani = GetComponent<Animator>();

    }

    void Update()
    {
        ShieldDash();
        Skill_1_1();
        if (Input.GetKeyDown(KeyCode.D))
        {
            GatherEnemy();
        }

    }
    void ShieldDash()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ani.Play("Skill_ShieldDash_1");    
        }
    }
    void Skill_1_1()
    {
        // 만약 addSpeed가 0 이라면 (현재 Skill_1이 아닐경우) skillOneDir 현재 dir 방향을 넣어준다.
        if (addSpeed == 0)
        {
            skillOneDir = this.transform.forward;
            // 만약 쉬프트가 눌리고 달리는 상태이며, dodge하는 중이 아니고, 쿨타임이 0이라면 
            if (Input.GetKeyDown(KeyCode.S) && skillOneCoolTime <= 0 && !JK_Player.instance.isDodge && !isSkillOne &&!isSkillOne_2)
            {
                // dodgeSpeed 값을 addSpeed에 넣고, isDodge를 true로 하면서 애니메이션을 재생한다. 이 후, dodgeCoolTime에 회피 쿨타임을 넣어주고, dodgeTime에 회피(무적) 시간을 넣어준다. 
                addSpeed = jumpSpeed;
                ani.Play("Skill_1");
                isSkillOne = true; ;
                skillOneCoolTime = 5f;
               

            }
        }
        // addSpeed가 0보다 크다면(전방 대쉬 중일 경우) addSpeed를 초기화한다.
        if (addSpeed > 0)
        {
            addSpeed -= jumpSpeed * Time.deltaTime * 2;

        }
        // skill_1의 첫번째 대쉬 단계가 끝나면 초기화
        else
        {
            addSpeed = 0;
            isSkillOne = false;
            
        }

    }
    public int detectRadius = 5;
    GameObject target;
    // Skill_1의 두번째 단계 앞으로 점프
    void Skill_1_2()
    {
        if (addSpeed == 0)
        {
            skillOneDir_2 = this.transform.forward;
            addSpeed = jumpSpeed;
            isSkillOne_2 = true;
        }
    }
    void Skill_1_3()
    {
        if (addSpeed > 0)
        {
            addSpeed = 0;

        }
        // 회피가 끝나면 모든 것을 초기화 한다.
        else
        {
            addSpeed = 0;
            isSkillOne_2 = false;
        }
       
    }
    
    // Skill_2의 첫번째 단계 기를 모으고 있는 도중 주변의 적을 빨아드린다 받는 피해를 70% 감소시키고 감소시킨 피해만큼 주변의 적에게 데미지를 입힘
    void skill_2_1()
    {
        
    }

    private void GatherEnemy()
    {
        Collider[] obj = Physics.OverlapSphere(transform.position, detectRadius);
        for (int i = 0; i < obj.Length; i++)
        {
            if (obj[i].tag.Contains("Monster"))
            {
                target = obj[i].gameObject;
                target.transform.position = transform.position;
            }

        }

    }
    void ShakeGround()
    {
        JK_CameraMove.instance.OnShakeCamera(0.5f, 0.05f);
    }
}
