using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour, ILogFunctionality
{
    [Header("Ground checking and Jump Properties")]
    [SerializeField] private GroundChecker m_GroundChecker;
    [SerializeField] private float m_JumpForce;


    [Header("Movement Properties")]
    [SerializeField] private float playerSpeed;

    [Header("Animation Properties")]
    [SerializeField] private Animator m_Animator;

    private Rigidbody2D playerRb;


    private bool m_Jumping;
    private bool m_InAir;

    private Vector2 m_StartTouchPos, m_EndTouchPos;
    [field: SerializeField] public bool CanLog { get; set; }

    private void Awake()
    {

        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleTouchInputs();
    }

    //private void HandleJumpInputs()
    //{
    //    if (Input.GetMouseButtonDown(0) && m_GroundChecker.Grounded == true)
    //    {
    //        m_Jumping = true;
    //    }
        
    //}

    private void FixedUpdate()
    {
        HandleJumpLogic();

        playerRb.velocity = new Vector2(1 * playerSpeed, playerRb.velocity.y);
        if(m_GroundChecker.Grounded == true)
        {
            m_Animator.SetBool("isRunning", playerRb.velocity.x > 0);
        }
    }

    private void HandleTouchInputs()
    {
        if (m_GroundChecker.Grounded == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_StartTouchPos = Input.mousePosition;
            }
            if (Input.GetMouseButtonUp(0))
            {
                m_EndTouchPos = Input.mousePosition;

                //get delta
                var delta = m_EndTouchPos.x - m_StartTouchPos.x;
               
                if (delta > 30)
                {
                    m_Animator.SetTrigger("roll");
                }
                else if (delta < 30)
                {
                    m_Jumping = true;
                }
            }
            m_InAir = false;
        }
        else if (m_GroundChecker.Grounded == false)
        {
            m_Jumping = false;
            m_InAir = true;
        }
  
    }
    private void HandleJumpLogic()
    {
        if (m_Jumping == true)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x,m_JumpForce);
            m_Animator.SetBool("isJumping", true);
        }
        if (m_InAir == true)
        {
            m_Animator.SetFloat("fallSpeed", playerRb.velocity.y);
        }
        if(m_InAir == false)
        {
            m_Animator.SetBool("isJumping", false);
            m_Jumping = false;
            //m_Animator.SetFloat("speed", playerRb.velocity.y);
        }
    }
}
