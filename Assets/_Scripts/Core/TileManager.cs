using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Beatmate.Core
{
    public class TileManager : MonoBehaviour
    {
        public static TileManager Instance { get; private set; }

        [SerializeField]
        private GameObject _tilesParent;

        private Tile[] _tiles;

        private void Awake()
        {
            Instance = this;
            _tiles = _tilesParent.GetComponentsInChildren<Tile>();
        }

        public void UnhighlightAllTiles()
        {
            foreach (Tile tile in _tiles)
            {
                tile.Unhighlight();
            }
        }

        public Tile GetTile(Vector3 tilePosition)
        {
            foreach (Tile tile in _tiles)
            {
                if (tile.transform.position == tilePosition)
                {
                    return tile;
                }
            }
            return null;
        }
    }
}
