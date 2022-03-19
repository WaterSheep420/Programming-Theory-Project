using UnityEngine;

public class LookAtCursor : MonoBehaviour
{
    Camera mainCamera;
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = -mainCamera.transform.position.z + transform.position.z;

        Vector3 lookAtPos = mainCamera.ScreenToWorldPoint(mousePos);

        Vector2 direction = (lookAtPos - transform.position).normalized;

        transform.right = direction;
    }
}
