using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagers : MonoBehaviour
{
    public Image SceneFadeImage;
    public GameObject SceneFadeObject;

    public float FadeDuration = 1f;

    private IEnumerator Start()
    {
        yield return FadeIn(FadeDuration);
    }

    public IEnumerator FadeIn(float duration)
    {
        Color startC = new Color(SceneFadeImage.color.r, SceneFadeImage.color.g, SceneFadeImage.color.b, 1);
        Color targetC = new Color(SceneFadeImage.color.r, SceneFadeImage.color.g, SceneFadeImage.color.b, 0);

        yield return Fade(startC, targetC, duration);

        SceneFadeObject.SetActive(false);
    }

    public IEnumerator FadeOut(float duration)
    {
        Color startC = new Color(SceneFadeImage.color.r, SceneFadeImage.color.g, SceneFadeImage.color.b, 0);
        Color targetC = new Color(SceneFadeImage.color.r, SceneFadeImage.color.g, SceneFadeImage.color.b, 1);

        SceneFadeObject.SetActive(true);

        yield return Fade(startC, targetC, duration);

    }

    private IEnumerator Fade(Color startC, Color targetC, float duration)
    {
        float timepass = 0;
        float percentage = 0;

        while (percentage < 1)
        {
            percentage = timepass / duration;
            SceneFadeImage.color = Color.Lerp(startC, targetC, percentage);

            yield return null;
            timepass += Time.deltaTime;
        }
    }
}
