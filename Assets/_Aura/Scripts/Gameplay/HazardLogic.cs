using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardLogic : MonoBehaviour
{
    [SerializeField] private HazardType m_HazardType;

    [Tooltip("Amount of damage dealt when touched")][SerializeField] 
    private float m_DamagePoints;
    public float DamagePoints
    {
        get => m_DamagePoints;
    }

    public void HandleCollision()
    {
        //ToDo:perhaps play got hit animation here or something
    }
}
public enum HazardType
{
    ThreeSpike
}
