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
    {   //�÷��̾ �� �濡 �ְ�
        if(other.name == "Warrior" && readyDetect)
        {
            // ���̾��Ű â�� ���Ͱ� ���� ��
            if (null == GameObject.FindWithTag("Monster_Melee_B") && null == GameObject.FindWithTag("Monster_Ranged_A")
                && null == GameObject.FindWithTag("Monster_Attack") && null == GameObject.FindWithTag("Monster_Ranged_A")
                && null == GameObject.FindWithTag("GateEffect") && didYouDetect == false)
            {
                // Ž���� �ߴ��� üũ�ϴ� �� true�� �ٲ۴�
                didYouDetect = true;
                // detect ���� (30,0,30) ��ŭ Ž���� �ؼ� �ɸ� �༮���� obj �ȿ� �ִ´�
                Collider[] obj = Physics.OverlapBox(transform.position, detect);
                // obj�� ������ŭ �ݺ���
                for (int i = 0; i < obj.Length; i++)
                {
                    // ���� obj[i] ��°�� �±װ� WarpGate�� ���
                    if (obj[i].CompareTag("WarpGate"))
                    {
                        // warpGate[i]�� ��ġ�� obj[i]�� ��ġ�� ����.
                        GameObject warp = Instantiate(gateEffect);
                        warp.transform.parent = obj[i].transform;
                        warp.transform.position = obj[i].transform.position;

                    }
                }
            }   
        }
    }

}
