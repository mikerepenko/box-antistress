using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameBox : MonoBehaviour {

	public GameObject box1;
	public GameObject box2;
	public GameObject box3;

	void Awake(){
		if (PlayerPrefs.GetInt ("box") == 1)
			box1.SetActive (true);
		if (PlayerPrefs.GetInt ("box") == 2)
			box2.SetActive (true);
		if (PlayerPrefs.GetInt ("box") == 3)
			box3.SetActive (true);
	}
}
