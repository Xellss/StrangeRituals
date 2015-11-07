using UnityEngine;
using System.Collections;

public class TextureFadeOut : MonoBehaviour 
{
    public int SecToStartFading;
    public int FadeOutSteps = 10;
    public float TimeToFadeOut = 10f;
    public bool DeleteOnOutFaded = true;

    private Material myMaterial;

    void Awake()
    {
        myMaterial = GetComponent <Material>();
        StartCoroutine(StartTimer());
    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(SecToStartFading);
        StartCoroutine(FadeOutTimer());
    }

    IEnumerator FadeOutTimer()
    {
        yield return new WaitForSeconds(TimeToFadeOut / FadeOutSteps);

        Color tempColor = myMaterial.color;
        tempColor.a -= (float)1 / FadeOutSteps;
        myMaterial.color = tempColor;

        StartCoroutine(FadeOutTimer());
    }

    IEnumerator DeleteTimer()
    {
        yield return new WaitForSeconds(SecToStartFading + TimeToFadeOut);
        Destroy(this.gameObject);
    }
}
