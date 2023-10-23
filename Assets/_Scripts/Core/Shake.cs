using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Beatmate.Core
{
    public class Shake : MonoBehaviour
    {
        [SerializeField]
        private AnimationCurve _curve;

        [SerializeField]
        private float _duration;

        [SerializeField]
        private float _strengthMultiplier;

        private Vector3 _initialPosition;

        private void Awake()
        {
            _initialPosition = transform.position;
        }

        public void StartShake()
        {
            StartCoroutine(ShakeRoutine());
        }

        private IEnumerator ShakeRoutine()
        {
            float elapsedTime = 0f;

            while (elapsedTime < _duration)
            {
                elapsedTime += Time.deltaTime;
                float strength = _curve.Evaluate(elapsedTime / _duration);
                transform.position =
                    _initialPosition
                    + UnityEngine.Random.insideUnitSphere * strength * _strengthMultiplier;
                yield return null;
            }

            transform.position = _initialPosition;
        }
    }
}
