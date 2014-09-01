using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*Enumerators of all events in game according to game object that fires them*/
public enum player_event_names {Dialog, OpenDoor}
public delegate void PlayerEventHandler(FuzionEventArg arg);
public struct PlayerEvents
{
	public Dictionary<int, PlayerEventHandler> dictionary;
	public PlayerEvents(int num)
	{
		dictionary = new Dictionary<int,PlayerEventHandler>();
	}
}


public enum ai_event_name{Dialog, OpenDoor}
public delegate void AIEventHandler(FuzionEventArg arg);
public struct AIEvents
{
	public Dictionary<int, AIEventHandler> dictionary;
	public AIEvents(int num)
	{
		dictionary = new Dictionary<int,AIEventHandler>();
	}
}




public class EventManager : MonoBehaviour, PlayerEventHandlerInterface, AIEventHandlerInterface {


	//Player Handler
	GameObject player_handler;
	/**Used by Event Manager to create a dictionary that stores Players events and registered listeners*/
	PlayerEvents player_events;

	//Register all game events
	void Start()
	{
		/**Register Player's events and listeners**/
		player_handler = GameObject.Find ("Player");
		player_events = new PlayerEvents (0);
	    registerPlayerEventsAndListeners ();
		

	}


	void Update () 
	{


	}

	/*Hard coded by hand.  Reference the player's script for events you want to listen too in order
	 to determine what events they own as well as the EventHandlerInterface.cs file*/
	void registerPlayerEventsAndListeners()
	{
	    player_events.dictionary.Add ((int)player_event_names.Dialog, new PlayerEventHandler(DialogEventHandler));
	    player_handler.GetComponent<Interactions> ()._DialogEvent += player_events.dictionary[(int)player_event_names.Dialog];


	}

	/******************IMPLEMENTING PLAYER_EVENT_HANDLER INTERFACE************************
	 *************************************************************************************/
	public void DialogEventHandler(FuzionEventArg arg)
	{
		Debug.Log ("Event Manager Dialog Handler Called");
		((DialogEventArg)arg).npc_character.SendMessage("interact");
	}
	public void OpenEventHandler(FuzionEventArg arg)
	{
		
	}
}
