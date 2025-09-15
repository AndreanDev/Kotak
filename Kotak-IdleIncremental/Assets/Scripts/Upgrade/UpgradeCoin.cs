using UnityEngine;
using System.Collections;

public class UpgradeCoin : MonoBehaviour
{
    public Upgrade upgrade;

    public SoundManager soundManager;

    public void CallStart()
    {
        upgrade = GetComponent<Upgrade>();
        SetCoinObject();

        StopAllCoroutines(); // prevent duplicate coroutines
        StartCoroutine(CoinIncrement());
    }

    public void IncreaseCoin(float coinGain)
    {
        float prestigeMultiplier = 1f + (0.5f * upgrade.prestige.coinBoosterArtifactLevel);
        float adsMultiplier = upgrade.ads.adsCoinBoost; // e.g. 1.25f

        upgrade.player.IncreaseCoin(coinGain * prestigeMultiplier * adsMultiplier); // Increase player coin

        upgrade.upgradeUI?.SetAllUI(); // safe null check
    }

    public float GetDurationTime(int index)
    {
        // Each level makes it 5% faster → multiply duration by (0.95 ^ level)
        float prestigeMultiplier = Mathf.Pow(0.95f, upgrade.prestige.generatorAcceleratorArtifactLevel);
        return upgrade.coinObject[index].duration * prestigeMultiplier;
    }

    public void SetCoinObject()
    {
        for (int i = 0; i < upgrade.coinObject.Length; i++)
        {
            upgrade.coinObject[i].LoadLevel();
            upgrade.coinObject[i].UpdateStats();
        }
    }

    public void UpgradeCoinLevel(int index)
    {
        if (upgrade.player.coin >= upgrade.coinObject[index].cost) // fixed
        {
            upgrade.player.DecreaseCoin(upgrade.coinObject[index].cost); // fixed

            upgrade.coinObject[index].level += 1;
            upgrade.coinObject[index].SaveLevel();
            upgrade.coinObject[index].UpdateStats(); // fixed

            upgrade.IncreaseTotalUpgrade();

            upgrade.saver.SaveUpgrade(); // fixed to save total upgrade

            upgrade.upgradeUI?.SetAllUI(); // safe null check

            soundManager.PlayUpgradeSfx(); // Play upgrade sound effect
        }
    }

    public IEnumerator CoinIncrement()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            for (int i = 0; i < upgrade.coinObject.Length; i++)
            {
                if (upgrade.coinObject[i].level >= 1)
                {
                    upgrade.coinObject[i].waitNow += 0.5f;

                    if (upgrade.coinObject[i].waitNow >= GetDurationTime(i))
                    {
                        upgrade.coinObject[i].waitNow = 0;
                        IncreaseCoin(upgrade.coinObject[i].cps);
                    }

                    upgrade.upgradeUI?.SetCoinSlider(i); // safe null check
                }
                else
                {
                    // Debug.Log($"Index {i} not unlocked yet");
                }
            }
        }
    }
    
}
