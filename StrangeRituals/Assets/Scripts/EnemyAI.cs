using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    [HideInInspector]
    public GameObject Player;

    public float MoveSpeed = 1;
    public int maxRange;
    public int minRange;

    public int state = 0; // state 0 is Idle, state 1 is attacking

    void Update()
    {
        if ((Vector3.Distance(transform.position, Player.transform.position) < maxRange)
           && (Vector3.Distance(transform.position, Player.transform.position) > minRange))
        {
            if (transform.position.x > Player.transform.position.x)
                transform.Translate(-1 * Time.deltaTime * MoveSpeed, 0, 0);
            if (transform.position.x < Player.transform.position.x)
                transform.Translate(1 * Time.deltaTime * MoveSpeed, 0, 0);
            if (transform.position.z > Player.transform.position.z)
                transform.Translate(0, 0, -1 * Time.deltaTime * MoveSpeed);
            if (transform.position.z < Player.transform.position.z)
                transform.Translate(0, 0, 1 * Time.deltaTime * MoveSpeed);

            state = 1;   
        }

        if ((Vector3.Distance(transform.position, Player.transform.position) > maxRange))
            state = 0;

    }
}
