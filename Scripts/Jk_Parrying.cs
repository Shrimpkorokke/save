using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jk_Parrying : MonoBehaviour
{
    public static Jk_Parrying instance;
    Animator ani;
    public bool isParrying;
    public bool parryingPossible;
    public bool counterPossible;
    public int parryingStep;
    public Vector3 parryingDir;

    public GameObject hitBox;
    private void Awake()
    {
        instance = this;
        ani = GetComponent<Animator>();
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.X) && !isParrying && !JK_Player.instance.isRun && this.tag != "Player_Defence")
        {
            Defence();
        }
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("Defence") || JK_Player.instance.isDodge || JK_Player.instance.isRun || JK_Player.instance.isDodgeAttack)
        {
            TriggerReset();
        }
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("Defence_Damage") && parryingPossible)
        {
            Parrying();
        }
        if (ani.GetCurrentAnimatorStateInfo(0).IsName("Parrying") && counterPossible && !ani.GetCurrentAnimatorStateInfo(0).IsName("Counter"))
        {

            if (Input.GetKey(KeyCode.Z))
            {
                Counter();
            }
        }
    }

    // ����
    public void Defence()
    {
        isParrying = true;
        ani.SetTrigger("Defence");
        parryingDir = JK_Player.instance.dir;
    }
    // ���� ���� (tag�� Player_Defence ������ �� �Ǵ� �ִϸ��̼��� ����� ��) ������ ������ �����ų �Լ� -> JK_PlayerHitBox OnTriggerEnter
    public void Defence_Damage()
    {
        parryingDir = JK_Player.instance.dir;
        ani.Play("Defence_Damage");
        isParrying = true;
    }

    // ���и� �� ���¿��� �°� �÷��̾ ����Ű�� ������ �����ų �Լ�
    public void Parrying()
    {
        if (parryingPossible == true)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                parryingDir = JK_Player.instance.dir;
                ani.Play("Parrying");
                isParrying = true;
            }
        }   
    }
    
    // �и� ���¿��� �÷��̾ ����Ű�� ������ �����ų �Լ�
    public void Counter()
    {
        if(counterPossible == true)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                parryingDir = JK_Player.instance.dir;
                ani.Play("Counter");
                isParrying = true;
                
            }
        }
    }
    public void ParryingReset()
    {
        isParrying = false;
        parryingPossible = false;
        counterPossible = false;
    }
    public void TriggerReset()
    {
        ani.ResetTrigger("Defence");
    }
   
    void ParryingPossible(float duration)
    {
        StartCoroutine(ParryingPossibleCoroutine(duration));
    }

    IEnumerator ParryingPossibleCoroutine(float duration)
    {
        parryingPossible = true;
        yield return new WaitForSecondsRealtime(duration);
        parryingPossible = false;
    }
    void CounterPossible(float duration)
    {
        StartCoroutine(CounterPossibleCoroutine(duration));
    }

    IEnumerator CounterPossibleCoroutine(float duration)
    {
        counterPossible = true;
        yield return new WaitForSecondsRealtime(duration);
        counterPossible = false;
    }




    /*public void CounterAttack(int time)
    {
        StartCoroutine(CounterAttackCoroutine(time));
    }
    IEnumerator CounterAttackCoroutine(int time)
    {
        
        for (int i = 0; i < time; i++)
        {
            JK_Sword.instance.AttackHit_2();
            yield return new WaitForSecondsRealtime(0.07f);
        }

    }*/
}
