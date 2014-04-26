using UnityEngine;
using System.Collections;

public class Control : MonoBehaviour {

  public float speed = 1.0f;


	// Use this for initialization
	void Start () {
	  
	}
	
	// Update is called once per frame
	void Update () {

    float x = Input.GetAxis("Horizontal");
    float z = Input.GetAxis("Vertical");

    Vector3 move = new Vector3(x * speed * Time.deltaTime, 0.0f, z * speed * Time.deltaTime);
    transform.position = transform.position + move;

	}
}
