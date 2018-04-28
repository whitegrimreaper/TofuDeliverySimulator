using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour {

    private Rigidbody rb;
    public float speeeeeeeeeeed;
    public int rotateSpeed;
    public Vector3 currentVelocity;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(rb.velocity.magnitude <= 20.0f)
        {
            rb.AddForce(transform.forward.normalized * 3);
        }
        speeeeeeeeeeed = rb.velocity.magnitude;
        currentVelocity = rb.velocity;

        if(Input.GetKeyDown(KeyCode.A))
        {
            transform.Rotate(new Vector3(0, -1, 0) * Time.deltaTime * rotateSpeed, Space.World);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Rotate(new Vector3(0, 1, 0) * Time.deltaTime * rotateSpeed, Space.World);
        }
    }
}
