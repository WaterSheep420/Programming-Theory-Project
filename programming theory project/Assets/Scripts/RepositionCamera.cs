using UnityEngine;

public class RepositionCamera : MonoBehaviour
{
    private void Awake()
    {
        if (SceneLoader.Instance != null)
        {
            transform.position = SceneLoader.Instance.MainCameraPosition;
        }
    }
}
