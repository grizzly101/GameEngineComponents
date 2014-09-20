using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BehaviorTree {

	FrogCognition  cog_model;

	Queue<Task> task_tree;


	public BehaviorTree(FrogCognition cogModel)
	{
		cog_model = cogModel;

		task_tree = new Queue<Task> ();
	}

}
