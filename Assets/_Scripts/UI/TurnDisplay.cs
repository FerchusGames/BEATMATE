using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Beatmate.Core;
using System;

namespace Beatmate.UI
{
    [RequireComponent(typeof(Image))]
    public class TurnDisplay : MonoBehaviour
    {
        private Image _displayBackground;

        [SerializeField]
        private Color _playerTurnColor;

        [SerializeField]
        private Color _enemyTurnColor;

        [SerializeField]
        private Color _dialogueColor;

        private void Awake()
        {
            GameManager.OnGameStateChange += UpdateTurnDisplay;
            _displayBackground = GetComponent<Image>();
        }

        private void UpdateTurnDisplay(GameState state)
        {
            switch (state)
            {
                case GameState.PlayerTurn:
                    _displayBackground.color = _playerTurnColor;
                    break;
                case GameState.EnemyTurn:
                    _displayBackground.color = _enemyTurnColor;
                    break;
                case GameState.Dialogue:
                    _displayBackground.color = _dialogueColor;
                    break;
                default:
                    break;
            }
        }
    }
}
