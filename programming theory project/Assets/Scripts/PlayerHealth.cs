//inheritance
public class PlayerHealth : Health
{
    //polymorphism
    protected override void Die()
    {
        AudioManager.Instance.Play(deathSound);

        SceneLoader.Instance.ReloadScene();
    }
}
