using UnityEngine;
using System.Collections;

/*Event to be passed to Dialog Manager when player engages NPC in converastion*/
public class DialogEventArg : FuzionEventArg {

	/*These objects store who the conversation is taking place with.*/
	public GameObject player_character;
	public GameObject npc_character;

	public DialogEventArg(GameObject player, GameObject npc)
	{
		npc_character = npc;
		player_character = player;
	}


}
