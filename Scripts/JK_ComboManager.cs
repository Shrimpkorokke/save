using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JK_ComboManager : MonoBehaviour
{
    public static JK_ComboManager instance;
    public GameObject comboObj; // Combo��� �����ִ� �ؽ�Ʈ 3�޺� �̻��̸� ��� ����
    public Text comboTxt;   // current �޺��� �� �ؽ�Ʈ
    public int currentCombo;
    public Animator ani;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        comboObj.SetActive(false);
        comboTxt.gameObject.SetActive(false);
    }

    public void IncreaseCombo()
    {
        currentCombo++;
        comboTxt.text = currentCombo.ToString();

        if(currentCombo >= 3)
        {
            comboTxt.gameObject.SetActive(true);
            comboObj.SetActive(true);
        }
        ani.SetTrigger("Combo");
    }
    public void ResetCombo()
    {
        currentCombo = 0;
        comboTxt.gameObject.SetActive(false);
        comboObj.SetActive(false);
    }
}
