using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK_UltEffect : MonoBehaviour
{
    //public Transform firstPos;
    public GameObject endPos;
    
    public void Start()
    {
        endPos = GameObject.Find("SecondPos");
        transform.position = endPos.transform.position;
        //UltEffect();
    }
    public void UltEffect()
    {
        //Vector3 targetPos = firstPos.transform.position;
        Vector3 secondPos = endPos.transform.position;
        //transform.position = targetPos;
        transform.position = Vector3.Lerp(transform.position, secondPos, 0.1f);
    }
}
