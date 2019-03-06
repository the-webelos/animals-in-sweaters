using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidbody;
	PlayerInput playerInput;
	int floorMask;

	private void Awake()
	{
		floorMask = LayerMask.GetMask("Floor");
		anim = GetComponent<Animator>();
		playerRigidbody = GetComponent<Rigidbody>();
		playerInput = GetComponent<PlayerInput>();
	}

	private void FixedUpdate()
	{
		Move(playerInput.GetHorizontal(), playerInput.GetVertical());
		Turning(playerInput.GetLookX(), playerInput.GetLookY());
        Jump();
		Animating();
	}

	private void Move(float h, float v)
	{
		movement.Set(h, 0f, v);
		movement = movement.normalized * speed * Time.deltaTime;
		playerRigidbody.MovePosition(transform.position + movement);
	}

	private void Turning(float x, float y)
	{
		if (System.Math.Abs(x) > double.Epsilon || System.Math.Abs(y) > double.Epsilon) {
			Quaternion rotation = Quaternion.LookRotation(new Vector3(x, 0f, y));
			playerRigidbody.MoveRotation(rotation);
		}
	}

    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && playerRigidbody.velocity.y == 0)
        {
            playerRigidbody.AddForce(Vector3.up * 300);
        }
    }

    private void Animating()
	{
        anim.SetBool("IsWalking", movement != Vector3.zero);
    }
}
