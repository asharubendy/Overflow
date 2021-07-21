using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{
    public static GameObject fadeUI;
    public static Image fadeImage;

    public CanvasGroup uiElement;
    public static bool newDay = false;

    void Start()
    {
        fadeImage = this.GetComponent<Image>();
    }

    private void Update()
    {
        if(newDay == true)
        {
            newDay = false;
            UIFadeIn();
        }
    }

    public void UIFadeIn()
    {
        Debug.Log("Step 2");
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 1));
        UIFadeOut();
    }

    public void UIFadeOut()
    {
        Debug.Log("Step 5");
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 0));
    }

    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 0.5f)
    {
        Debug.Log("Step 4");
        float timeStartedLerping = Time.time;
        float timeSinceStart = Time.time - timeStartedLerping;
        float percentageComplete = timeSinceStart / lerpTime;

        while (true)
        {
            timeSinceStart = Time.time - timeStartedLerping;
            percentageComplete = timeSinceStart / lerpTime;

            float currenvalue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currenvalue;

            if(percentageComplete >= 1)
            {
                break;
            }

            yield return new WaitForEndOfFrame();
        }

        print("Done");
    }
}
