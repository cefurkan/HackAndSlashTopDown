using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Prepare,
    MainGame,
    FinishGame,
}
public enum MainGame
{
    BossFight,
    Fight,
    NarrativeScene,
}
public enum CurremtWeapon
{
    Bow,
    Spear,
    Blade,
    Gun
}
public class GameManager : MonoBehaviour
{

    public PlayerController player;
    public static GameManager manager;

    public MainGame currentMainGame;
    public CurremtWeapon currentWeapon;
    private GameState _currentGameState;

    public GameState CurrentGameState
    {
        get { return _currentGameState; }
        set
        {
            switch (value)
            {
                case GameState.Prepare:
                    Debug.Log("Welcome");
                    break;
                case GameState.MainGame:
                    break;
                case GameState.FinishGame:
                    break;
                default:
                    break;
            }
            _currentGameState = value;
        }
    }

    private void Awake()
    {

        manager = this;
    }
    void Update()
    {
        switch (_currentGameState)
        {
            case GameState.Prepare:
                Debug.Log("Hazırlanıyorrrr");
                break;
            case GameState.MainGame:
                switch (currentMainGame)
                {
                    case MainGame.BossFight:
                        Debug.Log("BossFayttayım");
                        break;
                    case MainGame.Fight:
                        Debug.Log("Fayt");
                        break;
                    case MainGame.NarrativeScene:
                        Debug.Log("Narrativedeyim");
                        break;
                    default:
                        Debug.Log("Difault");
                        break;

                }
                Debug.Log("Hojgeldiniz");
                break;
            case GameState.FinishGame:
                break;
            default:
                Debug.Log("default");
                break;
        }
    }
}
