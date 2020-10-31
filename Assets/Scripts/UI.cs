using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using System;

public class UI : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _health;
    [SerializeField] private TMP_Text _coins;

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
        _player.CoinsChanged += OnCoinsChanged;
    }

    private void OnHealthChanged()
    {
        _health.text = _player.Health.ToString();
    }

    private void OnCoinsChanged()
    {
        _coins.text = _player.Coins.ToString();
    }
}
