using UnityEngine;
using System.Collections;

public class PlayerItems : MonoBehaviour
{
    public bool HasItem1 = false;
    public bool HasItem2 = false;
    public bool HasItem3 = false;

    public bool SpawnWave1 = false;
    public bool SpawnWave2 = false;
    public bool SpawnWave3 = false;

    public GameObject Item1;
    public GameObject Item2;
    public GameObject Item3;
    public GameObject Navi;

    [HideInInspector]
    public bool lookAtItem1 = false;
    [HideInInspector]
    public bool lookAtItem2 = false;
    [HideInInspector]
    public bool lookAtItem3 = false;
    [HideInInspector]
    public bool lookAtPentagram = false;

    private GameManager gameManagerObject;
    [HideInInspector]
    public MeshRenderer NaviRenderer;
    private QuickTime quickTime;

    void Awake()
    {
        GameObject gameManagergameObject = GameObject.Find("Gamemanager");
        gameManagerObject = gameManagergameObject.GetComponent<GameManager>();

        quickTime = GetComponent<QuickTime>();
        NaviRenderer = Navi.GetComponent<MeshRenderer>();
    }
    void Start()
    {
        lookAtItem1 = true;
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Item1")  // look at pent
        {
            HasItem1 = true;
            Item1.SetActive(false);
            Destroy(other.gameObject);
            lookAtItem1 = false;
            lookAtPentagram = true;
        }
        //if (other.gameObject.tag == "Ritual" && HasItem1) // look at obj 2
        //{
        //    SpawnWave1 = true;
        //    //HasItem1 = false;
        //    //Item2.SetActive(true);
        //    gameManagerObject.Level_1 = true;
        //    //lookAtPentagram = false;
        //    //lookAtItem2 = true;


        //}
        if (other.gameObject.name == "Item2")  // look at pent
        {
            HasItem2 = true;
            Destroy(other.gameObject);
            gameManagerObject.Level_1 = false;
            lookAtPentagram = true;
            lookAtItem2 = false;
        }
        //if (other.gameObject.tag == "Ritual" && HasItem2) // look at obj 3
        //{
        //    SpawnWave2 = true;
        //    //HasItem2 = false;
        //    //Item3.SetActive(true);
        //    gameManagerObject.Level_2 = true;
        //    //lookAtPentagram = false;
        //    //lookAtItem3 = true;

        //}
        if (other.gameObject.name == "Item3")  // look at pent
        {
            HasItem3 = true;
            Destroy(other.gameObject);
            gameManagerObject.Level_2 = false;
            lookAtPentagram = true;
            lookAtItem3 = false;
        }
        //if (other.gameObject.tag == "Ritual" && HasItem3) // Don´t look
        //{
        //    SpawnWave3 = true;
        //    //HasItem3 = false;
        //    gameManagerObject.Level_3 = true;
        //    lookAtPentagram = false;
        //    lookAtItem3 = false;
        //    naviRenderer.enabled = false;

        //}
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ritual" && HasItem1) // look at obj 2
        {
            SpawnWave1 = true;
            //HasItem1 = false;
            //Item2.SetActive(true);
            gameManagerObject.Level_1 = true;
            //lookAtPentagram = false;
            //lookAtItem2 = true;


        }


        if (other.gameObject.tag == "Ritual" && HasItem2) // look at obj 3
        {
            SpawnWave2 = true;
            //HasItem2 = false;
            //Item3.SetActive(true);
            gameManagerObject.Level_2 = true;
            //lookAtPentagram = false;
            //lookAtItem3 = true;

        }

        if (other.gameObject.tag == "Ritual" && HasItem3) // Don´t look
        {
            SpawnWave3 = true;
            //HasItem3 = false;
            gameManagerObject.Level_3 = true;
            //lookAtPentagram = false;
            //lookAtItem3 = false;
            //naviRenderer.enabled = false;

        }
    }
}
