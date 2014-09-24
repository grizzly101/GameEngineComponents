using UnityEngine;
using System.Collections;

public class Task {

	/*Every Task has access to the BehaviorTree it is a member of.  This allows it to access  *
	 *Attributes associated with the game entity or game object that the task is executing on.*/
	public BehaviorTree parent_tree;

	public Task(BehaviorTree parentTree)
	{
		parent_tree = parentTree;
	}

	public virtual bool run()
	{
		Debug.Log ("Task.virtual Run()");
		return true;
	}
}
