using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    private float _currentHealth;

    public event Action<float> HealthChanged;
    private bool _dead;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ChangeHealth(-10);
        }
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

    private void Death()
    {   
        GetComponent<PlayerMovement>().enabled = false;
        HealthChanged?.Invoke(0);
        Debug.Log("YOU DEAD");
    }
}
