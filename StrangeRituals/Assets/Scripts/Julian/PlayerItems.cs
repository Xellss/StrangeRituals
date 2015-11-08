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


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Item1")
        {
            hasItem1 = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Ritual" && hasItem1)
        {
            hasItem1 = false;
            Item2.SetActive(true);
        }
        if (other.gameObject.name == "Item2")
        {
            hasItem2 = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Ritual" && hasItem2)
        {
            hasItem2 = false;
            Item3.SetActive(true);
        }
        if (other.gameObject.name == "Item3")
        {
            hasItem3 = true;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Ritual" && hasItem3)
        {
            hasItem3 = false;
            Item3.SetActive(true);
        }
    }
}
