using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator anim;
    PlayerMovement movement;
    Rigidbody2D rb;

    int groundID;
    int fallID;
    void Start()
    {
        anim = GetComponent<Animator>();
        movement = GetComponentInParent<PlayerMovement>();
        rb = GetComponentInParent<Rigidbody2D>();

        groundID = Animator.StringToHash("isOnGround");
        fallID = Animator.StringToHash("verticalVelocity");
    }

   
    void Update()
    {
        anim.SetFloat("speed", Mathf.Abs(movement.xVelocity));
        anim.SetBool("isCrouching", movement.isCrouch);
        // anim.SetBool("isOnGround", movement.isOnGround);     
        anim.SetBool(groundID, movement.isOnGround); //两种方法
        anim.SetBool("isHanging", movement.isHanging);
        anim.SetBool("isJumping", movement.isJump);
        anim.SetFloat(fallID, rb.velocity.y);
    }

    public void StepAudio()
    {
        AudioManager.PlayFootstepAudio();
    }

    public void CrouchStepAudio()
    {
        AudioManager.PlayCrouchstepAudio();
    }
}
