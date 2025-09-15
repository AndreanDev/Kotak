using UnityEngine;

public class SoundSetting : MonoBehaviour
{
    public SoundManager soundManager;

    private const string MusicMutedKey = "MusicMuted";
    private const string SfxMutedKey = "SfxMuted";

    public GameObject muteMusicButton;
    public GameObject unmuteMusicButton;
    public GameObject muteSFXButton;
    public GameObject unmuteSFXButton;

    void Start()
    {
        // Apply saved settings on game start
        ApplySavedSettings();
    }

    public void ToggleMusic()
    {
        bool isMuted = PlayerPrefs.GetInt(MusicMutedKey, 0) == 1;
        isMuted = !isMuted;

        PlayerPrefs.SetInt(MusicMutedKey, isMuted ? 1 : 0);
        PlayerPrefs.Save();

        if (isMuted)
            soundManager.MuteMusic();
        else
            soundManager.UnmuteMusic();
        
        UpdateMusicButtons(isMuted); 
    }

    public void ToggleSfx()
    {
        bool isMuted = PlayerPrefs.GetInt(SfxMutedKey, 0) == 1;
        isMuted = !isMuted;

        PlayerPrefs.SetInt(SfxMutedKey, isMuted ? 1 : 0);
        PlayerPrefs.Save();

        if (isMuted)
            soundManager.MuteSfx();
        else
            soundManager.UnmuteSfx();

        UpdateSfxButtons(isMuted);
    }

    private void ApplySavedSettings()
    {
        bool musicMuted = PlayerPrefs.GetInt(MusicMutedKey, 0) == 1;
        bool sfxMuted = PlayerPrefs.GetInt(SfxMutedKey, 0) == 1;

        if (musicMuted)
            soundManager.MuteMusic();
        else
            soundManager.UnmuteMusic();

        if (sfxMuted)
            soundManager.MuteSfx();
        else
            soundManager.UnmuteSfx();

        UpdateMusicButtons(musicMuted);
        UpdateSfxButtons(sfxMuted);
    }

    private void UpdateMusicButtons(bool isMuted)
    {
        if (muteMusicButton != null) muteMusicButton.SetActive(!isMuted);
        if (unmuteMusicButton != null) unmuteMusicButton.SetActive(isMuted);
    }

    private void UpdateSfxButtons(bool isMuted)
    {
        if (muteSFXButton != null) muteSFXButton.SetActive(!isMuted);
        if (unmuteSFXButton != null) unmuteSFXButton.SetActive(isMuted);
    }
}
