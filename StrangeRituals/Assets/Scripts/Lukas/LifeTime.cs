using UnityEngine;
using System.Collections;

public class LifeTime : MonoBehaviour 
{
    public float TimeToLive;

    void Awake()
    {
        StartCoroutine(Lifetimer());
    }

    IEnumerator Lifetimer()
    {
        yield return new WaitForSeconds(TimeToLive);
        Destroy(this.gameObject);
    }
}
