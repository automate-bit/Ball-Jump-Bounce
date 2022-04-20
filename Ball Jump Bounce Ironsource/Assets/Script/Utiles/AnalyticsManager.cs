using UnityEngine;
using Firebase.Analytics;
using Firebase.Messaging;
public class AnalyticsManager : MonoBehaviour {
    private int currentLevel;
    public static AnalyticsManager current;
    private void Awake()    {
        if(current == null){
            current = this;
        }else{
            Destroy(current.gameObject);
        }
        DontDestroyOnLoad(current.gameObject);
        // GameAnalytics.Initialize();
    }
    
    private void Start(){
        if(PlayerPrefs.HasKey("CurrentLevel")){
            currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        }
        FirebaseMessaging.TokenReceived += OnTokenReceived;
        FirebaseMessaging.MessageReceived += OnMessageReceived;

        
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventAppOpen);
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventScreenView);
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                // Crashlytics will use the DefaultInstance, as well;
                // this ensures that Crashlytics is initialized.
                Firebase.FirebaseApp app = Firebase.FirebaseApp.DefaultInstance;

                // Set a flag here for indicating that your project is ready to use Firebase.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}",dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });  
    }
    
    public void OnCompanyGamesDownloadClick(){
        FirebaseAnalytics.LogEvent("Play_Resume_game_click");
    }
    public void OnCompanayGamesDownloadView(){
        FirebaseAnalytics.LogEvent("Play_Resume_game_view");
    }
    public void SetCurrentLevel(int levenumber){
        currentLevel = levenumber;
        FirebaseAnalytics.LogEvent("level number","level_number",levenumber);
        // anaylyticsData.Add("Level Number",levenumber);
        // GameAnalytics.SetGlobalCustomEventFields(anaylyticsData);
    }
    public void SetLevelStart(){
        // anaylyticsData.Add("Level Start",l)

        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLevelStart,"level_num",currentLevel);
        // GameAnalytics.StartSession();
    }
    public void SetLevelEnd(){

        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLevelEnd,"level_num",currentLevel);
        // GameAnalytics.EndSession();
    }
    public void SetGameStart(){
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventScreenView);
        // GameAnalytics.NewDesignEvent("Game Start");
    }
    public void OnRestart(){
        FirebaseAnalytics.LogEvent("restart","restart_level",currentLevel);
        // GameAnalytics.SetGlobalCustomEventFields(anaylyticsData);
        // GameAnalytics.NewDesignEvent("restart Data");
    }
    public void SetAdsEarning(AdsType adsType){
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventAdImpression);
        // GAAdType adType, string adSdkName, string adPlacement, long duration)

        // GameAnalytics.NewAdEvent(action,adType,adSdkName,adPlacement,duration);
        switch(adsType){
            case AdsType.Rewarded:
                FirebaseAnalytics.LogEvent("reward_ads");

            break;
            case AdsType.intersteial:
                FirebaseAnalytics.LogEvent("interstial_ads");
            break;

            case AdsType.Banner:
                FirebaseAnalytics.LogEvent("banner_ads");
            break;
        }
    }
    private void OnApplicationQuit(){
        SetviewTime();
    }
    public void SetPlayerLevelAnaylytics(int currentLevel){
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLevelUp,"Level",currentLevel);
    }
    public void SetAdImpressionDataAnayltyics(){
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventAdImpression);
        
    }
    public void SetTutoraialDataAnalytics(){
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventTutorialComplete);
    }
    public void SetviewTime(){
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventScreenView);
    }
    public void SetSpendRealCurrencyForCoins(int amount){
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventPurchase,"purchase_cash ",amount);
    }
    public void SetEarnVirtualCurrencyByAds(int amount,string currencyName){
        FirebaseAnalytics.LogEvent(
        FirebaseAnalytics.EventEarnVirtualCurrency,
            new Firebase.Analytics.Parameter[] {
                new Firebase.Analytics.Parameter(
                Firebase.Analytics.FirebaseAnalytics.ParameterValue, amount),
                new Firebase.Analytics.Parameter(
                Firebase.Analytics.FirebaseAnalytics.ParameterVirtualCurrencyName, currencyName),
            }
        );
    }
    public void PostScoreAnylytics(int currentLevel,int score,int totalRequired){
        FirebaseAnalytics.LogEvent(
        Firebase.Analytics.FirebaseAnalytics.EventPostScore,
            new Firebase.Analytics.Parameter[] {
                // new Firebase.Analytics.Parameter(
                // Firebase.Analytics.FirebaseAnalytics.ParameterCharacter, character),
                new Parameter(
                FirebaseAnalytics.ParameterLevel, currentLevel),
                new Parameter(
                FirebaseAnalytics.ParameterScore, score),
                new Parameter(
                    "total_requird_score",totalRequired
                )
                
            }
        );
    }
    public void PostUnLoackAcivement(string achievementId){
        FirebaseAnalytics.LogEvent(
        FirebaseAnalytics.EventUnlockAchievement,
            new Firebase.Analytics.Parameter[] {
                new Firebase.Analytics.Parameter(
                Firebase.Analytics.FirebaseAnalytics.ParameterAchievementId, achievementId),
            }
        );
    }
    public void LogInToPlayGames(){
        FirebaseAnalytics.LogEvent(
        FirebaseAnalytics.EventSignUp,
            new Firebase.Analytics.Parameter[] {
                new Firebase.Analytics.Parameter(
                Firebase.Analytics.FirebaseAnalytics.ParameterMethod,"playgames_google"),
            }
        );
    }
    public void SpendVirualCurrency(int amount,string itemName,string currencyName){
        FirebaseAnalytics.LogEvent(
        FirebaseAnalytics.EventSpendVirtualCurrency,
            new Firebase.Analytics.Parameter[] {
                new Firebase.Analytics.Parameter(
                Firebase.Analytics.FirebaseAnalytics.ParameterItemName, itemName),
                new Firebase.Analytics.Parameter(
                Firebase.Analytics.FirebaseAnalytics.ParameterValue, amount),
                new Firebase.Analytics.Parameter(
                Firebase.Analytics.FirebaseAnalytics.ParameterVirtualCurrencyName, currencyName),
            }
        );
    }
    public void SetIntersteailAdsData(){
        FirebaseAnalytics.LogEvent("interstatial_Ads");
    }
    public void SetRewardAdsData(){
        FirebaseAnalytics.LogEvent("Rewarded_ads");
        
    }
    public void SetLevelUpResult(int levelNum){
        FirebaseAnalytics.LogEvent(FirebaseAnalytics.EventLevelUp,FirebaseAnalytics.ParameterLevel,levelNum);
    }
    public void BannerAds(){
        FirebaseAnalytics.LogEvent("banner_ads");
    }

    public void ImpressionSuccesessEvent(IronSourceImpressionData impressionData){
        // Debug.Log("Ironsource Impression Log Data: " + impressionData);
        if(impressionData != null){
            Firebase.Analytics.Parameter[] AdParameter = {
                new Parameter("ad_platform","ironSource"),
                new Parameter("ad_source",impressionData.adNetwork),
                new Parameter("ad_unit_name",impressionData.adUnit),
                new Parameter("ad_adformat",impressionData.instanceName),
                new Parameter("currency","USD"),
                new Parameter("value",impressionData.revenue.ToString()),
                new Parameter("life_time_value",impressionData.lifetimeRevenue.ToString())

                
            };
            FirebaseAnalytics.LogEvent("ad_impressions",AdParameter);
            

        }
    }
    #region Messeging........


    public void OnTokenReceived(object sender, Firebase.Messaging.TokenReceivedEventArgs token) {
        Debug.Log("Received Registration Token: " + token.Token);
    }

    public void OnMessageReceived(object sender, Firebase.Messaging.MessageReceivedEventArgs e) {
        Debug.Log("Received a new message from: " + e.Message.From);
    }


    #endregion
    
    
    
}
public enum AdsType{
    Banner,intersteial,Rewarded
}
