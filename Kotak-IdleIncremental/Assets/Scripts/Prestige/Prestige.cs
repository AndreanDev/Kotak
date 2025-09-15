using UnityEngine;

public class Prestige : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public float prestigePoint;

    public int coinBoosterArtifactLevel; //50% boost per level, Boost coin gain in UpgradeCoin script IncreaseCoin() //Done
    public int damageBoosterArtifactLevel; //50% boost per level, Boost damage gain in UpgradeDamage script IncreaseTotalDamage() //Done
    public int prestigeBoosterArtifactLevel; //25% boost per level, Boost prestige gain in Prestige script GainPrestigePoint() //Done
    public int monsterSkipperArtifactLevel; //Skip 1 monster per level, Used in Stage script KilledMonster() //Done
    public int generatorAcceleratorArtifactLevel; //5% faster per level, Reduce duration time in UpgradeCoin script GetDurationTime() and UpgradeDamage script GetDurationTime() //Done

    public Player player;
    public Upgrade upgrade;
    public Monster monster;

    public PrestigeSaver saver;
    public PrestigeUI prestigeUI;

    public Stage stage;

    public void CallStart()
    {
        saver = GetComponent<PrestigeSaver>();
        prestigeUI = GetComponent<PrestigeUI>();

        // prestigeUI.CallStart();
    }

    public void SetAll()
    {
        prestigeUI.SetAllUI();
    }

    public void RunPrestige()
    {
        if (stage.currentStage >= 100)
        {
            GainPrestigePoint(player.level);

            ResetProgress();

            prestigeUI.SetAllUI();
            saver.SavePrestige();
        }
        else
        {
            Debug.LogWarning("You can only prestige before stage 100!");
        }
    }

    public void ResetProgress()
    {
        player.ResetPlayer();
        upgrade.ResetUpgrade();
        stage.ResetStage();

        monster.MonsterSpawn();
    }

    public float CalculatePrestigeGain()
    {
        return player.level * (1 + prestigeBoosterArtifactLevel * 0.25f);
    }

    public void GainPrestigePoint(float pointGain)
    {
        prestigePoint += (pointGain * (1 + prestigeBoosterArtifactLevel * 0.25f));
    }

    public int GetArtifactPrice(int artifact)
    {
        int level = 0;

        switch (artifact)
        {
            case 0: level = coinBoosterArtifactLevel; break;
            case 1: level = damageBoosterArtifactLevel; break;
            case 2: level = prestigeBoosterArtifactLevel; break;
            case 3: level = monsterSkipperArtifactLevel; break;
            case 4: level = generatorAcceleratorArtifactLevel; break;
            default: return int.MaxValue; // invalid
        }

        return (level + 1) * 100; // same formula for all artifacts
    }

    public void BuyArtifact(int artifact)
    {
        int price = GetArtifactPrice(artifact);

        if (prestigePoint < price)
        {
            Debug.LogWarning("Not enough Prestige Points to buy artifact " + artifact);
            return;
        }

        prestigePoint -= price;

        switch (artifact)
        {
            case 0: coinBoosterArtifactLevel++; break;
            case 1: damageBoosterArtifactLevel++; break;
            case 2: prestigeBoosterArtifactLevel++; break;
            case 3: monsterSkipperArtifactLevel++; break;
            case 4: generatorAcceleratorArtifactLevel++; break;
            default: return;
        }

        saver.SavePrestige();

        prestigeUI.SetAllUI();
    }
}
