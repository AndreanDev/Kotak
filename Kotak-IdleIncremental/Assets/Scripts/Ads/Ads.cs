using UnityEngine;

public class Ads : MonoBehaviour
{
    public float adsCoinBoost; //Become 1.25f when player watches ad, Called in UpgradeCoin script IncreaseCoin() //Done
    public float adsDamageBoost; //Become 1.25f when player watches ad, Called in UpgradeDamage script IncreaseTotalDamage() //Done
    public float adsDamageSpeedBoost = 1f; //Become 0.5f when player watches ad //Called in Battle script GetCooldownTime() //Done

    public bool adsRemoved;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public AdsSaver saver;
    public void CallStart()
    {
        saver = GetComponent<AdsSaver>();

        adsCoinBoost = 1f;
        adsDamageBoost = 1f;
        adsDamageSpeedBoost = 1f;
    }

    public void WatchAdForCoinBoost()
    {
        adsCoinBoost = 1.25f;
        // Implement ad watching logic here
    }

    public void WatchAdForDamageBoost()
    {
        adsDamageBoost = 1.25f;
        // Implement ad watching logic here
    }

    public void WatchAdForDamageSpeedBoost()
    {
        adsDamageSpeedBoost = 0.5f;
        // Implement ad watching logic here
    }

    public void RemoveAds()
    {
        adsRemoved = true;
        saver.SaveAds();
        // Implement ad removal logic here

    }
}
