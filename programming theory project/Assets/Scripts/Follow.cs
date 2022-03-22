using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private Transform target;

    [SerializeField] private float smoothSpeed = 10f;
    public Vector3 offset;
    private Vector3 velocity = Vector3.zero;

    private void LateUpdate()
    {
        //abstraction time. just in case this script needs more functionality, we dont want to clutter the LateUpdate function
        FollowTarget();
    }
    void FollowTarget()
    {
        Vector3 targetposition = target.position + offset;
        Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, targetposition, ref velocity, smoothSpeed * Time.deltaTime);

        transform.position = smoothedPosition;
    }
}
