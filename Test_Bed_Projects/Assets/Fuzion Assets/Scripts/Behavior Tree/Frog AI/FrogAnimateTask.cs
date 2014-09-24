using UnityEngine;
using System.Collections;

public class FrogAnimateTask : Task {


	public FrogAnimateTask(BehaviorTree parentTree):base(parentTree)
	{
		parent_tree = parentTree;
	}

	public override bool run()
	{
		Debug.Log ("FrogAnimateTask.Run()");
		//BehaviorTree->CogModel->NPC_State->MecanimStateMachine->data
		parent_tree.cog_model.frog_state.anim.SetBool ("is_idle",true);
		return true;
	}
}
