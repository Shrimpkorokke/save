using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK_StartManager : MonoBehaviour
{
    public GameObject player;
    public GameObject wall;
    public GameObject light;
    bool didYouPressStart;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            didYouPressStart = true;
        }
        if (didYouPressStart)
        {
            light.SetActive(true);
            wall.transform.position = Vector3.Lerp(wall.transform.position, player.transform.position - new Vector3(0, 0, -2), Time.deltaTime * 3);
        }
    }
}
