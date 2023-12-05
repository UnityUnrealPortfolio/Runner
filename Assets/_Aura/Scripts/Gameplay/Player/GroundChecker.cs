using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour, ILogFunctionality
{
    [SerializeField] private BoxCollider2D m_overlapBox;
    [SerializeField] private LayerMask m_GroundMask;

    private bool m_Grounded;
    public bool Grounded
    {
        get => m_Grounded;
        private set
        {
            m_Grounded = value;
        }
    }

    [field: SerializeField] public bool CanLog { get; set; }



    private void Update()
    {
        var results = Physics2D.OverlapBox(m_overlapBox.bounds.center, m_overlapBox.size, 0f, m_GroundMask);
        if (results != null)
        {
           
            Grounded = true;
        }
        else
        {
            Grounded= false;
        }
    }

    public void LogMessage(bool canLog, string gameobjectName, string message)
    {
        Logger.LogMessage(canLog, gameobjectName, message);
    }
}
