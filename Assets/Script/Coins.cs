using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Coins : MonoBehaviour {

	Text m;

	void Start(){
		m = gameObject.GetComponent<Text> ();
	}
	void Update () {
		m = gameObject.GetComponent<Text> ();
		m.text = PlayerPrefs.GetInt("money").ToString();
	}
}
