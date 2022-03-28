using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JK_ComboManager : MonoBehaviour
{
    public static JK_ComboManager instance;
    public GameObject comboObj; // Combo라고 써져있는 텍스트 3콤보 이상이면 띄울 예정
    public Text comboTxt;   // current 콤보를 쓸 텍스트
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
