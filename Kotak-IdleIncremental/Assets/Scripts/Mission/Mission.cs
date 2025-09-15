using UnityEngine;

public class Mission : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int missionPoint; //1% damage boost per point, used in Player script SetDamage()

    public float missionGoal; //Goal to complete mission

    public Upgrade upgrade;
    public MissionSaver saver;
    public MissionUI missionUI;

    public Player player;
    public void CallStart()
    {
        saver = GetComponent<MissionSaver>();
        missionUI = GetComponent<MissionUI>();

        missionUI.CallStart();
    }
    
    public void SetAll()
    {
        missionUI.SetAllUI();
    }

    public void CompleteMission()
    {
        if(upgrade.totalUpgrade >= missionGoal)
        {
            missionPoint += 1;
            missionGoal += 25; //Increase goal by 25 each mission completed

            saver.SaveMission();
            missionUI.SetAllUI();

            //Update player damage
            player.SetDamage();
        }
    }
}
