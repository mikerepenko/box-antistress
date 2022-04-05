using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdate : MonoBehaviour {

	public Text one;
	public Text two;
	public Text three;
	public GameObject buy;
	public GameObject limit;
	public Text money;

	void Start(){
		//Box 1
		if (PlayerPrefs.GetInt ("box") == 1) {
			one.text = "Выбран";
		} else
			one.text = "Не выбран";
		//Box 2
		if (PlayerPrefs.GetInt ("box") == 2) {
			two.text = "Выбран";
		} else {
			if (PlayerPrefs.GetInt ("buyone") == 1)
				two.text = "Не выбран";
			else
				two.text = "100000р";
		}
		//Box 3
		if (PlayerPrefs.GetInt ("box") == 3) {
			three.text = "Выбран";
		} else {
			if (PlayerPrefs.GetInt ("buytwo") == 1)
				three.text = "Не выбран";
			else
				three.text = "250000р";
		}
	}

	public void TextOne(){
		GameObject.Find("Click").GetComponent<AudioSource>().Play();
		PlayerPrefs.SetInt ("box", 1);
		//Box 1
		one.text = "Выбран";
		//Box 2
		if (PlayerPrefs.GetInt ("buyone") == 1)
			two.text = "Не выбран";
		else
			two.text = "100000р";
		//Box 3
		if (PlayerPrefs.GetInt ("buytwo") == 1)
			three.text = "Не выбран";
		else
			three.text = "250000р";
	}
	public void TextTwo(){
		GameObject.Find("Click").GetComponent<AudioSource>().Play();
		if (PlayerPrefs.GetInt ("buyone") == 1) {
			PlayerPrefs.SetInt ("box", 2);
			one.text = "Не выбран";
			two.text = "Выбран";
			if (PlayerPrefs.GetInt ("buytwo") == 1)
				three.text = "Не выбран";
			else
				three.text = "250000р";
			buy.SetActive (false);
		} else {
			//Параметр для покупки кубика
			PlayerPrefs.SetInt ("shop", 2);
			buy.SetActive (true);
			one.text = "Выбран";
			two.text = "100000р";
			if (PlayerPrefs.GetInt ("buytwo") == 1)
				three.text = "Не выбран";
			else
				three.text = "250000р";
		}
	}
	public void TextThree(){
		GameObject.Find("Click").GetComponent<AudioSource>().Play();
		if (PlayerPrefs.GetInt ("buytwo") == 1) {
			PlayerPrefs.SetInt ("box", 3);
			three.text = "Выбран";
			one.text = "Не выбран";
			if (PlayerPrefs.GetInt ("buyone") == 1)
				two.text = "Не выбран";
			else
				two.text = "100000р";
			buy.SetActive (false);
		} else {
			//Параметр для покупки кубика
			PlayerPrefs.SetInt ("shop", 3);
			buy.SetActive (true);
			one.text = "Выбран";
			three.text = "250000р";
			if (PlayerPrefs.GetInt ("buyone") == 1)
				two.text = "Не выбран";
			else
				two.text = "100000р";
		}
	}
	public void BuyBtn(){
		GameObject.Find("Click").GetComponent<AudioSource>().Play();
		//Проверка парметра кубика
		//Box 2
		if (PlayerPrefs.GetInt ("shop") == 2) {
			if (PlayerPrefs.GetInt ("money") >= 100000) {
				PlayerPrefs.SetInt ("money", PlayerPrefs.GetInt ("money") - 100000);
				money.text = PlayerPrefs.GetInt("money").ToString();
				PlayerPrefs.SetInt ("buyone", 1);
				two.text = "Не выбран";
				GameObject.Find("Coins").GetComponent<AudioSource>().Play();
				buy.SetActive (false);
			} else
				limit.SetActive (true);
		}
		//Box 3	
		if (PlayerPrefs.GetInt ("shop") == 3) {
			PlayerPrefs.SetInt ("money", PlayerPrefs.GetInt ("money") - 250000);
			money.text = PlayerPrefs.GetInt("money").ToString();
			if (PlayerPrefs.GetInt ("money") >= 250000) {
				PlayerPrefs.SetInt ("buytwo", 1);
				three.text = "Не выбран";
				GameObject.Find("Coins").GetComponent<AudioSource>().Play();
				buy.SetActive (false);
			} else
				limit.SetActive (true);
		}
	}
}
