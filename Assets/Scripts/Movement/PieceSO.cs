using UnityEngine;

[CreateAssetMenu(fileName = "Piece", menuName = "Pieces/Make a New Piece", order = 0)]
public class PieceSO : ScriptableObject
{
    [SerializeField]
    private Sprite _blueSprite;

    [SerializeField]
    private Sprite _redSprite;

    [SerializeField]
    private Sprite _greySprite;

    [field: SerializeField]
    public Vector2Int[] PossibleMovements { get; private set; }

    [field: Header("Only for the Pawn piece")]
    [field: SerializeField]
    public Vector2Int[] PossibleAttacks { get; private set; }

    [field: SerializeField]
    public Vector2Int[] FirstMovement { get; private set; }
}
