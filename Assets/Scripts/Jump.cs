using UnityEngine;
using UnityEngine.InputSystem;

public class Jump : MonoBehaviour
{
    [SerializeField] private InputActionReference jumpButton;
    [SerializeField] private float jumpHeight = 2.0f;
    [SerializeField] private float gravityValue = - 9.81f;

    private CharacterController characterController;
    private Vector3 playerVelocity;

    private void Awake() => characterController = GetComponent<CharacterController>();

    private void OnEnable() => jumpButton.action.performed += Jumping;

    private void onDsiable() => jumpButton.action.performed -= Jumping;

    private void Jumping(InputAction.CallbackContext obj)
    {
        if (!characterController.isGrounded) return;

        playerVelocity.y += Mathf.Sqrt(jumpHeight + -3.0f * gravityValue);
    }

    private void Update() 
    {
        if (characterController.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        characterController.Move(playerVelocity * Time.deltaTime);

        // Debug.Log("jumped");
    }
}
