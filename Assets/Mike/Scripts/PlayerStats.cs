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
}

public enum PlayerAbilities
{
	Dash,
	Missile,
	Axes,
	Grab,
	Shield,
}
