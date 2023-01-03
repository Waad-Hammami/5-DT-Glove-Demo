using UnityEngine;
using System;
using System.Collections;
using FDTGloveUltraCSharpWrapper;
public class GloveAudio : MonoBehaviour
{
	
	CfdGlove guanteObject;

	// Use this for initialization
	void Start()
	{
	
		guanteObject = new CfdGlove();
		


	}

	// Update is called once per frame
	void Update()
	{

		if (guanteObject.IsOpen())
		{
			int gesture = guanteObject.GetGesture();
			if (gesture.Equals(0))
			{
			
				FindObjectOfType<AudioManager>().Play("Dance");

			}
		}
		else
		{
			if (Input.GetKey("3"))
			{
				FindObjectOfType<AudioManager>().Play("Dance");
			}
		}

	}

	void OnGUI()
	{
		string s;
		int offset = 20;
		for (int i = 0; i < 16; i++)
		{
			s = "Sensor " + i.ToString() + " scaled value = " + guanteObject.GetSensorScaled(i).ToString();
			GUI.Label(new Rect(10, offset, 400, 20 + offset), s);
			offset += 20;
		}


		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		//		if(GUI.Button(new Rect(20,40,80,20), "Level 1")) {
		//			Application.LoadLevel(1);
		//		}
		//
		//		// Make the second button.
		//		if(GUI.Button(new Rect(20,70,80,20), "Level 2")) {
		//			Application.LoadLevel(2);
		//		}
	}
}
