using UnityEngine.SceneManagement;
public class PlayerHealth : Health
{
    public override void Death()
    {
        base.Death();
        GetComponent<PlayerMovement>().enabled = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }
}
