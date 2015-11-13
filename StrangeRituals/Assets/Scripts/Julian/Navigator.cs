using UnityEngine;
using System.Collections;

public class Navigator : MonoBehaviour
{
    public Transform Item1;
    public Transform Item2;
    public Transform Item3;
    public Transform Pentagram;

    public GameObject Player;

    private PlayerItems playersItems;

    void Awake()
    {
        playersItems = Player.GetComponent<PlayerItems>();
    }

    void Update()
    {
        if (playersItems.lookAtPentagram)
        {
            transform.LookAt(Pentagram);
        }
        if (playersItems.lookAtItem1)
        {
            transform.LookAt(Item1);
        }
        if (playersItems.lookAtItem2)
        {
            transform.LookAt(Item2);
        }
        if (playersItems.lookAtItem3)
        {
            transform.LookAt(Item3);
        }
    }
}