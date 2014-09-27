using UnityEngine;
using System.Collections;

public class FrogTalkTask : Task {

	string talk_clip;

	// Use this for initialization
	public FrogTalkTask(BehaviorTree parentTree, string talkClip):base(parentTree)
	{
		talk_clip = talkClip;
	}

	public override bool run()
	{
		Debug.Log ("FrogTalkTask.Run()");
		//(1) set audio clip for NPC
		parent_tree.cog_model.frog_state.m_voice = (AudioClip)Resources.Load (talk_clip, typeof(AudioClip));
		//(2) set conditional flag for NPC to signal talking
		parent_tree.cog_model.frog_state.is_talking = true;
		//(3) Queue mecanim to transistion to a talk animation
		parent_tree.cog_model.frog_state.anim.SetBool ("talk_now",true);

		return true;
	}
}
