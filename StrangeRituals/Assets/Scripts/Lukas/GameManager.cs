using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    [Tooltip("Fire this To spawn an Extra Wave")]
    public bool SpawnExtraWave = false;

    public bool Pause = false;
    [Tooltip("Change this to change Ritual Level")]
    public int CurrentStage = 1;

    public bool Level_1;
    public bool Level_2;
    public bool Level_3;

    private bool canPress = true;

    void Update()
    {
        if (canPress)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                canPress = false;
                StartCoroutine(PauseTimer());
                if (Pause)
                    Pause = false;
                else
                    Pause = true;
            }
        }
    }

    IEnumerator PauseTimer()
    {
        yield return new WaitForSeconds(0.2f);
        canPress = true;
    }
}
