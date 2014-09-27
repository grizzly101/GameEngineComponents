using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * Is a state machine containing all the states and behavior trees that capture the actions/behaviors
 * the frog AI will use to interact in its environment.  This also declares and defines the states
 * and behaviors.
 * 
 * This also stores key attributes of the Frog game object including variables which determine which voice to play, animation, etc
 * via NPC_State.  All AI processing occurs through the cognition model only.
 * */
public class FrogCognition : MonoBehaviour {
	
	//Declare the states and their IDs
	enum state_id {IDLE, DIALOG, ACTION};
	FrogState      idle, dialog, action;

	public FrogState crnt_state;
	public FrogState nxt_state;

	//Handle to GameObject
	public GameObject frog_object;

	//Handle to NPC_State Component
	public NPC_State frog_state;

	//Store available Behavior Trees
	Dictionary<string,BehaviorTree> tree_dict;


	// Use this for initialization.  Initializes states and behavior trees.
	void Start () {

		//Assign handle to AI GameObject
		frog_object = GameObject.Find("TheFrogBase");
		//Handle to NPC_State Component of AI GameObject
		frog_state = frog_object.GetComponent<NPC_State>() as NPC_State;

		//Define States
		idle   =  new FrogState ((int)state_id.IDLE);
		dialog =  new FrogState ((int)state_id.DIALOG);
		action =  new FrogState ((int)state_id.ACTION);

		/***Define Behavior Trees and store in dictionary***/
		tree_dict = new Dictionary<string,BehaviorTree> ();

		/****Temporary and for testing only*****
		 * (1) Create the behavior tree
		 * (2) Create tasks to add to the behavior tree
		 * (3) Add the tasks to the behavior tree
		*/
		BehaviorTree idle_behavior = new BehaviorTree (this);

		//root
		SelectorTask rootNode = new SelectorTask (idle_behavior);
		//Building tree from bottom up

		//Child One of root and its children
		SequenceTask idleSequence = new SequenceTask (idle_behavior);
		Task idleFrogAnimate = new FrogAnimateTask (idle_behavior,"is_idle");
		Task idleFrogTalk = new FrogTalkTask (idle_behavior,"hummingSong_uhThing");
		DecoratorTask frogTalkDecorator = new FrogTalkDecorator (idle_behavior, idleFrogTalk);
		idleSequence.child_list.Add (idleFrogAnimate);
		idleSequence.child_list.Add (frogTalkDecorator);
		 
		//Child Two of root and its children
		SelectorTask selectorNode = new SelectorTask (idle_behavior);
		Task jumpForwardFrog = new FrogJumpForwardTask (idle_behavior);
		selectorNode.child_list.Add (jumpForwardFrog);

		rootNode.child_list.Add (idleSequence);
		rootNode.child_list.Add (selectorNode);

		idle_behavior.task_tree.Add (rootNode);


		tree_dict.Add ("idle_behavior", idle_behavior);

		//Assign behavior trees to states
		idle.crnt_tree = tree_dict ["idle_behavior"];
		crnt_state = idle;
		nxt_state = idle;
	}
	
	// Update is called once per frame.  Implements a State Machine Processor
	void Update()
	{
		if(crnt_state.getID() != nxt_state.getID())
		{
			Debug.Log("OnEnter");
			crnt_state = nxt_state;
			//crnt_state.on_enter();
			crnt_state.onEnter ();
			
		}
		
		if(crnt_state.onProcess ())//crnt_state.getFinFlag() == false)
		{
			Debug.Log("Process");
			//crnt_state.on_process();
			//crnt_state.onProcess ();
		}
		else
		{
			Debug.Log ("exit");
			//crnt_state.on_exit();
			crnt_state.onExit ();
		}
	}
}
