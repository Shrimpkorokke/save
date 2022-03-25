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

    // ���Ӱ���
    public void Attack()
    {
        // ���� �޺� �ܰ踦 ��Ÿ���� comboStep�� 0�ϰ�� 
        if (comboStep == 0)
        {
            // ���� �ٶ󺸰� �ִ� ����(dir) ���� -> ���ݽ� �ٶ� ����(attackDir)�� �ְ�
            // Attack1�̶�� �̸��� ������ �ִ� �ִϸ��̼��� �����Ų��
            // �� ��, ù��° ������ ��Ÿ���� ���� comboStep�� 1�� ���� �ְ�, ���� ���̶�� ���¸� ��Ÿ���� isAttack�� true ���� �ִ´�.
            JK_Player.instance.attackDir = JK_Player.instance.dir;
            ani.Play("Attack1");
            comboStep = 1;
            isAttack = true;
            return;
        }
        // comboStep�� 0�� �ƴ� ���(ù��° ���� ����)
        if (comboStep != 0)
        {
            // comboPossible�� ���̸�
            if (comboPossible)
            {
                // comboPossible�� false�� �ٲٰ� comboStep�� ������ �ִ� �� + 1�� �Ѵ�.
                comboPossible = false;
                comboStep += 1;
            }
        }
    }

    // �ִϸ��̼� �̺�Ʈ�� ���� ������ �Է��� ���� ������ ���� �Լ�, ���� ������ �Ѵٴ� �ǹ��̱� �빮�� comboPossible�� true�� �ٲ�
    void ComboPossible()
    {
        comboPossible = true;
    }

    // ���� ���ݸ���� ����� �κп� ���� �Լ� / Combopossible �κп��� ����Ű�� �����ٸ� comboPossible�� true��, update������ Attack()�� ��� �����Ű�鼭 comboPossible�� true�� comboPossible�� false�� �ٲ۴����� comboStep�� 1
    // ������Ű�µ� comboStep�� �´� �ִϸ��̼��� ����Ѵ�.
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
    // �ִϸ��̼� �̺�Ʈ�� ������ ������ ������ ���� �Լ�, ���� ���Ӱ����� ���� �ʴ� �ٴ� �ǹ��̱� ������ comboPossible�� false�� �ٲ�
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
