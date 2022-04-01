using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK_EnemyDetection : MonoBehaviour
{
    GameObject[] MeleeEnemy;
    GameObject[] RangedEnemy;
    public GameObject gateEffect;

    public bool didYouDetect = false;
    public bool readyDetect = false;
    public float currentTime;
    public float MaxTime = 2;
    Vector3 detect = new Vector3(30, 0, 30);

    private void Update()
    {
         if(currentTime < MaxTime && readyDetect == false)
         {
            currentTime += Time.deltaTime; 
            
         }
         if(currentTime >= MaxTime && readyDetect == false)
        {
            readyDetect = true;
        }
         
    }

    private void OnTriggerStay(Collider other)
    {   //플레이어가 이 방에 있고
        if(other.name == "Warrior" && readyDetect)
        {
            // 하이어라키 창에 몬스터가 없을 때
            if (null == GameObject.FindWithTag("Monster_Melee_B") && null == GameObject.FindWithTag("Monster_Ranged_A")
                && null == GameObject.FindWithTag("Monster_Attack") && null == GameObject.FindWithTag("Monster_Ranged_A")
                && null == GameObject.FindWithTag("GateEffect") && didYouDetect == false)
            {
                // 탐지를 했는지 체크하는 걸 true로 바꾼다
                didYouDetect = true;
                // detect 범위 (30,0,30) 만큼 탐지를 해서 걸린 녀석들을 obj 안에 넣는다
                Collider[] obj = Physics.OverlapBox(transform.position, detect);
                // obj의 갯수만큼 반복문
                for (int i = 0; i < obj.Length; i++)
                {
                    // 만약 obj[i] 번째의 태그가 WarpGate일 경우
                    if (obj[i].CompareTag("WarpGate"))
                    {
                        // warpGate[i]의 위치는 obj[i]의 위치와 같다.
                        GameObject warp = Instantiate(gateEffect);
                        warp.transform.parent = obj[i].transform;
                        warp.transform.position = obj[i].transform.position;

                    }
                }
            }   
        }
    }

}
