using UnityEngine;
using System.Collections;

public class ChangeCameraFollow : MonoBehaviour
{
    [SerializeField] private Transform newTarget;

    [SerializeField] private Vector3 newOffset;
    [SerializeField] private float delay;

    [SerializeField] private Follow followScript;

    bool isMoving = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(ShiftOffset());
    }
    IEnumerator ShiftOffset()
    {
        yield return new WaitForSeconds(delay);

        followScript.offset = newOffset;
        if (newTarget != null)
            followScript.SwitchTarget(newTarget);
    }
}
