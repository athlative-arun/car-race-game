using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class PlayerCarController : MonoBehaviour
{
    [Header("Wheels Collider")]
    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider backLeftWheelCollider;
    public WheelCollider BackRightWheelCollider;
    [Header("Wheels Transforms")]
    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform backLeftWheelTransform;
    public Transform BackRightWheelTransform;

    [Header("Car Engine")]
    public float accelerationForce = 300f;
    public float breakingForce = 3000f;
    private float presentBreakForce = 0f;
    private float presentAcceleration = 0f;

    [Header("Car Steering")]
    public float wheelsTorque = 35f;
    private float presentTurnAngle = 0f;



    private void Update(){
        MoveCar();
        CarSteering();
        ApplyBreak();
    }

    private void MoveCar(){

    presentAcceleration = accelerationForce * Input.GetAxis("Vertical");
    frontLeftWheelCollider.motorTorque = presentAcceleration;
    frontRightWheelCollider.motorTorque = presentAcceleration;
    backLeftWheelCollider.motorTorque = presentAcceleration;
    BackRightWheelCollider.motorTorque = presentAcceleration;

    }

    private void CarSteering(){
        presentTurnAngle = wheelsTorque * Input.GetAxis("Horizontal");
        frontLeftWheelCollider.steerAngle = presentTurnAngle;
        frontRightWheelCollider.steerAngle = presentTurnAngle;

        SteeringWheels(frontLeftWheelCollider,frontLeftWheelTransform);
        SteeringWheels(frontRightWheelCollider,frontRightWheelTransform);
        SteeringWheels(backLeftWheelCollider,backLeftWheelTransform);
        SteeringWheels(BackRightWheelCollider,BackRightWheelTransform);
    }

    void SteeringWheels(WheelCollider WC, Transform WT){
        Vector3 position;
        Quaternion rotation;

        WC.GetWorldPose(out position, out rotation);
        WT.position = position;
        WT.rotation = rotation;
    }

    public void ApplyBreak(){
        if(Input.GetKey(KeyCode.Space))
            presentBreakForce = breakingForce;
        else
            presentBreakForce = 0f;

        frontLeftWheelCollider.brakeTorque = presentBreakForce;
        frontRightWheelCollider.brakeTorque = presentBreakForce;
        backLeftWheelCollider.brakeTorque = presentBreakForce;
        BackRightWheelCollider.brakeTorque = presentBreakForce;    
    }
}
