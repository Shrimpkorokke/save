using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK_TRPlayer : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Wall")
        {
            // 새로운씬 불러오기
        }
    }
}
