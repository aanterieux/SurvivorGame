using System.Linq;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    private enum PlayOrder
    {
        FROM_START,
        FROM_END,
        RANDOM
    }

    [SerializeField] private bool useSelfAudioSource = true;
    [SerializeField] private AudioSource audioSource = null;

    [Space]
    [Space]

    [SerializeField] private AudioResource[] audioToPlay = null;
    [SerializeField] private PlayOrder playOrder = PlayOrder.FROM_START;
    [SerializeField] private bool playOnStart = true;

    private int audioIndex = 0;
    private bool audioIsPaused = false;

    private bool NoAudio
    {
        get => (audioToPlay.Length == 0);
    }
    private bool CantPlay
    {
        get => (!audioSource || NoAudio);
    }

    public bool AudioIsPlaying
    {
        get =>
            (audioSource != null)
                ? audioSource.isPlaying
                : false;
    }
    public bool AudioIsPaused
    {
        get => audioIsPaused;
    }

    private void Awake()
    {
        if (useSelfAudioSource && !audioSource)
        {
            audioSource = GetComponent<AudioSource>();

            if (CantPlay)
            {
                audioSource = transform.AddComponent<AudioSource>();
            }
        }
    }


    private void OnEnable()
    {
        if (NoAudio)
        {
            LogNoAudioWarning();
            return;
        }

        if (audioSource && playOnStart)
        {
            switch (playOrder)
            {
                case PlayOrder.FROM_END: audioToPlay.Reverse(); break;
                case PlayOrder.RANDOM:
                    {
                        if (audioToPlay.Length > 1)
                        {
                            Shuffle(audioToPlay);
                        }
                    }
                    break;
            }

            audioSource.resource = audioToPlay[0];
            audioSource.Play();
        }
    }

    private void Update()
    {
        if (audioSource &&
            !audioSource.loop &&
            !audioSource.isPlaying &&
            audioSource.time > 0.05f)
        {
            PlayNextAudio();
        }
    }


    private void LogNoAudioWarning([CallerMemberName] string _functionName = "", TextColour _textColour = TextColour.WHITE)
    {
        ConsoleHelper.WarningColour(_textColour, $"[AudioPlayer.{_functionName}] Cannot play audio: AudioToPlay is empty.");
    }

    // Fisher-Yates algorithm
    private void Shuffle(object[] _array)
    {
        int n = _array.Length;

        for (int i = n - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            // Swap
            (_array[i], _array[j]) = (_array[j], _array[i]);
        }
    }


    public void PlayCurrentAudio()
    {
        if (CantPlay)
        {
            return;
        }

        audioSource.Play();
        audioIsPaused = false;
    }
    public void PauseCurrentAudio()
    {
        if (CantPlay)
        {
            return;
        }

        audioSource.Pause();
        audioIsPaused = true;
    }
    public void ResumeCurrentAudio()
    {
        if (CantPlay)
        {
            return;
        }

        audioSource.UnPause();
        audioIsPaused = false;
    }
    public void StopCurrentAudio()
    {
        if (CantPlay)
        {
            return;
        }

        audioSource.Stop();
        audioIsPaused = false;
    }
    public void RestartCurrentAudio()
    {
        if (CantPlay)
        {
            return;
        }

        audioSource.Stop();
        audioSource.Play();

        audioIsPaused = false;
    }

    public void PlayNextAudio()
    {
        if (CantPlay)
        {
            return;
        }

        audioIndex++;

        if (audioIndex > audioToPlay.Length - 1)
        {
            audioIndex = 0;
        }

        audioSource.Stop();
        audioSource.resource = audioToPlay[audioIndex];
        audioSource.Play();
    }
    public void PlayPreviousAudio()
    {
        if (CantPlay)
        {
            return;
        }

        audioIndex--;

        if (audioIndex < 0)
        {
            audioIndex = audioToPlay.Length - 1;
        }

        audioSource.Stop();
        audioSource.resource = audioToPlay[audioIndex];
        audioSource.Play();
    }
}
