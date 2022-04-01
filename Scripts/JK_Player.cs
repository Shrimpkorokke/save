using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JK_Player : MonoBehaviour
{
    

    public static JK_Player instance;

    public string stageName;
    public int enemyCount;

    public float speed = 30f;
    public float dodgeSpeed = 2;
    public float addSpeed;
    

    public float dodgeTime = 0f; // 무적시간
    public float dodgeCoolTime = 0f; // 회피 쿨타임
    
    float v;
    float h;

    public Vector3 attackDir;
    public Vector3 dir;
    Vector3 dodgeDir;
    Vector3 deadDir;

    public GameObject hitBox;
    bool dodgeKeyDown;
    bool attackKeyDown;
    bool parryingKeyDown;
    
    public bool isDodge;
    public bool isRun;
    public bool isDodgeAttack;
    
  
    public Animator ani;
    Rigidbody rb;

    public int hp = 100;
    public int maxHP = 1000;
    public Slider playerHP;

    public int ult;
    public int maxUlt = 50;
    public Slider ultGauge;
    public Image fillImage;

    
  
    void Awake()
    {
        instance = this;
        rb = GetComponent<Rigidbody>();
        ani = GetComponentInChildren<Animator>();
        
    }
    private void Start()
    {

        playerHP.maxValue = maxHP;
        HP = maxHP;

        ultGauge.maxValue = maxUlt;
        ULTGAUGE = 0;

    }



    void Update()
    {
  
        GetInput();
        Run();
        Turn();
        Dodge();
        CoolTimeCal();
        Dead();
        FullUltGauge();
        FreezeVelocity();


    }
    public int HP
    {
        get { return hp; }
        set
        {
            hp = value;
            playerHP.value = hp;
        }
    }

    public int ULTGAUGE
    {
        get { return ult; }
        set
        {
            ult = value;
            ultGauge.value = ult;
        }
    }
    // Player의 이동에 관련된 함수
    void Run() 
    {
             
        dir = Vector3.right * h + Vector3.forward * v;
        dir.Normalize();

        // Dodge 또는 스킬 1의 첫번째 미끄러지는 애니메이션 단계 (isSkillOne) 중이 아니라면 정상적으로 이동
        if (!isDodge && !JK_Skills.instance.isSkillOne)
        {

            rb.MovePosition(transform.position + dir * speed * Time.deltaTime);
                
        }
        // Dodge 중이라면 dodgeDir 방향으로 높인 속도 만큼 이동.
        else if(isDodge)
        {
            dir = dodgeDir;
            rb.MovePosition(transform.position + dodgeDir * (addSpeed * dodgeSpeed) * Time.deltaTime * 2.5f);
            
        }

        // 스킬 1의 첫번째 미끄러지는 애니메이션 단계 (isSkillOne) 중이라면 앞으로 대쉬
        else if (JK_Skills.instance.isSkillOne)
        {
            dir = JK_Skills.instance.skillOneDir;
            rb.MovePosition(transform.position + JK_Skills.instance.skillOneDir * (JK_Skills.instance.addSpeed * JK_Skills.instance.jumpSpeed) * Time.deltaTime * 2.5f);
        }

        // 스킬 1의 도약하는 애니메이션 단계 (isSkillOne_2) 중이라면 앞으로 대쉬
        if (JK_Skills.instance.isSkillOne_2)
        {
            dir = JK_Skills.instance.skillOneDir_2;
            rb.MovePosition(transform.position + JK_Skills.instance.skillOneDir * (JK_Skills.instance.addSpeed * JK_Skills.instance.jumpSpeed) * Time.deltaTime * 2.5f);
            

        }
       

        // 공격 중이라면 방향을 공격 직전의 방향으로 설정하고, 속도를 0으로 만든다. (못 움직이게)
        if (JK_PlayerAttack.instance.isAttack==true)
        {
            
            dir = attackDir;
            speed = 0;
            rb.MovePosition(transform.position + attackDir * speed * Time.deltaTime);
            speed = 30;
        }
        // 방어 중일 경우 방향을 방어 직전의 방향으로 설정하고, 속도를 0으로 만든다. (못 움직이게)
        else if (Jk_Parrying.instance.isParrying == true)
        {
            dir = Jk_Parrying.instance.parryingDir;
            speed = 0;
            rb.MovePosition(transform.position + Jk_Parrying.instance.parryingDir * speed * Time.deltaTime);
            
        }
        // 방어 중 공격 받을 경우 방향을 방어 직전의 방향으로 설정하고, 속도를 0으로 만든다. (못 움직이게)
        else if (this.ani.GetCurrentAnimatorStateInfo(0).IsName("Player_Damage"))
        {
            dir = Jk_Parrying.instance.parryingDir;
            speed = 0;
            rb.MovePosition(transform.position + Vector3.zero * speed * Time.deltaTime);
        }
        // 카운터 중 방향을 방어 직전의 방향으로 설정하고, 속도를 0으로 만든다. (못 움직이게)
        else if (this.ani.GetCurrentAnimatorStateInfo(0).IsName("Counter"))
        {
            dir = Jk_Parrying.instance.parryingDir;
            speed = 0;
            rb.MovePosition(transform.position + Vector3.zero * speed * Time.deltaTime);
        }
        // 플레이어가 죽을 때 방향을 죽기 직전의 방향으로 설정하고, 속도를 0으로 만든다. (못 움직이게)
        else if (this.tag == "Player_Dead")
        {
            dir = deadDir;
            rb.MovePosition(transform.position + Vector3.zero * speed * Time.deltaTime);
        }
        else if (JK_Skills.instance.isSkillOne)
        {
            /*dir = ;
            rb.MovePosition(transform.position + Vector3.zero * speed * Time.deltaTime);
            Vector3.forward;*/
        }
        else if (!isDodge && !Jk_Parrying.instance.isParrying && this.tag != "Player_Dead" && !JK_Skills.instance.isSkillOne && !JK_Skills.instance.isSkillOne_2 && !this.CompareTag("Player_SDash"))
        {
            speed = 30;
        }
        
        // 움직임이 있을 경우 isRun을 true, 아닐 경우 false의 값을 넣어준다.
        if (dir != Vector3.zero)
        {
            isRun = true;

        }
        else
        {
            isRun = false;

        }
        if(this.tag == "Player_Dead")
        {
            

        }
        // 움직임이 있을 경우 달리는 애니메이션을 재생한다.
        ani.SetBool("isRun", dir != Vector3.zero);

  
    }
    // 오브젝트의 바라보는 방향을 자신이 바라보는 방향으로 바꾼다.
    void Turn()
    {
        transform.LookAt(transform.position + dir);
    }

    // 일일히 input.get 어쩌구 하기 귀찮아서 넣었던 것들
    void GetInput()
    {
        v = Input.GetAxisRaw("Vertical");
        h = Input.GetAxisRaw("Horizontal");
        dodgeKeyDown = Input.GetButtonDown("Dodge");
    }
    

    // 쿨타임 계산 함수
    void CoolTimeCal()
    {
        if (dodgeCoolTime < 0)
        {
            dodgeCoolTime = 0;
        }
        else
        {
            dodgeCoolTime = dodgeCoolTime - Time.deltaTime;
        }

        
        
    }
   
    /*IEnumerator SkillCoolTimeCoroutine()
    {
        yield return;
    }*/

    // Dodge 함수
    void Dodge()
    {
        // 만약 addSpeed가 0 이라면 (현재 회피 중이 아닐 경우) dodgeDir에 현재 dir 방향을 넣어준다.
        if(addSpeed == 0)
        {
            dodgeDir = dir;
            // 만약 쉬프트가 눌리고 달리는 상태이며, dodge하는 중이 아니고, 쿨타임이 0이라면 
            if(dodgeKeyDown && isRun && !isDodge && dodgeCoolTime <= 0)
            {
                // dodgeSpeed 값을 addSpeed에 넣고, isDodge를 true로 하면서 애니메이션을 재생한다. 이 후, dodgeCoolTime에 회피 쿨타임을 넣어주고, dodgeTime에 회피(무적) 시간을 넣어준다. 
                addSpeed = dodgeSpeed;
                isDodge = true;
                ani.SetBool("isDodge", isDodge);
                dodgeCoolTime = 2f;
                dodgeTime = 1f;
                
            }
        }
        // addSpeed가 0보다 크다면(회피 중일 경우) addSpeed를 초기화한다.
        if(addSpeed > 0)
        {
            addSpeed -= dodgeSpeed * Time.deltaTime *2;
            
        }
        // 회피가 끝나면 모든 것을 초기화 한다.
        else
        {
            addSpeed = 0;
            isDodge = false;
            dodgeTime = 0;
            
            ani.SetBool("isDodge", isDodge);
            
        }
    }

    

    void Dead()
    {
        deadDir = dir;
        if (hp<=0)
        {
            this.tag = "Player_Dead";
            ani.Play("Dead");
        }
        
    }

    void FullUltGauge()
    {
        if(ultGauge.value == maxUlt)
        {
            fillImage.color = new Color (160/255f, 245/255f, 255/255f);
        }
    }
    void FreezeVelocity()
    {
        rb.velocity = Vector3.zero;
    }
    public void DamageAction(int damage)
    {
        //Enemy의 공격력만큼 플레이어의 체력을 깎는다.
        hp -= damage;
        HP = hp;
    }
}
