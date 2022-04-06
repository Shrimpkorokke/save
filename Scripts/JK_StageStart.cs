using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK_StageStart : MonoBehaviour
{
    public static JK_StageStart instance;
    GameObject player;
    GameObject stage;
    private void Start()
    {
        instance = this;
        player = GameObject.Find("Warrior");
        stage = JK_StageManager.instance.stages[0];
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Warrior")
        {
            if (this.transform.parent.name == "WarpEffectPosition")
            {
                if (stage.activeInHierarchy == true)
                {
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(0, 0, 0));
                }
                else if (stage.activeInHierarchy == false)
                {
                    stage.SetActive(true);
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(0, 0, 0));
                }
            }
            JK_Tutorial.instance.duringTuto = false;
        }
       
    }
    IEnumerator Warp(float x, float y, float z) //워프 코루틴
    {
        yield return new WaitForSeconds(1f);
        player.transform.position = new Vector3(x, y, z);
       
    }
}
