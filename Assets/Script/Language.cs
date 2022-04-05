using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour {

	public Text play;
	public Text shop;
	public Text setting;
	public Text language;
	public Text lBtn;
	public Text view;
	public Text vBtn;
	public Text stress;
	public Text shopBoard;

	void Start () {
		if (PlayerPrefs.GetString ("Language") == "en") {
			play.text = "Play";
			shop.text = "Shop";
			setting.text = "Settings";
			language.text = "Language";
			lBtn.text = "English";
			view.text = "Reviews";
			vBtn.text = "Estimate";
			stress.text = "Stress levels";
			shopBoard.text = "Shop";
		} else{
			play.text = "Играть";
			shop.text = "Магазин";
			setting.text = "Настройки";
			language.text = "Язык";
			lBtn.text = "Русский";
			view.text = "Отзывы";
			vBtn.text = "Оценить";
			stress.text = "Уровень стресса";
			shopBoard.text = "Магазин";
		}
	}
	public void ChangeLanguage(){
		if (PlayerPrefs.GetString ("Language") == "ru") {
			PlayerPrefs.SetString ("Language", "en");
			play.text = "Play";
			shop.text = "Shop";
			setting.text = "Settings";
			language.text = "Language";
			lBtn.text = "English";
			view.text = "Reviews";
			vBtn.text = "Estimate";
			stress.text = "Stress levels";
			shopBoard.text = "Shop";
			GameObject.Find("Click").GetComponent<AudioSource>().Play();
		} 
		else {
			PlayerPrefs.SetString ("Language", "ru");
			play.text = "Играть";
			shop.text = "Магазин";
			setting.text = "Настройки";
			language.text = "Язык";
			lBtn.text = "Русский";
			view.text = "Отзывы";
			vBtn.text = "Оценить";
			stress.text = "Уровень стресса";
			shopBoard.text = "Магазин";
			GameObject.Find("Click").GetComponent<AudioSource>().Play();
		}
	}
}
