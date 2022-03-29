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

    float currentTime;
    float comboEndureTime = 4;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        comboObj.SetActive(false);
        comboTxt.gameObject.SetActive(false);
    }
    public void Update()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= comboEndureTime)
        {
            currentTime = 0;
            ResetCombo();
        }
    }


    public void IncreaseCombo()
    {
        currentCombo++;
        currentTime = 0;
        comboTxt.text = currentCombo.ToString();

        if(currentCombo >= 1)
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
