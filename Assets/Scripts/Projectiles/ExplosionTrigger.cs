using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionTrigger : MonoBehaviour
{
	public GameObject explosionSystem;

    void OnTriggerEnter(Collider other) {
		GameObject explosion = Instantiate(explosionSystem, transform.position, Quaternion.identity);
    }
}
