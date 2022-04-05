using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AppodealAds.Unity.Common;
using AppodealAds.Unity.Api;

public class GameManager : MonoBehaviour, IRewardedVideoAdListener {

	#region Rewarded Video callback handlers
	public void onRewardedVideoLoaded() {  }
	public void onRewardedVideoFailedToLoad() {  }
	public void onRewardedVideoShown() {  }
	public void onRewardedVideoClosed() {  }
	public void onRewardedVideoFinished(int amount, string name)
	{
		if (isAds) {
			AddMoney (500);
			isAds = false;
		}
	}
	#endregion

	private int rund;
	public Text money;
	private bool isAds;

	void Awake () {
		//Подключение Appodeal
		string appKey = "932d94c1696799cef40c95f798e4dcc0d2d63cbfd9c1f1e3";
		Appodeal.disableLocationPermissionCheck();
		//Appodeal.setTesting(true);
		//Appodeal.confirm(Appodeal.SKIPPABLE_VIDEO);
		Appodeal.initialize(appKey, Appodeal.REWARDED_VIDEO | Appodeal.INTERSTITIAL);
		Appodeal.setRewardedVideoCallbacks(this);
	}
	public void AddMoney(int c){
		PlayerPrefs.SetInt ("money", PlayerPrefs.GetInt ("money") + c);
		money.text = PlayerPrefs.GetInt("money").ToString();
	}
	public void AdsClick(){
		isAds = true;
		StartCallBack ();
	}
	public void StopBanner()
	{
		Appodeal.hide(Appodeal.BANNER_BOTTOM);
		Appodeal.hide(Appodeal.INTERSTITIAL);
	}
	public void StartCallBack()
	{
		if (Appodeal.isLoaded(Appodeal.REWARDED_VIDEO ))
			Appodeal.show(Appodeal.REWARDED_VIDEO );
	}
	public void StartInterstitial()
	{  
		if (Appodeal.isLoaded(Appodeal.INTERSTITIAL))
			Appodeal.show(Appodeal.INTERSTITIAL);
	}
	public void StartBanner()
	{
		if (Appodeal.isLoaded(Appodeal.BANNER_BOTTOM))
			Appodeal.show(Appodeal.BANNER_BOTTOM);
	}
	void Start(){
		money.text = PlayerPrefs.GetInt ("money").ToString ();
		//Очистка рекламы
		Appodeal.hide(Appodeal.INTERSTITIAL);
		//Проверка купленной версии без рекламы
		if (PlayerPrefs.GetInt ("noads") != 1) {
			StartInterstitial ();
		}
	}
	public void BoxAds(){
		StartInterstitial ();
	}
}
