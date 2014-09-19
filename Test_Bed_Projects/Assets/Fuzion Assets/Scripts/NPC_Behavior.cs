using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class NPC_Behavior : MonoBehaviour {

	private Animator anim;
	private AnimatorStateInfo crntBaseState;
	private AnimatorStateInfo layer2CrntState;
	public DialogueStateMachine dial_manager;
	public AudioClip	m_voice;
	public AudioSource  m_mouth;
	public bool			converse_gui;

	public delegate	void converse();

	public converse	converse_callback; 

   	void Start()
	{
		anim = GetComponent<Animator>();
		if(anim.layerCount == 2)
		{
			anim.SetLayerWeight(1,1);
		}
		m_mouth = this.gameObject.AddComponent<AudioSource>();
		m_mouth.playOnAwake = false;

		//player_dialogue_options.Add (new string ("Ask about the key"));
		//player_dialogue_options.Add (new string ("Exit Conversation"));

	}

	void FixedUpdate()
	{
		crntBaseState = anim.GetCurrentAnimatorStateInfo (1);

		if(anim.layerCount == 2)
		{
			layer2CrntState = anim.GetCurrentAnimatorStateInfo(1);
		}

		if(Input.GetKey("up"))
		{

			anim.SetBool ("talk_now",true);
			print ("up");
		}

	}

	void OnAnimatorMove()
	{

	}






	
	
}
  