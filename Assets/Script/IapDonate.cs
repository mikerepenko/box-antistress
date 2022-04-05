using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

public class IapDonate : MonoBehaviour, IStoreListener
{
	public MenuManager menuManager;


	public static IapDonate Instance{set;get;}

	private static IStoreController m_StoreController;          // The Unity Purchasing system.
	private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.

	public static string PRODUCT_1 =    "box1";
	public static string PRODUCT_2 =    "box2";   
	public static string PRODUCT_3 =    "box3"; 
	public static string PRODUCT_4 =    "box4";   
	public static string PRODUCT_NO_ADS =    "noads";  

	private void Awake()
	{
		Instance = this;
	}

	private void Start()
	{
		if (m_StoreController == null)
		{
			InitializePurchasing();
		}
	}

	public void InitializePurchasing() 
	{
		if (IsInitialized())
		{
			return;
		}

		var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());


		builder.AddProduct(PRODUCT_1, ProductType.Consumable);
		builder.AddProduct(PRODUCT_2, ProductType.Consumable);
		builder.AddProduct(PRODUCT_3, ProductType.Consumable);
		builder.AddProduct(PRODUCT_4, ProductType.Consumable);

		UnityPurchasing.Initialize(this, builder);
	}


	private bool IsInitialized()
	{
		return m_StoreController != null && m_StoreExtensionProvider != null;
	}


	public void BuyOne()
	{
		BuyProductID(PRODUCT_1);
	}
	public void BuyTwo()
	{
		BuyProductID(PRODUCT_2);
	}
	public void BuyThree()
	{
		BuyProductID(PRODUCT_3);
	}
	public void BuyNoAds()
	{
		BuyProductID(PRODUCT_NO_ADS);
	}


	private void BuyProductID(string productId)
	{
		// If Purchasing has been initialized ...
		if (IsInitialized())
		{
			// ... look up the Product reference with the general product identifier and the Purchasing 
			// system's products collection.
			Product product = m_StoreController.products.WithID(productId);

			// If the look up found a product for this device's store and that product is ready to be sold ... 
			if (product != null && product.availableToPurchase)
			{
				Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
				// ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed 
				// asynchronously.
				m_StoreController.InitiatePurchase(product);
			}
			// Otherwise ...
			else
			{
				// ... report the product look-up failure situation  
				Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
			}
		}
		// Otherwise ...
		else
		{
			// ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or 
			// retrying initiailization.
			Debug.Log("BuyProductID FAIL. Not initialized.");
		}
	}

	public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
	{
		Debug.Log("OnInitialized: PASS");
		m_StoreController = controller;
		m_StoreExtensionProvider = extensions;
	}


	public void OnInitializeFailed(InitializationFailureReason error)
	{
		Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
	}


	public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args) 
	{
		if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_1, StringComparison.Ordinal))
		{
			//menuManager.BuyOne ();
		}
		else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_2, StringComparison.Ordinal))
		{
			//menuManager.BuyTwo ();
		}
		else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_3, StringComparison.Ordinal))
		{
			//menuManager.BuyThree ();
		}
		else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_NO_ADS, StringComparison.Ordinal))
		{
			//menuManager.BuyNoAds ();
		}
		// Or ... an unknown product has been purchased by this user. Fill in additional products here....
		else 
		{
			Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
		}

		// Return a flag indicating whether this product has completely been received, or if the application needs 
		// to be reminded of this purchase at next app launch. Use PurchaseProcessingResult.Pending when still 
		// saving purchased products to the cloud, and when that save is delayed. 
		return PurchaseProcessingResult.Complete;
	}


	public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
	{
		// A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing 
		// this reason with the user to guide their troubleshooting actions.
		Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
	}
}