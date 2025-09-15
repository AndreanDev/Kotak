using UnityEngine;

public class UpgradeSaver : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Upgrade upgrade;
    void Start()
    {
        upgrade = GetComponent<Upgrade>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SaveUpgrade()
    {
        PlayerPrefs.SetFloat("UpgradeTotalDamage", upgrade.totalDamage);
        PlayerPrefs.SetFloat("UpgradeTotalUpgrade", upgrade.totalUpgrade);
        
        PlayerPrefs.Save();
    }

    public void LoadUpgrade()
    {
        upgrade.totalDamage = PlayerPrefs.GetFloat("UpgradeTotalDamage", 0f);
        upgrade.totalUpgrade = PlayerPrefs.GetFloat("UpgradeTotalUpgrade", 0f);

        //Called set all after load to update UI
        // upgrade.SetAll();
    }
}
