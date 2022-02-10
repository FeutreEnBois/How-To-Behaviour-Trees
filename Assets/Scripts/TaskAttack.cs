using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using BehaviourTree;
public class TaskAttack : Node
{
    private Transform _lastTarget;
    private EnemyManager _enemyManager;
    private Animator _animator;

    private float _attackTime = 1f;
    private float _attackCounter = 0f;

    public TaskAttack(Transform transform)
    {
        _animator = transform.GetComponent<Animator>();
    }
    public override NodeState Evaluate()
    {
        Transform target = (Transform)GetData("target");
        if(target != _lastTarget)
        {
            _enemyManager = target.GetComponent<EnemyManager>();
            _lastTarget = target;
        }
        
        _attackCounter += Time.deltaTime;
        if(_attackCounter >= _attackTime)
        {
            Debug.Log("Attacking target");
            bool enemyIsDead = _enemyManager.TakeHit();
            if (enemyIsDead)
            {
                ClearData("target");
            }
            else
            {
                _attackCounter = 0f;
            }
        }

        state = NodeState.RUNNING;
        return state;
    }
}
