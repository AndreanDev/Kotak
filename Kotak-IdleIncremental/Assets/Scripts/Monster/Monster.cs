using UnityEngine;

public class Monster : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public float maxHealth;
    public float health;
    public float expDrop;

    public Stage stage;
    public Battle battle;
    
    public MonsterUI monsterUI;
    void Start()
    {
        monsterUI = GetComponent<MonsterUI>();
        monsterUI.CallStart();
    }

    public void MonsterSpawn()
    {
        // HP formula
        maxHealth = (10f * stage.currentStage * Mathf.Pow(1.025f, stage.currentStage)) + 5f * stage.currentStage;

        health = maxHealth;

        monsterUI.SetHealthSlider();

        // EXP formula (random base between 3f and 5.5f)
        float expBase = Random.Range(3f, 5.5f);
        expDrop = expBase * stage.currentStage;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;

        monsterUI.SetHealthSlider();

        battle.battleAnimation.PlayDamageAnimation();

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        battle.EndBattle();
    }
}
