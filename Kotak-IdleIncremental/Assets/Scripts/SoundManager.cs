using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource clickSource;
    public AudioSource upgradeSource;
    public AudioSource attackSource;

    public AudioSource backgroundMusicSource;
    
    // Mute/Unmute Background Music
    public void MuteMusic()
    {
        if (backgroundMusicSource != null)
            backgroundMusicSource.mute = true;
    }

    public void UnmuteMusic()
    {
        if (backgroundMusicSource != null)
            backgroundMusicSource.mute = false;
    }

    // Mute/Unmute All SFX
    public void MuteSfx()
    {
        foreach (AudioSource sfx in GetAllSfxSources())
        {
            if (sfx != null) sfx.mute = true;
        }
    }

    public void UnmuteSfx()
    {
        foreach (AudioSource sfx in GetAllSfxSources())
        {
            if (sfx != null) sfx.mute = false;
        }
    }

    // Helper to get all SFX sources
    private AudioSource[] GetAllSfxSources()
    {
        return new AudioSource[]
        {
            clickSource,
            upgradeSource,
            attackSource,
        };
    }

    // SFX Play Methods
    public void PlayClickingSfx()
    {
        if (clickSource != null) clickSource.Play();
        else Debug.LogWarning("Click AudioSource is not assigned!");
    }

    public void PlayUpgradeSfx()
    {
        if (upgradeSource != null) upgradeSource.Play();
        else Debug.LogWarning("Upgrade AudioSource is not assigned!");
    }

    public void PlayAttackSfx()
    {
        if (attackSource != null) attackSource.Play();
        else Debug.LogWarning("Attack AudioSource is not assigned!");
    }

    public void PlayBackgroundMusic()
    {
        if (backgroundMusicSource != null && !backgroundMusicSource.isPlaying)
            backgroundMusicSource.Play();
    }

    public void PauseBackgroundMusic()
    {
        if (backgroundMusicSource != null && backgroundMusicSource.isPlaying)
            backgroundMusicSource.Pause();
    }
}
