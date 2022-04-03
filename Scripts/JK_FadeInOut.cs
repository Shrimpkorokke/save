using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JK_FadeInOut : MonoBehaviour
{
    [SerializeField]
    [Range(0.01f, 10f)]
    private float fadeTime; // 값이 10이면 1초 (값이 클수록 빠름)
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
            // fadeTime으로 나누어서 fadeTime 시간 동안
            //percent 값이 0에서 1로 증가하도록 함
            currentTime += Time.deltaTime;
            percent = currentTime / fadeTime;

            //알파값을 start부터 end까지 fadeTime 시간 동안 뱐화시킨다
            Color color = image.color;
            color.a = Mathf.Lerp(start, end, percent);
            image.color = color;

            yield return null;
        }
    }
}
