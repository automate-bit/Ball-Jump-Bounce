#if !UNITY_EDITOR && (UNITY_IPHONE || UNITY_IOS)

using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace IronSourceAnalyticsSDK
{
    class IronSourceAnalyticsIOSAgent : IIronSourceAnalyticsAgent
    {

        [DllImport("__Internal")]
        private static extern void CFIronSourceAnalyticsInit(string appKey);

        [DllImport("__Internal")]
        private static extern string CFIronSourceAnalyticsGetSDKVersion();

        [DllImport("__Internal")]
        private static extern void CFSetIronSourceAnalyticsPluginData(string pluginType, string pluginVersion, string pluginFWVersion);

        [DllImport("__Internal")]
        private static extern void CFIronSourceAnalyticsSetUserId(string userId);

        [DllImport("__Internal")]
        private static extern void CFIronSourceAnalyticsSetIAPSettings(string purchasingType, params string[] values);

        [DllImport("__Internal")]
        private static extern void CFIronSourceAnalyticsSetAppResources(string resourceType, params string[] values);

        [DllImport("__Internal")]
        private static extern void CFIronSourceAnalyticsSetUserPrivacy(string privacyRestriction, bool isRestricted, string reason);

        [DllImport("__Internal")]
        private static extern void CFIronSourceAnalyticsSetUserInfo(string userInfoJson);

        [DllImport("__Internal")]
        private static extern void CFIronSourceAnalyticsUpdateUserResources(string userResourceJson);

        [DllImport("__Internal")]
        private static extern void CFIronSourceAnalyticsUpdateUserPurchase(string userPurchaseJson);

        [DllImport("__Internal")]
        private static extern void CFIronSourceAnalyticsUpdateProgress(string progressJson);

        [DllImport("__Internal")]
        private static extern void CFIronSourceAnalyticsUpdateImpressionData(string mediationName, string impressionDataJson);

        [DllImport("__Internal")]
        private static extern void CFIronSourceAnalyticsCustomActivity(string customActivityJson);

        public void init(string appKey)
        {
            CFSetIronSourceAnalyticsPluginData("Unity", IronSourceAnalytics.pluginVersion(), IronSourceAnalytics.unityVersion());
            CFIronSourceAnalyticsInit(appKey);
        }

        public void setAppUserId(string userId)
        {
            CFIronSourceAnalyticsSetUserId(userId);
        }

        public void setAppResources(ISAnalyticsResourceType resourceType, params string[] values)
        {
            CFIronSourceAnalyticsSetAppResources(resourceType.ToString(), values);
        }

        public void setUserInfo(HashSet<ISAnalyticsMetaData> metaDataList)
        {
            Dictionary<string, object> dic = new Dictionary<string, object>();
            foreach (ISAnalyticsMetaData metaData in metaDataList)
            {
                dic.Add(metaData.metaDataPair.Key, metaData.metaDataPair.Value);
            }

            string json = Json.Serialize(dic);
            CFIronSourceAnalyticsSetUserInfo(json);
        }

        public void setUserPrivacy(ISAnalyticsPrivacyRestriction toUpdate, bool restriced, ISAnalyticsReason why)
        {
            CFIronSourceAnalyticsSetUserPrivacy(toUpdate.ToString(), restriced, why.ToString());
        }

        public void setIAPSettings(ISAnalyticsPurchasingType purchasingType, params string[] values)
        {
            CFIronSourceAnalyticsSetIAPSettings(purchasingType.ToString(), values);
        }

        public void updateUserResources(string appResource)
        {
            CFIronSourceAnalyticsUpdateUserResources(appResource);
        }

        public void updateProgress(string userProgress)
        {
            CFIronSourceAnalyticsUpdateProgress(userProgress);
        }

        public void updateUserPurchase(string appPurchase)
        {
            CFIronSourceAnalyticsUpdateUserPurchase(appPurchase);
        }

        public void updateImpressionData(ISAnalyticsMediationName from, string json)
        {
            CFIronSourceAnalyticsUpdateImpressionData(from.ToString(), json);
        }

        public void updateCustomActivity(string userActivity)
        {
            CFIronSourceAnalyticsCustomActivity(userActivity);
        }

        public string getSDKVersion()
        {
            string sdkVersion = CFIronSourceAnalyticsGetSDKVersion();
            return sdkVersion;
        }
    }
}
#endif