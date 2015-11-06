using UnityEngine;
using System.Collections;

public class LevelSwitch : MonoBehaviour {

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "LevelSwitch")
        {
            Application.LoadLevel("LvL2");
        }
    }
}
