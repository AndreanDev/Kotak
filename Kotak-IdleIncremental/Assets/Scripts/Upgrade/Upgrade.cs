using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public float totalDamage;

    public float totalUpgrade;

    public UpgradeDamageObject[] damageObject;
    public UpgradeCoinObject[] coinObject;

    public FormatNumber format;
    public CalculateUpgrade calculate;
    public UpgradeSaver saver;
    public UpgradeUI upgradeUI;
    public UpgradeCoin upgradeCoin;
    public UpgradeDamage upgradeDamage;

    public Player player;
    public Ads ads;
    public Prestige prestige;
    public Mission mission;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void CallStart()
    {
        saver = GetComponent<UpgradeSaver>();
        upgradeUI = GetComponent<UpgradeUI>();

        upgradeCoin = GetComponent<UpgradeCoin>();
        upgradeCoin.CallStart();

        upgradeDamage = GetComponent<UpgradeDamage>();
        upgradeDamage.CallStart();

        // upgradeUI.CallStart();z
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void IncreaseTotalUpgrade()
    {
        totalUpgrade += 1;

        mission.missionUI.SetAllUI(); //Update mission progress UI

        saver.SaveUpgrade();
    }

    public void ResetUpgrade()
    {
        totalDamage = 0;

        foreach (UpgradeDamageObject obj in damageObject)
        {
            obj.ResetLevel();
        }

        foreach (UpgradeCoinObject obj in coinObject)
        {
            obj.ResetLevel();
        }

        saver.SaveUpgrade();
        
        upgradeUI.SetAllUI();
    }
}
