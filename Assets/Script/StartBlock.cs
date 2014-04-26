using UnityEngine;
using System.Collections;

public class StartBlock : MonoBehaviour {


  public void StartGame(GameObject player)
  {
    player.transform.position = transform.position;
    player.transform.rotation = transform.rotation;
    player.rigidbody.velocity = Vector3.zero;
  }
	
	// Update is called once per frame
  public void Update()
  {
	  
	}
}
