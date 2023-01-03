using UnityEngine;
using System;
using System.Collections;
using UnityEngine.Audio;
using System.Collections.Generic;
using FDTGloveUltraCSharpWrapper;

public class Glove : MonoBehaviour 
{
	public GameObject[] CaracterList; 
	List<Animator> animatorList = new List<Animator>();
	CfdGlove guanteObject;


	void Start () {
	
		guanteObject = new CfdGlove();
		try{
			guanteObject.Open("USB0");
			GetComponent<Light>().intensity = 5.0f;

		} catch {
			GetComponent<Light>().intensity = 1.0f;
		}
		if (CaracterList.Length >= 1) 
		{
			for (int i = 0; i < CaracterList.Length; i++) 
			{
				animatorList.Add(CaracterList[i].GetComponent<Animator>());
				animatorList[i].enabled = false; 
			}
		}
		else
		{
			return; 
		}
		
	}
	
	public void CaracterIdle(string caracterName)
	{
		if (CaracterList.Length >= 1)
		{
			for (int i = 0; i < CaracterList.Length; i++)
			{
				if (CaracterList[i].name == caracterName)
				{
					animatorList[i].enabled = true;
					animatorList[i].SetBool("idle", true);
					animatorList[i].SetBool("dance", false);
					
				}
			}
		}
		else
		{
			return;
		}
	}
	public void CaracterDance(string caracterName1)
	{
		if (CaracterList.Length >= 1)
		{
			for (int i = 0; i < CaracterList.Length; i++)
			{
				if (CaracterList[i].name == caracterName1)
				{
					animatorList[i].enabled = true;
					animatorList[i].SetBool("dance",true);
					animatorList[i].SetBool("idle", false);
				}
			}
		}
		else
		{
			return;
		}
	}

	// Update is called once per frame
	void Update () {

		if(guanteObject.IsOpen())
		{
			int gesture = guanteObject.GetGesture();
			GetComponent<Light>().color = Color.green;
			
			if (gesture.Equals(0))
			{FindObjectOfType<AudioManager>().Play("Dance");
				GetComponent<Light>().color = Color.red;
				CaracterDance("MantisIdle");
				CaracterDance("TigressIdle");
				CaracterDance("PandaIdle");

			}
			else if (gesture.Equals(1)) {
				GetComponent<Light>().color = Color.yellow;

			}
		} else {
			if (Input.GetKey("1"))
			{
				
				GetComponent<Light>().color = Color.green;
				

			} else if (Input.GetKey("2")) {
				CaracterIdle("MantisIdle");
				CaracterIdle("TigressIdle");
				CaracterIdle("PandaIdle");
				GetComponent<Light>().color = Color.yellow;

				
			} else if (Input.GetKey("3")) {
			
			
				GetComponent<Light>().color = Color.red;
				

			} else if (Input.GetKey("0")) {
				GetComponent<Light>().color = Color.white;
			}
		}
	
	}
	
	void OnGUI () 
	{
		string s;
		int offset = 20;
		for (int i = 0; i < 16; i++)
		{
			s = "Sensor " + i.ToString() + " scaled value = " + guanteObject.GetSensorScaled(i).ToString();
			GUI.Label(new Rect(10,offset,400,20+offset), s);
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
