using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour {

    public Text Text;

	void Update ()
    {
        if (Input.anyKeyDown)
        {
            StartCoroutine(load());
        }
	}

    IEnumerator load()
    {
        Text.text = "Prepare yourself!";
        yield return new WaitForSeconds(3);
        Application.LoadLevel("Level1");
    }
}
