using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class NPC_State : MonoBehaviour {

	public Animator anim;
	public AnimatorStateInfo crntBaseState;
	public AnimatorStateInfo layer2CrntState;
	public DialogueStateMachine dial_manager;
	public AudioClip	m_voice;
	public AudioSource  m_mouth;
	public bool			converse_gui;

	public delegate	void converse();

	public converse	converse_callback; 

	public float move_speed;
	public Vector3 move_direction;

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

		rigidbody.MovePosition (rigidbody.position + (move_speed * move_direction) * Time.deltaTime);

	}

	void OnAnimatorMove()
	{

	}

	void moveCharacter(float speed, Vector3 direction)
	{
		move_speed = speed;
		move_direction = direction;
	}


	
}
  