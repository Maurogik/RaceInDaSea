using UnityEngine;
using System.Collections;

public class SpeedBlock : MonoBehaviour {

	public int force;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
      Vector3 move = Vector3.forward;
      move = transform.TransformDirection(move);
			other.gameObject.transform.rigidbody.AddForce(move*force, ForceMode.Impulse);
		}
	}
}