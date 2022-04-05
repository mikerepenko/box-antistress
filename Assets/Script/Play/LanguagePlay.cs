using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LanguagePlay : MonoBehaviour {

	public Text stress;
	
	void Start () {
		if (PlayerPrefs.GetString ("Language") == "ru") {
			stress.text = "Уровень стресса";
		} else {
			stress.text = "Stress levels";
		}
	}
}
