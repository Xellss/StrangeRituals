using UnityEngine;
using System.Collections;

public class QuickTimeKeyboard : MonoBehaviour {

    public Transform QuickTimeOne;
    public Transform QuickTimeTwo;
    public Transform QuickTimeThree;
    public Transform ActivateQuickTimeEvent;
    public GameObject ChristmasTree;
    public GameObject Spawner;
    public GameManager GameManager;


    private Animator QuickTimeOneA;
    private Animator QuickTimeTwoA;
    private Animator QuickTimeThreeA;
    private PlayerItems playerItems;
    private EnemySpawner enemySpawner;
    private CaracterController characterController;

    private Transform left;
    private Transform right;
    private Transform up;
    private Transform down;
    private Transform k1;
    private Transform k3;
    private Transform k4;
    private Transform k2;

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

    void Awake()
    {
        QuickTimeOneA = QuickTimeOne.GetComponent<Animator>();
        QuickTimeTwoA = QuickTimeTwo.GetComponent<Animator>();
        QuickTimeThreeA = QuickTimeThree.GetComponent<Animator>();

        enemySpawner = Spawner.GetComponent<EnemySpawner>();
        playerItems = GetComponent<PlayerItems>();
        characterController = GetComponent<CaracterController>();
    }

    void Update()
    {
        if (!characterController.UseJoyStick)
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
    }

    void winGame()
    {
        print("WINWINWIN");
        ChristmasTree.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if ((other.gameObject.tag == "Ritual" && !characterController.UseJoyStick && !end) && playerItems.HasItem1 || (!characterController.UseJoyStick && playerItems.HasItem2) || (!characterController.UseJoyStick&& playerItems.HasItem3))
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
        if (Input.GetButtonDown("StartQuickTimeK") && canActivateQuickTime && !GameManager.Pause)
        {
            if (!checkQuickTimeOne && playerItems.HasItem1)
            {
                ActivateQuickTimeEvent.gameObject.SetActive(false);
                StartCoroutine(waitForFail(QuickTimeOne, 3));
                StartEventOne();
            }

            if (checkQuickTimeOne && !checkQuickTimeTwo && playerItems.HasItem2)
            {
                StartCoroutine(waitForFail(QuickTimeTwo, 4));
                ActivateQuickTimeEvent.gameObject.SetActive(false);
                StartEventTwo();

            }
            if (checkQuickTimeOne && checkQuickTimeTwo && !checkQuickTimeThree && playerItems.HasItem3)
            {
                StartCoroutine(waitForFail(QuickTimeThree, 5));
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
        if (!WinEventOne && !GameManager.Pause)
        {
            left = QuickTimeOne.FindChild("Left");
            right = QuickTimeOne.FindChild("Right");
            up = QuickTimeOne.FindChild("Up");
            down = QuickTimeOne.FindChild("Down");
            StopEventOne();
        }
        if (!WinEventTwo && !GameManager.Pause)
        {
            StopEventTwo();
        }
        if (!WinEventThree && !GameManager.Pause)
        {
            StopEventThree();
        }
    }
    private void StopEventOne()
    {

        if (closeQuickTime && !WinEventOne && !WinGame)
        {
            QuickTimeOne.gameObject.SetActive(false);
            StopAllCoroutines();
            left.gameObject.SetActive(true);
            right.gameObject.SetActive(true);
            up.gameObject.SetActive(true);
            down.gameObject.SetActive(true);
        }

        if (!WinEventOne && eventStarter && !WinGame)
        {
            left = QuickTimeOne.FindChild("Left");
            right = QuickTimeOne.FindChild("Right");
            up = QuickTimeOne.FindChild("Up");
            down = QuickTimeOne.FindChild("Down");



            if (Input.GetButtonDown("LeftK") && !key1)
            {
                key1 = true;
                left.gameObject.SetActive(false);
            }
            else if (Input.GetButtonDown("RightK") && key1 && !key2)
            {
                key2 = true;
                right.gameObject.SetActive(false);

            }
            else if (Input.GetButtonDown("UpK") && key2 && !key3)
            {
                key3 = true;
                up.gameObject.SetActive(false);

            }
            else if (Input.GetButtonDown("DownK") && key3 && !key4)
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
        if (closeQuickTime && !WinEventTwo && WinEventOne && !WinGame)
        {
            QuickTimeTwo.gameObject.SetActive(false);
            StopAllCoroutines();
            k4.gameObject.SetActive(true);
            k3.gameObject.SetActive(true);
            left.gameObject.SetActive(true);
            k1.gameObject.SetActive(true);
            up.gameObject.SetActive(true);
            down.gameObject.SetActive(true);
        }

        if (!WinEventTwo && eventStarter && WinEventOne && !WinGame)
        {
            left = QuickTimeTwo.FindChild("Left");
            //right = QuickTimeTwo.FindChild("Right");
            up = QuickTimeTwo.FindChild("Up");
            down = QuickTimeTwo.FindChild("Down");

            k1 = QuickTimeTwo.FindChild("1");
            //k2 = QuickTimeTwo.FindChild("2");
            k4 = QuickTimeTwo.FindChild("4");
            k3 = QuickTimeTwo.FindChild("3");



            if (Input.GetButtonDown("4") && !key1)
            {
                key1 = true;
                k4.gameObject.SetActive(false);
            }
            else if (Input.GetButtonDown("3") && key1 && !key2)
            {
                key2 = true;
                k3.gameObject.SetActive(false);

            }
            else if (Input.GetButtonDown("LeftK") && key2 && !key3)
            {
                key3 = true;
                left.gameObject.SetActive(false);

            }
            else if (Input.GetButtonDown("1") && key3 && !key4)
            {
                key4 = true;
                k1.gameObject.SetActive(false);
            }
            else if (Input.GetButtonDown("UpK") && key4 && !key5)
            {
                key5 = true;
                up.gameObject.SetActive(false);

            }
            else if (Input.GetButtonDown("DownK") && key5 && !key6)
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

                //enemySpawner.StartSpawning = true;
                //enemySpawner.StartSpawning = false;

                playerItems.lookAtPentagram = false;
                playerItems.lookAtItem3 = true;
            }





        }
    }
    private void StopEventThree()
    {

        if (closeQuickTime && !WinEventThree && WinEventOne && WinEventTwo && !WinGame)
        {
            QuickTimeThree.gameObject.SetActive(false);
            StopAllCoroutines();
            up.gameObject.SetActive(true);
            down.gameObject.SetActive(true);
            left.gameObject.SetActive(true);
            right.gameObject.SetActive(true);
            k1.gameObject.SetActive(true);
            k2.gameObject.SetActive(true);
            k4.gameObject.SetActive(true);
            k3.gameObject.SetActive(true);
        }

        if (!WinEventThree && eventStarter && WinEventOne && WinEventTwo && !WinGame)
        {
            left = QuickTimeThree.FindChild("Left");
            right = QuickTimeThree.FindChild("Right");
            up = QuickTimeThree.FindChild("Up");
            down = QuickTimeThree.FindChild("Down");

            k1 = QuickTimeThree.FindChild("1");
            k2 = QuickTimeThree.FindChild("2");
            k4 = QuickTimeThree.FindChild("4");
            k3 = QuickTimeThree.FindChild("3");


            if (Input.GetButtonDown("UpK") && !key1)
            {
                key1 = true;
                up.gameObject.SetActive(false);
            }
            else if (Input.GetButtonDown("DownK") && key1 && !key2)
            {
                key2 = true;
                down.gameObject.SetActive(false);

            }
            else if (Input.GetButtonDown("LeftK") && key2 && !key3)
            {
                key3 = true;
                left.gameObject.SetActive(false);

            }
            else if (Input.GetButtonDown("RightK") && key3 && !key4)
            {
                key4 = true;
                right.gameObject.SetActive(false);
            }
            else if (Input.GetButtonDown("1") && key4 && !key5)
            {
                key5 = true;
                k1.gameObject.SetActive(false);

            }
            else if (Input.GetButtonDown("2") && key5 && !key6)
            {
                key6 = true;
                k2.gameObject.SetActive(false);

            }
            else if (Input.GetButtonDown("4") && key6 && !key7)
            {
                key7 = true;
                k4.gameObject.SetActive(false);

            }
            else if (Input.GetButtonDown("3") && key7 && !key8)
            {
                k3.gameObject.SetActive(false);

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

    IEnumerator waitForDestroy(GameObject eventObject)
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
        }
        if (WinEventOne && !WinEventTwo)
        {
            k4.gameObject.SetActive(true);
            k3.gameObject.SetActive(true);
            left.gameObject.SetActive(true);
            k1.gameObject.SetActive(true);
            up.gameObject.SetActive(true);
            down.gameObject.SetActive(true);
        }
        if (WinEventOne && WinEventTwo && !WinEventThree)
        {
            up.gameObject.SetActive(true);
            down.gameObject.SetActive(true);
            left.gameObject.SetActive(true);
            right.gameObject.SetActive(true);
            k1.gameObject.SetActive(true);
            k2.gameObject.SetActive(true);
            k4.gameObject.SetActive(true);
            k3.gameObject.SetActive(true);
        }
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
        {
            QuickTimeTwoA.Play("QuickTimeFale");
            k4.gameObject.SetActive(true);
            k3.gameObject.SetActive(true);
            left.gameObject.SetActive(true);
            k1.gameObject.SetActive(true);
            up.gameObject.SetActive(true);
            down.gameObject.SetActive(true);
        }
        if (WinEventOne && WinEventTwo && !WinEventThree)
        {
            QuickTimeThreeA.Play("QuickTimeFale");
            up.gameObject.SetActive(true);
            down.gameObject.SetActive(true);
            left.gameObject.SetActive(true);
            right.gameObject.SetActive(true);
            k1.gameObject.SetActive(true);
            k2.gameObject.SetActive(true);
            k4.gameObject.SetActive(true);
            k3.gameObject.SetActive(true);
        }

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
