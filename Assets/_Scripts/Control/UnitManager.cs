using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Beatmate.Control
{
    public class UnitManager : MonoBehaviour
    {
        public static UnitManager Instance { get; private set; }

        void Awake()
        {
            Instance = this;
        }
    }
}
