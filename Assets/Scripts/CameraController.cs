using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    // for limiting camera movement to stay within the map: 

    [SerializeField]
    float leftLimit;

    [SerializeField]
    float rightLimit;

    [SerializeField]
    float topLimit;

    [SerializeField]
    float bottomLimit;

    [SerializeField]
    float timeOffset = 0.5f;


    // Update is called once per frame
    void Update() // LateUpdate
    {
        // starting position of the camera
        Vector3 startPosition = transform.position; 

        // mouse position in pixels -> its world position as a Vector3 
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane; // setting the z value so that the objects are visible 
        Vector3 desiredPosition = Camera.main.ScreenToWorldPoint(mousePos);
        desiredPosition.z = -10;

        // smoothly move the camera: 
        transform.position = Vector3.Lerp(startPosition,
            // desired position, clamped: 
            new Vector3(
            Mathf.Clamp(desiredPosition.x, leftLimit, rightLimit),
            Mathf.Clamp(desiredPosition.y,  bottomLimit, topLimit), // order matters! 
            desiredPosition.z
            ), 
            timeOffset * Time.deltaTime); 

    }

    private void OnDrawGizmos()
    {
        // draw a red box around the boundary for camera movement 
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(leftLimit, bottomLimit)); // left vertical 
        Gizmos.DrawLine(new Vector2(rightLimit, topLimit), new Vector2(rightLimit, bottomLimit)); // right vertical
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit)); // top horizontal 
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(rightLimit, bottomLimit)); // bottom horizontal 

    }
}
