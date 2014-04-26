using UnityEngine;
using System.Collections;

public class StartBlock : MonoBehaviour {


  public void StartGame(GameObject player)
  {
    player.transform.position = transform.position;
    player.transform.rotation = transform.rotation;
  }
	
	// Update is called once per frame
  public void Update()
  {
	  
	}
}
