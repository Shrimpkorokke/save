using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK_CameraMove : MonoBehaviour
{
    public static JK_CameraMove instance;
    public Transform target; // ���� ��� (Player)
    public Vector3 offset; // �÷��̾�� ���� �󸶸�ŭ �������� ���� ���ϴ� ���Ͱ�
    public Vector3 offset2;

    public float shakeTime;
    public float shakeIntensity;

    public float ultShakeTime;
    public float ultShakeIntensity;

    public bool isBonusStage;
    /// <param name="ShakeTime> ī�޶� ��鸲 ���� �ð�(�������� ������ default 1.0f)
    /// <param name="ShakeIntensity> ī�޶� ��鸲 ���� (���� Ŭ���� ���� ��鸰��)(�������� ������ default 0.1f)    
    private void Awake()
    {
        instance = this;
    }
   
    // Update is called once per frame
    void Update()
    {
        if(false == JK_Player.instance.isInBonusRoom)
        {
            transform.position = target.position + offset;
            transform.rotation = Quaternion.Euler(40, 0, 0);
        }
        else if(true == JK_Player.instance.isInBonusRoom)
        {
            transform.position = target.position + offset2;
            transform.rotation = Quaternion.Euler(6, 0, 0);
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
    public void ResetUltShake()
    {
        StopCoroutine("UltShake");
        
    }
    public void UltOnShakeCamera(float ultShakeTime = 0.02f, float ultShakeIntensity = 0.05f)
    {
        this.ultShakeTime = ultShakeTime;
        this.ultShakeIntensity = ultShakeIntensity;

        StopCoroutine("UltShake");
        StartCoroutine("UltShake");
    }
    public IEnumerator UltShake()
    {
        Vector3 startPosition = transform.position;
        yield return new WaitForSecondsRealtime(0.5f);
        while (ultShakeTime > 0.0f)
        {
            transform.position = startPosition + Random.insideUnitSphere * ultShakeIntensity;

            ultShakeTime -= Time.deltaTime;
            yield return null;
        }
        transform.position = startPosition;
    }
    

}
