using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Beatmate.Core
{
    public class BeatManager : MonoBehaviour
    {
        public static BeatManager Instance { get; private set; }

        [SerializeField]
        private float _bpm;

        [SerializeField]
        private AudioSource _audioSource;

        [SerializeField]
        private Intervals[] _intervals;

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            foreach (Intervals interval in _intervals)
            {
                float sampledTime = (
                    _audioSource.timeSamples
                    / (_audioSource.clip.frequency * interval.GetIntervalLength(_bpm))
                );
                interval.CheckForNewInterval(sampledTime);
            }
        }

        public void StartAudio()
        {
            _audioSource.Play();
        }

        public void StopAudio()
        {
            _audioSource.Stop();
        }

        public bool IsAudioPlaying()
        {
            return _audioSource.isPlaying;
        }
    }

    [System.Serializable]
    public class Intervals
    {
        [SerializeField]
        private float _steps;

        [SerializeField]
        private UnityEvent _trigger;

        private int _lastInterval;

        public float GetIntervalLength(float bpm)
        {
            return 60f / bpm * _steps;
        }

        public void CheckForNewInterval(float interval)
        {
            if (Mathf.FloorToInt(interval) != _lastInterval)
            {
                _lastInterval = Mathf.FloorToInt(interval);
                _trigger.Invoke();
            }
        }
    }
}
