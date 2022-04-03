using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JK_BonusSkill : MonoBehaviour
{
    // 스킬 리스트
    public List<GameObject> allSkillList = new List<GameObject>();
    public List<GameObject> selectedSkillList = new List<GameObject>();
    // 카드 3개의 위치
    Vector3[] position = new Vector3[3];
    
    // Start is called before the first frame update
    void Start()
    {   
        // 카드 3개 위치 할당
        position[0] = new Vector3(-200, 0, 0);
        position[1] = new Vector3(0, 0, 0);
        position[2] = new Vector3(200, 0, 0);

        // 스킬, 상태 카드는 랜덤으로 3개가 나옴
        for (int i = 0; i < 3; i++)
        {
            // random에 0부터 스킬 갯수만큼 랜덤 숫자를 넣음
            int random = Random.Range(0, allSkillList.Count);
            // 나온 랜덤 숫자에 해당하는 스킬을 킴
            allSkillList[random].SetActive(true);
            // 해당 스킬의 위치를 position[i]의 위치로 변경
            allSkillList[random].transform.localPosition = position[i];
            // 해당 스킬을 선택된 리스트 목록에 넣음
            selectedSkillList.Add(allSkillList[random]);
            // 전체 스킬 리스트에서 삭제(삭제를 안 하면 중복이 나올 수 있음 / 스킬 선택이 끝나면 선택했던 스킬 다시 넣어야 함)
            allSkillList.RemoveAt(random);
        }
    }

    // 스킬을 클릭하면 발동될 함수
    public void OnClickAssignBonus()
    {
        for (int i = selectedSkillList.Count-1; i >= 0; i--)
        {
            // 선택된 스킬들을 넣어두었던 리스트에서 마지막에 위치한(selecttedSkillList.Count) 스킬을 전체 리스트에 넣음.
            allSkillList.Add(selectedSkillList[i]);
            // 그리고 첫번째 스킬 삭제 / 0번째 스킬이 삭제되면 다음 스킬이 0번째 스킬이 되기 때문에 RemoveAt(0)을 사용
            selectedSkillList.RemoveAt(i);
        }
        JK_BonusRoom.instance.didYouGetBonus = true;
        gameObject.SetActive(false);
        
    }
}
