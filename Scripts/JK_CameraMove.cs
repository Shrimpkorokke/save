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
    
    public Transform ultCamPosition;
    public bool isUltPosition = false;
    public bool duringMoveCam = false;

    public Transform firstStagePos;

    public Transform tar; // ������ ��ġ, ȸ���� ��ǥ
    public Transform lookTarget; // �ٶ� ��ġ
    public void Start()
    {
        transform.position = target.position + offset;
    }
    void Update()
    {
        /*Vector3 targetPosition = target.transform.position;
        // lookTarget���� target�� �ٶ󺸰� �ε��� ���� �ִٸ�
        Ray ray = new Ray(lookTarget.transform.position, target.transform.position - lookTarget.transform.position);
        RaycastHit hitInfo;*/

        if (false == JK_Player.instance.isInBonusRoom && !JK_Skills.instance.isUlt && !isUltPosition && !JK_Tutorial.instance.introduce)
        {
            transform.position = target.position + offset;
            transform.rotation = Quaternion.Euler(40, 0, 0);
        }
        else if(true == JK_Player.instance.isInBonusRoom)
        {
            transform.position = target.position + offset2;
            transform.rotation = Quaternion.Euler(6, 0, 0);
        }
        else if(JK_Skills.instance.isUlt && !isUltPosition)
        {
            transform.position = Vector3.Lerp(transform.position, ultCamPosition.transform.position, Time.deltaTime * 20);
            transform.rotation =  Quaternion.Lerp(transform.rotation, ultCamPosition.transform.rotation, Time.deltaTime * 5);
        }
        else if (JK_Tutorial.instance.introduce)
        {
            transform.position = Vector3.Lerp(transform.position, firstStagePos.transform.position, Time.deltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, firstStagePos.transform.rotation, Time.deltaTime);
        }
        /*else if (Physics.Raycast(ray, out hitInfo))
        {
            targetPosition = hitInfo.point;
            // ����ġ�� targetPosition�� �� ��ġ�� �ϰ� �ʹ�.
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10);
            transform.rotation = target.transform.rotation;
        }*/
        

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
