using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK_HitStop : MonoBehaviour
{
    public static JK_HitStop instance;
    bool wating;

    void Awake()
    {
        instance = this;
    }
    // 공격시 불러올 시간을 멈추는 함수 duration(멈출 시간) 값을 받는다.
    public void Stop(float duration)
    {
        // 만약 wating 상태라면 함수 종료
        if (wating)
        {
            return;
        }
        Time.timeScale = 0.0f;

        StartCoroutine(Wait(duration));
    
    }
    // stop함수로 시간을 멈춘걸 지속시키는 함수
    IEnumerator Wait(float duration)
    {
        wating = true;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1.0f;
        wating = false;
    }
   
    
}
