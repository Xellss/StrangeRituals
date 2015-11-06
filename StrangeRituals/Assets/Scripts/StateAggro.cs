using UnityEngine;
using System.Collections;

public class StateAggro : State
{
    Random random;

    Vector3 Checkpoint1 = new Vector3(7.0f, 0.0f, 7.0f);
    Vector3 Checkpoint2 = new Vector3(7.0f, 0.0f, -7.0f);
    Vector3 Checkpoint3 = new Vector3(-7.0f, 0.0f, 7.0f);
    Vector3 Checkpoint4 = new Vector3(-7.0f, 0.0f, 7.0f);

    public override void Update(Agent agent)
    {
        agent.MoveSpeed = 2;
        Vector3 delta = agent.target.position - agent.transform.position;
        delta.y = 0;
        float distance = delta.magnitude;
        if (distance < agent.maxRange && distance > agent.minRange)
        {
            agent.Move(delta.normalized * agent.MoveSpeed);
        }

        if (agent.HP > 50)
        {
            agent.ChangeState<StateNormal>();
            agent.state = 1;
        }

        if ((Vector3.Distance(agent.transform.position, agent.target.position) > agent.maxRange) && agent.HP < 50)
        {
            int randomCheck = Random.Range(1, 4);

            seek(agent, randomCheck);
        }

    }
    void seek(Agent agent, int randomCheck)
    {

        if (randomCheck == 1)
        {
            if (Checkpoint1.x > agent.transform.position.x)
                agent.transform.Translate(-1 * Time.deltaTime * agent.MoveSpeed, 0, 0);
            if (Checkpoint1.x < agent.transform.position.x)
                agent.transform.Translate(1 * Time.deltaTime * agent.MoveSpeed, 0, 0);
            if (Checkpoint1.z > agent.transform.position.z)
                agent.transform.Translate(0, 0, -1 * Time.deltaTime * agent.MoveSpeed);
            if (Checkpoint1.z < agent.transform.position.z)
                agent.transform.Translate(0, 0, 1 * Time.deltaTime * agent.MoveSpeed);

            if (Checkpoint1.x == agent.transform.position.x && Checkpoint1.z == agent.transform.position.z)
            {
                return;
            }
            
        }
    } // seek end

}// Namespace end
