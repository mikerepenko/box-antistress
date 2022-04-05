using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IapButtons : MonoBehaviour {

	public void Buy1()
	{
		if (PlayerPrefs.GetInt ("buyone") != 1) {
			IapDonate.Instance.BuyOne ();
			PlayerPrefs.SetInt ("box", 2);
		}
		else
			PlayerPrefs.SetInt ("box", 2);
	}
	public void Buy2()
	{
		if (PlayerPrefs.GetInt ("buytwo") != 1) {
			IapDonate.Instance.BuyTwo ();
			PlayerPrefs.SetInt ("box", 3);
		} 
		else
			PlayerPrefs.SetInt ("box", 3);
	}
	public void Buy3()
	{
		if (PlayerPrefs.GetInt ("buythree") != 1) {
			IapDonate.Instance.BuyThree ();
			PlayerPrefs.SetInt ("box", 4);
		}
		else
			PlayerPrefs.SetInt ("box", 4);
	}
	public void BuyNoAds()
	{
		if (PlayerPrefs.GetInt ("noads") != 1)
			IapDonate.Instance.BuyNoAds();	
	}
}
