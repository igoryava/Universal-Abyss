using UnityEngine;

public class IsAttachedEnemy : MonoBehaviour
{
    public bool _isAttached;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<CanPlayerStepOnEnemy>(out CanPlayerStepOnEnemy stepOnEnemy))
        {
            _isAttached = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<CanPlayerStepOnEnemy>(out CanPlayerStepOnEnemy stepOnEnemy))
        {
            _isAttached = false;
        }
    }
}
