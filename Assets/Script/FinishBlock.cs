using UnityEngine;
using System.Collections;

public class FinishBlock : MonoBehaviour {

  public GameController gameController;

	// Use this for initialization
	void Start ()
  {
	
	}

  void OnTriggerEnter(Collider other)
  {
    if (other.tag == "Player")
    {
      gameController.EndGame();
    }
  }
}
