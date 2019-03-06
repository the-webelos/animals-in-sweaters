using UnityEngine;

public class Projectile : MonoBehaviour {
	public GameObject explosionSystem;
	public bool explodeOnContact = true;

	public int hitDamage;
	public int explosionForce;
	public int explosionRadius;
	public float fireForce;
	public float fireAngle = 0f;
	public float lifetime = 3f;

	private void OnTriggerEnter(Collider other)
	{
		foreach (IHitTaker hitTaker in other.GetComponents<IHitTaker>()) {
			hitTaker.TakeHit(hitDamage);
		}

		if (explodeOnContact) {
			Explode();
			Destroy(gameObject);
		}
	}

	private void FixedUpdate() {
		lifetime -= Time.deltaTime;

		if (lifetime <= 0f) {
			Explode();
		}
	}

	private void Explode() {
		if (explosionSystem) { 
	    	GameObject explosion = Instantiate(explosionSystem, transform.position, Quaternion.identity);
    	}

		Rigidbody rb = gameObject.GetComponent<Rigidbody>();

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

		rb.useGravity = true;
	    Vector3 dir = Quaternion.AngleAxis(fireAngle*-1f, transform.right) * direction ;
		rb.AddForce(dir * fireForce, ForceMode.Impulse);
	}
}
