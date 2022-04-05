using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour {

	public AudioSource click;
	public GameObject m_on, m_off;
	public LanguageAnim languageAnim;

	void Start () {
		click = click.GetComponent<AudioSource> ();
	}
	public void PlayBtn(){
		click.Play ();
		Application.LoadLevel ("play");
	}
	public void ShopBtn(){
		click.Play ();
	}
	public void Click(){
		click.Play ();
	}
	public void Home(){
		click.Play ();
		Application.LoadLevel ("menu");
	}
	public void MusicBtn(){
		if (PlayerPrefs.GetString("Music") != "no")
		{
			PlayerPrefs.SetString("Music", "no");
			m_on.SetActive(false);
			m_off.SetActive(true);
			AudioListener.pause = true;
		}
		else
		{           
			PlayerPrefs.SetString("Music", "yes");                  
			m_on.SetActive(true);
			m_off.SetActive(false); 
			AudioListener.pause = false;
			click.Play ();
		}
	}
}
