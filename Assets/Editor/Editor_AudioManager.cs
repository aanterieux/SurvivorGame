using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AudioManager))]
public class Editor_AudioManager : Editor
{
    private AudioManager manager = null;
    private Color playPauseColour = Color.white;
    private string playPauseText = "";

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        manager = (AudioManager)(target);

        if (!manager)
        {
            return;
        }

        bool audioIsPlaying = manager.AudioIsPlaying;
        bool audioIsPaused = manager.AudioIsPaused;

        if (audioIsPaused)
        {
            playPauseColour = Color.cyan;
            playPauseText = "Resume";
        }
        else
        {
            playPauseColour = Color.yellow;
            playPauseText = "Pause";
        }

        GUILayout.BeginHorizontal();
        GUI.backgroundColor = Color.green;

            if (GUILayout.Button("Play"))
            {
                if (audioIsPaused)
                {
                    manager.ResumeCurrentAudio();
                }
                else
                {
                    manager.PlayCurrentAudio();
                }
            }

        GUI.backgroundColor = playPauseColour;

            if ((audioIsPlaying || !audioIsPaused) &&
                GUILayout.Button(playPauseText))
            {
                if (audioIsPaused)
                {
                    manager.RestartCurrentAudio();
                }
                else
                {
                    manager.PauseCurrentAudio();
                }
            }
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        GUI.backgroundColor = Color.red;

            if ((audioIsPlaying || !audioIsPaused) &&
                GUILayout.Button("Stop"))
            {
                manager.StopCurrentAudio();
            }

        GUI.backgroundColor = Color.blue;

            if ((audioIsPlaying || !audioIsPaused) &&
                GUILayout.Button("Restart"))
            {
                manager.RestartCurrentAudio();
            }
        GUI.backgroundColor = Color.white;
        GUILayout.EndHorizontal();

        GUILayout.BeginHorizontal();
        if (GUILayout.Button("<"))
        {
            manager.PlayNextAudio();
        }

        if (GUILayout.Button(">"))
        {
            manager.PlayPreviousAudio();
        }
        GUILayout.EndHorizontal();
    }
}
