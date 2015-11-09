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

    private Animator QuickTimeOneA;
    private Animator QuickTimeTwoA;
    private Animator QuickTimeThreeA;

    Transform left;
    Transform right;
    Transform up;
    Transform down;

    Transform a;
    Transform x;
    Transform y;
    Transform b;

    public bool canActivateQuickTime = false;
    private bool checkQuickTimeOne = false;
    private bool checkQuickTimeTwo = false;
    private bool checkQuickTimeThree = false;
    private bool closeQuickTime = false;

    private bool winEventOne = false;
    private bool winEventTwo = false;
    private bool winEventThree = false;

    private bool input = true;

    private bool eventStarter = false;
    private bool key1 = false;
    private bool key2 = false;
    private bool key3 = false;
    private bool key4 = false;
    private bool key5 = false;
    private bool key6 = false;
    private bool key7 = false;
    private bool key8 = false;

    private bool WinGame = false;
    private bool end = false;

    private float h;
    private float v;


    void Awake()
    {
        QuickTimeOneA = QuickTimeOne.GetComponent<Animator>();
        QuickTimeTwoA = QuickTimeTwo.GetComponent<Animator>();
        QuickTimeThreeA = QuickTimeThree.GetComponent<Animator>();
    }

    void Update()
    {
        print("Testupdate");

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

         if (Input.GetButtonDown("A"))// && key3 && !key4)
        {
          //  key4 = true;
            a.gameObject.SetActive(false);
            print("A gedrückt");
        }
    }

    void winGame()
    {
        print("WINWINWIN");
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ritual" && !end)
        {
            ActivateQuickTimeEvent.gameObject.SetActive(true);
            canActivateQuickTime = true;
            closeQuickTime = false;
        }
    }
    void OnCollisionExit(Collision other)
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
            if (!checkQuickTimeOne)
            {
                ActivateQuickTimeEvent.gameObject.SetActive(false);
                StartCoroutine(waitForFail(QuickTimeOne,5));
                StartEventOne();
            }

            if (checkQuickTimeOne && !checkQuickTimeTwo)
            {
                StartCoroutine(waitForFail(QuickTimeTwo,10));
                ActivateQuickTimeEvent.gameObject.SetActive(false);
                StartEventTwo();

            }
            if (checkQuickTimeOne && checkQuickTimeTwo && !checkQuickTimeThree)
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
        if (!winEventOne)
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
        if (!winEventOne)
        {
            StopEventOne();
        }
        if (!winEventTwo)
        {
            StopEventTwo();
        }
        if (!winEventThree)
        {
            StopEventThree();
        }
    }
    private void StopEventOne()
    {

        h = Input.GetAxis("Left");
        v = Input.GetAxis("Up");


        if (closeQuickTime && !winEventOne && !WinGame)
        {
            QuickTimeOne.gameObject.SetActive(false);
        }

        if (!winEventOne && eventStarter && !WinGame)
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


                winEventOne = true;
                checkQuickTimeOne = true;
                key1 = false;
                key2 = false;
                key3 = false;
                QuickTimeOneA.Play("QuickTimeComplete");
                StopAllCoroutines();
                StartCoroutine(waitForDestroy(QuickTimeOne.gameObject));
            }





        }

    }
    private void StopEventTwo()
    {
        h = Input.GetAxis("Left");
        v = Input.GetAxis("Up");


        if (closeQuickTime && !winEventTwo && winEventOne && !WinGame)
        {
            QuickTimeOne.gameObject.SetActive(false);
        }

        if (!winEventTwo && eventStarter && winEventOne && !WinGame)
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
                print("A gedrückt");
            }
            else if (v == 1 && key4 && !key5)
            {
                key5 = true;
                up.gameObject.SetActive(false);

            }
            else if (v == -1 && key5 && !key6)
            {
                down.gameObject.SetActive(false);

                winEventTwo = true;
                checkQuickTimeTwo = true;
                key1 = false;
                key2 = false;
                key3 = false;
                key4 = false;
                key5 = false;
                QuickTimeTwoA.Play("QuickTimeComplete");
                StopAllCoroutines();
                StartCoroutine(waitForDestroy(QuickTimeTwo.gameObject));

            }





        }
    }
    private void StopEventThree()
    {
        h = Input.GetAxis("Left");
        v = Input.GetAxis("Up");


        if (closeQuickTime && !winEventThree && winEventOne && winEventTwo && !WinGame)
        {
            QuickTimeOne.gameObject.SetActive(false);
        }

        if (!winEventThree && eventStarter && winEventOne && winEventTwo && !WinGame)
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

                winEventThree = true;
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

        if (!winEventOne)
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

        if (!winEventOne)
        {
            QuickTimeOneA.Play("QuickTimeFale");
            left.gameObject.SetActive(true);
            right.gameObject.SetActive(true);
            up.gameObject.SetActive(true);
            down.gameObject.SetActive(true);

        }
        if (winEventOne && !winEventTwo)
            QuickTimeTwoA.Play("QuickTimeFale");
        if (winEventOne && winEventTwo && !winEventThree)
            QuickTimeThreeA.Play("QuickTimeFale");

        StartCoroutine(waitForDisable(quickTime.gameObject));
        StartCoroutine(showButto());

    }
    IEnumerator showButto()
    {
        yield return new WaitForSeconds(1.2f);
        if (!winEventThree)
        {
            ActivateQuickTimeEvent.gameObject.SetActive(true);
            canActivateQuickTime = true;
            closeQuickTime = false;
        }
        
    }

}
