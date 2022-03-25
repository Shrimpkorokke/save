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
    // ���ݽ� �ҷ��� �ð��� ���ߴ� �Լ� duration(���� �ð�) ���� �޴´�.
    public void Stop(float duration)
    {
        // ���� wating ���¶�� �Լ� ����
        if (wating)
        {
            return;
        }
        Time.timeScale = 0.0f;

        StartCoroutine(Wait(duration));
    
    }
    // stop�Լ��� �ð��� ����� ���ӽ�Ű�� �Լ�
    IEnumerator Wait(float duration)
    {
        wating = true;
        yield return new WaitForSecondsRealtime(duration);
        Time.timeScale = 1.0f;
        wating = false;
    }
   
    
}
