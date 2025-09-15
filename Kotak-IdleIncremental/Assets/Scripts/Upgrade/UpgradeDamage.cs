using UnityEngine;
using System.Collections;

public class UpgradeDamage : MonoBehaviour
{
    public Upgrade upgrade;

    public SoundManager soundManager;

    public void CallStart()
    {
        upgrade = GetComponent<Upgrade>();
        SetDamageObject();

        StopAllCoroutines(); // avoid duplicate coroutines
        StartCoroutine(DamageIncrement());
    }

    public void IncreaseTotalDamage(float damageGain)
    {
        float prestigeMultiplier = 1f + (0.1f * upgrade.prestige.damageBoosterArtifactLevel);
        float adsMultiplier = upgrade.ads.adsDamageBoost; // e.g. 1.25f

        upgrade.totalDamage += damageGain * prestigeMultiplier * adsMultiplier;

        upgrade.saver.SaveUpgrade(); //To save total damage

        upgrade.player.SetDamage(); // Update player damage
    }

    public float GetDurationTime(int index)
    {
        // Each level makes it 5% faster → multiply duration by (0.95 ^ level)
        float prestigeMultiplier = Mathf.Pow(0.95f, upgrade.prestige.generatorAcceleratorArtifactLevel);
        return upgrade.damageObject[index].duration * prestigeMultiplier;
    }

    public void SetDamageObject()
    {
        for (int i = 0; i < upgrade.damageObject.Length; i++)
        {
            upgrade.damageObject[i].LoadLevel();
            upgrade.damageObject[i].UpdateStats();
            print("Damage object " + i + " level: " + upgrade.damageObject[i].level);
        }
    }

    public void UpgradeDamageLevel(int index)
    {
        if (upgrade.player.coin >= upgrade.damageObject[index].cost)
        {
            upgrade.player.DecreaseCoin(upgrade.damageObject[index].cost); // fixed

            upgrade.damageObject[index].level += 1;
            upgrade.damageObject[index].SaveLevel();
            upgrade.damageObject[index].UpdateStats();

            upgrade.IncreaseTotalUpgrade();

            upgrade.saver.SaveUpgrade(); // fixed to save total upgrade

            upgrade.upgradeUI?.SetAllUI(); // safe null check

            soundManager.PlayUpgradeSfx(); // Play upgrade sound effect
        }
    }

    public IEnumerator DamageIncrement()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);

            for (int i = 0; i < upgrade.damageObject.Length; i++)
            {
                if (upgrade.damageObject[i].level >= 1)
                {
                    upgrade.damageObject[i].waitNow += 0.5f;

                    if (upgrade.damageObject[i].waitNow >= GetDurationTime(i))
                    {
                        upgrade.damageObject[i].waitNow = 0;
                        IncreaseTotalDamage(upgrade.damageObject[i].dps);
                    }

                    upgrade.upgradeUI?.SetDamageSlider(i);
                }
                else
                {
                    // Debug.Log($"Damage index {i} not unlocked yet");
                }
            }
        }
    }
}
