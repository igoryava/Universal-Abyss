using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float _maxHealth;
    private float _health;

    public event Action<float> HealthChanged;

    private void Start()
    {
        _health = _maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ChangeHealth(-10);
        }
    }

    private void ChangeHealth(float value)
    {
        _health += value;

        if(_health <= 0)
        {
            Death();
        }
        else
        {
            float healtPercentage = (float)_health / _maxHealth;
            HealthChanged?.Invoke(healtPercentage);
        }
    }

    private void Death()
    {
        HealthChanged?.Invoke(0);
        Debug.Log("YOU DEAD");
    }
}
