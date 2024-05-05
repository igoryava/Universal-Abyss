using UnityEngine.UI;
using UnityEngine;

public class HeathBar : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private Health _health;

    private void Awake()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDestroy()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float valueAsPercantage)
    {
        Debug.Log(valueAsPercantage);
        _healthBar.fillAmount = valueAsPercantage;
    }

}
