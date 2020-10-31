using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OctopusAttackState : State
{
    [SerializeField] private Transform _attackPosition;
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _attackPosition.position, _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player target))
        {
            target.ApplyDamage(_damage);
        }
    }
}
