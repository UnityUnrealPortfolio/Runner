using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandler : MonoBehaviour, ILogFunctionality
{
    [field:SerializeField]public bool CanLog { get ; set ; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var collided_object = collision.gameObject.GetComponent<PickupBase>();
        //detect collision with Pickups
        if ( collided_object!= null)
        {
            switch (collided_object.PickupType)
            {
                case PickupType.Coin:
                    Logger.LogMessage(CanLog, "picked up Coin!");
                    break;
            }

            collided_object.Handle_Pickup();
        }
        else
        {
            if (collision.gameObject.CompareTag("Goal"))
            {
                //restart level
                //ToDo:this is to be handled by GameManager
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
