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
		dial_manager = GameObject.Find ("Game_Manager").GetComponent<GameStateManager>().d_manager;
		m_mouth = this.gameObject.AddComponent<AudioSource>();
		m_mouth.playOnAwake = false;
		converse_gui = false;
		converse_callback = NPCDisplay;
		//player_dialogue_options.Add (new string ("Ask about the key"));
		//player_dialogue_options.Add (new string ("Exit Conversation"));

	}

	void OnGUI()
	{

	  if(converse_gui)
	  {
			Screen.showCursor = converse_gui;

			converse_callback ();
			NPCDisplay ();
			//if(GUI.Button (new Rect (20,40,300,20), "Ask About the key.")) 
			//{
				
		//	}

		//	if(GUI.Button (new Rect (20,80,300,20), "Exit Conversation.")) 
		//	{
		
		//	}
		}
		else
		{
			Screen.showCursor = false;
		}

	}

	void NPCDisplay()
	{
		GUI.Box(new Rect(0, 0, 100, 200), "Bobby The Key Master <HP 003|MP N/A |Keys 100>");
	}

	void interact()    
	{

		dial_manager.LoadNPCstateGraph("Bobby");
		print ("Hello I'm Bobby!");

	}
	

	
	
}
  