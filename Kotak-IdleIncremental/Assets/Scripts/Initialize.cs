using UnityEngine;

public class Initialize : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Player player;
    public Upgrade upgrade;
    public Ads ads;
    public Prestige prestige;
    public Mission mission;
    public Stage stage;
    public Battle battle;
    void Start()
    {
        upgrade.CallStart();
        ads.CallStart();
        prestige.CallStart();
        mission.CallStart();
        player.CallStart();
        stage.CallStart();

        ads.saver.LoadAds();
        prestige.saver.LoadPrestige();
        mission.saver.LoadMission();
        upgrade.saver.LoadUpgrade();
        player.saver.LoadPlayer();
        stage.saver.LoadStage();

        upgrade.upgradeUI.CallStart(); //This is bad practice but whatever
        mission.missionUI.CallStart(); //This is bad practice but whatever
        prestige.prestigeUI.CallStart(); //This is bad practice but whatever
        player.playerUI.CallStart(); //This is bad practice but whatever

        battle.CallStart();
    }

}
