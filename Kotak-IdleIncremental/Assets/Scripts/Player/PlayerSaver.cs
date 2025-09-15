using UnityEngine;

public class PlayerSaver : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Player player;
    void Start()
    {
        player = GetComponent<Player>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SavePlayer()
    {
        // Save player data here
        PlayerPrefs.SetFloat("Exp", player.exp);
        PlayerPrefs.SetFloat("Level", player.level);
        PlayerPrefs.SetFloat("Coin", player.coin);

        PlayerPrefs.Save();
    }

    public void LoadPlayer()
    {
        // Load player data here
        player.exp = PlayerPrefs.GetFloat("Exp", 0);
        player.level = PlayerPrefs.GetFloat("Level", 1);
        player.coin = PlayerPrefs.GetFloat("Coin", 10);

        player.SetExpToLevelUp();
        player.SetDamage(); //This is so bad omg
    }
}
