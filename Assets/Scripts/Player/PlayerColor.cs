using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColor : MonoBehaviour
{
	public Color color = new Color(1f, 0f, 0f, 1f);

	void Start() {
		SetColor(color);
	}

	public void SetColor(Color newColor) {
		color = newColor;

		SkinnedMeshRenderer rndr = GetComponent<SkinnedMeshRenderer>();
		rndr.material.color = color;
	}
}
