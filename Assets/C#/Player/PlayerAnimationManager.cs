using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    private Animator playerAnimator;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }

    public void MovementAnimations(float horizontalVelocity)
    {
        if(horizontalVelocity > 0.1f || horizontalVelocity < -0.1f)
        {
            playerAnimator.SetInteger("MovementState", 2);
        }
        else
        {
            playerAnimator.SetInteger("MovementState", 0);
        }
    }

    public void SetAirSpeed(float verticalVelocity)
    {
        playerAnimator.SetFloat("AirSpeed", verticalVelocity);
    }

    public void JumpAnimations()
    {
        playerAnimator.SetTrigger("Jump");
    }

    public void SetGround(bool _grounded)
    {
        playerAnimator.SetBool("Grounded", _grounded);
    }

    public void AttackAnimation()
    {
        playerAnimator.SetTrigger("Attack");
    }
}
