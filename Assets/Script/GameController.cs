using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {
	
  public FinishBlock finishLine;
  public StartBlock startingBlock;
  public Terrain terrain;

  public Texture2D bombTex;
  public Texture2D inkTex;


  public List<GameObject> players;
  public List<Transform> prefabs;


	// Use this for initialization
	void Start () {
    players = new List<GameObject>();

    GameConfig conf = GameConfig.GetInstance();

    for (int i = 0; i < conf.players.Count; ++i)
    {
      Debug.Log(" ind : " + i + " player " + conf.players[i]);
      GameObject player = (Instantiate(prefabs[GameConfig.GetInstance().selectedPrefab[i]]) as Transform).gameObject;
      player.GetComponent<Control>().terrain = terrain;
      player.GetComponent<Control>().playerIndex = conf.players[i];
      startingBlock.StartGame(player);
      players.Add(player);

      Camera playerCam = player.transform.GetComponentInChildren<Camera>();
      playerCam.rect = new Rect(0.0f, 0.0f + (i * 0.5f), 1.0f, 1.0f / conf.players.Count);

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

  void OnGUI()
  {

    GUI.skin = GameConfig.GetInstance().skin;

    GameConfig conf = GameConfig.GetInstance();

    for (int i = 0; i < conf.players.Count; ++i)
    {
      GUI.Label(new Rect(20, (Screen.height / 2 ) * (1-i) + 20, 120, 80), "Player " + (conf.players[i] + 1));

      Control control = players[i].GetComponent<Control>();
      Bonus.BonusType type = control.GetBonusType();
      Debug.Log("Type : " + type);
      Rect texRect = new Rect(20, (Screen.height / 2 ) * (1-i) + 100, 100, 100);

      if (type == Bonus.BonusType.Ink)
      {
        GUI.DrawTexture(texRect, inkTex);
      }
      else if (type == Bonus.BonusType.Bomb)
      {
        GUI.DrawTexture(texRect, bombTex);
      }

    }

  }
}
