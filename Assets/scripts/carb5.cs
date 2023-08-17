using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carb5 : MonoBehaviour
{

    public WheelCollider frontleft;
    public WheelCollider frontright;
    public WheelCollider rearleft;
    public WheelCollider rearright;

    public float forceSpeed;
    public float forcerotateSpeed;
    public float forcerotateDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVerhical = Input.GetAxis("Vertical");

        frontright.steerAngle = inputHorizontal * forcerotateSpeed;
        frontleft.steerAngle = inputHorizontal * forcerotateSpeed;

        rearleft.motorTorque = inputVerhical * forceSpeed;
        rearright.motorTorque = inputVerhical * forceSpeed;
    }
}
