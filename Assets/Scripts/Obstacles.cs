using UnityEngine;

public class Obstacles : MonoBehaviour
{
  private Rigidbody _rigidbody;
  private void Awake()
  {
    _rigidbody = GetComponent<Rigidbody>();
  }
}
