using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class PlayerInteractions : MonoBehaviour
{
    [SerializeField] private Transform _attackPosition;
    [SerializeField] private float _attackRange;
    [SerializeField] private int _damage;
    [SerializeField] private float _delay;

    private Animator _animator;
    private PlayerInput _input;
    private float _elapsedTime;
    private int _currentAttackType;

    private void Awake()
    {
        _currentAttackType = 0;

        _animator = GetComponent<Animator>();

        _input = new PlayerInput();
        _input.Enable();

        _input.Player.Attack.performed += ctx => TryAttack();
    }

    private void Update()
    {
        _elapsedTime += Time.deltaTime;
    }

    private void TryAttack()
    {
        if (_elapsedTime >= _delay)
        {
            _elapsedTime = 0;
            Attack();
        }
    }

    private void Attack()
    {
        AttackType type = (AttackType)_currentAttackType;

        if (_currentAttackType < 2)
            _currentAttackType++;
        else
            _currentAttackType = 0;

        _animator.SetTrigger(type.ToString());

        Collider2D[] hits = Physics2D.OverlapCircleAll(_attackPosition.position, _attackRange);

        if (hits == null)
            return;

        foreach (var hit in hits)
        {
            if (hit.TryGetComponent(out Enemy target))
                target.ApplyDamage(_damage);
        }

    }

    enum AttackType
    {
        Attack1,
        Attack2,
        Attack3
    }
}
