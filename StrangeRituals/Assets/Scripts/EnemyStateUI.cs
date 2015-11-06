using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EnemyStateUI : MonoBehaviour
{

    Text text;
    EnemyAI enemyAI;
    Agent agent;

    void Start()
    {
        text = gameObject.GetComponent<Text>();
        enemyAI = gameObject.GetComponentInParent<EnemyAI>();
        agent = gameObject.GetComponentInParent<Agent>();

        text.text = "Idle... ";
    }

    void Update()
    {
        if (agent.state == 0)
            text.text = "Idle...";
        if (agent.state == 1)
            text.text = "Attack!";
        if (agent.state == 2)
            text.text = "F%§&!!";

    }
}
