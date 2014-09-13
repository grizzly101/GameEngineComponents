using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BehaviorTree {

	Queue<Task> task_tree;


	public BehaviorTree()
	{
		task_tree = new Queue<Task> ();
	}

}
