using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public static event Action<GameState> OnGameStateChange;

    void Awake()
    {
        Instance = this;
    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.Dialogue:
                HandleDialogue();
                break;
            case GameState.PlayerTurn:
                HandlePlayerTurn();
                break;
            case GameState.EnemyTurn:
                HandleEnemyTurn();
                break;
            case GameState.Victory:
                HandleVictory();
                break;
            case GameState.Defeat:
                HandleDefeat();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState), newState, null);
        }

        OnGameStateChange?.Invoke(newState);
    }

    private void HandleDefeat()
    {
        throw new NotImplementedException();
    }

    private void HandleVictory()
    {
        throw new NotImplementedException();
    }

    private void HandleEnemyTurn()
    {
        throw new NotImplementedException();
    }

    private void HandlePlayerTurn()
    {
        throw new NotImplementedException();
    }

    private void HandleDialogue()
    {
        throw new NotImplementedException();
    }
}

public enum GameState
{
    Dialogue = 0,
    PlayerTurn = 1,
    EnemyTurn = 2,
    Victory = 3,
    Defeat = 4,
}
