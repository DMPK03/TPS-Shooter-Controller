using UnityEngine;
using System;

namespace Dmpk_TPS
{
    public class MovementController : MonoBehaviour
    {
		public static event Action<float, float, float> moveEvent;
		public static event Action<bool> FreeFall, Jump, Grounded, Crouch;
		
		[Header("Movement")]
		[SerializeField]private const float MOVESPEED = 3;
        
		[Header("Jumping and Gravity")]
		[SerializeField]private float jumpHeight = 1.2f;
		[SerializeField]private float gravity = -15.0f;
		[SerializeField]private float jumpTimeout = 0.3f;
		[SerializeField]private float fallTimeout = 0.1f;
		[SerializeField]private LayerMask groundLayers;

        private CharacterController controller;

		private float crouchModifier = 1f;
		private float animSprint, sprint;
        private Vector3 moveDirection, targetDirection = Vector3.zero;

		private float verticalVelocity = 0f;
		private float terminalVelocity = 53.0f;
		private float jumpTimeoutDelta;
		private float fallTimeoutDelta;
		private float groundedOffset = -0.14f;
		private float groundedRadius = 0.29f;

		private bool grounded = true, isJumping;
		private float transitionSpeed = 8;

		private void Awake() {
			InputManager.Move += move => targetDirection = Vector3.forward * move.x + Vector3.right * move.y;
			InputManager.Jumping += j => isJumping = j;
			InputManager.Sprinting += OnSprint;
			InputManager.Crouching += OnCrouch;
		}

		private void OnSprint(bool s)
		{
			sprint = s? 2f : 1;
		}

		private void OnCrouch(bool c)
		{
			crouchModifier = c? .5f : 1; 
			Crouch?.Invoke(c);
		}

        private void Start() {
            controller = GetComponent<CharacterController>();
			jumpTimeoutDelta = jumpTimeout;
			fallTimeoutDelta = fallTimeout;
        }

        private void Move()
		{
			float step = transitionSpeed * Time.deltaTime;

			moveDirection = Vector3.MoveTowards(moveDirection, targetDirection, step);

			float velocityX = Vector3.Dot(moveDirection, transform.forward);
           	float velocityY = Vector3.Dot(moveDirection, transform.right);				
			Vector3 finalMove = new Vector3(velocityX, 0, velocityY);

			float sprintModifier = moveDirection.x > 0.5f && sprint > 1 ? sprint : 1;
			
			controller.Move(finalMove * (MOVESPEED * sprintModifier * crouchModifier * Time.deltaTime) + new Vector3(0.0f, verticalVelocity, 0.0f) * Time.deltaTime);

			animSprint = Mathf.MoveTowards(animSprint, sprintModifier, step);
			moveEvent?.Invoke(moveDirection.x, moveDirection.z, animSprint);
		}

		private void GroundedCheck()
		{
			Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - groundedOffset, transform.position.z);
			grounded = Physics.CheckSphere(spherePosition, groundedRadius, groundLayers, QueryTriggerInteraction.Ignore);

			Grounded?.Invoke(grounded);
		}

		private void JumpAndGravity()
		{
			if (grounded)
			{
				fallTimeoutDelta = fallTimeout;

				Jump?.Invoke(false);
				FreeFall?.Invoke(false);

				if (verticalVelocity < 0.0f) verticalVelocity = -2f;

				if (isJumping && jumpTimeoutDelta <= 0.0f)
				{
					verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
					Jump?.Invoke(true);
				}
				if (jumpTimeoutDelta >= 0.0f) jumpTimeoutDelta -= Time.deltaTime;
			}
			else
			{
				jumpTimeoutDelta = jumpTimeout;

				if (fallTimeoutDelta >= 0.0f) fallTimeoutDelta -= Time.deltaTime;
				FreeFall?.Invoke(true);
			}
			if (verticalVelocity < terminalVelocity) verticalVelocity += gravity * Time.deltaTime;
		}


        private void Update() 
		{
			GroundedCheck();
			JumpAndGravity();
			Move();
        }

        

        
        

        
        


    }
}