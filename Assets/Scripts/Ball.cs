using UnityEngine;
using UnityEngine.InputSystem;

public class Ball : MonoBehaviour
{
    public float bounceForce;
    bool gameStarted;
    Rigidbody2D rb;
   // PlayerInput playerInput;
    public PlayerInput playerInput;
    private InputAction touchPress;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        touchPress = playerInput.actions.FindAction("TouchPress");
    }

    void Start()
    {
        gameStarted = false;
    }


    void OnEnable()
    {
        touchPress.Enable();
    }
    void OnDisable()
    {
        touchPress.Disable();
    }
    // Update is called once per frame
    void Update()
    {
        if(!gameStarted)
        {
            if(touchPress.triggered)
            {
                GameManager.instance.GameStart();
                StartBounce();
                gameStarted = true;
                
            }    
        }

    }
    public void StartBounce()
    {
        Vector2 randomPos = new Vector2(Random.Range(-1,1),1);

        rb.AddForce(randomPos * bounceForce, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "FallCheck")
        { 
            GameManager.instance.Restart();
        }
        else if(collision.gameObject.tag == "Paddle")
        {
            GameManager.instance.Score();
        }
    }
}
