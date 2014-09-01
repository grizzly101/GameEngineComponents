using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueStateMachine : iStateMachine {

	GameObject NPC;
	NPC_Behavior npc_behav;

	public DialogueStateMachine(string npc_name)
	{
		NPC = GameObject.Find (npc_name);
		npc_behav = NPC.GetComponent <NPC_Behavior>();
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
						npc_behav.converse_gui = false;
						return;
					}
				}
				else
				{
					crnt_state = null;
					npc_behav.converse_gui = false;
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
	public void LoadNPCstateGraph(string NPC_tag)
	{
		crnt_graph = new StateGraph ();

		crnt_graph.state_list = new List<iState> ();
		//pass in NPC object reference and stateID
		crnt_graph.state_list.Add (new InitialState(NPC,0));
		crnt_graph.state_list.Add (new DialogueState(NPC,1));
	

		//Assign the first state in the list to the State Machine for processing
		crnt_state = crnt_graph.state_list[0];
		crnt_state.onEnter ();


	}
}
