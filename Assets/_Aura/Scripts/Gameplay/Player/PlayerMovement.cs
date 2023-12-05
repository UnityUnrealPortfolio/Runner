using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour, ILogFunctionality
{
    [Header("Ground checking and Jump Properties")]
    [SerializeField] private GroundChecker m_GroundChecker;
    [SerializeField] private float m_JumpForce;
    private bool m_Jump;
    private bool m_InAir;

    [SerializeField] private float playerSpeed;
    private Rigidbody2D playerRb;
    private float _totalTime = 50;

    [field: SerializeField] public bool CanLog { get; set; }

    private void Awake()
    {
     
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Logger.LogMessage(CanLog, "Jump!");
            if (m_GroundChecker.Grounded == true)
            {
               m_Jump = true;
            }
            else
            {
               m_InAir = true;
            }
        }
        if(m_GroundChecker.Grounded == false)
        {
            m_Jump= false;
        }
    }
    private void FixedUpdate()
    {
        _totalTime -= 1;
        if (_totalTime < 0)
        {
            _totalTime = 50;
        }

        if (m_Jump)
        {
            playerRb.AddForce(Vector2.up * m_JumpForce, ForceMode2D.Impulse);
        }
        if(m_InAir)
        {
            //ToDo:implement variable jump here!
        }
        playerRb.velocity = new Vector2(1 * playerSpeed, playerRb.velocity.y);
    }

}
