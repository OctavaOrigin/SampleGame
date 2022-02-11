using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityForce : MonoBehaviour
{
    private float gravity;
    private bool enable;
    Data data;
    CubeController cubeController;
    float t = 0;

    void Awake(){
        data = FindObjectOfType<Data>();
        cubeController = GetComponent<CubeController>();
    }

    void Start(){
        gravity = data.gravity;
    }

    public void CubeGravityEnable(){
        enable = true;
    }

    public void CubeGravityDisable(){
        enable = false;
    }

    private void Update(){
        if (enable){
            ApplyGravity();
        }
    }

    private void ApplyGravity(){
        if (!cubeController.cc.isGrounded){
            t += Time.deltaTime;
            Vector3 s = Vector3.up * cubeController.upSpeed * t - Vector3.up * t * t * (gravity * Time.deltaTime) /2;
            cubeController.cc.Move(s);
        }else{
            t = 0;
        }
    }
}
