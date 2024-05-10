using UnityEngine;

public class PlayerFalling : MonoBehaviour
{
    [SerializeField] private GameObject _placeOfDeath;
    [SerializeField] private PlayerHealth _healthChanged;

    private void Update()
    {
        if(transform.position.y <= _placeOfDeath.transform.position.y)
        {
            if (TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
            {
                playerHealth.TakeDamage(100000);
            }
        }
    }
}
