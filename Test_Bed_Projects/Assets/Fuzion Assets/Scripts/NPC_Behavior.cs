using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class NPC_Behavior : MonoBehaviour {

	public DialogueStateMachine dial_manager;
	public AudioClip	m_voice;
	public AudioSource  m_mouth;
	public bool			converse_gui;

	public delegate	void converse();

	public converse	converse_callback; 

   	void Start()
	{

		m_mouth = this.gameObject.AddComponent<AudioSource>();
		m_mouth.playOnAwake = false;

		//player_dialogue_options.Add (new string ("Ask about the key"));
		//player_dialogue_options.Add (new string ("Exit Conversation"));

	}






	
	
}
  