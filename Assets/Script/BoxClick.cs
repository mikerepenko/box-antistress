using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxClick : MonoBehaviour {

	public bool isClick;
	private bool isCircle;
	private bool isDoor;
	private bool isSphera;
	public Hp hp;
	private int name;
	private bool isThree;
	public GameObject around;
	public GameObject spheraAudio;
	private int maxAds = 20;

	void Start(){
		PlayerPrefs.SetInt ("ads", 0);
		isClick = true;
		if(gameObject.name == "Door")
			name = 1;
		if (gameObject.name == "Circle")
			name = 2;
		if (gameObject.name == "3")
			name = 3;
		if (gameObject.name == "Sphera")
			name = 4;
	}
	void Update(){
		if (name == 1) {
			if (isDoor) {
				transform.Rotate (new Vector3 (20, 0, 0));
			}
		}
		if (name == 2) {
			if (isCircle) {
				transform.Rotate (new Vector3 (transform.localRotation.x, transform.localRotation.y, 5000f));
			}
		}
		if (name == 3) {
			if (isThree) {
				transform.Rotate (new Vector3 (transform.localRotation.x, transform.localRotation.y, 5000f));
			}
		}
		if (name == 4) {
			if (isSphera) {
				transform.Rotate (new Vector3 (transform.localRotation.x, transform.localRotation.y, 50f));
			}
		}
	}

	void OnMouseUp(){
		switch (gameObject.name) {
		case "A":
			GameObject.Find ("Abcde").GetComponent<AudioSource> ().Play ();
			this.transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, 1.513353f);
			break;
		case "B":
			GameObject.Find ("Abcde").GetComponent<AudioSource> ().Play ();
			this.transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, 1.513353f);
			break;
		case "C":
			GameObject.Find ("Abcde").GetComponent<AudioSource> ().Play ();
			this.transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, 1.513353f);
			break;
		case "D":
			GameObject.Find ("Abcde").GetComponent<AudioSource> ().Play ();
			this.transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, 1.513353f);
			break;
		case "E":
			GameObject.Find ("Abcde").GetComponent<AudioSource> ().Play ();
			this.transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, 1.513353f);
			break;
		case "Sphera":
			isSphera = false;
			spheraAudio.SetActive (false);
			break;
		case "Circle":
			isCircle = false;
			around.SetActive(false);
			break;
		case "Door":
			isDoor = false;
			around.SetActive(false);
			break;
		case "3":
			isThree = false;
			around.SetActive(false);
			break;
		}
	}
	void OnMouseDown(){
		switch (gameObject.name) 
		{
		case "Button":
			PlayerPrefs.SetInt ("money", PlayerPrefs.GetInt ("money") + 1);
			if (!isClick) {
				this.transform.localRotation = Quaternion.Euler (0, 78f, -90f);
				this.transform.localPosition = new Vector3 (-0.3f, 0.1007578f, 0);
				hp.AddStress ();
				GameObject.Find("Click").GetComponent<AudioSource>().Play();
				isClick = true;
			} 
			else {
				this.transform.localRotation = Quaternion.Euler (0, 90, -90);
				this.transform.localPosition = new Vector3 (0, 0.1007578f, 0);
				hp.AddStress ();
				GameObject.Find("Click").GetComponent<AudioSource>().Play();
				isClick = false;
			}
			break;
		case "3":
			PlayerPrefs.SetInt ("money", PlayerPrefs.GetInt ("money") + 1);
			isThree = true;
			hp.AddStress ();
			around.SetActive (true);
			break;
		case "Circle":
			PlayerPrefs.SetInt ("money", PlayerPrefs.GetInt ("money") + 1);
			isCircle = true;
			hp.AddStress ();
			around.SetActive (true);
			break;
		case "Sphera":
			PlayerPrefs.SetInt ("money", PlayerPrefs.GetInt ("money") + 1);
			isSphera = true;
			hp.AddStress ();
			spheraAudio.SetActive (true);
			break;
		case "Door":
			PlayerPrefs.SetInt ("money", PlayerPrefs.GetInt ("money") + 1);
			isDoor = true;
			hp.AddStress ();
			around.SetActive (true);
			break;
		case "A":
			PlayerPrefs.SetInt ("money", PlayerPrefs.GetInt ("money") + 1);
			GameObject.Find ("Abcde").GetComponent<AudioSource> ().Play ();
			this.transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, 1.36f);
			hp.AddStress ();
			break;
		case "B":
			PlayerPrefs.SetInt ("money", PlayerPrefs.GetInt ("money") + 1);
			GameObject.Find ("Abcde").GetComponent<AudioSource> ().Play ();
			this.transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, 1.36f);
			hp.AddStress ();
			break;
		case "C":
			PlayerPrefs.SetInt ("money", PlayerPrefs.GetInt ("money") + 1);
			GameObject.Find ("Abcde").GetComponent<AudioSource> ().Play ();
			this.transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, 1.36f);
			hp.AddStress ();
			break;
		case "D":
			PlayerPrefs.SetInt ("money", PlayerPrefs.GetInt ("money") + 1);
			GameObject.Find ("Abcde").GetComponent<AudioSource> ().Play ();
			this.transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, 1.36f);
			hp.AddStress ();
			break;
		case "E":
			PlayerPrefs.SetInt ("money", PlayerPrefs.GetInt ("money") + 1);
			GameObject.Find ("Abcde").GetComponent<AudioSource> ().Play ();
			this.transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, 1.36f);
			hp.AddStress ();
			break;
		}
		Ads ();
	}
	public void Ads(){
		//Ads count
		PlayerPrefs.SetInt ("ads", PlayerPrefs.GetInt ("ads") + 1);
		if (PlayerPrefs.GetInt ("ads") >= maxAds) {
			GameObject.Find ("GameManager").GetComponent<GameManager> ().BoxAds ();
			PlayerPrefs.SetInt ("ads", 0);
		}
	}
}
