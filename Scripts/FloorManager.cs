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
                // 1. Floor ���忡�� Floor�� �ϳ� �����
                GameObject floor = Instantiate(floorFactory);
                // ���� �ֱٿ� ������� Floor�� Docker ��ġ�� ��ġ
                floor.transform.position = latestFloor.docker.transform.position;
                // 3.Floor�� ���� �ڽ����� �ϰ� �ʹ�. ���� �θ� = ��
                floor.transform.parent = transform;
                // 4. ���θ��� floor�� latestfloor�� ����
                latestFloor = floor.GetComponent<Floor>();
                latestFloor.floorManager = this;
                count++;
            }
            
            yield return new WaitForSeconds(createTime);
        }
    }
    private void Update()
    {
        // Ư���������� �̵��ϰ� �ʹ�
        transform.position += dir * speed * Time.deltaTime;
    }
}
