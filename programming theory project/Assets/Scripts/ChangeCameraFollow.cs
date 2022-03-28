using UnityEngine;
using System.Collections;

public class ChangeCameraFollow : MonoBehaviour
{
    [SerializeField] private Transform newTarget;
    [SerializeField] private GameObject toggleTrigger;

    [SerializeField] private Vector3 newOffset;
    [SerializeField] private float delay;

    [SerializeField] private Follow followScript;

    private BoxCollider2D area;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(ShiftCamera());
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ToggleTrigger();
    }
    IEnumerator ShiftCamera()
    {
        yield return new WaitForSeconds(delay);

        followScript.offset = newOffset;

        if (newTarget != null)
            followScript.SwitchTarget(newTarget);
    }
    void ToggleTrigger()
    {
        if (toggleTrigger != null)
        {
            if (toggleTrigger.activeSelf)
                toggleTrigger.SetActive(false);
            else
                toggleTrigger.SetActive(true);

            gameObject.SetActive(false);
        }
    }
    private void OnDrawGizmos()
    {
        if(area == null)
            area = GetComponent<BoxCollider2D>();

        Gizmos.color = new Color(1, 0, 0, 0.25f);
        Gizmos.DrawCube(transform.position, area.size);
    }
}
