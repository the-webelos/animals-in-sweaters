using UnityEngine;

public class PlayerAttack : MonoBehaviour, IPickupTaker
{
	public float timeBetweenPrimaryAttacks = 0.15f;
    public float timeBetweenSecondaryAttacks = 1f;
	public GameObject primaryAttackPrefab;
	public GameObject secondaryAttackPrefab;

    private float primaryAttackTimer;
    private float secondaryAttackTimer;
    PlayerInput playerInput;

	void Awake() {
		playerInput = GetComponentInParent<PlayerInput>();

        primaryAttackTimer = timeBetweenPrimaryAttacks;
        secondaryAttackTimer = timeBetweenSecondaryAttacks;
	}

	void FixedUpdate() {
		if (playerInput.GetFire1()) {
            primaryAttackTimer += Time.deltaTime;
            if (primaryAttackTimer >= timeBetweenPrimaryAttacks && Time.timeScale != 0) {
                primaryAttackTimer = 0f;
                Attack(primaryAttackPrefab);
            }
		}

		if (playerInput.GetFire2()) {
            secondaryAttackTimer += Time.deltaTime;
            if (secondaryAttackTimer >= timeBetweenSecondaryAttacks && Time.timeScale != 0) {
                secondaryAttackTimer = 0f;
                Attack(secondaryAttackPrefab);
            }
		}
	}

	void Attack(GameObject weaponPrefab) {
		if (weaponPrefab != null) {
			GameObject weapon = Instantiate(weaponPrefab, transform.position, transform.rotation);
			weapon.GetComponent<IWeapon>().Attack();
		}
	}

	public void PickupWeapon(GameObject prefab) {
		secondaryAttackPrefab = prefab;
	}
}