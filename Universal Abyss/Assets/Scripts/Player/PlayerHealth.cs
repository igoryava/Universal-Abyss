public class PlayerHealth : Health
{
    public override void Death()
    {
        base.Death();
        GetComponent<PlayerMovement>().enabled = false;
    }
}
