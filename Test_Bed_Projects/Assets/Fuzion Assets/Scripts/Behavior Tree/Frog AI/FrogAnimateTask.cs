using UnityEngine;
using System.Collections;


/*This task simply sets a mecanim transistion flag so the animate controller on the frog 
 * transistions to the animation we want played on the frog.*/
public class FrogAnimateTask : Task {


	string mecanim_transistion;

	public FrogAnimateTask(BehaviorTree parentTree, string mecanimTransistion):base(parentTree)
	{
		parent_tree = parentTree;

		mecanim_transistion = mecanimTransistion;
	}

	public override bool run()
	{
		Debug.Log ("FrogAnimateTask.Run()");
		//BehaviorTree->CogModel->NPC_State->MecanimStateMachine->data

		parent_tree.cog_model.frog_state.anim.SetBool (mecanim_transistion,true);

		return true;
	}
}
