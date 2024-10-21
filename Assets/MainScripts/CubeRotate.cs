using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeRotate : MonoBehaviour
{
    public Transform target;
    public float targetHeight = 2.0f;
    public float distance = 2.8f;
    public float maxDistance = 10f;
    public float minDistance = 0.5f;
    public float xSpeed = 250.0f;
    public float ySpeed = 120.0f;
    public float yMinLimit = -40f;
    public float yMaxLimit = 80f;
    public float zoomRate = 20f;
    public float rotationDampening = 3.0f;
    private float x = 0.0f;
    private float y = 0.0f;
    public bool isTalking = false;

    void Start () {
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        // Make the rigid body not change rotation
        if (transform.GetComponent<Rigidbody>())
        transform.GetComponent<Rigidbody>().freezeRotation = true;
    }

    void Update () {
        if (target) {
            if(Input.GetMouseButton(1)){
            x += Input.GetAxis("Mouse X") * xSpeed * 0.02f;
            y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;
                    }
                    //y = ClampAngle(y, yMinLimit, yMaxLimit);
                
                    if(Input.GetAxis("Mouse ScrollWheel") != 0){
                    distance=distance-Input.GetAxis("Mouse ScrollWheel")*5;
                    if (distance < minDistance) {distance=minDistance;}
                    if (distance > maxDistance) {distance=maxDistance;}
                    }
                        
            var rotation = Quaternion.Euler(y, x, 0);
            var position = rotation * new Vector3(0.0f, 0.0f, -distance) + target.position;
        
            transform.rotation = rotation;
            transform.position = position;
        }
    }

    static float ClampAngle (float angle, float min, float max) {
            if (angle < -360)
                    angle += 360;
            if (angle > 360)
                    angle -= 360;
            return Mathf.Clamp (angle, min, max);
    }
}
