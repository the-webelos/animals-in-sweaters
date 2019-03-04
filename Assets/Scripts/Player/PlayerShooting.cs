﻿using UnityEngine;

public class PlayerShooting : MonoBehaviour {
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float range = 100f;

    float timer;
    Ray shootRay = new Ray();
    RaycastHit shootHit;
    int shootableMask;
    ParticleSystem gunParticles;
    LineRenderer gunLine;
    AudioSource gunAudio;
    Light gunLight;
    float effectsDisplayTime = 0.2f;
	PlayerInput playerInput;

    void Awake() {
        shootableMask = LayerMask.GetMask("Shootable");
        gunParticles = GetComponent<ParticleSystem>();
        gunLine = GetComponent<LineRenderer>();
        gunAudio = GetComponent<AudioSource>();
        gunLight = GetComponent<Light>();
		playerInput = GetComponentInParent<PlayerInput>();
    }


    void FixedUpdate() {
        timer += Time.deltaTime;

		if (playerInput.GetFire1() && timer >= timeBetweenBullets && Time.timeScale != 0) {
            Shoot();
        }

        if (timer >= timeBetweenBullets * effectsDisplayTime) {
            DisableEffects();
        }
    }


    public void DisableEffects() {
        gunLine.enabled = false;
        gunLight.enabled = false;
    }


    void Shoot() {
        timer = 0f;

        gunAudio.Play();

        gunLight.enabled = true;

        gunParticles.Stop();
        gunParticles.Play();

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if (Physics.Raycast(shootRay, out shootHit, range, shootableMask)) {
            //shootHit.collider.SendMessage("TakeHit", new Bullet(damagePerShot, shootHit.point), SendMessageOptions.DontRequireReceiver);
            foreach(IHitTaker hitTaker in shootHit.collider.GetComponents<IHitTaker>()) {
                hitTaker.TakeHit(damagePerShot, shootHit.point, (shootHit.point - shootRay.origin)/Time.deltaTime, 0.2f);
            }
            /*EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();
            if(enemyHealth != null)
            {
                enemyHealth.TakeDamage (damagePerShot, shootHit.point);
            }

            EnemyMovement enemyMovement = shootHit.collider.GetComponent<EnemyMovement>();
            if (enemyMovement != null)
            {
                enemyMovement.KnockBack(shootRay.direction);
            }*/

            gunLine.SetPosition(1, shootHit.point);
        } else {
            gunLine.SetPosition(1, shootRay.origin + shootRay.direction * range);
        }
    }
}
