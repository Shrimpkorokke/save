using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK_PlayerAttack : MonoBehaviour
{
    public static JK_PlayerAttack instance;

    public float addSpeed;
   


    bool comboPossible;
    
    int comboStep;
    public bool isAttack = true;
   
    Animator ani;
    private void Awake()
    {
        instance = this;
        ani = GetComponent<Animator>();
    }

    // 연속공격
    public void Attack()
    {
        // 현재 콤보 단계를 나타내는 comboStep이 0일경우 
        if (comboStep == 0)
        {
            // 현재 바라보고 있는 방향(dir) 값을 -> 공격시 바라볼 방향(attackDir)에 넣고
            // Attack1이라는 이름을 가지고 있는 애니메이션을 재생시킨다
            // 그 후, 첫번째 공격을 나타내기 위해 comboStep에 1의 값을 넣고, 공격 중이라는 상태를 나타내는 isAttack에 true 값을 넣는다.
            JK_Player.instance.attackDir = JK_Player.instance.dir;
            ani.Play("Attack1");
            comboStep = 1;
            isAttack = true;
            return;
        }
        // comboStep이 0이 아닐 경우(첫번째 공격 이후)
        if (comboStep != 0)
        {
            // comboPossible이 참이면
            if (comboPossible)
            {
                // comboPossible을 false로 바꾸고 comboStep을 가지고 있는 수 + 1을 한다.
                comboPossible = false;
                comboStep += 1;
            }
        }
    }

    // 애니메이션 이벤트로 다음 공격의 입력을 받을 지점에 넣을 함수, 다음 공격을 한다는 의미이기 대문에 comboPossible을 true로 바꿈
    void ComboPossible()
    {
        comboPossible = true;
    }

    // 다음 공격모션이 재생될 부분에 넣을 함수 / Combopossible 부분에서 공격키를 눌렀다면 comboPossible이 true고, update문에서 Attack()을 계속 실행시키면서 comboPossible이 true면 comboPossible을 false로 바꾼다음에 comboStep을 1
    // 증가시키는데 comboStep에 맞는 애니메이션을 재생한다.
    void Combo()
    {
        if (comboStep == 2)
        {
            ani.Play("Attack2");
        }
        if (comboStep == 3)
        {
            ani.Play("Attack3");
        }
        if (comboStep == 4)
        {
            ani.Play("Attack4");
        }
    }
    // 애니메이션 이벤트로 공격이 끝나는 지점에 넣을 함수, 다음 연속공격을 하지 않는 다는 의미이기 때문에 comboPossible을 false로 바꿈
    public void ComboReset()
    {
        comboPossible = false;
        comboStep = 0;
        isAttack = false;
    }

    
   
    private void Update()
    {
        if (Input.GetKey(KeyCode.Z) && !JK_Player.instance.isDodge && !Jk_Parrying.instance.isParrying && !ani.GetCurrentAnimatorStateInfo(0).IsName("Counter"))
        { 
            Attack();
        }
        
    }
}
