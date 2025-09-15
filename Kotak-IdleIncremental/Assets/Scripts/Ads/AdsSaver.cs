using UnityEngine;

public class AdsSaver : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    Ads ads;

    void Start()
    {
        ads = GetComponent<Ads>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveAds()
    {
        // Save ads data here
        PlayerPrefs.SetInt("NoAds", ads.adsRemoved ? 1 : 0);

        PlayerPrefs.Save();
    }

    public void LoadAds()
    {
        // Load ads data here
        ads.adsRemoved = PlayerPrefs.GetInt("NoAds", 0) == 1;
    }
}
