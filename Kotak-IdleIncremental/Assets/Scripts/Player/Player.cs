using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float coin;
    public float exp;
    public float expToNextLevel;
    public float level;
    public float damage;

    public Upgrade upgrade;
    public Mission mission;
    public Prestige prestige;

    public PlayerSaver saver;
    public PlayerUI playerUI;

    public void CallStart()
    {
        saver = GetComponent<PlayerSaver>();
        playerUI = GetComponent<PlayerUI>();

    }

    public void SetAll()
    {
        playerUI.SetAllUI();

        SetDamage();
        SetExpToLevelUp();
    }

    public void SetDamage()
    {
        float MissionMultiPlier = 1f + (0.01f * mission.missionPoint);
        float baseDamage = 1f + upgrade.totalDamage;

        damage = MissionMultiPlier * baseDamage / 3f;
    }

    public void SetExpToLevelUp()
    {
        expToNextLevel = 10f + (level * 10f) + Mathf.Pow(level, 1.2f);
    }

    public void GetExp(float expGain)
    {
        exp += expGain;

        if (exp >= expToNextLevel)
        {
            level += 1;
            exp -= expToNextLevel;
            SetExpToLevelUp();

            prestige.prestigeUI.PrestigePointUI(); //Update prestige point UI to enable prestige button
        }

        saver.SavePlayer();
        playerUI.SetExpUI();
    }

    public void IncreaseCoin(float coinGain)
    {
        coin += coinGain + (float)mission.missionPoint * 5;

        saver.SavePlayer();
        playerUI.SetCoinUI();
    }

    public void DecreaseCoin(float coinLoss)
    {
        coin -= coinLoss;

        saver.SavePlayer();
        playerUI.SetCoinUI(); //Only update coin UI
    }

    public void ResetPlayer()
    {
        coin = 10f;
        exp = 0f;
        level = 1f;
        damage = 1f;

        SetExpToLevelUp();
        SetDamage();

        saver.SavePlayer();
        playerUI.SetAllUI();
    }
}
