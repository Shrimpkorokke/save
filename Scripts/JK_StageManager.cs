using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK_StageManager : MonoBehaviour
{
    public static JK_StageManager instance;
    private void Awake()
    {
        instance = this;
    }
    public GameObject[] stages;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
