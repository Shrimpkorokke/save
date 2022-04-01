using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK_Sword : MonoBehaviour
{
    public static JK_Sword instance;
    public CapsuleCollider attackHitBox_1;
    public CapsuleCollider attackHitBox_2;
    public CapsuleCollider s_dashHitbox; //*0330���д뽬 ������Ʈ�ڽ�
    public CapsuleCollider Player_S_dash; //*0330 ���д뽬�Ͻ� �÷��̾� ��Ʈ�ڽ�, �ݶ��̴� ��� ��Ȱ��ȭ
    public GameObject hitEffectFactory;
    
    Transform monster; //���� ��ǥ Ư��
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
        //monster = GameObject.FindWithTag("Monster").transform; //���� ��ġ Ư��
    }

    private void Update() //*0330 ���д뽬�� �÷��̾� �ݶ��̴� off
    {
        if (this.tag == "Player_SDash")
        {
            Player_S_dash.enabled = false;
        }
        else
        {
            Player_S_dash.enabled = true;
        }
    }

    // OntriggerEnter -> �����ΰ��� �ε����� �� 
    private void OnTriggerEnter(Collider other)
    {
            // �׸��� �� ������Ʈ�� �±װ� Player_HitBox���
            //Hp�� ��� / �����̴��� ü���� �ٲٰ� / ī�޶� ���� / �ð��� ���߰� / ������� ����Ѵ� 
        if(this.tag == "Player_Attack" || this.tag == "Player_Skill1")
        {
            if (other.tag == "Monster_Melee_B" || other.tag == "Monster_Attack")
            {
                //MeleeEnemy�� ���� ������ ó�� �� ü�¹� ����
                other.GetComponent<HSK_MeleeEnemy01>().HitEnemy(damage);
                HSK_MeleeEnemy01.SingleTonMeleeEnemy01.hp = HSK_MeleeEnemy01.SingleTonMeleeEnemy01.hp - damage;
                other.GetComponent<HSK_MeleeEnemy01>().HpBarDown();

                // �ñر� ������ ����, ��Ʈ��ž, ī�޶� ��鸲, ȿ�������, ��Ʈ ����Ʈ ���
                JK_Player.instance.ULTGAUGE = JK_Player.instance.ULTGAUGE + 1;
                JK_ComboManager.instance.IncreaseCombo();
                GameObject hitEffect = Instantiate(hitEffectFactory); //����Ʈ ���
                hitEffect.transform.position = other.transform.position + new Vector3(0, 1, 0); //����Ʈ ��ġ
                JK_CameraMove.instance.OnShakeCamera(0.05f, 0.05f);
                JK_HitStop.instance.Stop(0.05f);
                JK_AudioManager.instance.PlayAudio();
                print("Hit");
            }
            else if (other.tag == "Monster_Ranged_A")
            {
                //MeleeEnemy�� ���� ������ ó�� �� ü�¹� ����
                other.GetComponent<HSK_RangedEnemy01>().HitEnemy(damage);
                HSK_RangedEnemy01.SingleTonRangedEnemy01.hp = HSK_RangedEnemy01.SingleTonRangedEnemy01.hp - damage;
                other.GetComponent<HSK_RangedEnemy01>().HpBarDown();

                // �ñر� ������ ����, ��Ʈ��ž, ī�޶� ��鸲, ȿ�������, ��Ʈ ����Ʈ ���
                JK_Player.instance.ULTGAUGE = JK_Player.instance.ULTGAUGE + 1;
                JK_ComboManager.instance.IncreaseCombo();
                GameObject hitEffect = Instantiate(hitEffectFactory); //����Ʈ ���
                hitEffect.transform.position = other.transform.position + new Vector3(0, 1, 0); //����Ʈ ��ġ
                JK_CameraMove.instance.OnShakeCamera(0.05f, 0.05f);
                JK_HitStop.instance.Stop(0.05f);
                JK_AudioManager.instance.PlayAudio();
                print("Hit");
            }
        }

        if(this.tag == "Player_SDash")
        {
            if (other.tag == "Monster_Melee_B" || other.tag == "Monster_Attack")
            {
                //MeleeEnemy�� ���� ������ ó�� �� ü�¹� ����
                other.GetComponent<HSK_MeleeEnemy01>().HitEnemy(1);
                HSK_MeleeEnemy01.SingleTonMeleeEnemy01.hp = HSK_MeleeEnemy01.SingleTonMeleeEnemy01.hp - damage;
                other.GetComponent<HSK_MeleeEnemy01>().HpBarDown();

                // �ñر� ������ ����, ��Ʈ��ž, ī�޶� ��鸲, ȿ�������, ��Ʈ ����Ʈ ���
                JK_Player.instance.ULTGAUGE = JK_Player.instance.ULTGAUGE + 1;
                JK_ComboManager.instance.IncreaseCombo();
                GameObject hitEffect = Instantiate(hitEffectFactory); //����Ʈ ���
                hitEffect.transform.position = other.transform.position + new Vector3(0, 1, 0); //����Ʈ ��ġ
                JK_CameraMove.instance.OnShakeCamera(0.05f, 0.05f);
                //JK_HitStop.instance.Stop(0.001f);
                JK_AudioManager.instance.PlayAudio();
                print("ShieldDash Hit");
            }
            else if (other.tag == "Monster_Ranged_A")
            {
                //MeleeEnemy�� ���� ������ ó�� �� ü�¹� ����
                other.GetComponent<HSK_RangedEnemy01>().HitEnemy(1);
                HSK_RangedEnemy01.SingleTonRangedEnemy01.hp = HSK_RangedEnemy01.SingleTonRangedEnemy01.hp - damage;
                other.GetComponent<HSK_RangedEnemy01>().HpBarDown();

                // �ñر� ������ ����, ��Ʈ��ž, ī�޶� ��鸲, ȿ�������, ��Ʈ ����Ʈ ���
                JK_Player.instance.ULTGAUGE = JK_Player.instance.ULTGAUGE + 1;
                JK_ComboManager.instance.IncreaseCombo();
                GameObject hitEffect = Instantiate(hitEffectFactory); //����Ʈ ���
                hitEffect.transform.position = other.transform.position + new Vector3(0, 1, 0); //����Ʈ ��ġ
                JK_CameraMove.instance.OnShakeCamera(0.05f, 0.05f);
                //JK_HitStop.instance.Stop(0.001f);
                JK_AudioManager.instance.PlayAudio();
                print("ShieldDash Hit");
            }

        }

        if(this.tag == "Player_Parrying")
        {
            if (other.tag == "Monster_Melee_B" || other.tag == "Monster_Attack")
            {
                //MeleeEnemy�� ���� ������ ó�� �� ü�¹� ����
                other.GetComponent<HSK_MeleeEnemy01>().HitEnemy(1);
                HSK_MeleeEnemy01.SingleTonMeleeEnemy01.hp = HSK_MeleeEnemy01.SingleTonMeleeEnemy01.hp - damage;
                other.GetComponent<HSK_MeleeEnemy01>().HpBarDown();

                // �ñر� ������ ����, ��Ʈ��ž, ī�޶� ��鸲, ȿ�������, ��Ʈ ����Ʈ ���
                JK_Player.instance.ULTGAUGE = JK_Player.instance.ULTGAUGE + 1;
                JK_ComboManager.instance.IncreaseCombo();
                GameObject hitEffect = Instantiate(hitEffectFactory); //����Ʈ ���
                hitEffect.transform.position = other.transform.position + new Vector3(0, 1, 0); //����Ʈ ��ġ
                JK_CameraMove.instance.OnShakeCamera(0.05f, 0.05f);
                //JK_HitStop.instance.Stop(0.001f);
                JK_AudioManager.instance.PlayAudio();
            }
            else if (other.tag == "Monster_Ranged_A")
            {
                //MeleeEnemy�� ���� ������ ó�� �� ü�¹� ����
                other.GetComponent<HSK_RangedEnemy01>().HitEnemy(1);
                HSK_RangedEnemy01.SingleTonRangedEnemy01.hp = HSK_RangedEnemy01.SingleTonRangedEnemy01.hp - damage;
                other.GetComponent<HSK_RangedEnemy01>().HpBarDown();

                // �ñر� ������ ����, ��Ʈ��ž, ī�޶� ��鸲, ȿ�������, ��Ʈ ����Ʈ ���
                JK_Player.instance.ULTGAUGE = JK_Player.instance.ULTGAUGE + 1;
                JK_ComboManager.instance.IncreaseCombo();
                GameObject hitEffect = Instantiate(hitEffectFactory); //����Ʈ ���
                hitEffect.transform.position = other.transform.position + new Vector3(0, 1, 0); //����Ʈ ��ġ
                JK_CameraMove.instance.OnShakeCamera(0.05f, 0.05f);
                //JK_HitStop.instance.Stop(0.001f);
                JK_AudioManager.instance.PlayAudio();

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
    public void S_DashHit() //*0330 ���йб� ��Ʈ�ڽ� on/off
    {
        StartCoroutine("S_DashHitboxEnable");
    }

    // �������� 1�� �ݶ��̴��� Ű�� �Լ� (Attack 1,2,4 )
    IEnumerator AttackHitBoxEnable_1()
    {
        // �������� 1�� �ݶ��̴��� Ű�� 0.1�� �ڿ� ����
        attackHitBox_1.enabled = true;
        //print("attackHitBox_1.enabled = true");
        yield return new WaitForSeconds(0.1f);
        attackHitBox_1.enabled = false;
        //print("attackHitBox_1.enabled = false");
    }

    // �������� 2�� �ݶ��̴��� Ű�� �Լ� (Attack3 )
    IEnumerator AttackHitBoxEnable_2() 
    {
        // �������� 2�� �ݶ��̴� Ű�� 0.1�� �ڿ� ����
        attackHitBox_2.enabled = true;
        //print("attackHitBox_2.enabled = true");
        yield return new WaitForSeconds(0.02f);
        attackHitBox_2.enabled = false;
        //print("attackHitBox_2.enabled = false");
    }

    //*0330 ���йб� �ݶ��̴��� Ű�� �Լ�
    IEnumerator S_DashHitboxEnable()
    {
        // ���йб��� �ݶ��̴� Ű�� 0.02�� �ڿ� ����
        s_dashHitbox.enabled = true;
        print("attackHitBox_2.enabled = true");
        yield return new WaitForSeconds(0.02f);
        s_dashHitbox.enabled = false;
        print("attackHitBox_2.enabled = false");
    }

    // �ִϸ��̼� �̺�Ʈ�� ���Ǵ� �Լ� -> �±׸� �ٲ��ش� -> ����: �ִϸ��̼� �̺�Ʈ �߰��� ���� �� Function�ǿ� �� �Լ��� �������� String ĭ�� �ٲٰ� ���� �±׸� ���´� ��) Player_Attack
    void ChangeTag(string t)
    {
        this.tag = t;
    }
}
