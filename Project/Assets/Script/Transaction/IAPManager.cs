﻿using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Purchasing;

	// Deriving the Purchaser class from IStoreListener enables it to receive messages from Unity Purchasing.
public class IAPManager : MonoBehaviour, IStoreListener
{

	private static IAPManager Instance{ set; get;}

		private static IStoreController m_StoreController;          // The Unity Purchasing system.
		private static IExtensionProvider m_StoreExtensionProvider; // The store-specific Purchasing subsystems.

		public static string PRODUCT_100_GOLD = "buy100";   
		public static string PRODUCT_500_GOLD = "buy500";
		public static string PRODUCT_999_GOLD = "buy999"; 

	int coins;

	private void Awake() {

		Instance = this;
	}

	private void Start()
	{

	coins = PlayerPrefs.GetInt ("coin", 0);

		// If we haven't set up the Unity Purchasing reference
		if (m_StoreController == null)
		{
			// Begin to configure our connection to Purchasing
			InitializePurchasing();
		}
	}

	public void InitializePurchasing() 
	{
		// If we have already connected to Purchasing ...
		if (IsInitialized())
		{
			// ... we are done here.
			return;
		}
			
		var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());


	builder.AddProduct(PRODUCT_100_GOLD, ProductType.Consumable);
	builder.AddProduct(PRODUCT_500_GOLD, ProductType.Consumable);
	builder.AddProduct(PRODUCT_999_GOLD, ProductType.Consumable);

		UnityPurchasing.Initialize(this, builder);
	}


	private bool IsInitialized()
	{
		// Only say we are initialized if both the Purchasing references are set.
		return m_StoreController != null && m_StoreExtensionProvider != null;
	}


	public void Buy100Gold()
	{

		BuyProductID(PRODUCT_100_GOLD);
	}

	public void Buy500Gold()
	{

		BuyProductID(PRODUCT_500_GOLD);
	}

	public void Buy999Gold()
	{

		BuyProductID(PRODUCT_999_GOLD);
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
		// Purchasing has succeeded initializing. Collect our Purchasing references.
		Debug.Log("OnInitialized: PASS");

		// Overall Purchasing system, configured with products for this application.
		m_StoreController = controller;
		// Store specific subsystem, for accessing device-specific store features.
		m_StoreExtensionProvider = extensions;
	}


	public void OnInitializeFailed(InitializationFailureReason error)
	{
		// Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
		Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
	}
    
        
	public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args) 
	{
		// A consumable product has been purchased by this user.
		if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_100_GOLD, StringComparison.Ordinal))
		{
			Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
                
			// The consumable item has been successfully purchased, add 100 coins to the player's in-game score.
			coins += 100;
			if (coins > 999)
				coins = 999;
            StartCoroutine(new InformationModify().SendInfo("Coins", coins));

            StartCoroutine(new InformationHolder().Account(InformationHolder.AccountData.Username, PlayerPrefs.GetString("PASSWORD", null)));
        }
			// Or ... a non-consumable product has been purchased by this user.
		else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_500_GOLD, StringComparison.Ordinal))
			{
				Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
			    coins += 500;
			    if (coins > 999)
				    coins = 999;
                StartCoroutine(new InformationModify().SendInfo("Coins", coins));
                StartCoroutine(new InformationHolder().Account(InformationHolder.AccountData.Username, PlayerPrefs.GetString("PASSWORD", null)));
        }
			// Or ... a subscription product has been purchased by this user.
		else if (String.Equals(args.purchasedProduct.definition.id, PRODUCT_999_GOLD, StringComparison.Ordinal))
			{
				Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));
			coins += 999;
			if (coins > 999)
				coins = 999;
            StartCoroutine(new InformationModify().SendInfo("Coins", coins));
            StartCoroutine(new InformationHolder().Account(InformationHolder.AccountData.Username, PlayerPrefs.GetString("PASSWORD", null)));
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