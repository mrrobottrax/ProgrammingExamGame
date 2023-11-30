using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
	[SerializeField] float speed;
	[SerializeField] float gravity = -10;
	[SerializeField] LayerMask layerMask;

	Vector3 moveDirection = Vector3.zero;
	Vector3 velocity = Vector3.zero;
	bool movingX;

	bool grounded = true;

	Rigidbody rb;

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Start()
	{
		movingX = false;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (moveDirection == Vector3.zero)
			{
				// First movement
				GameManager.singleton.OnGameStart();
			}

			SwitchDirection();
		}
	}

	void SwitchDirection()
	{
		movingX = !movingX;

		if (movingX)
		{
			moveDirection.x = 1;
			moveDirection.y = 0;
			moveDirection.z = 0;
		}
		else
		{
			moveDirection.x = 0;
			moveDirection.y = 0;
			moveDirection.z = 1;
		}
	}

	private void FixedUpdate()
	{
		GroundCheck();

		float initYVel = velocity.y + gravity * Time.fixedDeltaTime;

		velocity = moveDirection * speed;

		if (!grounded)
			velocity.y = initYVel;

		rb.velocity = velocity;
	}

	void GroundCheck()
	{
		bool wasGrounded = grounded;
		grounded = Physics.Raycast(transform.position, Vector3.down, 1, layerMask, QueryTriggerInteraction.Ignore);

		if (!grounded && wasGrounded)
		{
			// First frame of non-groundedness
			GameManager.singleton.OnPlayerFall();
		}
	}
}
