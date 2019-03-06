using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour, IWeapon
{
	public int hitDamage;

	public void Attack()
	{
		Debug.Log("MELEE");
	}
}
