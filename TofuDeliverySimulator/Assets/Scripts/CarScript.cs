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
        if (offVector)
        {
            //Debug.Log("AAH");
            //rb.velocity *= 0.98f;
        }
		if(rb.velocity.magnitude <= maxSpeed)
        {
            rb.AddForce(transform.forward.normalized * (maxSpeed - rb.velocity.magnitude));
        }
        speeeeeeeeeeed = rb.velocity.magnitude;
        currentVelocity = rb.velocity;
        currentForward = transform.forward;

        

        if(Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * rotateSpeed, Space.World);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * rotateSpeed, Space.World);
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
