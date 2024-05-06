using UnityEngine;

public class IsAttachedPlatform : MonoBehaviour
{
    [SerializeField] private LayerMask _whatIsPlatform;

    private Rigidbody2D _rigidbody;
    public bool IsAttached;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<CanPlayerStepOnPlatform>(out CanPlayerStepOnPlatform stepOnPlatform))
        {
            transform.SetParent(collision.transform);
            _rigidbody.gravityScale = 0;
            IsAttached = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<CanPlayerStepOnPlatform>(out CanPlayerStepOnPlatform stepOnPlatform))
        {
            transform.SetParent(null);
            _rigidbody.gravityScale = 1;
            IsAttached = false;
        }
    }
}