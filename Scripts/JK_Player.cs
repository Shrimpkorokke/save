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
    

    public float dodgeTime = 0f; // �����ð�
    public float dodgeCoolTime = 0f; // ȸ�� ��Ÿ��
    
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
    // Player�� �̵��� ���õ� �Լ�
    void Run() 
    {
             
        dir = Vector3.right * h + Vector3.forward * v;
        dir.Normalize();

        // Dodge �Ǵ� ��ų 1�� ù��° �̲������� �ִϸ��̼� �ܰ� (isSkillOne) ���� �ƴ϶�� ���������� �̵�
        if (!isDodge && !JK_Skills.instance.isSkillOne)
        {

            rb.MovePosition(transform.position + dir * speed * Time.deltaTime);
                
        }
        // Dodge ���̶�� dodgeDir �������� ���� �ӵ� ��ŭ �̵�.
        else if(isDodge)
        {
            dir = dodgeDir;
            rb.MovePosition(transform.position + dodgeDir * (addSpeed * dodgeSpeed) * Time.deltaTime * 2.5f);
            
        }

        // ��ų 1�� ù��° �̲������� �ִϸ��̼� �ܰ� (isSkillOne) ���̶�� ������ �뽬
        else if (JK_Skills.instance.isSkillOne)
        {
            dir = JK_Skills.instance.skillOneDir;
            rb.MovePosition(transform.position + JK_Skills.instance.skillOneDir * (JK_Skills.instance.addSpeed * JK_Skills.instance.jumpSpeed) * Time.deltaTime * 2.5f);
        }

        // ��ų 1�� �����ϴ� �ִϸ��̼� �ܰ� (isSkillOne_2) ���̶�� ������ �뽬
        if (JK_Skills.instance.isSkillOne_2)
        {
            dir = JK_Skills.instance.skillOneDir_2;
            rb.MovePosition(transform.position + JK_Skills.instance.skillOneDir * (JK_Skills.instance.addSpeed * JK_Skills.instance.jumpSpeed) * Time.deltaTime * 2.5f);
            

        }
       

        // ���� ���̶�� ������ ���� ������ �������� �����ϰ�, �ӵ��� 0���� �����. (�� �����̰�)
        if (JK_PlayerAttack.instance.isAttack==true)
        {
            
            dir = attackDir;
            speed = 0;
            rb.MovePosition(transform.position + attackDir * speed * Time.deltaTime);
            speed = 30;
        }
        // ��� ���� ��� ������ ��� ������ �������� �����ϰ�, �ӵ��� 0���� �����. (�� �����̰�)
        else if (Jk_Parrying.instance.isParrying == true)
        {
            dir = Jk_Parrying.instance.parryingDir;
            speed = 0;
            rb.MovePosition(transform.position + Jk_Parrying.instance.parryingDir * speed * Time.deltaTime);
            
        }
        // ��� �� ���� ���� ��� ������ ��� ������ �������� �����ϰ�, �ӵ��� 0���� �����. (�� �����̰�)
        else if (this.ani.GetCurrentAnimatorStateInfo(0).IsName("Player_Damage"))
        {
            dir = Jk_Parrying.instance.parryingDir;
            speed = 0;
            rb.MovePosition(transform.position + Vector3.zero * speed * Time.deltaTime);
        }
        // ī���� �� ������ ��� ������ �������� �����ϰ�, �ӵ��� 0���� �����. (�� �����̰�)
        else if (this.ani.GetCurrentAnimatorStateInfo(0).IsName("Counter"))
        {
            dir = Jk_Parrying.instance.parryingDir;
            speed = 0;
            rb.MovePosition(transform.position + Vector3.zero * speed * Time.deltaTime);
        }
        // �÷��̾ ���� �� ������ �ױ� ������ �������� �����ϰ�, �ӵ��� 0���� �����. (�� �����̰�)
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
        
        // �������� ���� ��� isRun�� true, �ƴ� ��� false�� ���� �־��ش�.
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
        // �������� ���� ��� �޸��� �ִϸ��̼��� ����Ѵ�.
        ani.SetBool("isRun", dir != Vector3.zero);

  
    }
    // ������Ʈ�� �ٶ󺸴� ������ �ڽ��� �ٶ󺸴� �������� �ٲ۴�.
    void Turn()
    {
        transform.LookAt(transform.position + dir);
    }

    // ������ input.get ��¼�� �ϱ� �����Ƽ� �־��� �͵�
    void GetInput()
    {
        v = Input.GetAxisRaw("Vertical");
        h = Input.GetAxisRaw("Horizontal");
        dodgeKeyDown = Input.GetButtonDown("Dodge");
    }
    

    // ��Ÿ�� ��� �Լ�
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

    // Dodge �Լ�
    void Dodge()
    {
        // ���� addSpeed�� 0 �̶�� (���� ȸ�� ���� �ƴ� ���) dodgeDir�� ���� dir ������ �־��ش�.
        if(addSpeed == 0)
        {
            dodgeDir = dir;
            // ���� ����Ʈ�� ������ �޸��� �����̸�, dodge�ϴ� ���� �ƴϰ�, ��Ÿ���� 0�̶�� 
            if(dodgeKeyDown && isRun && !isDodge && dodgeCoolTime <= 0)
            {
                // dodgeSpeed ���� addSpeed�� �ְ�, isDodge�� true�� �ϸ鼭 �ִϸ��̼��� ����Ѵ�. �� ��, dodgeCoolTime�� ȸ�� ��Ÿ���� �־��ְ�, dodgeTime�� ȸ��(����) �ð��� �־��ش�. 
                addSpeed = dodgeSpeed;
                isDodge = true;
                ani.SetBool("isDodge", isDodge);
                dodgeCoolTime = 2f;
                dodgeTime = 1f;
                
            }
        }
        // addSpeed�� 0���� ũ�ٸ�(ȸ�� ���� ���) addSpeed�� �ʱ�ȭ�Ѵ�.
        if(addSpeed > 0)
        {
            addSpeed -= dodgeSpeed * Time.deltaTime *2;
            
        }
        // ȸ�ǰ� ������ ��� ���� �ʱ�ȭ �Ѵ�.
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
        //Enemy�� ���ݷ¸�ŭ �÷��̾��� ü���� ��´�.
        hp -= damage;
        HP = hp;
    }
}
