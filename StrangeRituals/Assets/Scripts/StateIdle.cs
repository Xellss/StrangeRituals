using UnityEngine;
using System.Collections;

public class StateIdle : State
{

    public override void Update(Agent agent)
    {
        agent.state = 0;

        if ((Vector3.Distance(agent.transform.position, agent.target.position) < agent.maxRange)
           && (Vector3.Distance(agent.transform.position, agent.target.position) > agent.minRange))
        {
            agent.ChangeState<StateNormal>();
            agent.state = 1;
        }

        if (agent.HP < 50)
        {
            agent.ChangeState<StateAggro>();
            agent.state = 2;
        }
    }
}
