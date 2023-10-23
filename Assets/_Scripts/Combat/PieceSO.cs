using UnityEngine;

namespace Beatmate.Combat
{
    [CreateAssetMenu(fileName = "Piece", menuName = "Pieces/Make a New Piece", order = 0)]
    public class PieceSO : ScriptableObject
    {
        [SerializeField]
        public Sprite BlueSprite;

        [SerializeField]
        public Sprite RedSprite;

        [SerializeField]
        public Sprite GreySprite;

        [field: SerializeField]
        public bool IsPawn { get; private set; }

        [field: SerializeField]
        public Vector2Int[] PossibleMovements { get; private set; }

        [field: Header("Only for the Pawn piece")]
        [field: SerializeField]
        public Vector2Int[] PossibleAttacks { get; private set; }

        [field: SerializeField]
        public Vector2Int[] FirstMovement { get; private set; }
    }
}
