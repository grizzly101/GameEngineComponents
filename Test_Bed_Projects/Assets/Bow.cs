using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Bow : MonoBehaviour {

	//Is the player pulling the arrow back on the bow-string?
	public bool	pulled_arrow;

	//Used to calculate the amount of force on the arrow from the bow-string
	public float pull_timer;

	/*
	 * Determines the type of arrow to instantiate for firing.
	 * Set by the player when they select ammunition 
	*/
	string arrow_type;
	
	public GameObject bow_object;

	/*
	 * List of Arrow prefabs to clone for firing.  Determined by arrow_type.
	 * The tuple contains the prefab, quantity of arrow player owns, name of arrow
	 * (Actually Stored inside Players Inventory Component and Accessed from here)
	*/
	public struct TypeArrow{
		public GameObject arrow_prefab;
		public int		   arrow_quantity;
		public string	   arrow_name;
	}

	List<TypeArrow> 	player_quill;

	public GameObject temp_fire_arrow;  //fire arrow prefab (place holder for this script);  All arrow prefabs should be instantiated in the player_quill

	//Clone of arrow_prefab_object - used as the projectile
	GameObject p_arrow;

	/*
	 * Define the position and orientation of the arrow from which it is being
	 * fired.  Set by the players camera.
	*/
	Vector3 p_arrow_pos;
	Vector3 p_rotation;

	// Use this for initialization
	void Start () 
	{
		/*
		 * Initialize an arrow type to add to the players quill.
		 * This will be done in the players inventory when they first unlock the arrow type.
		*/ 
		TypeArrow fire_arrow;
		fire_arrow.arrow_name = "fire";
		fire_arrow.arrow_prefab = temp_fire_arrow;
		fire_arrow.arrow_quantity = 5;

		//player_quill.Add (fire_arrow);
	}

	/*
	 * Instantiates an arrow in the bow once the player draws their bow
	 * from their inventory.
	*/ 
	void BowDrawn()
	{
		//Initialize Clone of arrow to fire
		p_arrow = Instantiate (temp_fire_arrow) as GameObject;

		//Position p_arrow here
	}

	//Call this in Update once per frame
	void PullBow()
	{
		//Left Mouse held down
		if (Input.GetMouseButton (0)) //pulling bow back
		{
			pulled_arrow = true;

		}
		else if(Input.GetMouseButton (1)) //cancel shot: right mouse pressed
		{
			pulled_arrow = false;
		}
		else if(pulled_arrow == true) //pull has been released (left-click is false now)
		{
			//calculate force on arrow

			/*
			 * If more arrows available then reset arrow on screen by
			 * calling BowDrawn()
			*/

			//reset variables
			pulled_arrow = false;
		}
	}

	//call this in FixedUpdate
	void FireArrow()
	{
		//apply force to arrow to shoot forward
	}

}
