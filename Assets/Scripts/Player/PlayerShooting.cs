using UnityEngine;

public class PlayerShooting : MonoBehaviour, IPickupTaker
{
	public int damagePerShot = 20;
	public float timeBetweenBullets = 0.15f;
	public float range = 100f;
	public GameObject projectilePrefab;

	float timer;
	Ray shootRay = new Ray();
	RaycastHit shootHit;
	int shootableMask;
	LineRenderer gunLine;
	float effectsDisplayTime = 0.2f;
	PlayerInput playerInput;

	void Awake()
	{
		shootableMask = LayerMask.GetMask("Shootable");
		gunLine = GetComponentInChildren<LineRenderer>();
		playerInput = GetComponentInParent<PlayerInput>();
	}


	void FixedUpdate()
	{
		timer += Time.deltaTime;

		if (playerInput.GetFire1() && timer >= timeBetweenBullets && Time.timeScale != 0) {
			ShootPrimary();
		}
		if (playerInput.GetFire2() && timer >= timeBetweenBullets && Time.timeScale != 0) {
			ShootSecondary();
		}

		if (timer >= timeBetweenBullets * effectsDisplayTime) {
			DisableEffects();
		}
	}


	public void DisableEffects()
	{
		gunLine.enabled = false;
	}


	void ShootPrimary()
	{
		timer = 0f;

		gunLine.enabled = true;
		Vector3 dischardPos = transform.position + (transform.forward * .5f);
		gunLine.SetPosition(0, dischardPos);

		shootRay.origin = dischardPos;
		shootRay.direction = transform.forward;

		if (Physics.Raycast(shootRay, out shootHit, range, shootableMask)) {
			foreach (IHitTaker hitTaker in shootHit.collider.GetComponents<IHitTaker>()) {
				hitTaker.TakeHit(damagePerShot);
			}

			gunLine.SetPosition(1, shootHit.point);
		} else {
			gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
		}
	}

	void ShootSecondary()
	{
		timer = 0f;

		Vector3 dischardPos = transform.position + (transform.forward * 2f) + (transform.up * .8f);

		Projectile projectile = Instantiate(projectilePrefab, dischardPos, transform.rotation).GetComponent<Projectile>();
		projectile.Fire(transform.forward);
	}

	public void PickupProjectile(GameObject prefab) {
		projectilePrefab = prefab;
	}
}
