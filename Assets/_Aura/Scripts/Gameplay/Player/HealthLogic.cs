using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthLogic : MonoBehaviour,ILogFunctionality
{
    [SerializeField] private float m_PlayerMaxHealth;
    public float PlayerHealth
    {
        get => m_PlayerMaxHealth;
        set
        {
            m_PlayerMaxHealth = value;
            if(m_PlayerMaxHealth <= 0)
            {
                HandlePlayerDeath();
            }
        }
    }

    [field:SerializeField]public bool CanLog { get; set; }

    private void HandlePlayerDeath()
    {
        GameManager.Instance.ResetGame();
    }

}
