using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JK_FadeInOut : MonoBehaviour
{
    [SerializeField]
    [Range(0.01f, 10f)]
    private float fadeTime; // ���� 10�̸� 1�� (���� Ŭ���� ����)
    private Image image;
    
    void Start()
    {
        image = GetComponent<Image>();
        
    }

    IEnumerator Fade(float start, float end)
    {
        float currentTime = 0.0f;
        float percent = 0.0f;

        while (percent < 1)
        {
            // fadeTime���� ����� fadeTime �ð� ����
            //percent ���� 0���� 1�� �����ϵ��� ��
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            //���İ��� start���� end���� fadeTime �ð� ���� ��ȭ��Ų��
            Color color = image.color;
            color.a = Mathf.Lerp(start, end, percent);
            image.color = color;

            yield return null;
        }
    }
}
