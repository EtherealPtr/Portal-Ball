using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    public Sounds[] audioFiles;
    public static AudioControl instance;

	// Use this for initialization
	void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

		foreach (Sounds i in audioFiles)
        {
            i.source = gameObject.AddComponent<AudioSource>();
            i.source.clip = i.clip;
            i.source.volume = i.volume;
            i.source.pitch = i.pitch;
            i.source.loop = i.loop;
        }
	}

    private void Start()
    {
        PlayAudioFile("GameTheme");
    }

    public void PlayAudioFile(string name)
    {
        Sounds aSound = Array.Find(audioFiles, Sounds => Sounds.name == name);

        // Check if the sound was not find 
        if (aSound == null)
        {
            Debug.LogWarning("The sound: " + name + " was not found!"); 
            return;
        }

        // Play the sound 
        aSound.source.Play();
    }

    public void StopAudioFile(string name)
    {
        Sounds aSound = Array.Find(audioFiles, Sounds => Sounds.name == name);

        // Check if the sound was not find 
        if (aSound == null)
        {
            Debug.LogWarning("The sound: " + name + " was not found!");
            return;
        }

        // Play the sound 
        aSound.source.Stop();
    }
}
