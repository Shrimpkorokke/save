using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class JK_Skills : MonoBehaviour
{
    public static JK_Skills instance;
    Animator ani;
    public float addSpeed;
    public float jumpSpeed;

    public float skillOneCoolTime;
    public float currentCooltime;
    public float skillTwoCoolTime = 10;
    public float SkillTwoCurrentCoolTime;

    public bool isSkillOne;
    public bool isSkillOne_2;
    
    public Vector3 skillOneDir;
    public Vector3 skillOneDir_2;

    float temp;
    public Image[] skills;
    
    public GameObject particle;

    [SerializeField]
    [Range(0.01f, 10f)]
    private float fadeTime; // ���� 10�̸� 1�� (���� Ŭ���� ����)
    private float fadeInTime = 0.3f;
    public Light light;
    
    public GameObject ultHitBox;
    private void Awake()
    {
        instance = this;
        ani = GetComponent<Animator>();
        //monsterList = new List<NavMeshAgent>();

    }
    private void Start()
    {
        currentCooltime = 0.01f;
    }
    void Update()
    {
        
        Skill_1_1();
        Skill_1_CoolTime();
        Skill_2_1();
        Skill_2_CoolTime();
        Ult();
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("Ult"))
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                UltAttack();
            }
        }
    }

    
    void Skill_1_1()
    {
        // ���� addSpeed�� 0 �̶�� (���� Skill_1�� �ƴҰ��) skillOneDir ���� dir ������ �־��ش�.
        if (addSpeed == 0)
        {
            skillOneDir = this.transform.forward;
            // ���� ����Ʈ�� ������ �޸��� �����̸�, dodge�ϴ� ���� �ƴϰ�, ��Ÿ���� 0�̶�� 
            if (Input.GetKeyDown(KeyCode.S) && currentCooltime <= 0 && !JK_Player.instance.isDodge && !isSkillOne && !isSkillOne_2 && !isUlt)
            {
                // dodgeSpeed ���� addSpeed�� �ְ�, isDodge�� true�� �ϸ鼭 �ִϸ��̼��� ����Ѵ�. �� ��, dodgeCoolTime�� ȸ�� ��Ÿ���� �־��ְ�, dodgeTime�� ȸ��(����) �ð��� �־��ش�. 
                addSpeed = jumpSpeed;
                ani.Play("Skill_1");
                isSkillOne = true; 
                currentCooltime = skillOneCoolTime;
                temp = 0;


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

    void ResetSkillOne()
    {
        addSpeed = 0;
        isSkillOne = false;
        isSkillOne_2 = false;
    }

    void ShakeGround()
    {
        JK_CameraMove.instance.OnShakeCamera(0.5f, 0.05f);
    }


    void Skill_1_CoolTime()
    {
        if (currentCooltime > 0)
        {
            skills[0].enabled = true;
            currentCooltime = currentCooltime - Time.deltaTime;
            skills[0].fillAmount = skills[0].fillAmount - 1.0f / skillOneCoolTime * Time.deltaTime;
            temp = temp + Time.deltaTime;
        }
        if (currentCooltime <= 0)
        {
            currentCooltime = 0;
            skills[0].fillAmount = 1;
            skills[0].enabled = false;
        }
    }


    void Skill_2_1()
    {
        if (Input.GetKey(KeyCode.A) && SkillTwoCurrentCoolTime <= 0)
        {
            SkillTwoCurrentCoolTime = skillTwoCoolTime;
            ani.Play("Skill_ShieldDash_1");
        }
    }

    void Skill_2_2()
    {
        // ���� addSpeed�� 0 �̶�� (���� Skill_1�� �ƴҰ��) skillOneDir ���� dir ������ �־��ش�.
        if (addSpeed == 0)
        {
            skillOneDir = this.transform.forward;
            // ���� ����Ʈ�� ������ �޸��� �����̸�, dodge�ϴ� ���� �ƴϰ�, ��Ÿ���� 0�̶�� 
            if (Input.GetKeyDown(KeyCode.S) && currentCooltime <= 0 && !JK_Player.instance.isDodge && !isSkillOne && !isSkillOne_2)
            {
                // dodgeSpeed ���� addSpeed�� �ְ�, isDodge�� true�� �ϸ鼭 �ִϸ��̼��� ����Ѵ�. �� ��, dodgeCoolTime�� ȸ�� ��Ÿ���� �־��ְ�, dodgeTime�� ȸ��(����) �ð��� �־��ش�. 
                addSpeed = jumpSpeed;
                ani.Play("Skill_1");
                isSkillOne = true;
                currentCooltime = skillOneCoolTime;
                temp = 0;


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


    void Skill_2_CoolTime()
    {
        if (SkillTwoCurrentCoolTime > 0)
        {
            skills[1].enabled = true;
            SkillTwoCurrentCoolTime = SkillTwoCurrentCoolTime - Time.deltaTime;
            skills[1].fillAmount = skills[1].fillAmount - 1.0f / skillTwoCoolTime * Time.deltaTime;
            temp = temp + Time.deltaTime;
        }
        if (SkillTwoCurrentCoolTime <= 0)
        {
            SkillTwoCurrentCoolTime = 0;
            skills[1].fillAmount = 1;
            skills[1].enabled = false;
        }
    }
    public bool isUlt;
    public Vector3 ultDir;
    public void Ult()
    {
        if(Input.GetKeyDown(KeyCode.D) && JK_Player.instance.ULTGAUGE >= 50)
        {
            ani.Play("Ult");
            isUlt = true;
            ultDir = this.transform.forward;
            JK_Player.instance.ULTGAUGE = 0;
            
        }
    }
    public void UltStop()
    {
        ani.StartPlayback();
        JK_HitStop.instance.SlowStop(5f);
        //particle.SetActive(true);
        JK_CameraMove.instance.UltOnShakeCamera(1, 0.02f);
        StartCoroutine(UltFade(1, 0.3f));
    }

    public void UltAttack()
    {
        ani.StopPlayback();
        JK_Sword.instance.ChangeTag("Player_Ult");
        UltReset();
        StartCoroutine(UltFadeIn(0.3f, 1f));
        JK_HitStop.instance.SlowStop(2f);
        
    }

    public void UltAttack2()
    {
        StartCoroutine("IEUltAttack");
    }
    IEnumerator IEUltAttack()
    {
        ultHitBox.SetActive(true);
        yield return new WaitForSeconds(0.02f);
        ultHitBox.SetActive(false);
        yield return new WaitForSeconds(0.02f);

        ultHitBox.SetActive(true);
        yield return new WaitForSeconds(0.02f);
        ultHitBox.SetActive(false);
        yield return new WaitForSeconds(0.02f);

        ultHitBox.SetActive(true);
        yield return new WaitForSeconds(0.02f);
        ultHitBox.SetActive(false);
        yield return new WaitForSeconds(0.02f);

        ultHitBox.SetActive(true);
        yield return new WaitForSeconds(0.02f);
        ultHitBox.SetActive(false);
        yield return new WaitForSeconds(0.02f);

        ultHitBox.SetActive(true);
        yield return new WaitForSeconds(0.02f);
        ultHitBox.SetActive(false);
        yield return new WaitForSeconds(0.02f);

        ultHitBox.SetActive(true);
        yield return new WaitForSeconds(0.02f);
        ultHitBox.SetActive(false);
        yield return new WaitForSeconds(0.02f);

        ultHitBox.SetActive(true);
        yield return new WaitForSeconds(0.02f);
        ultHitBox.SetActive(false);
        yield return new WaitForSeconds(0.02f);

        ultHitBox.SetActive(true);
        yield return new WaitForSeconds(0.02f);
        ultHitBox.SetActive(false);
        yield return new WaitForSeconds(0.02f);

        ultHitBox.SetActive(true);
        yield return new WaitForSeconds(0.02f);
        ultHitBox.SetActive(false);
        yield return new WaitForSeconds(0.02f);

        ultHitBox.SetActive(true);
        yield return new WaitForSeconds(0.02f);
        ultHitBox.SetActive(false);
    }
    
    IEnumerator UltFade(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            // fadeTime���� ����� fadeTime �ð� ����
            //percent ���� 0���� 1�� �����ϵ��� ��
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            //���İ��� start���� end���� fadeTime �ð� ���� ��ȭ��Ų��
            float intensity = light.intensity;
            intensity = Mathf.Lerp(start, end, percent);
            light.intensity = intensity;

            yield return null;
        }
    }
    IEnumerator UltFadeIn(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            // fadeTime���� ����� fadeTime �ð� ����
            //percent ���� 0���� 1�� �����ϵ��� ��
            currentTime += Time.deltaTime;
            percent = currentTime / fadeInTime;

            //���İ��� start���� end���� fadeTime �ð� ���� ��ȭ��Ų��
            float intensity = light.intensity;
            intensity = Mathf.Lerp(start, end, percent);
            light.intensity = intensity;

            yield return null;
        }
    }


    public GameObject ultSword;
    public GameObject normalSword;
    public GameObject postProcessing;
    public GameObject ultEffect;
    public void UltReset()
    {
        JK_CameraMove.instance.ResetUltShake();
        JK_HitStop.instance.ResetSlowStop();
        StopCoroutine("UltFade");
        StopCoroutine("UltFadeIn");
        
    }
    public bool UltBoolSet()
    {
        isUlt = false;
        return isUlt;
    }
    public void MeshEffect()
    {
        if (normalSword.activeSelf == true)
        {
            normalSword.SetActive(false);
            ultSword.SetActive(true);
            postProcessing.SetActive(true);
            

        }
        else if (ultSword.activeSelf == true)
        {
            ultSword.SetActive(false);
            normalSword.SetActive(true);
            postProcessing.SetActive(false);
            
        }
    }

    GameObject ultObj;
    public Transform firstPos;
    public Transform endPos;
    public void UltEffect()
    {
        ultObj = Instantiate(ultEffect);
        ultObj.transform.position = firstPos.transform.position;
    }
    public void OffUltEffect()
    {
        Destroy(ultObj);
    }
    
    /* public int detectRadius = 5;
     GameObject target;
     public float gatheringSpeed = 2;

     float damage;
     float skillTwoCooltime = 0;
     bool gatherEnemy = false;
     List<NavMeshAgent> monsterList;*/
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

    /*private void GatherEnemy()
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
    }

    void DisposeEnemy()
    {
        for (int i = 0; i < monsterList.Count; i++)
        {
            monsterList[i].isStopped = false;
            monsterList[i].enabled = true;
        }
        monsterList.Clear();
    }*/
}
