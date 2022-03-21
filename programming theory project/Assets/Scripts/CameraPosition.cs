using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    private void Awake()
    {
        if (SceneLoader.Instance != null)
        {

            transform.position = SceneLoader.Instance.MainCameraPosition;
        }
    }
}
