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

    // 막기
    public void Defence()
    {
        isParrying = true;
        ani.SetTrigger("Defence");
        parryingDir = JK_Player.instance.dir;
    }
    // 막기 도중 (tag가 Player_Defence 상태일 때 또는 애니메이션이 재생될 때) 공격이 들어오면 실행시킬 함수 -> JK_PlayerHitBox OnTriggerEnter
    public void Defence_Damage()
    {
        parryingDir = JK_Player.instance.dir;
        ani.Play("Defence_Damage");
        isParrying = true;
    }

    // 방패를 든 상태에서 맞고 플레이어가 공격키를 누르면 실행시킬 함수
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
    
    // 패링 상태에서 플레이어가 공격키를 누르면 실행시킬 함수
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
