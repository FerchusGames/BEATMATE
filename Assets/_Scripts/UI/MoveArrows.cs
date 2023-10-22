using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Beatmate.Control;

namespace Beatmate.UI
{
    public class MoveArrows : MonoBehaviour
    {
        [SerializeField]
        private float _baseOpacity = 0.1f;

        [SerializeField]
        private Image _upArrow;

        [SerializeField]
        private Image _downArrow;

        [SerializeField]
        private Image _leftArrow;

        [SerializeField]
        private Image _rightArrow;

        private void OnEnable()
        {
            PlayerController.OnMovementVectorChange += UpdateArrowOpacity;
        }

        private void OnDisable()
        {
            PlayerController.OnMovementVectorChange -= UpdateArrowOpacity;
        }

        public void UpdateArrowOpacity(Vector2Int movementVector)
        {
            _upArrow.color = new Color(1, 1, 1, movementVector.y > 0 ? 1 : _baseOpacity);
            _downArrow.color = new Color(1, 1, 1, movementVector.y < 0 ? 1 : _baseOpacity);
            _leftArrow.color = new Color(1, 1, 1, movementVector.x < 0 ? 1 : _baseOpacity);
            _rightArrow.color = new Color(1, 1, 1, movementVector.x > 0 ? 1 : _baseOpacity);
        }
    }
}
