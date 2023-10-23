using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

namespace Beatmate.Core
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        public GameState State;

        public static event Action<GameState> OnGameStateChange;
        public static event Action OnPlayerTurn;
        public static event Action OnEnemyTurn;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            UpdateGameState(GameState.Dialogue);
        }

        public void UpdateGameState(GameState newState)
        {
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

            State = newState;

            OnGameStateChange?.Invoke(newState);
        }

        public void TurnSwitch()
        {
            switch (State)
            {
                case GameState.PlayerTurn:
                    UpdateGameState(GameState.EnemyTurn);
                    break;
                case GameState.EnemyTurn:
                    UpdateGameState(GameState.PlayerTurn);
                    break;
                default:
                    break;
            }
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
            OnEnemyTurn?.Invoke();
            Debug.Log("Enemy turn");
        }

        private void HandlePlayerTurn()
        {
            OnPlayerTurn?.Invoke();
            if (!BeatManager.Instance.IsAudioPlaying())
            {
                BeatManager.Instance.StartAudio();
            }
            Debug.Log("Player turn");
        }

        private void HandleDialogue()
        {
            StartCoroutine(
                DialogueManager.Instance.TypeText("I've been acting weird? It's probably nothing")
            );
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
}
