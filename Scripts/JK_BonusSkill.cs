using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JK_BonusSkill : MonoBehaviour
{
    // ��ų ����Ʈ
    public List<GameObject> allSkillList = new List<GameObject>();
    public List<GameObject> selectedSkillList = new List<GameObject>();
    // ī�� 3���� ��ġ
    Vector3[] position = new Vector3[3];
    
    // Start is called before the first frame update
    void Start()
    {   
        // ī�� 3�� ��ġ �Ҵ�
        position[0] = new Vector3(-200, 0, 0);
        position[1] = new Vector3(0, 0, 0);
        position[2] = new Vector3(200, 0, 0);

        // ��ų, ���� ī��� �������� 3���� ����
        for (int i = 0; i < 3; i++)
        {
            // random�� 0���� ��ų ������ŭ ���� ���ڸ� ����
            int random = Random.Range(0, allSkillList.Count);
            // ���� ���� ���ڿ� �ش��ϴ� ��ų�� Ŵ
            allSkillList[random].SetActive(true);
            // �ش� ��ų�� ��ġ�� position[i]�� ��ġ�� ����
            allSkillList[random].transform.localPosition = position[i];
            // �ش� ��ų�� ���õ� ����Ʈ ��Ͽ� ����
            selectedSkillList.Add(allSkillList[random]);
            // ��ü ��ų ����Ʈ���� ����(������ �� �ϸ� �ߺ��� ���� �� ���� / ��ų ������ ������ �����ߴ� ��ų �ٽ� �־�� ��)
            allSkillList.RemoveAt(random);
        }
    }

    // ��ų�� Ŭ���ϸ� �ߵ��� �Լ�
    public void OnClickAssignBonus()
    {
        for (int i = selectedSkillList.Count-1; i >= 0; i--)
        {
            // ���õ� ��ų���� �־�ξ��� ����Ʈ���� �������� ��ġ��(selecttedSkillList.Count) ��ų�� ��ü ����Ʈ�� ����.
            allSkillList.Add(selectedSkillList[i]);
            // �׸��� ù��° ��ų ���� / 0��° ��ų�� �����Ǹ� ���� ��ų�� 0��° ��ų�� �Ǳ� ������ RemoveAt(0)�� ���
            selectedSkillList.RemoveAt(i);
        }
        JK_BonusRoom.instance.didYouGetBonus = true;
        gameObject.SetActive(false);
        
    }
}
