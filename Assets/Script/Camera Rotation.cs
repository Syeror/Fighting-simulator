using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform CameraAxisTransform;
    public float RotationSpeed;
    //Clamp
    public float MinAngle;
    public float MaxAngle;
    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y + Time.deltaTime*RotationSpeed*Input.GetAxis("Mouse X"), 0);
        var NewAnglexX = CameraAxisTransform.localEulerAngles.x - Time.deltaTime * Input.GetAxis("Mouse Y") * RotationSpeed;
  
        if (NewAnglexX > 180)
            NewAnglexX -= 360;

        NewAnglexX = Mathf.Clamp(NewAnglexX, MinAngle, MaxAngle);
        CameraAxisTransform.localEulerAngles = new Vector3(NewAnglexX ,0, 0);
    }
}
