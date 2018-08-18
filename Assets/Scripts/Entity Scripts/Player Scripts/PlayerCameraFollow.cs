using UnityEngine;
using System.Collections;

public class PlayerCameraFollow : MonoBehaviour
{
    public Transform target;

    public static PlayerCameraFollow instance;
    public float smoothSpeed = 0.125f;
    private Vector3 offset = new Vector3(0,0,-10);
    public Vector3 desiredPosition;
    public Vector3 smoothedPosition;
    public float zoom = 10;

    void Start()
    {
        if(instance != null)
        {
            Destroy(this);
        }

        instance = this;


    }

    public void SetToTile(int x, int y)
    {
        transform.position = new Vector3(x, y, 0) + offset;
    }

    public void SetPosition(float x, float y)
    {
        transform.position = new Vector3(x, y, 0) + offset;
    }

    void LateUpdate()
    {
        if(Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            Camera.main.orthographicSize += Input.GetAxis("Mouse ScrollWheel")*-2;
            Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, 2, 8);
            //Debug.Log(offset.z);
        }

        desiredPosition = target.position + offset;
        smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

    }

    void updateZoom()
    {

    }
}