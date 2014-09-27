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

	//State Flags
	public bool is_talking;

   	void Start()
	{  
		is_talking = false;
		anim = GetComponent<Animator>();
		if(anim.layerCount == 2)
		{
			anim.SetLayerWeight(1,1);
		}
		m_mouth = this.gameObject.AddComponent<AudioSource>();



	}

	void FixedUpdate()
	{
		crntBaseState = anim.GetCurrentAnimatorStateInfo (1);

		if(anim.layerCount == 2)
		{
			layer2CrntState = anim.GetCurrentAnimatorStateInfo(1);
		}

		rigidbody.MovePosition (rigidbody.position + (move_speed * move_direction) * Time.deltaTime);

		Speak();

	}

	void OnAnimatorMove()
	{

	}

	void Speak()
	{
		Debug.Log ("Called Speak");
		Debug.Log (is_talking);
		if(is_talking)
		{
			//m_mouth.PlayOneShot(m_voice,1);
			//m_voice = (AudioClip)Resources.Load ("Unicorn", typeof(AudioClip));
			m_mouth.clip = m_voice;
			m_mouth.Play();
			is_talking = false;
		}
	}

	void moveCharacter(float speed, Vector3 direction)
	{
		move_speed = speed;
		move_direction = direction;
	}


	
}
  