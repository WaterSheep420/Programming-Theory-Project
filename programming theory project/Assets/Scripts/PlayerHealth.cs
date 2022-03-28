public class PlayerHealth : Health
{
    protected override void Die()
    {
        SceneLoader.Instance.ReloadScene();
    }
}
