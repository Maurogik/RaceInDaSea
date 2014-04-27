using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour {

  public GUISkin menuSkin;
  public Texture2D[] poulpID;
  Rect startRect;
  Rect quitRect;
  Rect titleRect;
  Rect infoRect;
  Rect loadingRect;
  List<Rect> charsRect;
  int selectAvatar;
  MenuState state;

  enum MenuState
  {
    StartMenu,
    PlayerConnectMenu,
    EndGameMenu,
    LoadingScreen,
	PlayerSelectMenu
  }

	// Use this for initialization
  void Start ()
  {
    state = MenuState.StartMenu;
    startRect = new Rect(Screen.width / 2 - 200, Screen.height / 2 - 300, 400, 100);
    quitRect = new Rect(Screen.width / 2 - 200, Screen.height / 2 -150 , 400, 100);
    titleRect = new Rect(Screen.width / 2 - 200, 50, 400, 100);
    infoRect = new Rect(100, Screen.height / 2 , Screen.width - 200, 200);
    loadingRect = new Rect(Screen.width / 2 - 200, Screen.height / 2 - 200, 400, 400);
	
	charsRect = new List<Rect>();
	Rect rect = new Rect(Screen.width / 2 - 325, Screen.height / 2 - 325, 300, 300);
	charsRect.Add(rect);
		Rect rect2 = new Rect(Screen.width / 2 + 25, Screen.height / 2 - 325, 300, 300);
	charsRect.Add(rect2);
		Rect rect3 = new Rect(Screen.width / 2 - 325, Screen.height / 2 + 25, 300, 300);
	charsRect.Add(rect3);
		Rect rect4 = new Rect(Screen.width / 2 + 25, Screen.height / 2 + 25, 300, 300);
	charsRect.Add(rect4);
		selectAvatar = 0;
	
    if (GameConfig.GetInstance().displayEndGameMenu)
    {
      state = MenuState.EndGameMenu;
    }

    GameConfig.GetInstance().skin = menuSkin;
	}
	
	// Update is called once per frame
	void Update ()
  {
    if (state == MenuState.PlayerConnectMenu)
    {
      for (int i = 0; i < GameConfig.GetInstance().maxPlayers; ++i)
      {
        bool here = i == 0 ? Input.GetKey(KeyCode.Joystick1Button0) : Input.GetKey(KeyCode.Joystick2Button0);
        here |= Input.GetButton("Drift" + (i + 1));
        if (here)
        {
          Debug.Log("connect " + i);
          if (!GameConfig.GetInstance().players.Contains(i))
          {
            GameConfig.GetInstance().players.Add(i);
          }
        }
        
      }
    }
	
	}

  void OnGUI()
  {
    GUI.skin = menuSkin;

    switch (state)
    {
      case MenuState.StartMenu :

        GUI.Label(titleRect, "Main Menu");

        if (GUI.Button(startRect, "Start"))
        {
          state = MenuState.PlayerConnectMenu;
        }

        if (GUI.Button(quitRect, "Quit"))
        {
          Debug.Log("Quitting game");
          Application.Quit();
        }

        break;
      case MenuState.PlayerConnectMenu :

        GUI.Label(titleRect, "Player Connection");

        GUI.Label(infoRect, "Player 1 : Press 'space', 'left shift' or joystick button 'A' \n"
                          + "Player 2 : Press 'enter', 'right shift' or joystick button 'A'");

        bool start = GUI.Button(startRect, "Start");
        if (start && GameConfig.GetInstance().players.Count > 0)
        {
          state = MenuState.PlayerSelectMenu;
        }

        if (GUI.Button(quitRect, "Back"))
        {
          state = MenuState.StartMenu;
        }

        for (int i = 0; i < GameConfig.GetInstance().players.Count; ++i)
        {
          Rect boxRect = new Rect(Screen.width / 2 - 200 + 200 * i, Screen.height / 2 + 300, 180, 100);
          GUI.Box(boxRect, "Player " + (GameConfig.GetInstance().players[i] + 1));
        }

        break;
	  case MenuState.PlayerSelectMenu :
			GUI.Label(titleRect, "Choose your character, player " + (selectAvatar+1) + "!");
			for(int i=0; i<poulpID.Length; i++) {
				bool selected = GUI.Button(charsRect[i], poulpID[i]);
				if(selected) {
					GameConfig.GetInstance().selectedPrefab.Add(i);
					selectAvatar++;
					if(selectAvatar == GameConfig.GetInstance().players.Count) {
						state = MenuState.LoadingScreen;
					}
				}
			}
		break;
      case MenuState.EndGameMenu :

        GUI.Label(titleRect, "So, you won or what ?");

        if(GUI.Button(startRect, "Back"))
        {
          GameConfig.GetInstance().playersPosition.Clear();
          GameConfig.GetInstance().players.Clear();
          state = MenuState.StartMenu;
        }

        for (int i = 0; i < GameConfig.GetInstance().playersPosition.Count; ++i)
        {
          GUI.Box(new Rect(Screen.width / 2 - 100, Screen.height / 2 + i * 150, 200, 100), GameConfig.GetInstance().playersPosition[i]);
        }

        break;

      case MenuState.LoadingScreen :
        GUI.Label(loadingRect, "Loading level, please wait");
        Application.LoadLevel("RaceScene");
        break;
    }


  }
}
