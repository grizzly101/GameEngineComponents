using UnityEngine;
using System.Collections;

public class FrogTalkDecorator : DecoratorTask {

	bool run_once;
	float talk_timer;
	public FrogTalkDecorator(BehaviorTree parentTree, Task childTask):base(parentTree)
	{
		child_task = childTask;
		run_once = false;

	}
	
	public override bool run()
	{
		Debug.Log ("FrogTalkDecorator.run");

		if(run_once == false)
		{
			child_task.run ();
			assignDelegate ();
			run_once = true;
			return true;
		}

		if(parent_tree.cog_model.frog_state.m_mouth.isPlaying)
		{
			Debug.Log("FrogTalkDecorator: is playing");
			return true;
		}
		else
		{
			Debug.Log("FrogTalkDecorator: removing delegate");
			parent_tree.cog_model.frog_state.anim.SetBool ("talk_now",false);
			parent_tree.cog_model.frog_state.anim.SetBool ("is_idle",false);
			removeDelegate();
			return false;
		}
	}
}
