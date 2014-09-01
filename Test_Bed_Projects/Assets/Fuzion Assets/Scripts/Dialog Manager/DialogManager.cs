using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public struct conversation
{
	public DialogueStateMachine state_machine;
	public StateGraph			 dialog_graph;
}


public class DialogManager : MonoBehaviour {

	//Stores list of all conversations currently occurring in the game
	public List<conversation> converse_list; 


	// Use this for initialization
	void Start () 
	{
		converse_list = new List<conversation> ();
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//Update conversations each frame
		foreach (conversation talk in converse_list)
		{
			talk.state_machine.SMupdate ();
		}

	}


	//Used by Event Manager to notify Dialog Manager to create a manage a conversation
	public void createConversationFromEventArg(DialogEventArg arg)
	{
		//(1) Create conversation between player and NPC
		conversation newConverse = new conversation ();
		//(1a) Create SM
		newConverse.state_machine = new DialogueStateMachine ();
		newConverse.state_machine.NPC = arg.npc_character;

		//(2) Define state graph from xml or yaml
		newConverse.dialog_graph = newConverse.state_machine.createDialogStateGraph ();
		//(3) add conversation to the list
		converse_list.Add (newConverse);
	}
}
