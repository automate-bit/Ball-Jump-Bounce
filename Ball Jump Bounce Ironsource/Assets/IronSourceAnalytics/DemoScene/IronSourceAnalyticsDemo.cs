using System;
using System.Collections.Generic;
using UnityEngine;
using IronSourceAnalyticsSDK;

public class IronSourceAnalyticsDemo : MonoBehaviour
{
    private const string COINS_APP_CURRENCY = "Coins";
    private const string STORE_RESOURCE_PLACEMENT = "store";
    private const string IN_SHOP_PURCHASE_USER_ACTION = "purchased_in_shop";
    private const string COINS_BUNDLE_123_PURCHASE_ITEM = "coins_bundle_123";
    private const string HOLIDAY_PROMOTION_ITEM_CATEGORY = "holiday_promotion";
    private const string OUT_OF_COINS_POPUP_PURCHASE_PLACEMENT = "out_of_coins_popup";
    private const string USD_CURRENCY = "USD";

    private readonly static string[] appCurrencies = new string[] { COINS_APP_CURRENCY };
    private readonly static string[] resourcesPlacements = new string[] { STORE_RESOURCE_PLACEMENT };
    private readonly static string[] userActions = new string[] { IN_SHOP_PURCHASE_USER_ACTION };
    private readonly static string[] iapOffersIDs = new string[] { COINS_BUNDLE_123_PURCHASE_ITEM };
    private readonly static string[] iapOfferingCategories = new string[] { HOLIDAY_PROMOTION_ITEM_CATEGORY };
    private readonly static string[] iapOfferingLocations = new string[] { OUT_OF_COINS_POPUP_PURCHASE_PLACEMENT };


    // Start is called before the first frame update
    void Start()
    {
#if UNITY_ANDROID
        string appKey = "85460dcd";
#elif UNITY_IPHONE
        string appKey = "8545d445";
#else
        string appKey = "unexpected_platform";
#endif
        Debug.Log("unity-script: unity version" + IronSourceAnalytics.unityVersion());

        // Example of adding the resources types available in the application
        IronSourceAnalytics.setAppResources(ISAnalyticsResourceType.CURRENCIES, appCurrencies);

        // Add all activities where it is possible to spend or gain app resources
        IronSourceAnalytics.setAppResources(ISAnalyticsResourceType.PLACEMENTS, resourcesPlacements);

        // Add all places where users can spend or gain app resources
        IronSourceAnalytics.setAppResources(ISAnalyticsResourceType.USERACTIONS, userActions);

        // Example of adding the packages available in the application
        IronSourceAnalytics.setIAPSettings(ISAnalyticsPurchasingType.PURCHASE_ITEMS, iapOffersIDs);

        // Example of adding the categories of the packages available in the application
        IronSourceAnalytics.setIAPSettings(ISAnalyticsPurchasingType.ITEM_CATEGORIES, iapOfferingCategories);

        // Example of adding the locations in the application for purchasing
        IronSourceAnalytics.setIAPSettings(ISAnalyticsPurchasingType.PURCHASE_PLACEMENTS, iapOfferingLocations);

        // Example of setting the user ID, given that currentID is the application internal API to get the current user ID
        string appUserId = SystemInfo.deviceUniqueIdentifier;
        IronSourceAnalytics.setAppUserId(appUserId);

        // Example of using the user information settings API, prior to sdk initialization
        HashSet<ISAnalyticsMetaData> metaDataSet = new HashSet<ISAnalyticsMetaData>
        {
            new ISAnalyticsMetaData(ISAnalyticsMetaDataKey.ACHIEVEMENT, "success"),
            new ISAnalyticsMetaData(ISAnalyticsMetaDataKey.FIRST_LOGIN, DateTime.Now),
            new ISAnalyticsMetaData(ISAnalyticsMetaDataKey.CREATION_DATE, DateTime.Now),
            new ISAnalyticsMetaData(ISAnalyticsMetaData.GENDER.FEMALE),
            new ISAnalyticsMetaData(ISAnalyticsMetaData.LOGIN_TYPE_VALUE.FACEBOOK),
            new ISAnalyticsMetaData(ISAnalyticsMetaDataKey.IAP_USER, true),
            new ISAnalyticsMetaData(ISAnalyticsMetaDataKey.IS_SUBSCRIBED, true),
            new ISAnalyticsMetaData(ISAnalyticsMetaDataKey.AGE, 30)
        };
        IronSourceAnalytics.setUserInfo(metaDataSet);

        // Example of using the user privacy settings API, prior to sdk initialization
        IronSourceAnalytics.setUserPrivacy(ISAnalyticsPrivacyRestriction.RESTRICTED_DATA, true, ISAnalyticsReason.COPPA);

        // SDK init
        Debug.Log("unity-script: IronSourceAnalytics init");
        IronSourceAnalytics.init(appKey);
    }

    public void OnGUI()
    {

        GUI.backgroundColor = Color.blue;
        GUI.skin.button.fontSize = (int)(0.035f * Screen.width);

        Rect updateProgressButton = new Rect(0.10f * Screen.width, 0.15f * Screen.height, 0.80f * Screen.width, 0.08f * Screen.height);
        if (GUI.Button(updateProgressButton, "Update Progress"))
        {
            Debug.Log("unity-script: UpdateProgressButtonClicked");
            ISAnalyticsUserProgress userProgress = new ISAnalyticsUserProgress("level_1").state(ISAnalyticsProgressState.BEGIN).score(0).attempt(1);
            IronSourceAnalytics.updateProgress(userProgress);
        }

        Rect updateUserResourcesButton = new Rect(0.10f * Screen.width, 0.25f * Screen.height, 0.80f * Screen.width, 0.08f * Screen.height);
        if (GUI.Button(updateUserResourcesButton, "Update User Resources"))
        {
            Debug.Log("unity-script: UpdateUserResourcesButtonClicked");
            // Example of resource gained by user:
            ISAnalyticsResourceUpdate coins = new ISAnalyticsResourceUpdate(COINS_APP_CURRENCY).gained(30).placement(STORE_RESOURCE_PLACEMENT).userAction(IN_SHOP_PURCHASE_USER_ACTION).balance(1);
            IronSourceAnalytics.updateUserResources(coins);

            // Example of resource consumed by user:
            coins.consumed(10);
            IronSourceAnalytics.updateUserResources(coins);
        }

        Rect updateUserPurchaseButton = new Rect(0.10f * Screen.width, 0.35f * Screen.height, 0.80f * Screen.width, 0.08f * Screen.height);
        if (GUI.Button(updateUserPurchaseButton, "Update User Purchase"))
        {
            Debug.Log("unity-script: updateUserPurchaseButtonButtonClicked");
            //// The in-app purchase update of the user
            ISAnalyticsInAppPurchase coinsBundle = new ISAnalyticsInAppPurchase(COINS_BUNDLE_123_PURCHASE_ITEM).fromCategory(HOLIDAY_PROMOTION_ITEM_CATEGORY).paid(15.3f).purchasedPlacement(OUT_OF_COINS_POPUP_PURCHASE_PLACEMENT).currency(USD_CURRENCY);
            IronSourceAnalytics.updateUserPurchase(coinsBundle);
        }


        Rect updateActivityButton = new Rect(0.10f * Screen.width, 0.45f * Screen.height, 0.80f * Screen.width, 0.08f * Screen.height);
        if (GUI.Button(updateActivityButton, "Update User Activity"))
        {
            Debug.Log("unity-script: updateUserActivityButtonButtonClicked");
            //// The activity of the user
            ISAnalyticsUserActivity userLoggedInActivity = new ISAnalyticsUserActivity("user_logged_in");
            IronSourceAnalytics.updateCustomActivity(userLoggedInActivity);

            //// The activity of the user with attribute
            userLoggedInActivity.attribute("from_x_button");
            IronSourceAnalytics.updateCustomActivity(userLoggedInActivity);

        }
    }

}
