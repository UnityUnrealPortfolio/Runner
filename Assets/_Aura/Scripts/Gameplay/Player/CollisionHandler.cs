using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandler : MonoBehaviour, ILogFunctionality
{
    [field: SerializeField] public bool CanLog { get; set; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //detect collision with Pickups
        var collided_object = collision.gameObject.GetComponent<PickupBase>();
        if (collided_object != null)
        {
            switch (collided_object.PickupType)
            {
                case PickupType.Coin:
                    //Logger.LogMessage(CanLog, "picked up Coin!");
                    break;
            }

            collided_object.Handle_Pickup();
        }

        //detect collision with Goal
        if (collision.gameObject.CompareTag("Goal"))
        {
            //restart level
           
          GameManager.Instance.ResetGame();
        }

       

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //detect collision with hazard objects
       if(collision.gameObject.TryGetComponent<HazardLogic>(out var hazard_object))
        {
            Logger.LogMessage(CanLog, "Hit Hazard!");
            GetComponent<HealthLogic>().PlayerHealth -= hazard_object.DamagePoints;
            hazard_object.HandleCollision();
        }
        else
        {
            Logger.LogMessage(CanLog, "not hit hazard!");
        }

    }
}
