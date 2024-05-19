using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : Health
{
    [SerializeField] private Animator _animator;

    private void Start()
    {
        _animator = GetComponent<Animator>();   
    }

    public override void Death()
    {
        base.Death();
        _animator.SetBool("Dead", true);
    }

    public void DeathAnimationEnd()
    {
        GetComponent<PlayerMovement>().enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
