using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovingPoints : MonoBehaviour
{

    CubeController controller;
    private Queue<Vector3> queue;
    Vector3 currentPoint;
    bool ReachedNextPosition;

    void Awake(){
        controller = GetComponent<CubeController>();
        queue = new Queue<Vector3>();
    }

    void Start(){
        ReachedNextPosition = true;
    }

    private void SetNewPoint(){
        if (!(queue.Count == 0)){
            ReachedNextPosition = false;
            currentPoint = LookAtNextPoint();
            controller.NewPositionToMoveTo(GetNextPoint());
        }
    }

    private Vector3 LookAtNextPoint(){
        return queue.Peek();
    }
    public Vector3 GetNextPoint(){
        return queue.Dequeue();
    }

    public void AddPoint(Vector3 point){
        queue.Enqueue(point);
        if (ReachedNextPosition){
            SetNewPoint();
        }
    }

    void Update(){
        if (!ReachedNextPosition){
            Vector3 currentPos = new Vector3(transform.position.x, 0, transform.position.z);
            Vector3 targetPos = new Vector3(currentPoint.x, 0, currentPoint.z);
            if (Vector3.Distance(currentPos, targetPos) < 0.05f){
                ReachedNextPosition = true;
                SetNewPoint();
            }
            
        }
    }

}
