using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
	public HashSet<PlayerAbilities> unlockedAbilities = new HashSet<PlayerAbilities>();
	public float playerHealth = 100f;
	public float playerMaxHealth = 100f;
	public float playerLifeSteal = 0f;
	public float playerDamage = 10f;
	public float playerMoveSpeed = 10f;
	public float playerDashLength = 8f;
	public float playerDashRate = 1f;
	public float playerFireRate = 1f;
	public float playerRotationSpeed = 0.5f;
	public float playerProjectileSpeed = 1f;
	public float playerMissileRate = 7f;
	public float playerShieldLevel = 0;
	public float playerAxeLevel = 0;
	public float playerGrabLevel = 0;
	public float playerMissileLevel = 0;

}

public enum PlayerAbilities
{
	Dash,
	Missile,
	Axes,
	Grab,
	Shield,
}
