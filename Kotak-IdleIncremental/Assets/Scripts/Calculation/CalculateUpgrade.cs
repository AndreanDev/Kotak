using UnityEngine;

public class CalculateUpgrade : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    float GetUpgradeIncrement(float level, float increment, float baseIncrement)
    {
        int per500 = Mathf.FloorToInt(level / 500f);
        int per1000 = Mathf.FloorToInt(level / 1000f);
        int per2500 = Mathf.FloorToInt(level / 2500f);
        int per5000 = Mathf.FloorToInt(level / 5000f);
        int per10000 = Mathf.FloorToInt(level / 10000f);
        return baseIncrement + (per500 * increment * 1) + (per1000 * increment * 3) + (per2500 * increment * 5) + (per5000 * increment * 10) + (per10000 * increment * 50);
    }

    float GetNextCoinBoostTierStart(float level)
    {
        float nextTier = Mathf.Ceil((level + 1f) / 500f) * 500f;

        print("Next tier: " + nextTier);
        return nextTier;
    }

    public (float level, float totalCost) CalculateUpgradesExponent(float coins, float baseCost, float currentLevel, float multi)
    {
        if (baseCost <= 0f || coins <= 0f || multi <= 1f) return (0f, 0f); // multi must be > 1 to avoid invalid logs

        float multiplier = Mathf.Pow(multi, currentLevel);
        float level = Mathf.Floor(Mathf.Log((coins * (multi - 1f)) / (baseCost * multiplier) + 1f, multi));
        float totalCost = baseCost * multiplier * (Mathf.Pow(multi, level) - 1f) / (multi - 1f);

        print("Total Level = " + level + " , Total Cost = " + totalCost);

        return (level, totalCost);
    }

    // public (int levelGained, float totalCost) CalculateUpgradeLinear(float gold, float baseCost, float scaleFactor, float currentLevel)
    // {

    //     float A = 0.5f * scaleFactor;
    //     float B = baseCost + scaleFactor * (1f + currentLevel - 0.5f);
    //     float C = -gold;

    //     float discriminant = B * B - 4f * A * C;

    //     if (discriminant < 0f)
    //         return (0, 0f); // Cannot afford any upgrades

    //     float sqrtDiscriminant = Mathf.Sqrt(discriminant);
    //     float n = (-B + sqrtDiscriminant) / (2f * A);
    //     int levelGained = Mathf.FloorToInt(n);

    //     // Compute total cost again to return it
    //     float totalCost = levelGained * baseCost
    //         + scaleFactor * (levelGained * (1f + currentLevel) + levelGained * (levelGained - 1f) / 2f);

    //     print("Coin Upgrade level Total" + levelGained);
    //     print("Coin Upgrade cost Total" + totalCost);

    //     return (levelGained, totalCost);
    // }
    
    public (int levelGained, float totalCost) CalculateUpgradeLinear(
    float gold,
    float baseCost,
    float scaleFactor,
    float currentLevel)
    {
        float A = 0.5f * scaleFactor;
        float B = baseCost + scaleFactor * (1f + currentLevel - 0.5f);
        float C = -gold;

        float discriminant = B * B - 4f * A * C;

        if (discriminant < 0f)
            return (0, 0f); // Cannot afford any upgrades

        float sqrtDiscriminant = Mathf.Sqrt(discriminant);
        float n = (-B + sqrtDiscriminant) / (2f * A);
        int levelGained = Mathf.FloorToInt(n);

        // ✅ Always cap to next tier
        int currentLevelInt = Mathf.FloorToInt(currentLevel);
        int nextTier = Mathf.CeilToInt((currentLevel + 1f) / 500f) * 500;
        int levelsToNextTier = nextTier - currentLevelInt;
        levelGained = Mathf.Min(levelGained, levelsToNextTier);

        // Calculate actual total cost of those levels
        float totalCost = levelGained * baseCost
            + scaleFactor * (levelGained * (1f + currentLevel) + levelGained * (levelGained - 1f) / 2f);

        print("Coin Upgrade level Total: " + levelGained);
        print("Coin Upgrade cost Total: " + totalCost);

        return (levelGained, totalCost);
    }

}
