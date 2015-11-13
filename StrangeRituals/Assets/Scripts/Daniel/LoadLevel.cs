using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour {

    public Text text;

	void Update ()
    {
        if (Input.anyKeyDown)
        {
            StartCoroutine(load());
        }	
	}

    IEnumerator load()
    {
        text.text = "Prepare yourself!";
        yield return new WaitForSeconds(3);
        Application.LoadLevel("Level1");
    }
}
