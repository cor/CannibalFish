using UnityEngine;
using System.Collections;

public class AIFishController : MonoBehaviour {

	Rigidbody2D rb;
	public PlayerController playerController;


	public float moveSpeedMultiplier = 0.05f;
	public float slowDownMultiplier = 0.999f;

	public float growValuePerLevel = 0.1f;
	public float growValuePerUpdate = 0.01f;

	public bool facingRight = true;

	public float deadZone = 0.2f;

	public bool enabled = false;

	public int currentLevel = 0;

	float initialWidth = 1f;

	public float horizontalSpeed = 3f;
	public float verticalSpeed = 0f;


	public int playerLayer = 8;

	bool alive = true; // a bool to prevent double collisions


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		initialWidth = transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {


		// PLAYER INPUT ISN'T NEEDED
		// -------------------------

		// float horizontalInput = Input.GetAxis("Horizontal");
		// float verticalInput = Input.GetAxis("Vertical");

		// Vector2 inputVector = new Vector2(horizontalInput, verticalInput);


		// rb.velocity += (moveSpeedMultiplier * inputVector);

		// if (Mathf.Abs(horizontalInput) <= deadZone) {
		// 	rb.velocity = new Vector2(rb.velocity.x * slowDownMultiplier, rb.velocity.y);
		// }

		// if (Mathf.Abs(verticalInput) <= deadZone) {
		// 	rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * slowDownMultiplier);
		// }


		if (enabled) {

			Vector2 newVelocity = new Vector2(horizontalSpeed, verticalSpeed);
			rb.velocity = newVelocity;
		}

	}

	void FixedUpdate() {

		float horizontalSpeed = rb.velocity.x;

		// flip the transform when we're facing the wrong direction
		if (horizontalSpeed > 0  && !facingRight)  {
			Flip ();
		}
		else if (horizontalSpeed < 0 && facingRight) {
			Flip ();
		}

		UpdateSize();
	}

	void Flip() {
		facingRight = !facingRight;
		Vector3 scale = transform.localScale;
		scale.x *= -1; // flip the transform
		transform.localScale = scale;
	}

	void UpdateSize() {

		Vector3 scale = transform.localScale;

		if (Mathf.Abs(scale.x) < initialWidth + currentLevel * growValuePerLevel - growValuePerUpdate) {
			scale.x *= (1 + growValuePerUpdate);
			scale.y *= (1 + growValuePerUpdate);
		}

		else if (Mathf.Abs(scale.x) > initialWidth + currentLevel * growValuePerLevel + growValuePerUpdate) {
			scale.x *= (1 - growValuePerUpdate);
			scale.y *= (1 - growValuePerUpdate);
		}

		transform.localScale = scale;

	}

	void OnCollisionEnter2D(Collision2D col) {
		if (col.gameObject.layer == playerLayer && alive) {
			alive = false;
			playerController.currentLevel++;
			Destroy(gameObject); 		
		}
	}
	
}
