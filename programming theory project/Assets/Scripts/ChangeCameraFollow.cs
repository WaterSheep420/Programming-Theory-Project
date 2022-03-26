using UnityEngine;
using System.Collections;

public class ChangeCameraFollow : MonoBehaviour
{
    [SerializeField] private Transform newTarget;

    [SerializeField] private Vector3 newOffset;
    [SerializeField] private float delay;

    [SerializeField] private Follow followScript;

    private BoxCollider2D area;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(ShiftCamera());
    }
    IEnumerator ShiftCamera()
    {
        yield return new WaitForSeconds(delay);

        followScript.offset = newOffset;

        if (newTarget != null)
            followScript.SwitchTarget(newTarget);
    }
    private void OnDrawGizmos()
    {
        if(area == null)
            area = GetComponent<BoxCollider2D>();

        Gizmos.color = new Color(1, 0, 0, 0.25f);
        Gizmos.DrawCube(transform.position, area.size);
    }
}
