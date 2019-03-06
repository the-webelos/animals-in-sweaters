using UnityEngine;

public class PlayerAttack : MonoBehaviour, IPickupTaker
{
	public float timeBetweenAttacks = 0.15f;
	public GameObject primaryAttackPrefab;
	public GameObject secondaryAttackPrefab;

	float timer;
	PlayerInput playerInput;

	void Awake() {
		playerInput = GetComponentInParent<PlayerInput>();
	}

	void FixedUpdate() {
		timer += Time.deltaTime;

		if (playerInput.GetFire1() && timer >= timeBetweenAttacks && Time.timeScale != 0) {
			Attack(primaryAttackPrefab);
		}
		if (playerInput.GetFire2() && timer >= timeBetweenAttacks && Time.timeScale != 0) {
			Attack(secondaryAttackPrefab);
		}
	}

	void Attack(GameObject weaponPrefab) {
		timer = 0f;

		if (weaponPrefab != null) {
			GameObject weapon = Instantiate(weaponPrefab, transform.position, transform.rotation);
			weapon.GetComponent<IWeapon>().Attack();
		}
	}

	public void PickupWeapon(GameObject prefab) {
		secondaryAttackPrefab = prefab;
	}
}