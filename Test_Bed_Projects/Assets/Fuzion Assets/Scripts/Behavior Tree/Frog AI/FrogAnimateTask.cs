using UnityEngine;
using System.Collections;

public class FrogAnimateTask : Task {

	float tParam;
	public FrogAnimateTask(BehaviorTree parentTree):base(parentTree)
	{
		parent_tree = parentTree;
		tParam = 0;
	}

	public override bool run()
	{
		Debug.Log ("FrogAnimateTask.Run()");
		//BehaviorTree->CogModel->NPC_State->MecanimStateMachine->data
		tParam = tParam + Time.deltaTime;
		parent_tree.cog_model.frog_state.anim.SetBool ("is_idle",true);
		parent_tree.cog_model.frog_state.anim.SetFloat ("jump_threshold",tParam);
		return true;
	}
}
