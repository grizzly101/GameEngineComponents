using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DialogueState : iState {

	//Contains a sequence of captions to be displayed no the screen
	List<string> gui_captions;
	//Contains a sequence of audio clips to be played
	List<AudioClip> speech_clips;
	int clip_index;
	//Contains an indexed list of the children the state can transition too
	List<int> child_states;
	
	//handle to its own state graph
	DialogStateGraph my_state_graph;

	float audio_clip_timer;

	GameObject NPC;

	public DialogueState(int stateName, List<string> guiCaptions, List<AudioClip> speechClips, DialogStateGraph dsg)
	{
		my_state_graph = dsg;
		state_id = stateName;
		gui_captions = guiCaptions;
		speech_clips = speechClips;
		clip_index = 0;
		state_process = true;
		NPC = my_state_graph.NPC;
	}
	
	public override bool inProcess()
	{
		if(audio_clip_timer > 0)
		{
			audio_clip_timer -= Time.deltaTime;

		}
		else
		{
			if(speech_clips.Count > (clip_index + 1))
			{
				clip_index +=1;
				audio_clip_timer = speech_clips[clip_index].length;
				my_state_graph.NPC.GetComponent<NPC_State> ().m_voice = speech_clips [clip_index];
				my_state_graph.NPC.GetComponent<NPC_State>().m_mouth.clip = my_state_graph.NPC.GetComponent<NPC_State> ().m_voice;
				my_state_graph.NPC.GetComponent<NPC_State>().m_mouth.Play ();

			}
			else
			{
			    state_process = false;
			}
		}

		return state_process; 
	}
	
	public override void onEnter()
	{
		state_process = true;
	
		my_state_graph.NPC.GetComponent<NPC_State> ().m_voice = speech_clips [clip_index];
		my_state_graph.NPC.GetComponent<NPC_State>().m_mouth.clip = my_state_graph.NPC.GetComponent<NPC_State> ().m_voice;
		audio_clip_timer = speech_clips [clip_index].length;

		my_state_graph.NPC.GetComponent<NPC_State>().m_mouth.Play ();
	}
	
	public override void onExit()
	{
		//Assign animation to Player for batch playing or should we play the animation here?? exit_animation.play("name of clip");
		//exit_sound.Play();

		//my_state_graph.publish_transistion_request.Add(state_id,child_states[0]); //0 is a placeholder
		next_state_id = state_id + 1;
	}


}
