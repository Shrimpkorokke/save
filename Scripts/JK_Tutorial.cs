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
    // 처음 시간을 멈추고 
    IEnumerator IETutorialTalking()
    {

        yield return new WaitForSeconds(1f);
        playerTalkingObj.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "드";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "드디";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "드디어";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "드디어 도";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "드디어 도착";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "드디어 도착했";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "드디어 도착했다";
        yield return new WaitForSeconds(1f);

        playerTalkingTxt.text = "이";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "이곳";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "이곳에서";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "이곳에서 보";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "이곳에서 보물을";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "이곳에서 보물을 얻";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "이곳에서 보물을 얻어";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "이곳에서 보물을 얻어서";
        yield return new WaitForSeconds(0.3f);

        playerTalkingTxt.text = "어";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "어머";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "어머니의";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "어머니의 병";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "어머니의 병을";
        yield return new WaitForSeconds(0.2f);
        playerTalkingTxt.text = "낫";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "낫게";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "낫게 해";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "낫게 해드";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "낫게 해드리";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "낫게 해드리겠";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "낫게 해드리겠어!";
        yield return new WaitForSeconds(1f);

        playerTalkingObj.SetActive(false);
        enemyTalkingObj.SetActive(true);

        yield return new WaitForSeconds(0.3f);
        enemyTalkingTxt.text = "크";
        yield return new WaitForSeconds(0.3f);
        enemyTalkingTxt.text = "크. 하";
        yield return new WaitForSeconds(0.3f);
        enemyTalkingTxt.text = "크. 하. 하";
        yield return new WaitForSeconds(0.3f);
        enemyTalkingTxt.text = "크. 하. 하. 하";
        yield return new WaitForSeconds(0.3f);

        playerTalkingObj.SetActive(true);
        playerTalkingTxt.text = "                ???    ";

        enemyTalkingTxt.text = "멍";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "멍청";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "멍청한";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "멍청한 녀";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "멍청한 녀석";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "멍청한 녀석이";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "멍청한 녀석이 또";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "멍청한 녀석이 또 왔";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "멍청한 녀석이 또 왔군!";
        yield return new WaitForSeconds(1f);

        enemyTalkingTxt.text = "니";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "니가";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "니가 말";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "니가 말한";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "니가 말한 보";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "니가 말한 보물";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "니가 말한 보물은";
        yield return new WaitForSeconds(0.3f);

        enemyTalkingTxt.text = "맨";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "맨 끝";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "맨 끝방";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "맨 끝방에";
        playerTalkingTxt.text = "                !!!    ";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "맨 끝방에 있";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "맨 끝방에 있다";
        yield return new WaitForSeconds(1f);

        enemyTalkingTxt.text = "빨";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "빨리";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "빨리 찾";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "빨리 찾으";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "빨리 찾으러";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "빨리 찾으러 오";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "빨리 찾으러 오길";
        enemyTalkingTxt.text = "빨리 찾으러 오길 바";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "빨리 찾으러 오길 바라~";
        yield return new WaitForSeconds(0.5f);

        enemyTalkingTxt.text = "올";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "올 수";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "올 수 있";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "올 수 있다";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "올 수 있다면";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "올 수 있다면 말";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "올 수 있다면 말이";
        yield return new WaitForSeconds(0.1f);
        enemyTalkingTxt.text = "올 수 있다면 말이지";
        yield return new WaitForSeconds(0.5f);
        playerTalkingTxt.text = "              .....    ";
        enemyTalkingTxt.text = "크";
        yield return new WaitForSeconds(0.3f);
        enemyTalkingTxt.text = "크. 하";
        yield return new WaitForSeconds(0.3f);
        enemyTalkingTxt.text = "크. 하. 하";
        yield return new WaitForSeconds(0.3f);
        JK_CameraMove.instance.OnShakeCamera(1f, 0.08f);
        enemyTalkingTxt.text = "크. 하. 하. 하!";
        yield return new WaitForSeconds(1f);
        enemyTalkingObj.SetActive(false);
        playerTalkingTxt.text = "  미    ";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "  미심    ";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "  미심쩍    ";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "  미심쩍긴    ";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "  미심쩍긴 하    ";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "  미심쩍긴 하지    ";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = "  미심쩍긴 하지만    ";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = " 물    ";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = " 물러    ";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = " 물러설.    ";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = " 물러설 순    ";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = " 물러설 순 없    ";
        yield return new WaitForSeconds(0.1f);
        playerTalkingTxt.text = " 물러설 순 없어...    ";
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
        playerTalkingTxt.text = "               온다!";
        yield return new WaitForSeconds(0.6f);
        playerTalkingTxt.text = "               가자!";
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
