using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HSK_WarpGate : MonoBehaviour
{
    // 각 스테이지마다 
    public GameObject player;
    public GameObject[] stages;

    public int stageCount;
    public Image fadeinout; //스테이지 이동시 Fade out -> Fade in

    int stageLevel;
    int currentStageLevel;

    private void Start()
    {
        stages = JK_StageManager.instance.stages;
        player = GameObject.Find("Warrior");
        // Stages[]에 스테이지를 다 넣는다 총 9개의 스테이지. 
    }

    private void OnTriggerEnter(Collider other)
    {

        //워프게이트에 부딪힌 콜라이더가 플레이어라면
        if (other.tag == "Player_HitBox")
        {
            // 1-1
            if (this.transform.parent.name == "WarpGate_1-1_Up")
            {
                if (stages[3].activeInHierarchy == true)
                {
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(0, 0, 50));
                }
                else if (stages[3].activeInHierarchy == false)
                {
                    stages[3].SetActive(true);
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(0, 0, 50));
                }
            }

            if (this.transform.parent.name == "WarpGate_1-1_Right")
            {
                if (stages[1].activeInHierarchy == true)
                {
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(50, 0, 0));
                }
                else if (stages[1].activeInHierarchy == false)
                {
                    stages[1].SetActive(true);
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(50, 0, 0));
                }

            }
            // 1-2 

            if (this.transform.parent.name == "WarpGate_1-2_Left")
            {
                if (stages[0].activeInHierarchy == true)
                {
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(10, 0, 0));
                }
                else if (stages[0].activeInHierarchy == false)
                {
                    stages[0].SetActive(true);
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(10, 0, 0));
                }
                    
            }
            if (this.transform.parent.name == "WarpGate_1-2_Up")
            {
                if (stages[4].activeInHierarchy == true)
                {
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(60, 0, 50));
                }
                else if(stages[4].activeInHierarchy == false)
                {
                    stages[4].SetActive(true);
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(60, 0, 50));
                }
                    
            }
            if (this.transform.parent.name == "WarpGate_1-2_Right")
            {
                if (stages[2].activeInHierarchy == true)
                {
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(110, 0, 0));
                }
                else if(stages[2].activeInHierarchy == false)
                {
                    stages[2].SetActive(true);
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(110, 0, 0));
                }
                    
            }


            // 1-3
            if (this.transform.parent.name == "WarpGate_1-3_Left")
            {
                if (stages[1].activeInHierarchy == true)
                {
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(70, 0, 0));
                }
                else if(stages[1].activeInHierarchy == false)
                {
                    stages[1].SetActive(true);
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(70, 0, 0));
                }
                
                    
            }
            if (this.transform.parent.name == "WarpGate_1-3_Up")
            {
                if(stages[5].activeInHierarchy == true)
                {
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(120, 0, 50));
                }
                else if(stages[5].activeInHierarchy == false)
                {
                    stages[5].SetActive(true);
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(120, 0, 50));
                }
                
            }
            // 1-4
            if (this.transform.parent.name == "WarpGate_1-4_Down")
            {
                if (stages[0].activeInHierarchy == true)
                {
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(0, 0, 10));
                }
                else if(stages[0].activeInHierarchy == false)
                {
                    stages[0].SetActive(true);
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(0, 0, 10));
                }
            }
            if (this.transform.parent.name == "WarpGate_1-4_Right")
            {
                if(stages[4].activeInHierarchy == true)
                {
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(50, 0, 60));
                }
                else if(stages[4].activeInHierarchy == false)
                {
                    stages[4].SetActive(true);
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(50, 0, 60));
                }
            }
            if (this.transform.parent.name == "WarpGate_1-4_Up")
            {
                if(stages[6].activeInHierarchy == true)
                {
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(0, 0, 110));
                }
                else if (stages[6].activeInHierarchy == false)
                {
                    stages[6].SetActive(true);
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(0, 0, 110));
                }
               
            }
            // 1-5
            if (this.transform.parent.name == "WarpGate_1-5_Left")
            {
                if(stages[4].activeInHierarchy == true)
                {
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(10, 0, 60));
                }
                else if (stages[4].activeInHierarchy == false)
                {
                    stages[4].SetActive(true);
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(10, 0, 60));
                }
            }
            if (this.transform.parent.name == "WarpGate_1-5_Up")
            {
                if(stages[7].activeInHierarchy == true)
                {
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(60, 0, 110));
                }
                else if(stages[7].activeInHierarchy == false)
                {
                    stages[7].SetActive(true);
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(60, 0, 110));
                }
            }
            if (this.transform.parent.name == "WarpGate_1-5_Right")
            {
                if(stages[5].activeInHierarchy == true)
                {
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(110, 0, 60));
                }
                else if (stages[5].activeInHierarchy == false)
                {
                    stages[5].SetActive(true);
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(110, 0, 60));
                }
            }
            if (this.transform.parent.name == "WarpGate_1-5_Down")
            {
                if(stages[2].activeInHierarchy == true)
                {
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(60, 0, 10));
                }
                else if (stages[2].activeInHierarchy == false)
                {
                    stages[2].SetActive(true);
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(60, 0, 10));
                }
            }
            // 1-6
            if (this.transform.parent.name == "WarpGate_1-6_Left")
            {
                if(stages[4].activeInHierarchy == true)
                {
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(70, 0, 60));
                }
                else if(stages[4].activeInHierarchy == false)
                {
                    stages[4].SetActive(true);
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(70, 0, 60));
                }
                
            }
            if (this.transform.parent.name == "WarpGate_1-6_Up")
            {
                if(stages[8].activeInHierarchy == true)
                {
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(120, 0, 110));
                }
                else if(stages[8].activeInHierarchy == false)
                {
                    stages[8].SetActive(true);
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(120, 0, 110));
                }
            }
            if (this.transform.parent.name == "WarpGate_1-6_Down")
            {
                if(stages[2].activeInHierarchy == true)
                {
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(120, 0, 10));
                }
                else if(stages[2].activeInHierarchy == false)
                {
                    stages[2].SetActive(true);
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(120, 0, 10));
                }
            }
            // 1-7
            if (this.transform.parent.name == "WarpGate_1-7_Down")
            {
                if(stages[4].activeInHierarchy == true)
                {
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(0, 0, 70));
                }
                else if(stages[4].activeInHierarchy == false)
                {
                    stages[4].SetActive(true);
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(0, 0, 70));
                }
                
            }
            if (this.transform.parent.name == "WarpGate_1-7_Right")
            {
                if(stages[7].activeInHierarchy == true)
                {
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(50, 0, 120));
                }
                else if (stages[7].activeInHierarchy == false)
                {
                    stages[7].SetActive(true);
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(50, 0, 120));
                }
            }
            // 1-8
            if (this.transform.parent.name == "WarpGate_1-8_Left")
            {
                if(stages[7].activeInHierarchy == true)
                {
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(10, 0, 120));
                }
                else if (stages[7].activeInHierarchy == false)
                {
                    stages[8].SetActive(true);
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(10, 0, 120));
                }
            }
            if (this.transform.parent.name == "WarpGate_1-8_Right")
            {
                if(stages[8].activeInHierarchy == true)
                {
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(110, 0, 120));
                }
                else if(stages[8].activeInHierarchy == false)
                {
                    stages[8].SetActive(true);
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(110, 0, 120));
                }
            }
            if (this.transform.parent.name == "WarpGate_1-8_Down")
            {
                if(stages[4].activeInHierarchy == true)
                {
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(60, 0, 70));
                }
                else if (stages[4].activeInHierarchy == false)
                {
                    stages[4].SetActive(true);
                    print("Ready to Warp!");
                    HSK_GameManager.SingleTonGameManager.WarpToNextStage = true;
                    //플레이어를 다음 스테이지(좌표)로 이동시킨다
                    StartCoroutine(Warp(60, 0, 70));
                }

            }
        }




    }
    IEnumerator Warp(float x, float y, float z) //워프 코루틴
    {
        yield return new WaitForSeconds(1f);
        player.transform.position = new Vector3(x, y, z);
        /* if (this.name.Contains("Up"))
         {
             currentStageLevel += 3; 
         }
         else if (this.name.Contains("Right"))
         {
             currentStageLevel += 1;
         }
         else if (this.name.Contains("Down"))
         {
             currentStageLevel -= 3;
         }
         else if (this.name.Contains("left"))
         {
             currentStageLevel -= 1;
         }
         stageLevel++; //매 스테이지는 x값 60간격으로 오른쪽으로 정렬(중요)
         //NextStage.SetActive(true);//넘어갈 스테이지 생성*/
    }
}
