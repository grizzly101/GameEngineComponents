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

	//Contains the set of transitions this state node can use to move to a next node
	List<DialogTransition> state_transitions;

	//handle to its own state graph
	DialogStateGraph my_state_graph;

	float audio_clip_timer;



	public DialogueState(int stateName, List<string> guiCaptions, List<AudioClip> speechClips)
	{
		state_id = stateName;
		gui_captions = guiCaptions;
		speech_clips = speechClips;

		state_process = true;
	}
	
	public override bool inProcess()
	{
		if(audio_clip_timer != 0)
		{
			my_state_graph.NPC.GetComponent<npc_behav>().m_mouth.Play ();
			audio_clip_timer -= Time.deltaTime;
		}
		else
		{
			state_process = false;
		}
		return state_process; 
	}
	
	public override void onEnter()
	{
		state_process = true;
	
		my_state_graph.NPC.GetComponent<npc_behav>().m_voice =  Resources.Load("Unicorn") as AudioClip;
		my_state_graph.NPC.GetComponent<npc_behav>().m_mouth.clip = npc_behav.m_voice;
		audio_clip_timer = my_state_graph.NPC.GetComponent<npc_behav>.m_voice.length;
	
	}
	
	public override void onExit()
	{
		//Assign animation to Player for batch playing or should we play the animation here?? exit_animation.play("name of clip");
		//exit_sound.Play();

		//my_state_graph.publish_transistion_request.Add(state_id,child_states[0]); //0 is a placeholder
		next_state_id = child_states [0];
	}


}
