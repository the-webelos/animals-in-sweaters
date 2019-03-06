using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkingLifetime : MonoBehaviour
{
	public float lifetime;

	float lifetimeRemaining;
	Renderer rdr;
	Light lights;
	float blinkOffset = 0f;
	float blinkRate = 5f;

	private void Start() {
		lifetimeRemaining = lifetime;
		rdr = GetComponentInChildren<Renderer>();
		lights = GetComponent<Light>();
	}

	// Update is called once per frame
	void Update()
	{
		lifetimeRemaining -= Time.deltaTime;

		if (lifetimeRemaining < lifetime * .2f) {
			BlinkFast();
		} else if (lifetimeRemaining < lifetime * .8f) {
			BlinkSlow();
		}

		if (lifetimeRemaining <= 0) {
			Destroy(gameObject);
		}
	}

	private void BlinkSlow() {
		Blink(5f);
	}

	private void BlinkFast()
	{
		Blink(10f);
	}

	private void Blink(float multiplier)
	{
		// Lerp the multiplier so we get a smooth transition from slow to fast blink
		float mult = Mathf.Lerp(blinkRate, multiplier, blinkOffset);

	    float blinkingAlpha = (.5f + .5f * Mathf.Cos(blinkOffset * mult));

		// Update the alpha for the material
		Color c = rdr.material.color;
		c.a = blinkingAlpha;
		rdr.material.color = c;

		//update the lights
		lights.intensity = blinkingAlpha;

		blinkOffset += Time.deltaTime;
	}
}
