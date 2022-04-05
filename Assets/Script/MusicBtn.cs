using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicBtn : MonoBehaviour {

	void Start () {
		if (PlayerPrefs.GetString("Music") == "no")
		{
			if(gameObject.name == "On")
				gameObject.SetActive(false);        
		}
		else
		{
			if(gameObject.name == "Off")
				gameObject.SetActive(false);               
		}
	}
}
