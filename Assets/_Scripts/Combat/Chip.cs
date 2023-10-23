using UnityEngine;
using Beatmate.Core;

namespace Beatmate.Combat
{
    public class Chip : MonoBehaviour
    {
        [SerializeField]
        private PieceSO _pieceSO;

        private SpriteRenderer _spriteRenderer;

        public bool IsEnabled { get; private set; } = true;

        private bool _isSelected = false;

        private Transform _player;

        [SerializeField]
        private float _unselectedOpacity = 0.25f;

        [SerializeField]
        private float _hoverOpacity = 0.5f;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _player = GameObject.FindGameObjectWithTag("Player").transform;

            _spriteRenderer.sprite = _pieceSO.RedSprite;
        }

        private void Update()
        {
            if (!_isSelected)
                return;
            HighlightAttackTiles();
        }

        private void HighlightAttackTiles()
        {
            TileManager.Instance.UnhighlightAllTiles();

            Vector2Int[] attackOffsets = _pieceSO.IsPawn
                ? _pieceSO.PossibleAttacks
                : _pieceSO.PossibleMovements;

            foreach (Vector2Int attackOffset in attackOffsets)
            {
                Vector3 tilePosition =
                    _player.position + new Vector3(attackOffset.x, attackOffset.y, 0);

                Debug.Log(tilePosition);

                Tile tile = TileManager.Instance.GetTile(tilePosition);

                if (tile != null)
                {
                    tile.Hightlight();
                }
            }
        }

        public void Disable()
        {
            IsEnabled = false;
            _spriteRenderer.sprite = _pieceSO.GreySprite;
        }

        public void Select()
        {
            ChipManager.Instance.UnselectAllChips();
            _isSelected = true;
            _spriteRenderer.color = new Color(1, 1, 1, 1);
        }

        public void Unselect()
        {
            _isSelected = false;
            _spriteRenderer.color = new Color(1, 1, 1, _unselectedOpacity);
            TileManager.Instance.UnhighlightAllTiles();
        }

        private bool CanSelect()
        {
            return IsEnabled && !_isSelected;
        }

        private void OnMouseDown()
        {
            if (CanUnselect())
            {
                Unselect();
            }
            else if (CanSelect())
            {
                Select();
            }
        }

        private bool CanUnselect()
        {
            return IsEnabled && _isSelected;
        }

        private void OnMouseEnter()
        {
            if (CanSelect())
            {
                _spriteRenderer.color = new Color(1, 1, 1, _hoverOpacity);
            }
        }

        private void OnMouseExit()
        {
            if (CanSelect())
            {
                _spriteRenderer.color = new Color(1, 1, 1, _unselectedOpacity);
            }
        }
    }
}
