using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;


 public class Interactions : MonoBehaviour
   {
      int           interactble_layer;
      HintDisplay   hint_display;

      static readonly float RAY_LENGTH = 3;

      // Interactable objects.
      private const string TABLE_STAND = "NightStand";
      private const string HALLWAY_CLOCK = "Clock";
      private const string HALLWAY_DOOR = "Door";
	  private const string BOBBY_NPC = "Bobby";

	  /**Player Fireable Events**/	
	  public event PlayerEventHandler _DialogEvent;
	  public event PlayerEventHandler _OpenDoorEvent;

      void Start()
      {
         interactble_layer = 1 << 9;

         hint_display = (HintDisplay)this.GetComponent("HintDisplay"); 

      }

      public void interact(Vector3 rayDirection, Vector3 rayPosition)
      {
         RaycastHit   rayHit;
         GameObject   gameObject;

         // Check if they ray has collided with any of the layers.
         if (Physics.Raycast(rayPosition, rayDirection, out rayHit, RAY_LENGTH,
             interactble_layer))
         {
            // Find out which object was detected for this layer.
            gameObject = rayHit.collider.gameObject;
            if (gameObject.CompareTag(TABLE_STAND))
            {
               hint_display.showHint("[E] Open");
               if (Input.GetKeyDown(KeyCode.E))               
                  rayHit.collider.gameObject.SendMessage("interact");
            }
            else if (gameObject.CompareTag(HALLWAY_CLOCK))
            {
               hint_display.showHint("[E] Interact");
               if (Input.GetKeyDown(KeyCode.E))
                  rayHit.collider.gameObject.SendMessage("interact");
            }
            else if (gameObject.CompareTag(HALLWAY_DOOR))
            {
               hint_display.showHint ("[E] Open");
               if (Input.GetKeyDown(KeyCode.E))
                  rayHit.collider.gameObject.SendMessage("interact");
            }
			else if (gameObject.CompareTag(BOBBY_NPC))
			{
				hint_display.showHint ("[E] Talk");
				if (Input.GetKeyDown(KeyCode.E))
				{    
					//rayHit.collider.gameObject.SendMessage("interact");
					DialogEventArg tDialogArg = new DialogEventArg(this.gameObject,rayHit.collider.gameObject);
					Debug.Log ("Fired Dialog Event");
					_DialogEvent(tDialogArg);

				}
						
						
			}
				
         }
         else
         {
            // Nothing collided with the ray so turn off hints.
            hint_display.hideHint();
         }
      }


   }
