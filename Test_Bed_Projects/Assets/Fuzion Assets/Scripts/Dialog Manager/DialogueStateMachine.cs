using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueStateMachine : iStateMachine {

	public GameObject Player;
	public GameObject NPC;

	DialogStateGraph crnt_dsg;

	public DialogueStateMachine()
	{
		Player = GameObject.Find ("Player");


	}



	
	// Update is called once per frame
	public void SMupdate () 
	{
		if (crnt_state != null) 
		{
			if(crnt_state.inProcess() == false)
			{ 
				crnt_state.onExit ();

				if(crnt_state.next_state_id != -1)
				{
					//Ensure id (index) of next_state doesn't cause an out-of-bounds error
					if(crnt_state.next_state_id < crnt_graph.state_list.Count)
					{
						crnt_state = crnt_graph.state_list[crnt_state.next_state_id];
						crnt_state.onEnter();
					}
					else
					{
						crnt_state = null;

						return;
					}
				}
				else
				{
					crnt_state = null;

					return;
				}
			}
		}
	}

	public void notifyOfEvent(FuzionEventArg arg)
	{
	}

	/*
	 * Using the name of the NPC this function loads the state graph that
	 * represents the dialogue between the player and NPC.  This state graph
	 * is handed to the DialogueStateMachine to begin processing the graph.
	 */ 
	public DialogStateGraph createDialogStateGraph(string NPC_tag)
	{
		crnt_graph = new DialogStateGraph ();
		crnt_graph.NPC = GameObject.Find (NPC_tag);
		crnt_graph.state_list = new List<DialogueState> ();

		List<AudioClip> initialList = new List<AudioClip> ();
		initialList.Add ((AudioClip)Resources.Load("Unicorn", typeof(AudioClip))); 
		initialList.Add ((AudioClip)Resources.Load("key_master", typeof(AudioClip)));
		DialogueState initialState = new DialogueState(0,null,initialList, crnt_graph);

		List<AudioClip> secondList = new List<AudioClip> ();
		secondList.Add ((AudioClip)Resources.Load("key_master", typeof(AudioClip)));
		secondList.Add ((AudioClip)Resources.Load("Unicorn", typeof(AudioClip))); 
		DialogueState secondState = new DialogueState(1,null,secondList,crnt_graph);

		crnt_graph.state_list.Add (initialState);
		crnt_graph.state_list.Add (secondState);
	

		//Assign the first state in the list to the State Machine for processing
		crnt_state = crnt_graph.state_list[0];
		crnt_state.onEnter ();

		return crnt_graph;
	}
}
