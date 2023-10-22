using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Beatmate.Core
{
    [RequireComponent(typeof(AudioSource))]
    public class DialogueManager : MonoBehaviour
    {
        public static DialogueManager Instance { get; private set; }

        [Header("Audio")]
        [SerializeField]
        private AudioClip _dialogueTypingSoundClip;
        private AudioSource _audioSource;

        [SerializeField]
        private bool _shouldCutoffAudio = true;

        [SerializeField]
        private float _typingInterval = 0.05f;

        [SerializeField]
        private int _characterSoundInterval = 2;

        [SerializeField]
        private TextMeshProUGUI _dialogueText;

        [SerializeField]
        private float _dialoguePause = 2f;

        private void Awake()
        {
            Instance = this;
            _audioSource = GetComponent<AudioSource>();
        }

        public IEnumerator TypeText(string text)
        {
            _dialogueText.text = "";
            int currentDisplayedCharacterCount = 0;
            foreach (char c in text)
            {
                currentDisplayedCharacterCount++;
                _dialogueText.text += c;
                PlayDialogueSound(currentDisplayedCharacterCount);
                yield return new WaitForSeconds(_typingInterval);
            }
            yield return new WaitForSeconds(_dialoguePause);
            GameManager.Instance.UpdateGameState(GameState.PlayerTurn);
        }

        private void PlayDialogueSound(int currentDisplayedCharacterCount)
        {
            if (currentDisplayedCharacterCount % _characterSoundInterval == 0)
            {
                if (_shouldCutoffAudio)
                {
                    _audioSource.Stop();
                }
                _audioSource.PlayOneShot(_dialogueTypingSoundClip);
            }
        }
    }
}
