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

	private void OnTriggerEnter(Collider other)
	{
		foreach (IHitTaker hitTaker in other.GetComponents<IHitTaker>()) {
			hitTaker.TakeHit(hitDamage);
		}

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

		Destroy(gameObject);
	}

	public void Attack()
	{
		transform.position += (transform.forward * 1f) + (transform.up * .5f);

		Rigidbody rb = gameObject.GetComponent<Rigidbody>();

		rb.useGravity = true;
	    Vector3 dir = Quaternion.AngleAxis(fireAngle*-1f, transform.right) * transform.forward ;
		rb.AddForce(dir * fireForce, ForceMode.Impulse);
	}
}
