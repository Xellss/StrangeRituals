using UnityEngine;
using System.Collections;

public class StateNormal : State
{

    public override void Update(Agent agent)
    {
        agent.MoveSpeed = 1;

        Vector3 delta = agent.target.position-agent.transform.position;
        delta.y = 0;
        float distance = delta.magnitude;
        if (distance < agent.maxRange && distance > agent.minRange)
        {
            agent.Move(delta.normalized * agent.MoveSpeed);
            //if (agent.transform.position.x > agent.target.position.x)
            //    agent.transform.Translate(-1 * Time.deltaTime * agent.MoveSpeed, 0, 0);
            //if (agent.transform.position.x < agent.target.position.x)
            //    agent.transform.Translate(1 * Time.deltaTime * agent.MoveSpeed, 0, 0);
            //if (agent.transform.position.z > agent.target.position.z)
            //    agent.transform.Translate(0, 0, -1 * Time.deltaTime * agent.MoveSpeed);
            //if (agent.transform.position.z < agent.target.position.z)
            //    agent.transform.Translate(0, 0, 1 * Time.deltaTime * agent.MoveSpeed);

            agent.state = 1;
        }

        if (agent.HP < 50)
        {
            agent.ChangeState<StateAggro>();
            agent.state = 2;
        }

        if ((Vector3.Distance(agent.transform.position, agent.target.position) > agent.maxRange))
        {
            agent.ChangeState<StateIdle>();
            agent.state = 0;
        }
    }
}
