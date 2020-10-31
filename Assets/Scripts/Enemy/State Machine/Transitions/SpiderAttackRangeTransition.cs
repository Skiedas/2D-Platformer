using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAttackRangeTransition : Transition
{
    [SerializeField] private float _attackRange;

    private void Update()
    {
        if (Vector2.Distance(transform.position, new Vector2(Target.transform.position.x, transform.position.y)) < _attackRange)
            NeedTransit = true;
    }
}
