using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    public Vector3 dir = Vector3.back;
    public float speed = 5;
    public Floor latestFloor;
    public float createTime = 1;
    public int count;
    public int maxCount = 20;
    public GameObject floorFactory;
    public GameObject lightObj;
    IEnumerator Start()
    {
        while (true)
        {
            if (count < maxCount)
            {
                // 1. Floor 공장에서 Floor를 하나 만들고
                GameObject floor = Instantiate(floorFactory);
                // 가장 최근에 만들어진 Floor의 Docker 위치에 배치
                floor.transform.position = latestFloor.docker.transform.position;
                // 3.Floor를 나의 자식으로 하고 싶다. 나의 부모 = 너
                floor.transform.parent = transform;
                // 4. 새로만든 floor를 latestfloor로 갱신
                latestFloor = floor.GetComponent<Floor>();
                latestFloor.floorManager = this;
                count++;
            }
            
            yield return new WaitForSeconds(createTime);
        }
    }
    private void Update()
    {
        // 특정방향으로 이동하고 싶다
        transform.position += dir * speed * Time.deltaTime;
    }
}
