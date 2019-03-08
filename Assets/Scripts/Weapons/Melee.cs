using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour, IWeapon {
	public int hitDamage;

	Vector3 startRotation;
	float swingDuration = 2f;

	private void OnTriggerEnter(Collider other) {
		foreach (IHitTaker hitTaker in other.GetComponents<IHitTaker>()) {
			hitTaker.TakeHit(hitDamage);
		}
	}

	void Update() {
		transform.eulerAngles = Vector3.Lerp(startRotation, new Vector3(1, 0, 1), Time.deltaTime);
	}

	public void Attack() {
		transform.position += transform.up * .5f;

		transform.Rotate(Vector3.up, 90f);

		startRotation = transform.eulerAngles;

		Destroy(gameObject, 2f);
	}
}
