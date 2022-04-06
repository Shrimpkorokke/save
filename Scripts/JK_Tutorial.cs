using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class JK_Tutorial : MonoBehaviour
{
    public static JK_Tutorial instance;
    public bool duringTuto;
    public GameObject playerTalkingObj;
    public Text playerTalkingTxt;

    public GameObject enemyTalkingObj;
    public Text enemyTalkingTxt;
    public GameObject warpEffectPosition;
    public GameObject warpEffect;
    public bool introduce;

    private void Start()
    {
        duringTuto = true;
        instance = this;
        StartCoroutine("IETutorialTalking");
    }
    // ó�� �ð��� ���߰� 
    IEnumerator IETutorialTalking()
    {

        yield return new WaitForSeconds(1f);
        playerTalkingObj.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "��";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "���";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "����";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "���� ��";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "���� ����";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "���� ������";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "���� �����ߴ�";
        yield return new WaitForSeconds(1f);

        playerTalkingTxt.text = "��";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "�̰�";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "�̰�����";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "�̰����� ��";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "�̰����� ������";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "�̰����� ������ ��";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "�̰����� ������ ���";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "�̰����� ������ ��";
        yield return new WaitForSeconds(0.3f);

        playerTalkingTxt.text = "��";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "���";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "��Ӵ���";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "��Ӵ��� ��";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "��Ӵ��� ����";
        yield return new WaitForSeconds(0.2f);
        playerTalkingTxt.text = "��";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "����";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "���� ��";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "���� �ص�";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "���� �ص帮";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "���� �ص帮��";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "���� �ص帮�ھ�!";
        yield return new WaitForSeconds(1f);

        playerTalkingObj.SetActive(false);
        enemyTalkingObj.SetActive(true);

        yield return new WaitForSeconds(0.3f);
        enemyTalkingTxt.text = "ũ";
        yield return new WaitForSeconds(0.3f);
        enemyTalkingTxt.text = "ũ. ��";
        yield return new WaitForSeconds(0.3f);
        enemyTalkingTxt.text = "ũ. ��. ��";
        yield return new WaitForSeconds(0.3f);
        enemyTalkingTxt.text = "ũ. ��. ��. ��";
        yield return new WaitForSeconds(0.3f);

        playerTalkingObj.SetActive(true);
        playerTalkingTxt.text = "                ???    ";

        enemyTalkingTxt.text = "��";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "��û";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "��û��";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "��û�� ��";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "��û�� �༮";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "��û�� �༮��";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "��û�� �༮�� ��";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "��û�� �༮�� �� ��";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "��û�� �༮�� �� �Ա�!";
        yield return new WaitForSeconds(1f);

        enemyTalkingTxt.text = "��";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "�ϰ�";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "�ϰ� ��";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "�ϰ� ����";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "�ϰ� ���� ��";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "�ϰ� ���� ����";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "�ϰ� ���� ������";
        yield return new WaitForSeconds(0.3f);

        enemyTalkingTxt.text = "��";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "�� ��";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "�� ����";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "�� ���濡";
        playerTalkingTxt.text = "                !!!    ";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "�� ���濡 ��";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "�� ���濡 �ִ�";
        yield return new WaitForSeconds(1f);

        enemyTalkingTxt.text = "��";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "����";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "���� ã";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "���� ã��";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "���� ã����";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "���� ã���� ��";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "���� ã���� ����";
        enemyTalkingTxt.text = "���� ã���� ���� ��";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "���� ã���� ���� �ٶ�~";
        yield return new WaitForSeconds(0.5f);

        enemyTalkingTxt.text = "��";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "�� ��";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "�� �� ��";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "�� �� �ִ�";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "�� �� �ִٸ�";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "�� �� �ִٸ� ��";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "�� �� �ִٸ� ����";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "�� �� �ִٸ� ������";
        yield return new WaitForSeconds(0.5f);
        playerTalkingTxt.text = "              .....    ";
        enemyTalkingTxt.text = "ũ";
        yield return new WaitForSeconds(0.3f);
        enemyTalkingTxt.text = "ũ. ��";
        yield return new WaitForSeconds(0.3f);
        enemyTalkingTxt.text = "ũ. ��. ��";
        yield return new WaitForSeconds(0.3f);
        JK_CameraMove.instance.OnShakeCamera(1f, 0.08f);
        enemyTalkingTxt.text = "ũ. ��. ��. ��!";
        yield return new WaitForSeconds(1f);
        enemyTalkingObj.SetActive(false);
        playerTalkingTxt.text = "  ��    ";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "  �̽�    ";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "  �̽�½    ";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "  �̽�½��    ";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "  �̽�½�� ��    ";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "  �̽�½�� ����    ";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "  �̽�½�� ������    ";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = " ��    ";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = " ����    ";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = " ������.    ";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = " ������ ��    ";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = " ������ �� ��    ";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = " ������ �� ����...    ";
        yield return new WaitForSeconds(1f);

        playerTalkingObj.SetActive(false);

        
        
        StartCoroutine("IESecond");
        
    }
    IEnumerator IESecond()
    {
        GameObject obj = Instantiate(warpEffect);
        obj.transform.parent = warpEffectPosition.transform;
        obj.transform.position = warpEffectPosition.transform.position;
        yield return new WaitForSeconds(1f);
        JK_Player.instance.ani.Play("Walk");
        isWalk = true;
        yield return new WaitForSeconds(3f);
        isWalk = false;
        JK_Player.instance.ani.SetTrigger("FinishTuto");
    }
    public void StartIEThird()
    {
        StartCoroutine("IEThird"); 
    }
    IEnumerator IEThird()
    {
        playerTalkingObj.SetActive(true);
        playerTalkingTxt.text = "               �´�!";
        yield return new WaitForSeconds(0.6f);
        playerTalkingTxt.text = "               ����!";
        yield return new WaitForSeconds(0.8f);
        playerTalkingObj.SetActive(false);
    }

    public bool isWalk;
    private void Update()
    {
        if(isWalk == true)
        {
            JK_Player.instance.transform.position = Vector3.MoveTowards(JK_Player.instance.transform.position, warpEffectPosition.transform.position, Time.deltaTime * 3);
            
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            playerTalkingObj.SetActive(false);
            enemyTalkingObj.SetActive(false);
            StopCoroutine("IETutorialTalking");
            StartCoroutine("IESecond");
        }
    }
}
