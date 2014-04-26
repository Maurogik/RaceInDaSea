using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

  
  public Transform playerPrefab;
  public FinishBlock finishLine;
  public StartBlock startingBlock;
  public Terrain terrain;


  private GameObject player;



	// Use this for initialization
	void Start () {
    player = (Instantiate(playerPrefab) as Transform).gameObject;
    player.GetComponent<Control>().terrain = terrain;
    startingBlock.StartGame(player);
	}

  public void EndGame()
  {
    Debug.Log("End Game");
    startingBlock.StartGame(player);
  }
	
	// Update is called once per frame
	void Update () {
	
	}
}
