using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
        // monsterList = new List<NavMeshAgent>();

    }

    void Update()
    {
        ShieldDash();
        Skill_1_1();
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
            if (Input.GetKeyDown(KeyCode.S) && skillOneCoolTime <= 0 && !JK_Player.instance.isDodge && !isSkillOne && !isSkillOne_2)
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

    void Roar()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            ani.Play("Roar");
        }
    }


    void ShakeGround()
    {
        JK_CameraMove.instance.OnShakeCamera(0.5f, 0.05f);
    }
   /* public int detectRadius = 5;
    GameObject target;
    public float gatheringSpeed = 2;

    float damage;
    float skillTwoCooltime = 0;
    bool gatherEnemy = false;*/
    // List<NavMeshAgent> monsterList;
    /* private void GatherEnemy()
    {
        Collider[] obj = Physics.OverlapSphere(transform.position, detectRadius);
        for (int i = 0; i < obj.Length; i++)
        {
            if (obj[i].tag.Contains("Monster"))
            {
                target = obj[i].gameObject;
                *//*Vector3 dir = target.transform.position - transform.position;
                Vector3 targetPosition = Vector3.ClampMagnitude(dir, 0.1f);*//*
                Vector3 dir = transform.position - target.transform.position;
                Vector3 targetPosition = Vector3.ClampMagnitude(dir, 70);
                target.transform.position = Vector3.Lerp(target.transform.position, targetPosition, Time.deltaTime * 5);

            }
        }
    }*/

    /*private void GatherEnemy2()
    {
        Collider[] obj = Physics.OverlapSphere(transform.position, detectRadius);
        for (int i = 0; i < obj.Length; i++)
        {
            if (obj[i].tag.Contains("Monster"))
            {
                target = obj[i].gameObject;
                // agent기능을 끄고싶다. 왜냐하면 agnet가 위치를 강제로 설정하기때문이다.
                NavMeshAgent agent = target.GetComponent<NavMeshAgent>();
                agent.isStopped = true;
                agent.enabled = false;
                // 목록안에 포함되지 않은 요원이라면 추가하고싶다.
                if (false == monsterList.Contains(agent))
                {
                    monsterList.Add(agent);
                }

                Vector3 dir = target.transform.position - transform.position;
                Vector3 targetPosition = Vector3.ClampMagnitude(dir, 5);

                target.transform.position = Vector3.Lerp(target.transform.position, targetPosition, Time.deltaTime * 5);

            }
        }
    }*/

    /*void DisposeEnemy()
    {
        for (int i = 0; i < monsterList.Count; i++)
        {
            monsterList[i].isStopped = false;
            monsterList[i].enabled = true;
        }
        monsterList.Clear();
    }*/
}
