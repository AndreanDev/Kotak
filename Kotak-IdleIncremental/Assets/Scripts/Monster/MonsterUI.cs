using UnityEngine;
using UnityEngine.UI;
public class MonsterUI : MonoBehaviour
{
    public Slider healthSlider;

    private Monster monster;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void CallStart()
    {
        monster = GetComponent<Monster>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void SetHealthSlider()
    {
        float percentage = monster.health / monster.maxHealth;
        healthSlider.value = percentage;
    }
}
