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
			Vector3 move = new Vector3(0, 0, 1);
			other.gameObject.transform.rigidbody.AddForce(move*force, ForceMode.Impulse);
		}
	}
}