using UnityEngine;

public class Projectile : MonoBehaviour, IWeapon {
	public GameObject explosionSystem;
	public bool explodeOnContact = true;

	public int hitDamage;
	public int explosionForce;
	public float explosionRadius;
	public float fireForce;
	public float fireAngle = 0f;
	public float lifetime = 3f;

	private void OnTriggerEnter(Collider other) {
		if (explodeOnContact) {
			Explode();
		}
	}

	private void FixedUpdate() {
		lifetime -= Time.deltaTime;

		if (lifetime <= 0f) {
			Explode();
		}
	}

	public void Explode() {
		lifetime = 0f;

		if (explosionSystem) { 
	    	GameObject explosion = Instantiate(explosionSystem, transform.position, Quaternion.identity);
    	}

		Rigidbody rb = gameObject.GetComponent<Rigidbody>();

		foreach (Collider h in UnityEngine.Physics.OverlapSphere(transform.position, explosionRadius)) {
			Rigidbody r = h.GetComponent<Rigidbody>();
			if (r != null && !r.Equals(rb)) {
				r.AddExplosionForce(explosionForce, transform.position, explosionRadius, 0.0f, ForceMode.Impulse);
			}

			foreach (IHitTaker hitTaker in h.GetComponents<IHitTaker>()) {
				hitTaker.TakeHit(hitDamage);
			}

			foreach (Projectile projectile in h.GetComponents<Projectile>()) {
				if (projectile.lifetime > 0f) {
					projectile.Explode();
				}
			}
		}

		Destroy(gameObject);
	}

	public void Attack() {
		transform.position += (transform.forward * 2f) + (transform.up * .5f);

		Rigidbody rb = gameObject.GetComponent<Rigidbody>();

		rb.useGravity = true;
	    Vector3 dir = Quaternion.AngleAxis(fireAngle*-1f, transform.right) * transform.forward ;
		rb.AddForce(dir * fireForce, ForceMode.Impulse);
	}
}
