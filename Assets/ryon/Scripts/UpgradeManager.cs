using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public UpgradeDatabase upgradeDatabase;
    public PlayerStats playerStats;
    void Start()
    {
    }

    public Upgrade GetRandomUpgrade()
    {
        if (upgradeDatabase.upgrades.Count == 0)
        {
            Debug.LogWarning("No upgrades found in the database.");
            return null;
        }

        int randomIndex = Random.Range(0, upgradeDatabase.upgrades.Count);
        return upgradeDatabase.upgrades[randomIndex];
    }

    public void UpdatePlayerStats(Upgrade upgrade)
    {
        Debug.Log(upgrade.name + "fsadasdsadsada");
        switch (upgrade.name) {
            case "HealthIncrease":
                playerStats.playerMaxHealth += upgrade.value;
                break;
            case "DamageIncrease":
                playerStats.playerDamage += upgrade.value;
                break;
            case "LifeSteal":
                playerStats.playerLifeSteal += upgrade.value;
                break;
            case "MoveSpeed":
                playerStats.playerMoveSpeed += upgrade.value;
                break;

        }
    }

}
