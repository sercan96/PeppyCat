using System;
using UnityEngine;
using UnityEngine.Purchasing;

public class IAPController : MonoBehaviour,IStoreListener
{
    IStoreController controller;
    public string product;


    public void Start() {
        IAPStart();
    }

    private void IAPStart()
    {
       var module = StandardPurchasingModule.Instance();
       ConfigurationBuilder builder = ConfigurationBuilder.Instance(module);
       builder.AddProduct(product,ProductType.Consumable);
       UnityPurchasing.Initialize(this,builder);
    }
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
         this.controller = controller;
    }
    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("Error Initialized");
    }
    public void OnInitializeFailed(InitializationFailureReason error, string? message)
    {
        Debug.Log("Error Initialized");
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
         Debug.Log("Purchase Failed");
    }
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs e)
    {
        if(string.Equals(e.purchasedProduct.definition.id,product,StringComparison.Ordinal))
        {
            if(PlayerPrefs.GetInt("Noads") == 0)
            {
                PlayerPrefs.SetInt("Noads",1);
                UIManager.Instance.NoAdsRemove();
            }
            return PurchaseProcessingResult.Complete;
        }
        else
        {
            return PurchaseProcessingResult.Pending;
        }
    }
   

    public void IAPButton(string id)
    {
        Product product = controller.products.WithID(id);
        if(product!=null && product.availableToPurchase)
        {
            controller.InitiatePurchase(product);
            Debug.Log("Buying");
        }
        else
        {
            Debug.Log("Not Buying");
        }
    }

} 