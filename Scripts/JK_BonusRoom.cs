using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JK_BonusRoom : MonoBehaviour
{
    public static JK_BonusRoom instance;
    public bool didYouGetBonus = false;
    public GameObject message;
    public GameObject message2;
    public GameObject bonusSkillMessage;

    public Transform target;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        //transform.forward = target.forward;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Warrior")
        {
            message.SetActive(true);
            print("fafa");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Warrior")
        {
            message.SetActive(false);
        }
    }

    public void OnClickButtonYes()
    {
        message.SetActive(false);
        if(didYouGetBonus == false)
        {
            bonusSkillMessage.SetActive(true);
        }
        else
        {
            message.SetActive(false);
            message2.SetActive(true);
        }
        
    }

    public void OnclickButtonNo()
    {
        if (message.activeSelf)
        {
            message.SetActive(false);
        }
        else if (message2.activeSelf)
        {
            message2.SetActive(false);
        }
    }
   
    
}
