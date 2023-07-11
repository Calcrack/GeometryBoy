using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform Target;
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    private Vector3 camOffset;
    public float smoothTime = 0.2f;

    private Vector3 smoothVelocity;

    private void Start()
    {
        camOffset = transform.position - Target.position;
    }

    private void LateUpdate()
    {
        Vector3 targetPosition = Target.position + camOffset;
        float clampedX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float clampedY = Mathf.Clamp(targetPosition.y, minY, maxY);
        Vector3 targetClampedPosition = new Vector3(clampedX, clampedY, transform.position.z);

        if (Vector3.Distance(transform.position, targetClampedPosition) > 0.01f)
        {
            transform.position = Vector3.SmoothDamp(transform.position, targetClampedPosition, ref smoothVelocity, smoothTime);
        }
    }
}
