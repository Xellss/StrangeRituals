using UnityEngine;
using System.Collections;

public class RotateItems : MonoBehaviour {
    public float RotateSpeed = 5;
    private GameManager GameManagerObject;

    void Awake()
    {
        GameObject GamemanagerGameObject = GameObject.Find("Gamemanager");
        GameManagerObject = GamemanagerGameObject.GetComponent<GameManager>();
    }
	void Update()
    {
        if (!GameManagerObject.Pause)
        {
            transform.Rotate(0, RotateSpeed, 0, Space.Self);
        }
    }
}
