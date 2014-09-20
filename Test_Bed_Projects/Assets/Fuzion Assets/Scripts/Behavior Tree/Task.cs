using UnityEngine;
using System.Collections;

public class Task : MonoBehaviour {

	/*Every Task has access to the BehaviorTree it is a member of.  This allows it to access  *
	 *Attributes associated with the game entity or game object that the task is executing on.*/
	public BehaviorTree parent_tree;

	public Task(BehaviorTree parentTree)
	{
		parent_tree = parentTree;
	}

	public virtual bool run()
	{
		return true;
	}
}
