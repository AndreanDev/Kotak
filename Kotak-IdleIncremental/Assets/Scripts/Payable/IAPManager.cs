using UnityEngine;
// using UnityEngine.Purchasing;
// using UnityEngine.Purchasing.Extension;

public class IAPManager : MonoBehaviour//, IStoreListener
{
    // private static IStoreController storeController;
    // private static IExtensionProvider storeExtensionProvider;

    // public Payable payable;

    // // Product IDs (must exactly match the Play Console setup)
    // public const string DIAMOND001 = "diamond001";
    // public const string DIAMOND002 = "diamond002";
    // public const string DIAMOND003 = "diamond003";
    // public const string DIAMOND004 = "diamond004";
    // public const string BOOST001 = "boost001"; // Coin Fever
    // public const string BOOST002 = "boost002"; // No Ads

    // void Start()
    // {
    //     if (storeController == null)
    //     {
    //         InitializePurchasing();
    //     }
    // }

    // public void InitializePurchasing()
    // {
    //     var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

    //     builder.AddProduct(DIAMOND001, ProductType.Consumable);
    //     builder.AddProduct(DIAMOND002, ProductType.Consumable);
    //     builder.AddProduct(DIAMOND003, ProductType.Consumable);
    //     builder.AddProduct(DIAMOND004, ProductType.Consumable);
    //     builder.AddProduct(BOOST001, ProductType.NonConsumable); // Coin Fever
    //     builder.AddProduct(BOOST002, ProductType.NonConsumable); // No Ads

    //     UnityPurchasing.Initialize(this, builder);
    // }

    // public void BuyProduct(string productId)
    // {
    //     if (storeController != null)
    //     {
    //         Product product = storeController.products.WithID(productId);

    //         if (product != null && product.availableToPurchase)
    //         {
    //             storeController.InitiatePurchase(product);
    //         }
    //         else
    //         {
    //             Debug.Log("Product not available");
    //         }
    //     }
    //     else
    //     {
    //         Debug.Log("StoreController is not initialized");
    //     }
    // }

    // public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    // {
    //     string id = args.purchasedProduct.definition.id;

    //     switch (id)
    //     {
    //         case DIAMOND001:
    //             payable.TopUpDiamond(150); break;
    //         case DIAMOND002:
    //             payable.TopUpDiamond(475); break;
    //         case DIAMOND003:
    //             payable.TopUpDiamond(1080); break;
    //         case DIAMOND004:
    //             payable.TopUpDiamond(2520); break;
    //         case BOOST001:
    //             payable.TopUpCoinFever(); break;
    //         case BOOST002:
    //             payable.TopUpNoAdvertisement(); break;
    //     }

    //     return PurchaseProcessingResult.Complete;
    // }

    // public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    // {
    //     storeController = controller;
    //     storeExtensionProvider = extensions;
    //     Debug.Log("Unity IAP Initialized");
    // }

    // // Required by older IAP versions (some systems still expect this)
    // public void OnInitializeFailed(InitializationFailureReason error)
    // {
    //     Debug.Log("Unity IAP Initialization Failed (Legacy): " + error.ToString());
    // }

    // // Required by newer IAP versions (5.x+)
    // public void OnInitializeFailed(InitializationFailureReason error, string message)
    // {
    //     Debug.Log($"Unity IAP Initialization Failed (New): {error} - {message}");
    // }


    // public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    // {
    //     Debug.Log("Purchase failed: " + failureReason.ToString());
    // }
}

