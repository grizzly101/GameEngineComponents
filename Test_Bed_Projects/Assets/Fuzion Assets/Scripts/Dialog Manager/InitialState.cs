using UnityEngine;
using System.Collections;

public class InitialState : iState  {

	GameObject npc_ref;
	NPC_State npc_behav;
	bool		select_option;

	public InitialState(GameObject npc, int stateID)
	{
		state_process = true;
		npc_ref = npc;
		npc_behav = npc_ref.GetComponent <NPC_State>();
		next_state_id = -1;
		state_id = stateID;
		select_option = false;
	}

	public override bool inProcess()
	{

		if(select_option)
		{
			state_process = false;
		}

		return state_process; 
	}

	public override void onEnter()
	{
		state_process = true;
		npc_behav.m_voice =  Resources.Load("key_master") as AudioClip;
		npc_behav.m_mouth.clip = npc_behav.m_voice;
		npc_behav.converse_gui = true;
		npc_behav.converse_callback = StateDialogue;
		npc_behav.m_mouth.Play ();
	}

	public override void onExit()
	{

	}

	public void StateDialogue()
	{
		if(GUI.Button (new Rect (20,40,300,20), "Ask About the key.")) 
		{
			next_state_id = 1;
			select_option = true;
		}
		
		if(GUI.Button (new Rect (20,80,300,20), "Exit Conversation.")) 
		{
			next_state_id = -1; //should be an exit state
			select_option = true;
		}
	}

}
