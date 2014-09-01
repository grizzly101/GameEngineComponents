using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueState : iState {

	//Contains a sequence of captions to be displayed no the screen
	List<string> gui_captions;
	//Contains a sequence of audio clips to be played
	List<AudioClip> speech_clips;
	//Contains an indexed list of the children the state can transition too
	List<int> child_states;

	//handle to its own state graph
	StateGraph my_state_graph;



	public DialogueState(int stateName, List<string> guiCaptions, List<AudioClip> speechClips)
	{
		state_id = stateName;
		gui_captions = guiCaptions;
		speech_clips = speechClips;

		state_process = true;
	}
	
	public override bool inProcess()
	{

		return state_process; 
	}
	
	public override void onEnter()
	{
		state_process = true;

	//	npc_behav.m_voice =  Resources.Load("Unicorn") as AudioClip;
	//	npc_behav.m_mouth.clip = npc_behav.m_voice;
	//	npc_behav.m_mouth.Play ();

	}
	
	public override void onExit()
	{
		//Assign animation to Player for batch playing or should we play the animation here?? exit_animation.play("name of clip");
		//exit_sound.Play();

		//my_state_graph.publish_transistion_request.Add(state_id,child_states[0]); //0 is a placeholder
		next_state_id = child_states [0];
	}


}
