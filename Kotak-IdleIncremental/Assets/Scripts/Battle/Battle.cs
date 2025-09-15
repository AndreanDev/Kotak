using UnityEngine;
using System.Collections;

public class Battle : MonoBehaviour
{
    public float cooldownTime = 2.5f;

    public Monster monsterBattle; //The monster currently in battle
    public Ads ads;
    public Player player;
    public Stage stage;

    public BattleAnimation battleAnimation;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void CallStart()
    {
        StartBattle();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartBattle()
    {
        monsterBattle.MonsterSpawn();

        StartCoroutine(Attacking());
    }

    public void EndBattle()
    {
        stage.KilledMonster();

        battleAnimation.PlayDeathAnimation();

        stage.stageUI.SetAllUI();

        player.GetExp(monsterBattle.expDrop); //Gain expDrop per monster defeated

        monsterBattle.MonsterSpawn();
        
    }

    public float GetCooldownTime()
    {
        //Get ads booster from Ads script, 0.5f if ads watched, else 1f
        float adsMultiplier = ads.adsDamageSpeedBoost;

        //Return cooldown time after considering all boosters
        return cooldownTime * adsMultiplier;
    }

    public void AttackMonster()
    {
        if (monsterBattle != null)
        {
            battleAnimation.PlayAttackAnimation();

            monsterBattle.TakeDamage(player.damage);
        }   
    }

    public IEnumerator Attacking()
    {
        while (true)
        {
            yield return new WaitForSeconds(GetCooldownTime());
            AttackMonster();
        }
    }
}
