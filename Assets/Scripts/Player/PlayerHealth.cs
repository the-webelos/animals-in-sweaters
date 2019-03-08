using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class PlayerHealth : MonoBehaviour, IHitTaker {
	public int startingHealth = 100;
	public int currentHealth;
	//public Slider healthSlider;
	//public Image damageImage;
	public AudioClip deathClip;
	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

	Animator anim;
	AudioSource playerAudio;
	PlayerMovement playerMovement;
	PlayerAttack playerAttack;
	bool isDead;

	void Awake() {
		anim = GetComponent<Animator>();
		playerAudio = GetComponent<AudioSource>();
		playerMovement = GetComponent<PlayerMovement>();
		playerAttack = GetComponentInChildren<PlayerAttack>();
		currentHealth = startingHealth;
	}

	void OnTriggerEnter(Collider other) {
		if (other.tag == "DeathTrigger") {
			currentHealth = 0;
		}
	}


	void Update() {
		//if (damaged) {
		//    damageImage.color = flashColour;
		//} else {
		//    damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		//}
		if (currentHealth <= 0) {
			Death();
		}
	}


	public void TakeHit(int damage) {
		if (isDead) { return; }

		currentHealth -= damage;

//		healthSlider.value = currentHealth;

		playerAudio.Play();
	}


	void Death() {
		if (isDead) { return; }

		isDead = true;

		anim.SetTrigger("Die");

		playerAudio.clip = deathClip;
		playerAudio.Play();

		playerMovement.enabled = false;
		playerAttack.enabled = false;
	}
}