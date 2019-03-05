using UnityEngine;

public class Projectile : MonoBehaviour {
	public int hitDamage;
	public int explosionForce;
	public int explosionRadius;
	public float fireForce;
	public bool isLobbed = false;
	public float lifetime = 3f;

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player")) {
			other.attachedRigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius);
			Destroy(gameObject);
		}

		foreach (IHitTaker hitTaker in other.GetComponents<IHitTaker>()) {
			hitTaker.TakeHit(hitDamage);
		}
	}

	private void FixedUpdate() {
		lifetime -= Time.deltaTime;

		if (lifetime <= 0f) {
			Explode();
		}
	}

	private void Explode() {
		Rigidbody rb = gameObject.GetComponent<Rigidbody>();

		gameObject.GetComponent<Light>().enabled = true;

		foreach (Collider h in UnityEngine.Physics.OverlapSphere(transform.position, explosionRadius)) { 
     		Rigidbody r = h.GetComponent<Rigidbody>();
			if (r != null && !r.Equals(rb)) {
				r.AddExplosionForce(explosionForce, transform.position, explosionRadius);
			}
		}

		Destroy(gameObject, .5f);
	}

	public void Fire(Vector3 direction)
	{
		Rigidbody rb = gameObject.GetComponent<Rigidbody>();

		if (isLobbed) {
			rb.useGravity = true;
			Vector3 dir = Quaternion.AngleAxis(45, Vector3.forward) * direction ;
			dir.Normalize();
			rb.AddForce(dir * fireForce, ForceMode.Impulse);
		} else {
			rb.useGravity = false;
			direction.Normalize();
			rb.AddForce(direction * fireForce, ForceMode.Force);
		}

		rb.AddForce(direction * fireForce, ForceMode.Force);
	}
}
