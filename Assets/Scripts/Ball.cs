using UnityEngine;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour
{
    public float bounceForce;
    Rigidbody2D rb;
   // PlayerInput playerInput;
    public InputAction start;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //playerInput = GetComponent<PlayerInput>();
        //touchPress = playerInput.actions.FindAction("TouchPress");
    }

    void OnEnable()
    {
        start.Enable();
    }
    void OnDisable()
    {
        start.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        if(start.triggered)
        {
            StartBounce();
        }
    }
    public void StartBounce()
    {
        Vector2 randomPos = new Vector2(Random.Range(-1,1),1);

        rb.AddForce(randomPos * bounceForce, ForceMode2D.Impulse);
    }
}
