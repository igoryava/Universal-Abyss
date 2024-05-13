using System;
using UnityEngine;

public class PatrollerEnemyTakeDamage : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private PatrollerEnemyHealth _health;
    [SerializeField] private PlayerMovement _movement;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<IsAttachedEnemy>(out IsAttachedEnemy isAttachedEnemy))
        {
            _health.TakeDamage(_damage);
            _movement.Jump();
        }
    }
}
