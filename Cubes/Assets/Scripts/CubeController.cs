using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    [HideInInspector]
    public Data data;
    [HideInInspector]
    public CharacterController cc;
    [HideInInspector]
    public GravityForce gravityForce;
    [HideInInspector]
    public CubeMovingPoints points;

    float cubeSpeed;
    Vector3 targetToMove;
    public float upSpeed;


    private void Awake(){
        data = FindObjectOfType<Data>();
        cc = GetComponent<CharacterController>();
        gravityForce = GetComponent<GravityForce>();
        points = GetComponent<CubeMovingPoints>();
    }

    private void Start(){
        cubeSpeed = data.cubeSpeed;
        upSpeed = 0;
        gravityForce.CubeGravityEnable();
    }

    private void Update(){
        if (targetToMove != Vector3.zero){
            MoveToThePoint();
        }
    }

    private void MoveToThePoint(){
        Vector3 offSet = new Vector3(0, GetComponent<BoxCollider>().bounds.extents.y, 0);
        transform.position = Vector3.MoveTowards(transform.position, targetToMove + offSet, Time.deltaTime * cubeSpeed);
        if (cc.velocity == Vector3.zero){
            targetToMove = Vector3.zero;
        }
    }

    public void NewPositionToMoveTo(Vector3 changeTarget){
        targetToMove = changeTarget;
    }

    public void RefreshSpeedFromData(){
        cubeSpeed = data.cubeSpeed;
    }
}
