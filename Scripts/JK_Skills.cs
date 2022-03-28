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
        // ���� addSpeed�� 0 �̶�� (���� Skill_1�� �ƴҰ��) skillOneDir ���� dir ������ �־��ش�.
        if (addSpeed == 0)
        {
            skillOneDir = this.transform.forward;
            // ���� ����Ʈ�� ������ �޸��� �����̸�, dodge�ϴ� ���� �ƴϰ�, ��Ÿ���� 0�̶�� 
            if (Input.GetKeyDown(KeyCode.S) && skillOneCoolTime <= 0 && !JK_Player.instance.isDodge && !isSkillOne && !isSkillOne_2)
            {
                // dodgeSpeed ���� addSpeed�� �ְ�, isDodge�� true�� �ϸ鼭 �ִϸ��̼��� ����Ѵ�. �� ��, dodgeCoolTime�� ȸ�� ��Ÿ���� �־��ְ�, dodgeTime�� ȸ��(����) �ð��� �־��ش�. 
                addSpeed = jumpSpeed;
                ani.Play("Skill_1");
                isSkillOne = true; ;
                skillOneCoolTime = 5f;


            }
        }
        // addSpeed�� 0���� ũ�ٸ�(���� �뽬 ���� ���) addSpeed�� �ʱ�ȭ�Ѵ�.
        if (addSpeed > 0)
        {
            addSpeed -= jumpSpeed * Time.deltaTime * 2;

        }
        // skill_1�� ù��° �뽬 �ܰ谡 ������ �ʱ�ȭ
        else
        {
            addSpeed = 0;
            isSkillOne = false;

        }

    }

    // Skill_1�� �ι�° �ܰ� ������ ����
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
        // ȸ�ǰ� ������ ��� ���� �ʱ�ȭ �Ѵ�.
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
                // agent����� ����ʹ�. �ֳ��ϸ� agnet�� ��ġ�� ������ �����ϱ⶧���̴�.
                NavMeshAgent agent = target.GetComponent<NavMeshAgent>();
                agent.isStopped = true;
                agent.enabled = false;
                // ��Ͼȿ� ���Ե��� ���� ����̶�� �߰��ϰ�ʹ�.
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
