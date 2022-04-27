using UnityEngine;

public class CameraMovement : MonoBehaviour
{
  public Transform target;
  public Vector3 offset;

  public float pLerp = 0.125f;
  public float rLerp = 0.125f;

  private void LateUpdate()
  {
    Vector3 desirePosition = target.position + offset;
    Vector3 smoothPosition = Vector3.Lerp(transform.position, desirePosition, pLerp);
    transform.position = smoothPosition;
    transform.rotation = Quaternion.Lerp(transform.rotation, target.rotation, rLerp);
  }
}
