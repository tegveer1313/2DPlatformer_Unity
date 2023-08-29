using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public Rigidbody2D playerRB;

    [SerializeField] private Transform grounCheck;
    [SerializeField] private LayerMask groungLayer;
    [SerializeField] private Transform shootObj;

    private PlayerAnimationManager animationManager;
    float horizontalInput;
    float speed = 8f;
    float jumpPower = 10f;
    bool isFacingRight = true;
    public bool inGround = true;
    Attack attack;

    private void Awake()
    {
        animationManager = GetComponent<PlayerAnimationManager>();
        attack = GetComponent<Attack>();
    }

    //Calling all the functions
    public void AllMovements()
    {
        //Moving Player on given Inputs
        playerRB.velocity = new Vector2(horizontalInput * speed, playerRB.velocity.y);

        FlipCharacter();

        animationManager.SetAirSpeed(playerRB.velocity.y);

        inGround = IsGrounded();
        animationManager.SetGround(inGround);
    }

    //Taking jump input
    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && inGround)
        {
            //Playing Jump animations
            animationManager.JumpAnimations();

            //Performing Jump
            playerRB.velocity = new Vector2(playerRB.velocity.x, jumpPower);
        }

        if (context.canceled && playerRB.velocity.y > 0f)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, playerRB.velocity.y * 0.2f);
        }
    }

    //Getting Player movement inputs
    public void Move(InputAction.CallbackContext context)
    {
        horizontalInput = context.ReadValue<Vector2>().x;
    }

    //Attacking Player on Input pressed
    public void Attack(InputAction.CallbackContext context)
    {
        if (context.performed && inGround)
        {
            //performing attack animation by calling animation manager script
            animationManager.AttackAnimation();

            //Actully Damaging enemy by call a function from attack script
            attack.Fire(shootObj.position);
        }

        if (context.performed && !inGround)
        {
            animationManager.AttackAnimation();
            attack.Fire(shootObj.position);
        }
    }

    //Rotating player
    void FlipCharacter()
    {
        if (horizontalInput > 0f)
        {
            transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if (horizontalInput < 0f)
        {
            transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        }
    }

    //Checking Player is in ground or not
    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(grounCheck.position, 0.2f, groungLayer);
    }
}
