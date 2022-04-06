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
    private float fadeTime; // 값이 10이면 1초 (값이 클수록 빠름)
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
        // 만약 addSpeed가 0 이라면 (현재 Skill_1이 아닐경우) skillOneDir 현재 dir 방향을 넣어준다.
        if (addSpeed == 0)
        {
            skillOneDir = this.transform.forward;
            // 만약 쉬프트가 눌리고 달리는 상태이며, dodge하는 중이 아니고, 쿨타임이 0이라면 
            if (Input.GetKeyDown(KeyCode.S) && currentCooltime <= 0 && !JK_Player.instance.isDodge && !isSkillOne && !isSkillOne_2 && !isUlt)
            {
                // dodgeSpeed 값을 addSpeed에 넣고, isDodge를 true로 하면서 애니메이션을 재생한다. 이 후, dodgeCoolTime에 회피 쿨타임을 넣어주고, dodgeTime에 회피(무적) 시간을 넣어준다. 
                addSpeed = jumpSpeed;
                ani.Play("Skill_1");
                isSkillOne = true; 
                currentCooltime = skillOneCoolTime;
                temp = 0;


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
        // 만약 addSpeed가 0 이라면 (현재 Skill_1이 아닐경우) skillOneDir 현재 dir 방향을 넣어준다.
        if (addSpeed == 0)
        {
            skillOneDir = this.transform.forward;
            // 만약 쉬프트가 눌리고 달리는 상태이며, dodge하는 중이 아니고, 쿨타임이 0이라면 
            if (Input.GetKeyDown(KeyCode.S) && currentCooltime <= 0 && !JK_Player.instance.isDodge && !isSkillOne && !isSkillOne_2)
            {
                // dodgeSpeed 값을 addSpeed에 넣고, isDodge를 true로 하면서 애니메이션을 재생한다. 이 후, dodgeCoolTime에 회피 쿨타임을 넣어주고, dodgeTime에 회피(무적) 시간을 넣어준다. 
                addSpeed = jumpSpeed;
                ani.Play("Skill_1");
                isSkillOne = true;
                currentCooltime = skillOneCoolTime;
                temp = 0;


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
            // fadeTime으로 나누어서 fadeTime 시간 동안
            //percent 값이 0에서 1로 증가하도록 함
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            //알파값을 start부터 end까지 fadeTime 시간 동안 변화시킨다
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
            // fadeTime으로 나누어서 fadeTime 시간 동안
            //percent 값이 0에서 1로 증가하도록 함
            currentTime += Time.deltaTime;
            percent = currentTime / fadeInTime;

            //알파값을 start부터 end까지 fadeTime 시간 동안 변화시킨다
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
