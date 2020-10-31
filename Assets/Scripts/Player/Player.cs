using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _maxHeath;

    private Animator _animator;
    private int _health;
    private int _coins;

    public int Health => _health;
    public int Coins => _coins;

    public event UnityAction HealthChanged;
    public event UnityAction CoinsChanged;

    private void Start()
    {
        _animator = GetComponent<Animator>();

        _health = _maxHeath;
        HealthChanged?.Invoke();
        CoinsChanged?.Invoke();
    }

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        _animator.SetTrigger("Hurt");
        HealthChanged?.Invoke();

        if (_health <= 0)
            Die();
    }

    public void PickUpCoin(int coinValue)
    {
        _coins += coinValue;
        CoinsChanged?.Invoke();
    }

    private void Die()
    {

    }
}
