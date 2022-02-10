using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;
public class CheckEnemyInFOVRange : Node
{
    private Transform _transform;
    private static int _enemyLayerMask = 1 << 7;

    private Animator _animator;

    public CheckEnemyInFOVRange(Transform transform)
    {
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        // if we already have a target, succeed automatically
        object t = GetData("target");
        if(t == null)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(_transform.position,MonsterBT.fovRange,_enemyLayerMask);
            // target found
            if (colliders.Length > 0)
            {
                Debug.Log("Target detected");
                parent.parent.SetData("target", colliders[0].transform);
                //_animator.SetBool("Walking",true);
                state = NodeState.SUCCESS;
                return state;
            }

            // No target found
            state = NodeState.FAILURE;
            return state;
        }

        state = NodeState.SUCCESS;
        return state;
    }
}
