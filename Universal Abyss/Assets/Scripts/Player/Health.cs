using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    private float _currentHealth;

    public event Action<float> HealthChanged;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if (_currentHealth - damage <= 0)
        {
            Death();
        }
        else
        {
            _currentHealth -= damage;
        }
    }

    private void ChangeHealth(float value)
    {
        _currentHealth += value;

        if(_currentHealth <= 0)
        {
            Death();
        }
        else
        {
            float healtPercentage = (float)_currentHealth / _maxHealth;
            HealthChanged?.Invoke(healtPercentage);
        }
    }

    public virtual void Death()
    {   
        HealthChanged?.Invoke(0);
    }
}
