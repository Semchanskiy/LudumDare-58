using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;
[DefaultExecutionOrder(-3)]
public class AudioManager : MonoBehaviour
{

    [Serializable]
    public class SoundTagEntry
    {
        public string tag;
        public AudioClip[] clips;
    }

    [Header("Audio Sources")] 
    [SerializeField] private AudioSource MusicSource;
    [SerializeField] private List<AudioSource> SfxSource;

    [Header("Tagged Sound Clips")] 
    [SerializeField] private List<SoundTagEntry> SfxTaggedClips;
    [SerializeField] private List<SoundTagEntry> MusicTaggedClips;
    
    private Dictionary<string, AudioClip[]> _sfxDict;
    private Dictionary<string, AudioClip[]> _musicDict;

    public void Init()
    {
        
        G.audio = this;
        
        _sfxDict = new Dictionary<string, AudioClip[]>();
        _musicDict = new Dictionary<string, AudioClip[]>();
        
        foreach (var soundTagEntry in SfxTaggedClips)
        {
            if (!string.IsNullOrEmpty(soundTagEntry.tag))
                _sfxDict[soundTagEntry.tag] = soundTagEntry.clips;
        }

        foreach (var soundTagEntry in MusicTaggedClips)
        {
            if (!string.IsNullOrEmpty(soundTagEntry.tag))
                _musicDict[soundTagEntry.tag] = soundTagEntry.clips;
        }
    }
    
    public void PlaySFX(string tag, float volume = 1f,float speed = 1f)
    {
        if (!_sfxDict.TryGetValue(tag, out var clips)
            || clips.Length == 0)
        {
            Debug.LogWarning($"SFX tag '{tag}' not found or empty.");
            return;
        }

        var clip = clips[Random.Range(0, clips.Length)];

        AudioSource source = SfxSource[0];
        source.PlayOneShot(clip, volume);
        source.pitch = speed;
        SfxSource.Remove(source);
        SfxSource.Add(source);
    }
    
    public void PlayMusic(string tag, float volume = 1f, bool loop = true)
    {
        if (!_musicDict.TryGetValue(tag, out var clips)
            || clips.Length == 0)
        {
            Debug.LogWarning($"Music tag '{tag}' not found or empty.");
        }
        
        var clip = clips[Random.Range(0, clips.Length)];
        
        MusicSource.clip = clip;
        MusicSource.volume = volume;
        MusicSource.loop = loop;
        MusicSource.Play();
    }
}
