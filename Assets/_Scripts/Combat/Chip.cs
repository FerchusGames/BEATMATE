using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Beatmate.Movement;
using PlasticPipe.PlasticProtocol.Messages;

namespace Beatmate.Combat
{
    public class Chip : MonoBehaviour
    {
        [SerializeField]
        private PieceSO _pieceSO;

        private SpriteRenderer _spriteRenderer;

        public bool IsEnabled { get; private set; } = true;

        private bool _isSelected = false;

        [SerializeField]
        private float _unselectedOpacity = 0.25f;

        [SerializeField]
        private float _hoverOpacity = 0.5f;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
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
