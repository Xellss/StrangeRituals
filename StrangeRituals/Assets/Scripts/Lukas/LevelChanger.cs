using UnityEngine;
using System.Collections;

public class LevelChanger : MonoBehaviour
{
    public int LevelIndexToChangeTo;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Application.LoadLevel(LevelIndexToChangeTo);
        }
    }
}
