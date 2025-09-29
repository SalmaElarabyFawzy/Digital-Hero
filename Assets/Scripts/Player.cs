  using System;
  using UnityEngine;
  using UnityEngine.Serialization;
  public class Player : MonoBehaviour
  {
      public enum PlayerState
      {
        Idle,
        Walk,
      }
      [Header("Movement Parameters")]
      [SerializeField] private float rotationSpeed = 10f;
      public float rotationSmoothTime = 0.1f;
      public float moveSpeed = 5f;
      public Transform cameraTransform;
      [Header("Animator")]
      [SerializeField] private Animator animator;
      
      private float turnVelocity;

      private CharacterController controller;

      private void Start()
      {
          controller = GetComponent<CharacterController>();

          if (cameraTransform == null && Camera.main != null)
              cameraTransform = Camera.main.transform;
      }
      private void FixedUpdate()
      {
          HandleMovement();
      }
      private void HandleMovement()
      {
          PlayerState state = PlayerState.Idle;
          // --- Get Input ---
          float horizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right
          float vertical = Input.GetAxis("Vertical"); // W/S or Up/Down
          Vector3 inputDir = new Vector3(horizontal, 0f, vertical).normalized;

          if (inputDir.magnitude >= 0.1f)
          {
              state = PlayerState.Walk;
              // --- Rotate movement by camera direction ---
              float targetAngle = Mathf.Atan2(inputDir.x, inputDir.z) * Mathf.Rad2Deg
                                  + cameraTransform.eulerAngles.y;
              float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelocity,
                  rotationSmoothTime);
              transform.rotation = Quaternion.Euler(0f, angle, 0f);

              // --- Move in direction of camera ---
              Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
              controller.Move(moveDir.normalized * moveSpeed * Time.deltaTime);
          }
          
          // --- Update Animator ---
            animator.SetInteger("playerState", (int)state);
      }
  }
      
  