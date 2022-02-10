using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;
public class CheckEnemyInAttackRange : Node
{
    private Transform _transform;
    private Animator _animator;
    
    public CheckEnemyInAttackRange(Transform transform)
    {
        _transform = transform;
        _animator = transform.GetComponent<Animator>();
    }

    public override NodeState Evaluate()
    {
        object t = GetData("target");
        if (t == null)
        {
            state = NodeState.FAILURE;
            return state;
        }

        Transform target = (Transform)t;
        if (Vector2.Distance(_transform.position, target.position) <= MonsterBT.attackRange)
        {
            //_animator.SetBool("Attacking", true);
            //_animator.SetBool("Walking", false);
            Debug.Log("Target in attack range");
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}
