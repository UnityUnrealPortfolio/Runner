using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickupBase : MonoBehaviour, ILogFunctionality
{
    [field:SerializeField]public PickupType PickupType { get; protected set; }

    protected int pickUpValue;

    [field:SerializeField]public bool CanLog { get ; set; }

    public abstract void Handle_Pickup();

    

    
}
public enum PickupType
{
    Coin
}
