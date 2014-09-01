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


	void createConversationFromEventArg(DialogEventArg arg)
	{
		//(1) Create SM
		//(2) Define state graph from xml or yaml
		//(3) add conversation to the list
	}
}
