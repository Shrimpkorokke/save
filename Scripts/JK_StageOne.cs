using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK_StageOne : MonoBehaviour
{
    public static JK_StageOne instance;
    public GameObject enemySpawner;
    

    public void Awake()
    {
        instance = this;
    }

    IEnumerator Start()
    {
        yield return new WaitForSeconds(2f);
        enemySpawner.SetActive(true);
        JK_Tutorial.instance.introduce = true;
        yield return new WaitForSeconds(1f);
        JK_HitStop.instance.SlowStop(2f);
        yield return new WaitForSeconds(3f);
        JK_Tutorial.instance.StartIEThird();
        JK_Tutorial.instance.introduce = false;
        
    }

    
    void Update()
    {
        
    }

}
