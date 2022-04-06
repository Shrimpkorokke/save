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
                    //�÷��̾ ���� ��������(��ǥ)�� �̵���Ų��
                    StartCoroutine(Warp(0, 0, 0));
                }
                else if (stage.activeInHierarchy == false)
                {
                    stage.SetActive(true);
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //�÷��̾ ���� ��������(��ǥ)�� �̵���Ų��
                    StartCoroutine(Warp(0, 0, 0));
                }
            }
            JK_Tutorial.instance.duringTuto = false;
        }
       
    }
    IEnumerator Warp(float x, float y, float z) //���� �ڷ�ƾ
    {
        yield return new WaitForSeconds(1f);
        player.transform.position = new Vector3(x, y, z);
       
    }
}
