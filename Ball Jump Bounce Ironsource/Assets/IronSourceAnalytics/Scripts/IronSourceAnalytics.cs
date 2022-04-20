﻿using System.Collections.Generic;
using UnityEngine;

namespace IronSourceAnalyticsSDK
{
    public class IronSourceAnalytics
    {
        private const string UNITY_PLUGIN_VERSION = "0.1.0.0";

        public IronSourceAnalytics()
        {
        }

        public static void init(string appKey)
        {
            IronSourceAnalyticsAgent.Agent.init(appKey);
        }

        public static string pluginVersion()
        {
            return UNITY_PLUGIN_VERSION;
        }

        public static string unityVersion()
        {
            return Application.unityVersion;
        }

        public static void setAppUserId(string userId)
        {
            IronSourceAnalyticsAgent.Agent.setAppUserId(userId);
        }

        public static void setAppResources(ISAnalyticsResourceType resourceType, params string[] values)
        {
            IronSourceAnalyticsAgent.Agent.setAppResources(resourceType, values);
        }

        public static void setUserInfo(HashSet<ISAnalyticsMetaData> metaDataList)
        {
            IronSourceAnalyticsAgent.Agent.setUserInfo(metaDataList);
        }

        public static void setUserPrivacy(ISAnalyticsPrivacyRestriction toUpdate, bool restricted, ISAnalyticsReason why)
        {
            IronSourceAnalyticsAgent.Agent.setUserPrivacy(toUpdate, restricted, why);
        }

        public static void setIAPSettings(ISAnalyticsPurchasingType purchasingType, string[] values)
        {
            IronSourceAnalyticsAgent.Agent.setIAPSettings(purchasingType, values);
        }

        public static void updateUserResources(ISAnalyticsResourceUpdate appResource)
        {
            IronSourceAnalyticsAgent.Agent.updateUserResources(appResource);
        }

        public static void updateProgress(ISAnalyticsUserProgress userProgress)
        {
            IronSourceAnalyticsAgent.Agent.updateProgress(userProgress);
        }

        public static void updateUserPurchase(ISAnalyticsInAppPurchase appPurchase)
        {
            IronSourceAnalyticsAgent.Agent.updateUserPurchase(appPurchase);
        }

        public static void updateImpressionData(ISAnalyticsMediationName from, string json)
        {
            IronSourceAnalyticsAgent.Agent.updateImpressionData(from, json);
        }

        public static void updateCustomActivity(ISAnalyticsUserActivity userActivity)
        {
            IronSourceAnalyticsAgent.Agent.updateCustomActivity(userActivity);
        }

        public static void getSDKVersion()
        {
            IronSourceAnalyticsAgent.Agent.getSDKVersion();
        }

    }
}
