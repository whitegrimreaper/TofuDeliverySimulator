using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour {

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(rb.velocity.magnitude <= 20.0f)
        {
            rb.AddForce(new Vector3(1.5f, 0, 0));
        }
	}
}
