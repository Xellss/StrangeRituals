using UnityEngine;
using System.Collections;

public class PlayerItems : MonoBehaviour
{

    bool hasItem1 = false;
    bool hasItem2 = false;
    bool hasItem3 = false;

    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;

    [HideInInspector]
    public bool lookAtItem1 = false;
    [HideInInspector]
    public bool lookAtItem2 = false;
    [HideInInspector]
    public bool lookAtItem3 = false;
    [HideInInspector]
    public bool lookAtPentagram = false;

    private GameManager gameManagerObject;

    void Awake()
    {
        GameObject gameManagergameObject = GameObject.Find("Gamemanager");
        gameManagerObject = gameManagergameObject.GetComponent<GameManager>();
    }
    void Start()
    {
        lookAtItem1 = true;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Item1")  // look at pent
        {
            hasItem1 = true;
            Item1.SetActive(false);
            Destroy(other.gameObject);
            lookAtItem1 = false;
            lookAtPentagram = true;
        }
        if (other.gameObject.tag == "Ritual" && hasItem1) // look at obj 2
        {
            hasItem1 = false;
            Item2.SetActive(true);
            gameManagerObject.Level_1 = true;
            lookAtPentagram = false;
            lookAtItem2 = true;
        }
        if (other.gameObject.name == "Item2")  // look at pent
        {
            hasItem2 = true;
            Destroy(other.gameObject);
            gameManagerObject.Level_1 = false;
            lookAtPentagram = true;
            lookAtItem2 = false;
        }
        if (other.gameObject.tag == "Ritual" && hasItem2) // look at obj 3
        {
            hasItem2 = false;
            Item3.SetActive(true);
            gameManagerObject.Level_2 = true;
            lookAtPentagram = false;
            lookAtItem3 = true;
        }
        if (other.gameObject.name == "Item3")  // look at pent
        {
            hasItem3 = true;
            Destroy(other.gameObject);
            gameManagerObject.Level_2 = false;
            lookAtPentagram = true;
            lookAtItem3 = false;
        }
        if (other.gameObject.tag == "Ritual" && hasItem3) // Don´t look
        {
            hasItem3 = false;
            gameManagerObject.Level_3 = true;
            lookAtPentagram = false;
            lookAtItem3 = false;
        }
    }
}
