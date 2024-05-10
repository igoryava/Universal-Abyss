using UnityEngine;

public class PatrollerEnemyGiveDamage : MonoBehaviour
{
    [SerializeField] private float _damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            playerHealth.TakeDamage(_damage);
        }
    }
}
