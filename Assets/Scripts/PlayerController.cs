using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerController : MonoBehaviour
{
/*     public Rigidbody rb;

    public InputActionReference moveAction;

    public CharacterController cc;
    
    public float speed = 15.0F;
    private Vector2 _moveDirection;


    private float playerSpeed = 5.0f;
    private float jumpHeight = 1.5f;
    private float gravityValue = -9.81f;

    public CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer; */

    [Header("Character Settings")]
    public float playerSpeed = 5.0f;
    public float jumpHeight = 3f;
    public float gravityValue = -9.81f;

    public CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    public float maxHeight = 0f;
    public float maxFall = 15f;

    [Header("Input Actions")]
    public InputActionReference moveAction;
    public InputActionReference jumpAction;

    private void OnEnable()
    {
        moveAction.action.Enable();
        jumpAction.action.Enable();
    }

    private void OnDisable()
    {
        moveAction.action.Disable();
        jumpAction.action.Disable();
    }

    void Update()
    {
        if(transform.position.y > maxHeight) {
            maxHeight = transform.position.y;
        }
        if(transform.position.y < maxHeight - maxFall)
        {
            SceneManager.LoadScene("GameOverScene");
        }

        groundedPlayer = controller.isGrounded;

        if (groundedPlayer)
        {
            //Debug.Log("Grounded!");
            // Slight downward velocity to keep grounded stable
            if (playerVelocity.y < -2f)
                playerVelocity.y = -2f;

        }

        // Read input
        Vector2 input = moveAction.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        move = Vector3.ClampMagnitude(move, 1f);

        if (move != Vector3.zero)
            transform.forward = move;

        // Jump using WasPressedThisFrame()
        if (groundedPlayer && jumpAction.action.WasPressedThisFrame())
        {
            Debug.Log("Jump!");
            playerVelocity.y = Mathf.Sqrt(jumpHeight * -2f * gravityValue);
        }

        // Apply gravity
        playerVelocity.y += gravityValue * Time.deltaTime;

        // Move
        Vector3 finalMove = move * playerSpeed + Vector3.up * playerVelocity.y;
        controller.Move(finalMove * Time.deltaTime);
    }


    /* bool IsGrounded()
    {
        
       return true;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //rb.maxLinearVelocity = speed;
    }

    // Update is called once per frame
    void Update()
    {
        _moveDirection = moveAction.action.ReadValue<Vector2>()*speed;
   /*      if(transform.position.y < 1.5f){
            transform.position = new Vector3(transform.position.x, 1.5f, 0);
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, 0);
        }
 */
        //Debug.Log($"Move direction: {_moveDirection}");
//    }
//    private void FixedUpdate()
//    {
//        cc.Move(_moveDirection * Time.fixedDeltaTime);
///*         rb.linearVelocity += new Vector3(_moveDirection.x, _moveDirection.y, 0);
//        if(_moveDirection.x == 0) rb.linearVelocity -= new Vector3(rb.linearVelocity.x, 0, 0);
//        if(rb.linearVelocity.x > speed) rb.linearVelocity = new Vector3(speed, rb.linearVelocity.y, 0);
//        Debug.Log($"Linear velocity: {rb.linearVelocity}"); */
//    }
//
//    void OnCollisionEnter(Collision collision)
//    {
///*         transform.position = new Vector3(transform.position.x, 1.5f, 0);
//        foreach (ContactPoint contact in collision.contacts)
//        {
//            Debug.DrawRay(contact.point, contact.normal, Color.white);
//        }
// */    } */
}
