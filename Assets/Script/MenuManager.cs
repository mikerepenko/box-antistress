using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AppodealAds.Unity.Common;
using AppodealAds.Unity.Api;

public class MenuManager : MonoBehaviour, IRewardedVideoAdListener {

	#region Rewarded Video callback handlers
	public void onRewardedVideoLoaded() {  }
	public void onRewardedVideoFailedToLoad() {  }
	public void onRewardedVideoShown() {  }
	public void onRewardedVideoClosed() {  }
	public void onRewardedVideoFinished(int amount, string name)
	{
			AddMoney (500);
	}
	#endregion

	public Text money;

	void Awake () {
		//При первом вкл
		if (PlayerPrefs.GetInt ("firststart") != 1) {
			PlayerPrefs.SetInt ("box", 1);
			PlayerPrefs.SetString ("Language", "ru");
			PlayerPrefs.SetInt ("money", 100);
			//Выкл первого запуска
			PlayerPrefs.SetInt ("firststart", 1);
		}
		//Подключение Appodeal
		string appKey = "932d94c1696799cef40c95f798e4dcc0d2d63cbfd9c1f1e3";
		Appodeal.disableLocationPermissionCheck();
		//Appodeal.setTesting(true);
		//Appodeal.confirm(Appodeal.SKIPPABLE_VIDEO);
		Appodeal.initialize(appKey, Appodeal.REWARDED_VIDEO | Appodeal.INTERSTITIAL);
		Appodeal.setRewardedVideoCallbacks(this);
	}
	void Start(){
		money.text = PlayerPrefs.GetInt ("money").ToString ();
	}
	public void AddMoney(int c){
		PlayerPrefs.SetInt ("money", PlayerPrefs.GetInt ("money") + c);
		money.text = PlayerPrefs.GetInt("money").ToString();
	}
	public void AdsClick(){
		if (Appodeal.isLoaded(Appodeal.REWARDED_VIDEO ))
			Appodeal.show(Appodeal.REWARDED_VIDEO );
	}
}
