using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : Health
{
    [SerializeField] private Animator _animator;
    [SerializeField] private AudioSource _playerDeath;

    private void Start()
    {
        _animator = GetComponent<Animator>();   
    }

    public override void Death()
    {
        base.Death();
        _animator.SetBool("Dead", true);
        _playerDeath.Play();
    }

    public void DeathAnimationEnd()
    {
        GetComponent<PlayerMovement>().enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
