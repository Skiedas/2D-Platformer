using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFollowTargetState : State
{
    [SerializeField] private float _speed;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(Target.transform.position.x, transform.position.y), _speed * Time.deltaTime);
    }
}
