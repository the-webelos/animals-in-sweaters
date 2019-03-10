using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	PlayerInput playerInput;
	PlayerColor playerColor;
	PlayerMovement playerMovement;
	PlayerAttack playerAttack;
	PlayerHealth playerHealth;
	int index;

	void Awake()
	{
		playerInput = GetComponent<PlayerInput>();
		playerColor = GetComponentInChildren<PlayerColor>();
		playerMovement = GetComponent<PlayerMovement>();
		playerAttack = GetComponentInChildren<PlayerAttack>();
        playerHealth = GetComponent<PlayerHealth>();
	}

    private void Start()
    {
        Setup();
    }

    void Update()
	{
		if (playerHealth.IsDead()) {
			Freeze();
		}
	}

	public void Freeze()
	{
		playerMovement.enabled = false;
		playerAttack.enabled = false;
	}

	public void SetPlayerIndex(int index)
	{
		this.index = index;
	}

	void Setup() {
		playerInput.playerIndex = index;

		if (index == 0) {
			playerInput.useMouseLook = false;
		} else {
			playerInput.useMouseLook = true;
		}

		playerInput.SetLabels();
		playerColor.SetColor(new Color(index * 1f, 1f, 1f, 1f));
	}

	public PlayerHealth GetPlayerHealth() {
		return playerHealth;
	}

    public void SetPlayerHealthSlider(Slider slider)
    {
        playerHealth.healthSlider = slider;
    }
}