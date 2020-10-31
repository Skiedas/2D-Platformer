using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Player _target;
    [SerializeField] private int _health;
    [SerializeField] private float _deathAnimationTime;

    public Player Target => _target;

    private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;

        if (_health <= 0)
            Die();
    }

    private void Die()
    {
        StartCoroutine(Death());
    }

    private IEnumerator Death()
    {
        _animator.Play("Death");
        yield return new WaitForSeconds(_deathAnimationTime);
        Destroy(gameObject);
    }
}
