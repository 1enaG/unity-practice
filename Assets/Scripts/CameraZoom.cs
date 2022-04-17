using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{

    Camera cam;
    float currentZoom; // how many details fit in the frame. basically (target zoom) 
    float zoomIncrement = 3; // by how much the zoom will be incremented every time you scroll the wheel 
    float zoomLerpSpeed = 10; 

    private void Start()
    {
        cam = Camera.main;
        currentZoom = cam.orthographicSize;
    }

    void Update()
    {
        float scrollData = Input.GetAxis("Mouse ScrollWheel"); // 0.1 = up; -0.1 = down 
                                                               // Debug.Log(scrollData); // for testing 
                                                               //currentZoom -= scrollData * zoomStrengh; Eg: 4, 4.3, 4.6, 4.9, 5.2 ... (produced zoom values) 
                                                               //clamp before applying: 
        Debug.Log("Current zoom =" + currentZoom.ToString()); 
        currentZoom = Mathf.Clamp(currentZoom-scrollData*zoomIncrement, 2f, 5f); //

        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, currentZoom, zoomLerpSpeed * Time.deltaTime); 
        
    }
}
