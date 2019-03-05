using UnityEngine;

public class Projectile : MonoBehaviour {
	public int hitDamage;
	Vector3 hitPoint;

	private void OnTriggerEnter(Collider other)
	{
		Debug.Log("HIT: " + other);
		if (other.CompareTag("Player")) {
			Debug.Log("EXPLODE");
			other.attachedRigidbody.AddExplosionForce(1000, transform.position, 1);
			Destroy(gameObject);
		}
	}
}
