using UnityEngine;
using Beatmate.Core;

namespace Beatmate.Combat
{
    public class ChipManager : MonoBehaviour
    {
        public static ChipManager Instance { get; private set; }

        [SerializeField]
        private Chip[] _chips;

        private int _chipAmount;

        private void Awake()
        {
            Instance = this;
            _chipAmount = _chips.Length;
        }

        public void UnselectAllChips()
        {
            foreach (Chip chip in _chips)
            {
                chip.Unselect();
            }
        }

        public void DisableLastChip()
        {
            for (int i = _chips.Length - 1; i >= 0; i--)
            {
                if (_chips[i].IsEnabled)
                {
                    _chips[i].Disable();
                    _chipAmount--;
                    break;
                }
            }

            if (HasLost())
            {
                GameManager.Instance.UpdateGameState(GameState.Defeat);
            }
        }

        private bool HasLost()
        {
            return _chipAmount == 0;
        }
    }
}
