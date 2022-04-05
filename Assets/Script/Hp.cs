using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hp : MonoBehaviour {

	GameObject bar;
	private float count;

	void Start () {
		//Уровень стресса
		if (PlayerPrefs.GetFloat ("Hp") >= 481)
			PlayerPrefs.SetFloat ("Hp", 0);
		count = PlayerPrefs.GetFloat("Hp");
			gameObject.GetComponent<RectTransform> ().sizeDelta = new Vector2(count, 25);
	}

	public void AddStress(){
		PlayerPrefs.SetFloat ("Hp", PlayerPrefs.GetFloat ("Hp") + 1);

		if (PlayerPrefs.GetFloat ("Hp") > 481)
			PlayerPrefs.SetFloat ("Hp", 481);
		count = PlayerPrefs.GetFloat("Hp");
		gameObject.GetComponent<RectTransform> ().sizeDelta = new Vector2(count, 25);
	}
}
