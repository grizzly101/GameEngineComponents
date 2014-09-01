using UnityEngine;
using System.Collections;

public class OpenCloseDoor : MonoBehaviour {
	 
	private JointMotor door_motor;
	
	//Default values.  Can be set in script inspector
	public bool    prevState = false;
	public bool	   crntState = false;
	public float   open_velocity = 100;
	public float   close_velocity = -100;
	public float   sound_threshold;
	private float  y_angle = 0;
		
	public AudioSource door_sound;
	//public AudioSource close_sound;
	
	public AudioClip open_clip;
	public AudioClip close_clip;
	private int counter = 0;

	

	void Update()
	{
		y_angle = this.transform.localEulerAngles.y;
		print (y_angle + " " + sound_threshold);
		if(y_angle <= sound_threshold)
		{
			if(crntState != prevState)
			{
				door_sound.PlayOneShot(door_sound.clip);
				prevState = crntState;
			}
		}

	}

	
	
	void interact()
	{
		//hingeJoint.motor = door_motor;
		//hingeJoint.useMotor = true;
		counter++;
	    if(crntState == true)
			crntState = false;
		else
			crntState = true;
		
		if(counter%2 ==0)
		{
			rigidbody.AddTorque (0,close_velocity,0);
			door_sound.clip = close_clip;
			
			
		}
		else if(counter %2 !=0)
		{
			rigidbody.AddTorque (0,open_velocity,0);
			door_sound.clip = open_clip;
		}		
	}

}



