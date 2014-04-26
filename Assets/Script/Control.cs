﻿using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

  public float speed = 1.0f;
  public float rotateSpeed = 1.0f;


	// Use this for initialization
	void Start () {
	  
	}
	
	// Update is called once per frame
	void FixedUpdate () {

    float x = Input.GetAxis("Horizontal");
    float z = Input.GetAxis("Vertical");

    Rigidbody rigid = transform.rigidbody;

    Vector3 move = new Vector3(0.0f, 0.0f, z * speed);
    move = transform.TransformDirection(move);

    /*transform.position = transform.position + move;

    transform.Rotate(Vector3.up, x * rotateSpeed * Time.deltaTime);*/

    rigid.AddForce(move, ForceMode.Force);

    rigid.AddTorque(0.0f, x * rotateSpeed, 0.0f, ForceMode.Force);

	}
}
