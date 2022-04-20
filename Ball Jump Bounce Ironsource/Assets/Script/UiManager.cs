using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
public class UiManager : MonoBehaviour
{
    [SerializeField]private Slider sld;
    [SerializeField]private GameLoop gameLoop;
    [SerializeField]private TextMeshProUGUI level1;
    [SerializeField]private TextMeshProUGUI level2;
    [SerializeField]private GameObject RestartPanel;
    [SerializeField]private TextMeshProUGUI text_Complete;
    [SerializeField]private GameObject startBtn;
    [SerializeField]private GameObject WinScreen;
    [SerializeField]private TextMeshProUGUI winscreenText;
    [SerializeField]private InputSystem input;
    [SerializeField]private Transform[] baseOfarow;
    [SerializeField]private Transform Arrow;
    [SerializeField]private Transform audioBtn;
    [SerializeField]private TextMeshProUGUI timerText;
    [SerializeField]private Transform RetryButton;
    [SerializeField]private Transform ReviveButton;
    [SerializeField]private float speed = 0.125f;
    [SerializeField]private GameData gameData;
    bool callWhile = true;
    float timer = 4;
    private string levelName = "level";
    private int currentLevelNumber;
    private int currentMovePoint;
    public static UiManager current;
    private void Awake(){
        current = this;
    }
    
    private bool canMoveArrow;
    private void Start() {
        level1.text = gameData.level.ToString();
        level2.text = (gameData.level + 1).ToString();
        AdManager.instance.DisplayBanner();
        currentLevelNumber = gameData.level;

        //----------------------------------------------------------
        if(gameData.level < 7)
        {
            sld.maxValue = 13;
        }
        else
        {
            sld.maxValue = 23;
        }
        currentMovePoint = currentLevelNumber % 5;
        Debug.Log("Current Move Point " + currentMovePoint);
        Arrow.transform.position = new Vector3(baseOfarow[currentMovePoint].transform.position.x,Arrow.transform.position.x,Arrow.transform.position.z);
    }
    public void SliderValue(float amount)
    {
        sld.value = amount;
    }
    
    public void sTARTGame()
    {
        startBtn.SetActive(false);
        gameLoop.StartGame();
        ReviveButton.gameObject.SetActive(true);
    }
    public void Die()
    {
        RestartPanel.SetActive(true);

        text_Complete.text = Mathf.FloorToInt(((sld.value / 25) * 100)).ToString() + "%  COMPLETED";
    }
    public void Restart()
    {
        AdManager.instance.ShowInterstitial();
        sld.value = 0;
        gameLoop.Restart();
        startBtn.SetActive(true);
        RestartPanel.SetActive(false);
        WinScreen.SetActive(false);
    }
    public void gameWin()
    {
        AdManager.instance.DestroyBanner();
        WinScreen.SetActive(true);
        winscreenText.text = gameData.level.ToString() + " COMPLETED";
        
    }
    public void gameWinButton()
    {
        AdManager.instance.ShowInterstitial();
        AdManager.instance.DestroyBanner();
        gameLoop.Next();
    }
    ///----------------------WinScreen Activation---------------------------
    private void Update() {
        if(canMoveArrow){
            if(Vector3.Distance(Arrow.transform.position,baseOfarow[currentMovePoint + 1].transform.position) >= 0.01f){
                Arrow.transform.position = Vector3.MoveTowards(Arrow.transform.position,baseOfarow[currentMovePoint + 1].transform.position,speed * Time.deltaTime);

            }else{
                canMoveArrow = false;
            }
        }
    }
    void MoveArrow()
    {
        Vector3 dist = Vector3.zero;
        if(gameData.level % 5 == 0)
        {
            dist = new Vector2(baseOfarow[baseOfarow.Length - 1].transform.position.x , Arrow.transform.position.y);
        }
        else if(gameData.level % 5 == 1)
        {
            dist = new Vector2(baseOfarow[0].transform.position.x , Arrow.transform.position.y);
        }
        else if(gameData.level % 5 == 2)
        {
            dist = new Vector2(baseOfarow[1].transform.position.x , Arrow.transform.position.y);
        }
        else if(gameData.level % 5 == 3)
        {
            dist = new Vector2(baseOfarow[2].transform.position.x , Arrow.transform.position.y);
        }
        else if(gameData.level % 5 == 4)
        {
            dist = new Vector2(baseOfarow[3].transform.position.x , Arrow.transform.position.y);
        }
        float time = 1f;
        while(time > 0){
            time -= Time.deltaTime;
            
            
        }

    }
    //------------------open UI------------------
    public void Settings()
    {
        if(audioBtn.gameObject.activeSelf)
        {
            audioBtn.gameObject.SetActive(false);
        }
        else if(!audioBtn.gameObject.activeSelf)
        {
            audioBtn.gameObject.SetActive(true);
        }
    }
    public void revive(){
        AdManager.instance.ShowReward();
        
    }
    public void OnRewardFailed(){

    }
    public void OnAdComplete(){
        gameLoop.revive();
        RestartPanel.SetActive(false);
        startBtn.SetActive(true);
    }
    IEnumerator timerActivation()
    {
        
        while(timer > 0)
        {
            timer -= 1;
            yield return new WaitForSeconds(1);
            timerText.text = timer.ToString();
            if(timer <= 0)
            {
                RetryButton.gameObject.SetActive(true);
                timerText.text = "RETRY";
                ReviveButton.gameObject.SetActive(false);
                timer = 4;
                break;
            }
        }

    }
    
}
