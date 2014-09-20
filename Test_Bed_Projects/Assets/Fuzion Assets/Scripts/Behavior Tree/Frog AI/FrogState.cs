using UnityEngine;
using System.Collections;

public class FrogState : State {

	public BehaviorTree crnt_tree;
	public BehaviorTree prev_tree;

	public float  timer;

	public FrogState(int id):base(id)
	{
		crnt_tree = null;
		prev_tree = null;
	}

	void frogProcess()
	{
		//processes the current behavior tree crnt_tree
	}
}
