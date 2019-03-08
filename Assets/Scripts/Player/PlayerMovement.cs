using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6f;
    public float jumpMultiplier = 5f;
    public int maxJumps = 1;
    public float minTimeBetweenJumps = 0.5f;
    public AudioSource walkingAudioSrc;

	Animator anim;
	Rigidbody playerRigidbody;
	PlayerInput playerInput;
	int floorMask;

    private bool grounded = true;
    private int jumps = 0;
    private float jumpTimer;

	void Awake() {
		floorMask = LayerMask.GetMask("Floor");
		anim = GetComponent<Animator>();
		playerRigidbody = GetComponent<Rigidbody>();
		playerInput = GetComponent<PlayerInput>();
        jumpTimer = minTimeBetweenJumps;
	}

    void FixedUpdate() {
		Move(playerInput.GetHorizontal(), playerInput.GetVertical());
		Turning(playerInput.GetLookX(), playerInput.GetLookY());
        Jump();
		Animating();
	}

    private void OnCollisionEnter(Collision collision) {
        // if colliding with the environment, reset jumping to allow user to jump off environment
        if (collision.gameObject.layer == 10) {
            grounded = true;
            jumps = 0;
            jumpTimer = minTimeBetweenJumps;
        }
    }

    private void OnCollisionExit(Collision collision) {
        // if leaving collision with environment, reset previous jump values
        if (collision.gameObject.layer == 10) {
            grounded = false;
        }
    }

    private void Move(float h, float v) {
		if (System.Math.Abs(h) > double.Epsilon || System.Math.Abs(v) > double.Epsilon) {
			Vector3 direction = new Vector3(h, 0f, v).normalized * speed;
			playerRigidbody.AddForce(direction, ForceMode.Acceleration);
		}
//		movement.Set(h, 0f, v);
//		movement = movement.normalized * speed * Time.deltaTime;
//		playerRigidbody.MovePosition(transform.position + movement);
	}

	private void Turning(float x, float y) {
		if (System.Math.Abs(x) > double.Epsilon || System.Math.Abs(y) > double.Epsilon) {
			Quaternion rotation = Quaternion.LookRotation(new Vector3(x, 0f, y));
			playerRigidbody.MoveRotation(rotation);
		}
	}

    private void Jump() {
        jumpTimer += Time.deltaTime;
        if ((grounded || jumps < maxJumps) && playerInput.GetJump()) {
            if (jumpTimer >= minTimeBetweenJumps) {
                jumpTimer = 0f;
                jumps += 1;
                playerRigidbody.AddForce(Vector3.up * 300, ForceMode.Acceleration);
            }
        }
    }

    private void Animating() {
        bool isWalking = Mathf.Abs(playerRigidbody.velocity.x) > .01f || Mathf.Abs(playerRigidbody.velocity.z) > .01f;

        anim.SetBool("IsWalking", isWalking);

        if (isWalking && grounded && !walkingAudioSrc.isPlaying)
        {
            walkingAudioSrc.Play();
        }
    }
}
