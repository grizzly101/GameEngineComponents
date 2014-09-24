using UnityEngine;
using System.Collections;

public class FrogAnimDecorator : DecoratorTask {

	float timer;

	public FrogAnimDecorator(BehaviorTree parentTree,Task childTask, float timeUntilTalk):base(parentTree)
	{
		parent_tree = parentTree;
		timer = timeUntilTalk;
		child_task = childTask;
	
	}

	public override bool run()
	{
		Debug.Log ("FrogAnimateDecorator.Run()");
		child_task.run ();


		if (timer > 0) {
			 timer =  timer - Time.deltaTime;
			return true;
		} else
		{
			parent_tree.cog_model.frog_state.anim.SetBool ("is_idle",false);
			return false;
		}
		
	}
}
