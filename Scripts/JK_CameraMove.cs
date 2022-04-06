using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JK_CameraMove : MonoBehaviour
{
    public static JK_CameraMove instance;
    public Transform target; // 따라갈 대상 (Player)
    public Vector3 offset; // 플레이어로 부터 얼마만큼 떨어져서 갈지 정하는 벡터값
    public Vector3 offset2;

    public float shakeTime;
    public float shakeIntensity;

    public float ultShakeTime;
    public float ultShakeIntensity;
 
    public bool isBonusStage;
    
    /// <param name="ShakeTime> 카메라 흔들림 지속 시간(설정하지 않으면 default 1.0f)
    /// <param name="ShakeIntensity> 카메라 흔들림 세기 (값이 클수록 세게 흔들린다)(설정하지 않으면 default 0.1f)    
    private void Awake()
    {
        instance = this;
    }
    
    public Transform ultCamPosition;
    public bool isUltPosition = false;
    public bool duringMoveCam = false;

    public Transform firstStagePos;

    public Transform tar; // 가야할 위치, 회전할 목표
    public Transform lookTarget; // 바라볼 위치
    public void Start()
    {
        transform.position = target.position + offset;
    }
    void Update()
    {
        /*Vector3 targetPosition = target.transform.position;
        // lookTarget에서 target을 바라보고 부딪힌 것이 있다면
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
            // 그위치가 targetPosition을 그 위치로 하고 싶다.
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
    // 카메라를 shakeTime동안 shakeIntensity의 세기로 흔드는 코루틴 함수
    public IEnumerator ShakeByPosition()
    {
        Vector3 startPosition = transform.position;

        while (shakeTime > 0.0f)
        {
           
            //특정 축만 변경하길 원하면 아래 코드 이용 (이동하지 않을 축은 0 값만 사용)
            //float x = Random.Range(-1f, 1f);
            //float y = Random.Range(-1f, 1f);
            //float z = Random.Range(-1f, 1f);
            //transform.position = startPosition + new Vector3(x, y, z) * shakeIntensity;

            // 초기 위치로부터  구 범위(Size 1) * shakeIntensity의 범위 안에서 카메라 위치 이동
            transform.position = startPosition + Random.insideUnitSphere * shakeIntensity;

            // 시간 감소
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
