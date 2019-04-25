using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundManagerScript : MonoBehaviour {

    public enum Sound
    {
        MainMenu, PlayerAttack, PlayerDie, PlayerHurt, PlayerRun, SmallYetiHurt, stab, YetiDie, YetiHurt,
    };
    
    public static List<AudioClip> sounds = new List<AudioClip>();

    private static AudioSource audioSrcSfx;
    private static AudioSource audioSrcMusic;

    public Slider sfxVolume;
    public Slider musicVolume;

    private void Start()
    {
        sounds.Add(Resources.Load<AudioClip>("MainMenu"));
        sounds.Add(Resources.Load<AudioClip>("PlayerAttack"));
        sounds.Add(Resources.Load<AudioClip>("PlayerDie"));
        sounds.Add(Resources.Load<AudioClip>("PlayerHurt"));
        sounds.Add(Resources.Load<AudioClip>("PlayerJump"));
        sounds.Add(Resources.Load<AudioClip>("PlayerRun"));
        sounds.Add(Resources.Load<AudioClip>("SmallYetiHurt"));
        sounds.Add(Resources.Load<AudioClip>("stab"));
        sounds.Add(Resources.Load<AudioClip>("YetiDie"));
        sounds.Add(Resources.Load<AudioClip>("YetiHurt"));

        AudioSource[] sources = GetComponents<AudioSource>();
        audioSrcSfx = sources[0];
        audioSrcMusic = sources[1];

        audioSrcSfx.volume = PlayerPrefs.GetFloat("sfxVolume",0.95f);
        sfxVolume.value = audioSrcSfx.volume;
        audioSrcMusic.volume = PlayerPrefs.GetFloat("musicVolume",0.10f);
        musicVolume.value = audioSrcMusic.volume;
        /*
        if (SceneManager.GetActiveScene().buildIndex == 0)
            PlaySound(Sound.menu);
        else
            PlaySound(Sound.gamePlay);
            */
    }

    public void Update()
    {
    }

    public void SetMusicLevel()
    {
        audioSrcMusic.volume = musicVolume.value;
        PlayerPrefs.SetFloat("musicVolume", musicVolume.value);
    }

    public void SetSfxLevel()
    {
        audioSrcSfx.volume = sfxVolume.value;
        PlayerPrefs.SetFloat("sfxVolume", sfxVolume.value);
    }

    public static void PlaySound(Sound clip)
    {
        foreach(AudioClip a in sounds)
        {
            if(clip.ToString().Equals(a.name))
            {
                if (a.name == "gamePlay" || a.name == "menu")
                    audioSrcMusic.PlayOneShot(a);
                else
                    audioSrcSfx.PlayOneShot(a);
                return;
            }
        }
    }
}
