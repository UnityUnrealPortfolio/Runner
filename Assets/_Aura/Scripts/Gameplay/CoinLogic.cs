using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinLogic : PickupBase
{
    
    public override void Handle_Pickup()
    {
       Destroy(gameObject,m_TimeToDestruction);
    }
}
