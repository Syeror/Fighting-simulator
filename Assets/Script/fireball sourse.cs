using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballsourse : MonoBehaviour
{
    public Transform TargetPoint;
    public Camera CameraLink;
    public float TargetInSkyDistance;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    private void Update()
    {
        var Ray = CameraLink.ViewportPointToRay(new Vector3(0.5f , 0.7f, 0));
        
        RaycastHit hit;
        if(Physics.Raycast(Ray, out hit) )
        {
            TargetPoint.position = hit.point;

        }
        else
        {
            TargetPoint.position = Ray.GetPoint(TargetInSkyDistance);
        }

        transform .LookAt ( TargetPoint.position );

    }

    // Update is called once per frame
  
}
