using UnityEngine;

public class PlayerCarController : MonoBehaviour
{
   [Header("Wheels Collider")]
    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider backLeftWheelCollider;
    public WheelCollider backRightWheelCollider;

    [Header("Wheels Transform")]
    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform backLeftWheelTransform;
    public Transform backRightWheelTransform;


    [Header("Car Engine")]
    public float accelerationForce = 300f;
    public float breakingForce = 3000f;
    public float presentBreakForce = 0f;
    public float presentAcceleration = 0f:

    private void Update()
    {
        MoveCar();
    }
    private void MoveCar()

    frontLeftWheelCollider.motorTorque = presentAcceleration;
    frontRightWheelCollider.motorTorque = presentAcceleration;


    presentAcceleration = accelerationForce * Input.GetAxis("Vertical") 
}





