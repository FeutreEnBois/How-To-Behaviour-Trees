using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;

public class TaskGoToTarget : Node
{
    private Transform _transform;

    public TaskGoToTarget(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");

        if(Vector2.Distance(_transform.position, target.position) > 0.01f)
        {
            _transform.position = Vector2.MoveTowards(_transform.position, target.position,MonsterBT.speed*Time.deltaTime);
        }

        state = NodeState.RUNNING;
        return state;
    }
}
