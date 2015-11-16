using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadLevel : MonoBehaviour {

    public Text Text;
    public GameManager Gamemanager;
    public GameObject Player;
    private CaracterController characterController;


    void Awake()
    {
        characterController = Player.GetComponent<CaracterController>();
    }
      
    public void OnClickKeyboard()
    {
        characterController.UseJoyStick = false;
    }
    public void OnClickXbox()
    {
        characterController.UseJoyStick = true;
    }

    void Update ()
    {
        if (Input.GetButtonDown("EnterGame"))
        {
            StartCoroutine(load());
        }
        else
        {
            Gamemanager.Pause = true;
        }
	}
    IEnumerator load()
    {
        Text.text = "Prepare yourself!";
        yield return new WaitForSeconds(3);
        //Application.LoadLevel("Level1");
        this.gameObject.SetActive(false);
        Gamemanager.Pause = false;
    }
}
