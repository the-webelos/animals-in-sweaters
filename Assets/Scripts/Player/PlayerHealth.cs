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
    public AudioClip hurtClip;
	public float flashSpeed = 5f;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);

	Animator anim;
	AudioSource playerAudio;
	bool isDead;

	void Awake() {
		anim = GetComponent<Animator>();
		playerAudio = GetComponent<AudioSource>();
		currentHealth = startingHealth;
	}

	public bool IsDead() { return isDead; }

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

        playerAudio.clip = hurtClip;
		playerAudio.Play();
	}

	void Death() {
		if (isDead) { return; }

		isDead = true;

		anim.SetTrigger("Die");

		playerAudio.clip = deathClip;
		playerAudio.Play();
	}
}