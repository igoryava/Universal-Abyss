using UnityEngine;

public class IsAttachedPlatform : MonoBehaviour
{
    private float _horizontal;

    private Rigidbody2D _rigidbody;
    public bool IsAttached;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<CanPlayerStepOnPlatform>(out CanPlayerStepOnPlatform stepOnPlatform))
        {
            if (_horizontal != 0)
            {
                transform.SetParent(null);
                return;
            }

            transform.SetParent(collision.transform);
            IsAttached = true;

        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<CanPlayerStepOnPlatform>(out CanPlayerStepOnPlatform stepOnPlatform))
        {
            transform.SetParent(null);
            IsAttached = false;
        }
    }
}