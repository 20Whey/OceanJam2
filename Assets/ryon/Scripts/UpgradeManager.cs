using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public UpgradeDatabase upgradeDatabase;
    public PlayerStats playerStats;
    public HealthScript healthScript;
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
                healthScript.updateNewHealth();
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
            case "Barrier":
                if (!playerStats.unlockedAbilities.Contains(PlayerAbilities.Shield))
                {
                    playerStats.unlockedAbilities.Add(PlayerAbilities.Shield);
                    playerStats.playerShieldLevel += upgrade.value;
                }
                else
                {
                    playerStats.playerShieldLevel += upgrade.value;

                }
                break;
            case "AttackSpeed":
                playerStats.playerFireRate -= upgrade.value;
                break;
            case "ProjectileSpeedIncrease":
                playerStats.playerProjectileSpeed += upgrade.value;
                break;
            case "SeekingMissile":
                if (!playerStats.unlockedAbilities.Contains(PlayerAbilities.Missile))
                {
                    playerStats.unlockedAbilities.Add(PlayerAbilities.Missile);
                    playerStats.playerMissileLevel += upgrade.value;
                }
                else
                {
                    playerStats.playerMissileLevel += upgrade.value;

                }
                break;
            case "RotationSpeed":
                playerStats.playerRotationSpeed += upgrade.value;
                break;
            case "DashLength":
                playerStats.playerDashLength += upgrade.value;
                break;
            case "ViralSpinners":
                if (!playerStats.unlockedAbilities.Contains(PlayerAbilities.Axes))
                {
                    playerStats.unlockedAbilities.Add(PlayerAbilities.Axes);

                    playerStats.playerAxeLevel += upgrade.value;
                }
                else
                {
                    playerStats.playerAxeLevel += upgrade.value;

                }
                break;
            case "Grabber":
                if (!playerStats.unlockedAbilities.Contains(PlayerAbilities.Grab))
                {
                    playerStats.unlockedAbilities.Add(PlayerAbilities.Grab);

                    playerStats.playerGrabLevel += upgrade.value;
                }
                else
                {
                    playerStats.playerGrabLevel += upgrade.value;

                }
                break;

        }
    }

}
