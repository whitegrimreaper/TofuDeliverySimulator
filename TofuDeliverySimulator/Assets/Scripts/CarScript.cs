using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour {

    private Rigidbody rb;

    public float maxSpeed;

    public float speeeeeeeeeeed;
    public int rotateSpeed;
    public Vector3 currentVelocity;
    public Vector3 currentForward;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        bool offVector = Approximately(transform.forward.normalized, rb.velocity.normalized, 1);
        //Debug.Log(dist);
        Vector3 driftDiff = transform.forward - rb.velocity;
        rb.AddForce(driftDiff * 0.5f);
		
        speeeeeeeeeeed = rb.velocity.magnitude;
        currentVelocity = rb.velocity;
        currentForward = transform.forward;

        int timeHeld = 0;

        bool brakes = false;
        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            brakes = true;
            rb.AddForce(transform.forward * -1);
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * rotateSpeed, Space.World);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * rotateSpeed, Space.World);
        }

        if (rb.velocity.magnitude <= maxSpeed && !brakes)
        {
            rb.AddForce(transform.forward.normalized * (maxSpeed - rb.velocity.magnitude));
            Debug.Log("Adding force of " + transform.forward.normalized * (maxSpeed - rb.velocity.magnitude));
        }
    }

    //With absolute value
    //public bool Approximately(Vector3 me, Vector3 other, float allowedDifference)
    //{
    //    var dx = me.x - other.x;
    //    if (Mathf.Abs(dx) > allowedDifference)
    //        return false;

    //    var dy = me.y - other.y;
    //    if (Mathf.Abs(dy) > allowedDifference)
    //        return false;

    //    var dz = me.z - other.z;

    //    return Mathf.Abs(dz) >= allowedDifference;
    //}
    //With percentage i.e. between 0 and 1
    public bool Approximately(Vector3 me, Vector3 other, float percentage)
    {
        var dx = me.x - other.x;
        if (Mathf.Abs(dx) > me.x * percentage)
            return false;

        var dy = me.y - other.y;
        if (Mathf.Abs(dy) > me.y * percentage)
            return false;

        var dz = me.z - other.z;

        return Mathf.Abs(dz) >= me.z * percentage;
    }
}
