using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Beatmate.Movement;

namespace Beatmate.Control
{
    public class PlayerController : MonoBehaviour
    {
        private Mover _mover;

        private Vector2Int _movementVector;

        public static event Action<Vector2Int> OnMovementVectorChange;

        private void Awake()
        {
            _mover = GetComponent<Mover>();
        }

        private void Update()
        {
            _movementVector = GetMovementVector();
            OnMovementVectorChange?.Invoke(_movementVector);
            _mover.Move(_movementVector);
        }

        private Vector2Int GetMovementVector()
        {
            Vector2Int movementVector = Vector2Int.zero;

            if (Input.GetKey(KeyCode.W))
            {
                movementVector.y = 1;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                movementVector.y = -1;
            }

            if (Input.GetKey(KeyCode.A))
            {
                movementVector.x = -1;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                movementVector.x = 1;
            }

            return movementVector;
        }
    }
}
