using System.Collections.Generic;
using BehaviourTree;

public class MonsterBT : Tree
{
    public UnityEngine.Transform[] waypoints;

    public static float speed = 5f;
    public static float fovRange = 4f;
    public static float attackRange = 1f;
    protected override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Sequence(new List<Node>
            {
                new CheckEnemyInAttackRange(transform),
                new TaskAttack(transform),
            }),
            new Sequence(new List<Node>
            {
                new CheckEnemyInFOVRange(transform),
                new TaskGoToTarget(transform),
            }),
            new TaskPatrol(transform,waypoints),
        });

        return root;
    }

    void OnDrawGizmos()
    {
        UnityEngine.Gizmos.color = UnityEngine.Color.red;
        //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        UnityEngine.Gizmos.DrawSphere(transform.position, MonsterBT.fovRange);
    }
}
