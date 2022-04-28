using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirplaneController : MonoBehaviour
{
  private Rigidbody rb;
  public float FlySpeed = 5;
  public float YawAmount = 120;
  private float Yaw;

  private void Awake()
  {
    rb = GetComponent<Rigidbody>();
    rb.useGravity = false;
  }

  // Update is called once per frame
  void Update()
  {
    //inputs
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");

    //move forward
    transform.position += transform.forward * FlySpeed * Time.deltaTime;


    Yaw += horizontalInput * YawAmount * Time.deltaTime;
    float pitch = Mathf.Lerp(0, 20, Mathf.Abs(verticalInput)) * Mathf.Sign(verticalInput);
    float roll = Mathf.Lerp(0, 30, Mathf.Abs(horizontalInput)) * -Mathf.Sign(horizontalInput);

    //apply rotation
    transform.localRotation = Quaternion.Euler(Vector3.up * Yaw + Vector3.right * pitch + Vector3.forward * roll);
  }

  private void OnCollisionEnter(Collision collisionInfo)
  {
    if (collisionInfo.collider.tag == "Obstacle")
    {
      rb.useGravity = true;
      FindObjectOfType<GameManager>().GameOver(15);
    }
    else if (collisionInfo.collider.tag == "Sea") FindObjectOfType<GameManager>().GameOver(3);
  }
}
