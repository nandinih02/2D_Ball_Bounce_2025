using UnityEngine;
using UnityEngine.InputSystem;

public class Paddle : MonoBehaviour
{
    public int moveSpeed;

    private PlayerInput playerInput;
    private InputAction touchPress;
    private InputAction touchPosition;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        touchPress = playerInput.actions.FindAction("TouchPress");
        touchPosition = playerInput.actions.FindAction("TouchPosition");
    }

    void OnEnable()
    {
        touchPress.performed += TouchPressed;
        //touchPosition.Enable();
    }

    void OnDisable()
    {
        touchPress.performed -= TouchPressed;
        //touchPosition.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if(touchPress.WasReleasedThisFrame())
        {
            rb.linearVelocity = Vector2.zero;
        }
    }



    public void TouchPressed(InputAction.CallbackContext context)
    {
        Vector2 position = Camera.main.ScreenToWorldPoint(touchPosition.ReadValue<Vector2>());

        if(position.x < 0)
        {
            //Debug.Log("Left");
            rb.linearVelocity = Vector2.left * moveSpeed;       
        }
        else
        {
            //Debug.Log("Right");
            rb.linearVelocity = Vector2.right * moveSpeed; 
        }
    }
}
