using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
    public bool Pause = false;
    public int CurrentStage = 1;

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
