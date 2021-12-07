using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Behavour that Performs a velocity change in middle air  
/// </summary>
public class MidFlyVelocityBehave : MonoBehaviour,IMidFlyAble
{
    [SerializeField] private float force=3f;
    
    [SerializeField] private MovementController movementCtrl;
    
    void Init(MovementController movementCtrl)
    {
        this.movementCtrl = movementCtrl;
    }

    public void PerformMidFlyBehave()
    {
        // var endPoint = (transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition)).normalized;
        var mousePos = Input.mousePosition;
        var endPoint = Camera.main.ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y, 10 ));
        // var endPoint = (transform.position - target.position).normalized;
        Debug.DrawLine(transform.position, endPoint ,Color.blue,3f);
        movementCtrl?.ActivateRb();
        movementCtrl?.Push(endPoint.normalized * force);
    }
}
