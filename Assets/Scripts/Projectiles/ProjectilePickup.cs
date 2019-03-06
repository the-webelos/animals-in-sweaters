using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePickup : MonoBehaviour
{
	public GameObject pickupPrefab;

	private void OnTriggerEnter(Collider other) {
		IPickupTaker taker = other.GetComponentInChildren<IPickupTaker>();

		if (taker != null) {
			taker.PickupProjectile(pickupPrefab);

			Destroy(gameObject);
		}
	}
}
