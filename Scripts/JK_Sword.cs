using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK_Sword : MonoBehaviour
{
    public static JK_Sword instance;
    public CapsuleCollider attackHitBox_1;
    public CapsuleCollider attackHitBox_2;
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
        monster = GameObject.FindWithTag("Monster").transform; //���� ��ġ Ư��
    }

    // OntriggerEnter -> �����ΰ��� �ε����� �� 
    private void OnTriggerEnter(Collider other)
    {
        // ������ �±װ� Monster���
        if(other.tag == "Monster" || other.tag == "Monster_Attack")
        {
            // �׸��� �� ������Ʈ�� �±װ� Player_HitBox���
            //Hp�� ��� / �����̴��� ü���� �ٲٰ� / ī�޶� ���� / �ð��� ���߰� / ������� ����Ѵ� 
            
            if(this.tag == "Player_Attack" || this.tag == "Player_SDash" || this.tag == "Player_Skill1")
            {
                //MeleeEnemy�� ���� ������ ó�� �� ü�¹� ����
                other.GetComponent<HSK_MeleeEnemy01>().HitEnemy(damage);
                HSK_MeleeEnemy01.SingleTonMeleeEnemy01.hp = HSK_MeleeEnemy01.SingleTonMeleeEnemy01.hp - damage;
                other.GetComponent<HSK_MeleeEnemy01>().HpBarDown();

                //��Ʈ��ž, ī�޶� ��鸲, ȿ�������, ��Ʈ ����Ʈ ���
                GameObject hitEffect = Instantiate(hitEffectFactory); //����Ʈ ���
                hitEffect.transform.position = other.transform.position + new Vector3(0, 1, 0); //����Ʈ ��ġ
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

    // �������� 1�� �ݶ��̴��� Ű�� �Լ� (Attack 1,2,4 )
    IEnumerator AttackHitBoxEnable_1()
    {
        // �������� 1�� �ݶ��̴��� Ű�� 0.1�� �ڿ� ����
        attackHitBox_1.enabled = true;
        print("attackHitBox_1.enabled = true");
        yield return new WaitForSeconds(0.1f);
        attackHitBox_1.enabled = false;
        print("attackHitBox_1.enabled = false");
    }

    // �������� 2�� �ݶ��̴��� Ű�� �Լ� (Attack3 )
    IEnumerator AttackHitBoxEnable_2() 
    {
        // �������� 2�� �ݶ��̴� Ű�� 0.1�� �ڿ� ����
        attackHitBox_2.enabled = true;
        print("attackHitBox_2.enabled = true");
        yield return new WaitForSeconds(0.02f);
        attackHitBox_2.enabled = false;
        print("attackHitBox_2.enabled = false");
    }

    // �ִϸ��̼� �̺�Ʈ�� ���Ǵ� �Լ� -> �±׸� �ٲ��ش� -> ����: �ִϸ��̼� �̺�Ʈ �߰��� ���� �� Function�ǿ� �� �Լ��� �������� String ĭ�� �ٲٰ� ���� �±׸� ���´� ��) Player_Attack
    void ChangeTag(string t)
    {
        this.tag = t;
    }
}
