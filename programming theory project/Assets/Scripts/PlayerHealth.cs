//inheritance
public class PlayerHealth : Health
{
    //polymorphism
    protected override void Die()
    {
        SceneLoader.Instance.ReloadScene();
    }
}
