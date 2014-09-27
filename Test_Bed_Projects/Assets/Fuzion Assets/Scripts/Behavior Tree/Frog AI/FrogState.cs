using UnityEngine;
using System.Collections;

public class FrogState : State {

	public BehaviorTree crnt_tree;
	public BehaviorTree prev_tree;

	public float  state_timer;

	public FrogState(int id):base(id)
	{
		crnt_tree = null;
		prev_tree = null;
		state_timer = 0;
	}

	public bool onProcess()
	{
		//processes tasks in the current behavior tree crnt_tree

		/*Continue where the tree left off if necessary.  Determined by a decorator task.
		 *This delegate provides a "until" capability not possible with behavior trees and unity's update().
		 */
		if(crnt_tree.task_handler != null)
		{
			crnt_tree.task_handler();
			return true;
		}
		else
		{
			foreach(Task tNode in crnt_tree.task_tree)
			{
				if(tNode.run())
				{
					Debug.Log ("running task from onProcess()");
					return true;
				}
			}
		}
		
		return false;
	}

	public bool onExit()
	{
		crnt_tree.task_tree.Clear ();
		return true;
	}

	public bool onEnter()
	{
		return true;
	}
}
