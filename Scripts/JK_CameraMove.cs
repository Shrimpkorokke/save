using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK_CameraMove : MonoBehaviour
{
    public static JK_CameraMove instance;
    public Transform target; // ���� ��� (Player)
    public Vector3 offset; // �÷��̾�� ���� �󸶸�ŭ �������� ���� ���ϴ� ���Ͱ�

    public float shakeTime;
    public float shakeIntensity;
    /// <param name="ShakeTime> ī�޶� ��鸲 ���� �ð�(�������� ������ default 1.0f)
    /// <param name="ShakeIntensity> ī�޶� ��鸲 ���� (���� Ŭ���� ���� ��鸰��)(�������� ������ default 0.1f)    
    private void Awake()
    {
        instance = this;
    }
   
    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            OnShakeCamera(0.02f, 0.05f);
        }
    }
    public void OnShakeCamera(float shakeTime = 0.02f, float shakeIntensity = 0.05f)
    {
        this.shakeTime = shakeTime;
        this.shakeIntensity = shakeIntensity;

        StopCoroutine("ShakeByPosition");
        StartCoroutine("ShakeByPosition");
    }
    // ī�޶� shakeTime���� shakeIntensity�� ����� ���� �ڷ�ƾ �Լ�
    public IEnumerator ShakeByPosition()
    {
        Vector3 startPosition = transform.position;

        while (shakeTime > 0.0f)
        {
            //Ư�� �ุ �����ϱ� ���ϸ� �Ʒ� �ڵ� �̿� (�̵����� ���� ���� 0 ���� ���)
            //float x = Random.Range(-1f, 1f);
            //float y = Random.Range(-1f, 1f);
            //float z = Random.Range(-1f, 1f);
            //transform.position = startPosition + new Vector3(x, y, z) * shakeIntensity;

            // �ʱ� ��ġ�κ���  �� ����(Size 1) * shakeIntensity�� ���� �ȿ��� ī�޶� ��ġ �̵�
            transform.position = startPosition + Random.insideUnitSphere * shakeIntensity;

            // �ð� ����
            shakeTime -= Time.deltaTime;
            yield return null;
        }
        transform.position = startPosition;
    }


}
