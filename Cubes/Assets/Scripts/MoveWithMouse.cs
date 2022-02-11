using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWithMouse : MonoBehaviour
{
    private Camera cameraMain;
    CubeController controller;

    private void Awake(){
        cameraMain = Camera.main;
        controller = GetComponent<CubeController>();
    }



    void Update(){
        if (Input.GetMouseButtonDown(1)){
            MoveToMousePosition();
        }
    }

    private void MoveToMousePosition(){
        Ray ray = cameraMain.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hasHit = Physics.Raycast(ray, out hit, Mathf.Infinity, 1);
        if (hasHit && (hit.transform.gameObject.tag == "Walkable")){
            controller.points.AddPoint(hit.point);
        }
    }
}
