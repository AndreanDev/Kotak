using UnityEngine;

public class Stage : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float currentStage;
    public int monsterPerStage;
    public int monsterDefeated;

    public StageSaver saver;
    public StageUI stageUI;

    public Prestige prestige;
    public void CallStart()
    {
        saver = GetComponent<StageSaver>();

        saver.CallStart();

        stageUI = GetComponent<StageUI>();

        stageUI.CallStart();
    }

    public void SetAll()
    {
        SetMonsterPerStage();

        stageUI.SetAllUI();
    }

    public void SetMonsterPerStage()
    {
        monsterPerStage = 5 + ((int)currentStage / 20);
    }

    public void KilledMonster()
    {
        float skipper = prestige.monsterSkipperArtifactLevel;

        //Each level of monsterSkipperArtifactLevel allows player to skip 1 monster per kill
        monsterDefeated += 1 + (int)skipper;

        if (monsterDefeated >= monsterPerStage)
        {
            currentStage += 1;
            monsterDefeated = 0;
            saver.SaveStage();
            SetAll();

            prestige.prestigeUI.DisablePrestigeButton();
        }

        saver.SaveStage();
    }
    
    public void ResetStage()
    {
        currentStage = 1;
        monsterDefeated = 0;
        saver.SaveStage();
        SetAll();
    }
}
