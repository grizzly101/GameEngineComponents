using UnityEngine;
using System.Collections;

public class FrogJumpForwardTask : Task {

	float tParam;
	float delay;

	public FrogJumpForwardTask(BehaviorTree parentTree):base(parentTree)
	{
		parent_tree = parentTree;
		tParam = 0.33f;
		delay = 0;
	}
	
	public override bool run()
	{
		Debug.Log ("FrogJumpForward.Run()");
		//BehaviorTree->CogModel->NPC_State->MecanimStateMachine->data

		if(tParam < 1)
		{
		parent_tree.cog_model.frog_state.move_speed = 0.2f;
		parent_tree.cog_model.frog_state.move_direction = Vector3.forward;

		parent_tree.cog_model.frog_state.anim.SetBool ("jump_forward",true);
		parent_tree.cog_model.frog_state.anim.SetFloat ("jump_threshold",tParam);
		tParam = tParam + (Time.deltaTime);
		}
		else
		{
			parent_tree.cog_model.frog_state.move_speed = 0;


			delay = delay + Time.deltaTime;
			if(delay > 1)
			{
				tParam = 0.33f;
				delay = 0;
			}
		}


		return true;
	}
}
