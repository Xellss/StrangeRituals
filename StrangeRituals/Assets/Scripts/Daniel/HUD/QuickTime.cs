using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class QuickTime : MonoBehaviour
{

    public Transform QuickTimeOne;
    public Transform QuickTimeTwo;
    public Transform QuickTimeThree;
    public Transform ActivateQuickTimeEvent;
    public GameObject ChristmasTree;
    public GameObject Spawner;
    

    private Animator QuickTimeOneA;
    private Animator QuickTimeTwoA;
    private Animator QuickTimeThreeA;
    private PlayerItems playerItems;
    private EnemySpawner enemySpawner;

    private Transform left;
    private Transform right;
    private Transform up;
    private Transform down;
    private Transform a;
    private Transform x;
    private Transform y;
    private Transform b;

    public bool canActivateQuickTime = false;
    private bool checkQuickTimeOne = false;
    private bool checkQuickTimeTwo = false;
    private bool checkQuickTimeThree = false;
    private bool closeQuickTime = false;

    public bool WinGame = false;
    public bool WinEventOne = false;
    public bool WinEventTwo = false;
    public bool WinEventThree = false;
    public bool end = false;

    private bool eventStarter = false;
    private bool key1 = false;
    private bool key2 = false;
    private bool key3 = false;
    private bool key4 = false;
    private bool key5 = false;
    private bool key6 = false;
    private bool key7 = false;
    private bool key8 = false;

    

    private float h;
    private float v;


    void Awake()
    {
        QuickTimeOneA = QuickTimeOne.GetComponent<Animator>();
        QuickTimeTwoA = QuickTimeTwo.GetComponent<Animator>();
        QuickTimeThreeA = QuickTimeThree.GetComponent<Animator>();

        enemySpawner = Spawner.GetComponent<EnemySpawner>();
        playerItems = GetComponent<PlayerItems>();
    }

    void Update()
    {
        if (!WinGame && !end)
        {
            activateQuickTime();
            CheckStop();
        }
        if (WinGame && !end)
        {
            winGame();
            end = true;
        }

    }

    void winGame()
    {
        print("WINWINWIN");
        ChristmasTree.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ritual" && !end && playerItems.HasItem1 || playerItems.HasItem2 || playerItems.HasItem3)
        {
            ActivateQuickTimeEvent.gameObject.SetActive(true);
            canActivateQuickTime = true;
            closeQuickTime = false;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Ritual" && !end)
        {
            ActivateQuickTimeEvent.gameObject.SetActive(false);
            canActivateQuickTime = false;
            closeQuickTime = true;
            eventStarter = false;
        }
    }

    void activateQuickTime()
    {
        if (Input.GetButtonDown("StartQuickTime") && canActivateQuickTime)
        {
            if (!checkQuickTimeOne && playerItems.HasItem1)
            {
                ActivateQuickTimeEvent.gameObject.SetActive(false);
                StartCoroutine(waitForFail(QuickTimeOne,5));
                StartEventOne();
            }

            if (checkQuickTimeOne && !checkQuickTimeTwo && playerItems.HasItem2)
            {
                StartCoroutine(waitForFail(QuickTimeTwo,10));
                ActivateQuickTimeEvent.gameObject.SetActive(false);
                StartEventTwo();

            }
            if (checkQuickTimeOne && checkQuickTimeTwo && !checkQuickTimeThree && playerItems.HasItem3)
            {
                StartCoroutine(waitForFail(QuickTimeThree, 15));
                ActivateQuickTimeEvent.gameObject.SetActive(false);
                StartEventThree();
            }
            eventStarter = true;
        }
    }

    private void StartEventOne()
    {
        if (!WinEventOne)
        {
            QuickTimeOne.gameObject.SetActive(true);
        }
    }
    private void StartEventTwo()
    {
        QuickTimeTwo.gameObject.SetActive(true);
    }
    private void StartEventThree()
    {
        QuickTimeThree.gameObject.SetActive(true);
    }
    private void CheckStop()
    {
        if (!WinEventOne)
        {
            StopEventOne();
        }
        if (!WinEventTwo)
        {
            StopEventTwo();
        }
        if (!WinEventThree)
        {
            StopEventThree();
        }
    }
    private void StopEventOne()
    {

        h = Input.GetAxis("Left");
        v = Input.GetAxis("Up");


        if (closeQuickTime && !WinEventOne && !WinGame)
        {
            QuickTimeOne.gameObject.SetActive(false);
        }

        if (!WinEventOne && eventStarter && !WinGame)
        {
            left = QuickTimeOne.FindChild("Left");
            right = QuickTimeOne.FindChild("Right");
            up = QuickTimeOne.FindChild("Up");
            down = QuickTimeOne.FindChild("Down");



            if (h < 0 && !key1)
            {
                key1 = true;
                left.gameObject.SetActive(false);
            }
            else if (h > 0 && key1 && !key2)
            {
                key2 = true;
                right.gameObject.SetActive(false);

            }
            else if (v == 1 && key2 && !key3)
            {
                key3 = true;
                up.gameObject.SetActive(false);

            }
            else if (v == -1 && key3 && !key4)
            {
                down.gameObject.SetActive(false);


                WinEventOne = true;
                checkQuickTimeOne = true;
                key1 = false;
                key2 = false;
                key3 = false;
                QuickTimeOneA.Play("QuickTimeComplete");
                StopAllCoroutines();
                StartCoroutine(waitForDestroy(QuickTimeOne.gameObject));
                playerItems.HasItem1 = false;
                playerItems.Item2.SetActive(true);

                enemySpawner.StartSpawning = true;
                //enemySpawner.StartSpawning = false;


                playerItems.lookAtPentagram = false;
                playerItems.lookAtItem2 = true;

            }





        }

    }
    private void StopEventTwo()
    {
        h = Input.GetAxis("Left");
        v = Input.GetAxis("Up");


        if (closeQuickTime && !WinEventTwo && WinEventOne && !WinGame)
        {
            QuickTimeOne.gameObject.SetActive(false);
        }

        if (!WinEventTwo && eventStarter && WinEventOne && !WinGame)
        {
            left = QuickTimeTwo.FindChild("Left");
            //right = QuickTimeTwo.FindChild("Right");
            up = QuickTimeTwo.FindChild("Up");
            down = QuickTimeTwo.FindChild("Down");

            a = QuickTimeTwo.FindChild("A");
            //b = QuickTimeTwo.FindChild("B");
            y = QuickTimeTwo.FindChild("Y");
            x = QuickTimeTwo.FindChild("X");



            if (Input.GetButtonDown("Y") && !key1)
            {
                key1 = true;
                y.gameObject.SetActive(false);
            }
            else if (Input.GetButtonDown("X") && key1 && !key2)
            {
                key2 = true;
                x.gameObject.SetActive(false);

            }
            else if (h == -1 && key2 && !key3)
            {
                key3 = true;
                left.gameObject.SetActive(false);

            }
            else if (Input.GetButtonDown("A") && key3 && !key4)
            {
                key4 = true;
                a.gameObject.SetActive(false);
            }
            else if (v == 1 && key4 && !key5)
            {
                key5 = true;
                up.gameObject.SetActive(false);

            }
            else if (v == -1 && key5 && !key6)
            {
                down.gameObject.SetActive(false);

                WinEventTwo = true;
                checkQuickTimeTwo = true;
                key1 = false;
                key2 = false;
                key3 = false;
                key4 = false;
                key5 = false;
                QuickTimeTwoA.Play("QuickTimeComplete");
                StopAllCoroutines();
                StartCoroutine(waitForDestroy(QuickTimeTwo.gameObject));
                playerItems.HasItem2 = false;
                playerItems.Item3.SetActive(true);

                enemySpawner.StartSpawning = true;
                //enemySpawner.StartSpawning = false;

                playerItems.lookAtPentagram = false;
                playerItems.lookAtItem3 = true;
            }





        }
    }
    private void StopEventThree()
    {
        h = Input.GetAxis("Left");
        v = Input.GetAxis("Up");


        if (closeQuickTime && !WinEventThree && WinEventOne && WinEventTwo && !WinGame)
        {
            QuickTimeOne.gameObject.SetActive(false);
        }

        if (!WinEventThree && eventStarter && WinEventOne && WinEventTwo && !WinGame)
        {
            left = QuickTimeThree.FindChild("Left");
            right = QuickTimeThree.FindChild("Right");
            up = QuickTimeThree.FindChild("Up");
            down = QuickTimeThree.FindChild("Down");

            a = QuickTimeThree.FindChild("A");
            b = QuickTimeThree.FindChild("B");
            y = QuickTimeThree.FindChild("Y");
            x = QuickTimeThree.FindChild("X");



            if (v == 1 && !key1)
            {
                key1 = true;
                up.gameObject.SetActive(false);
            }
            else if (v == -1 && key1 && !key2)
            {
                key2 = true;
                down.gameObject.SetActive(false);

            }
            else if (h == -1 && key2 && !key3)
            {
                key3 = true;
                left.gameObject.SetActive(false);

            }
            else if (h == 1 && key3 && !key4)
            {
                key4 = true;
                right.gameObject.SetActive(false);
            }
            else if (Input.GetButtonDown("A") && key4 && !key5)
            {
                key5 = true;
                a.gameObject.SetActive(false);

            }
            else if (Input.GetButtonDown("B") && key5 && !key6)
            {
                key6 = true;
                b.gameObject.SetActive(false);

            }
            else if (Input.GetButtonDown("Y") && key6 && !key7)
            {
                key7 = true;
                y.gameObject.SetActive(false);

            }
            else if (Input.GetButtonDown("X") && key7 && !key8)
            {
                x.gameObject.SetActive(false);

                WinEventThree = true;
                checkQuickTimeThree = true;
                WinGame = true;
                key1 = false;
                key2 = false;
                key3 = false;
                key4 = false;
                key5 = false;
                key6 = false;
                key7 = false;
                QuickTimeThreeA.Play("QuickTimeComplete");
                StopAllCoroutines();
                StartCoroutine(waitForDestroy(QuickTimeThree.gameObject));
                playerItems.HasItem3 = false;
                //playerItems.lookAtPentagram = false;
                playerItems.NaviRenderer.enabled = false;



            }
        }
    }

    IEnumerator waitForDestroy(GameObject eventObject )
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(eventObject);
    }
    IEnumerator waitForDisable(GameObject eventObject)
    {
        yield return new WaitForSeconds(0.3f);
        key1 = false;
        key2 = false;
        key3 = false;
        QuickTimeOneA.Play("QuickTimeStandart");

        StartCoroutine(pla(eventObject));

        if (!WinEventOne)
        {
            left.gameObject.SetActive(true);
            right.gameObject.SetActive(true);
            up.gameObject.SetActive(true);
            down.gameObject.SetActive(true);
            //Image i = QuickTimeOne.GetComponent<Image>();



        }
        //if (winEventOne && !winEventTwo)
        //if (winEventOne && winEventTwo && !winEventThree)
    }
    IEnumerator pla(GameObject eventObject)
    {
        yield return new WaitForSeconds(0.6f);
        eventObject.SetActive(false);


    }
    IEnumerator waitForFail(Transform quickTime, float time)
    {
        yield return new WaitForSeconds(time);

        if (!WinEventOne)
        {
            QuickTimeOneA.Play("QuickTimeFale");
            left.gameObject.SetActive(true);
            right.gameObject.SetActive(true);
            up.gameObject.SetActive(true);
            down.gameObject.SetActive(true);

        }
        if (WinEventOne && !WinEventTwo)
            QuickTimeTwoA.Play("QuickTimeFale");
        if (WinEventOne && WinEventTwo && !WinEventThree)
            QuickTimeThreeA.Play("QuickTimeFale");

        StartCoroutine(waitForDisable(quickTime.gameObject));
        StartCoroutine(showButto());

    }
    IEnumerator showButto()
    {
        yield return new WaitForSeconds(1.2f);
        if (!WinEventThree)
        {
            ActivateQuickTimeEvent.gameObject.SetActive(true);
            canActivateQuickTime = true;
            closeQuickTime = false;
        }
        
    }

}
