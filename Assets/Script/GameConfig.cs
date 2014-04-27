using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameConfig {

  private static GameConfig _instance;

  public static GameConfig GetInstance()
  {
    if (_instance == null)
    {
      _instance = new GameConfig();
    }
    return _instance;
  }

  public GameConfig()
  {
    players = new List<int>();
    playersPosition = new List<string>();
  }

  public List<int> players;
  public int maxPlayers = 2;
  public List<string> playersPosition;
  public bool displayEndGameMenu = false;
  public GUISkin skin;
  public float driftStrength = 4.0f;

}
