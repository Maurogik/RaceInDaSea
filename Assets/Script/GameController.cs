﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

  
  public Transform playerPrefab;
  public FinishBlock finishLine;
  public StartBlock startingBlock;
  public Terrain terrain;


  public List<GameObject> players;



	// Use this for initialization
	void Start () {
    players = new List<GameObject>();

    GameConfig conf = GameConfig.GetInstance();

    for (int i = 0; i < conf.players.Count; ++i)
    {
      GameObject player = (Instantiate(playerPrefab) as Transform).gameObject;
      player.GetComponent<Control>().terrain = terrain;
      player.GetComponent<Control>().playerIndex = conf.players[i];
      startingBlock.StartGame(player);
      players.Add(player);

      Camera playerCam = player.transform.GetComponentInChildren<Camera>();
      playerCam.rect = new Rect(0.0f, 0.0f + i * 0.5f, 1.0f, 1.0f / conf.players.Count);

    }
    players[0].AddComponent<AudioListener>();


	}

  public void EndGame(int player)
  {
    Debug.Log("End Game");

    GameConfig.GetInstance().playersPosition.Add("Player "+(player + 1));

    for (int i = 0; i < GameConfig.GetInstance().players.Count; ++i)
    {
      if(!GameConfig.GetInstance().playersPosition.Contains("Player "+(i + 1)))
      {
        return;
      }
    }
    GameConfig.GetInstance().displayEndGameMenu = true;
    Application.LoadLevel("MenuScene");
  }
	
	// Update is called once per frame
	void Update () {
	
	}
}
