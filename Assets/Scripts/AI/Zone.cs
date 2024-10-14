using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zone : MonoBehaviour
{
    //private Collider collider;
    public event Action<Vector3> OnEnterZone;
    public event Action<Vector3> OnExitZone;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("Player Enter "+this.name+ " zone");
            var collisionPoint = collision.ClosestPoint(transform.position);
            OnEnterZone?.Invoke(collisionPoint);
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Player Exit "+this.name+ " zone");
            var collisionPoint = collision.ClosestPoint(transform.position);
            OnExitZone?.Invoke(collisionPoint);
        }
    }
}
