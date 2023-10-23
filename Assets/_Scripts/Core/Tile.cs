using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Beatmate.Core
{
    public class Tile : MonoBehaviour
    {
        [SerializeField]
        private Sprite _defaultSprite;

        [SerializeField]
        private Sprite _highlightedSprite;

        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void Hightlight()
        {
            _spriteRenderer.sprite = _highlightedSprite;
        }

        public void Unhighlight()
        {
            _spriteRenderer.sprite = _defaultSprite;
        }
    }
}
