using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderTargetLostTransition : Transition
{
    [SerializeField] private float _distance;

    private void Update()
    {
        if (Vector2.Distance(transform.position, new Vector2(Target.transform.position.x, transform.position.y)) > _distance)
            NeedTransit = true;
    }
}
