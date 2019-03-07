using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;
    public float jumpMultiplier = 5f;

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
		if (System.Math.Abs(h) > double.Epsilon || System.Math.Abs(v) > double.Epsilon) {
			Vector3 direction = new Vector3(h, 0f, v).normalized * speed;
			playerRigidbody.AddForce(direction, ForceMode.Acceleration);
		}
//		movement.Set(h, 0f, v);
//		movement = movement.normalized * speed * Time.deltaTime;
//		playerRigidbody.MovePosition(transform.position + movement);
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
//        if(playerInput.GetJump() && System.Math.Abs(playerRigidbody.velocity.y) <= double.Epsilon)
		if (playerInput.GetJump()) {
    		playerRigidbody.AddForce(Vector3.up * jumpMultiplier, ForceMode.Acceleration);
        }
    }

    private void Animating()
	{
		anim.SetBool("IsWalking", Mathf.Abs(playerRigidbody.velocity.x) > .01f || Mathf.Abs(playerRigidbody.velocity.z) > .01f);
    }
}
