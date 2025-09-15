using UnityEngine;

public class FrameSetter : MonoBehaviour
{
    private const string PREF_KEY = "TargetFrameRate";

    // Default frame rate if no saved value
    public int defaultFrameRate = 60;

    public GameObject[] frameButton;
    void Start()
    {
        int savedFPS = PlayerPrefs.GetInt(PREF_KEY, defaultFrameRate);
        SetFrameRate(savedFPS);
    }

    public void SetFrameRate(int fps)
    {
        if (fps != 30 && fps != 60 && fps != 90 && fps != 120)
        {
            Debug.LogWarning($"Unsupported FPS value {fps}. Defaulting to {defaultFrameRate}.");
            fps = defaultFrameRate;
        }

        Application.targetFrameRate = fps;
        PlayerPrefs.SetInt(PREF_KEY, fps);
        PlayerPrefs.Save();

        // First, set all buttons to false
        for (int i = 0; i < frameButton.Length; i++)
        {
            frameButton[i].SetActive(false);
        }

        // Then activate only the selected one
        int index = (fps / 30) - 1;
        if (index >= 0 && index < frameButton.Length)
        {
            frameButton[index].SetActive(true);
        }

        Debug.Log($"Frame rate set to {fps}");
    }

    // Helper method if you want to hook it to UI buttons
    public void SetFPS30() => SetFrameRate(30);
    public void SetFPS60() => SetFrameRate(60);
    public void SetFPS90() => SetFrameRate(90);
    public void SetFPS120() => SetFrameRate(120);
}
