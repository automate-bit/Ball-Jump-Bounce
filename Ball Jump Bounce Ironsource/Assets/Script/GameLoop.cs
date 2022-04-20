using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameLoop : MonoBehaviour
{
    [SerializeField]private InputSystem input;
    [SerializeField]private Player player;
    [SerializeField]private GameObject levelContainer;
    [SerializeField]private UiManager uiManager;
    [SerializeField]private Transform PlayerTransform;
    [SerializeField]private GameData game;
    private void Start() {
        game.LevelNext();
    }
    public void StartGame()
    {
        player.GetComponent<Rigidbody>().isKinematic = false;
        input.setTouch(true);
        // Debug.Log("Input is " + input.isTouch);
    }
    public void DieBall()
    {
        input.setTouch(false);
    }
    public void Restart()
    {
        // uiManager.Restart();
        PlayerTransform.position = new Vector3(-0.07f,25.15788f,-1.562f);
        player.Restart();
        foreach(Transform i in levelContainer.transform)
        {
            i.gameObject.SetActive(true);
        }
        game.LevelDecrese();
    }
    public void GameWin()
    {
        input.setTouch(false);
        player.GetComponent<Rigidbody>().isKinematic = true;
    }
    public void Next()
    {
        SceneManager.LoadSceneAsync(0);
    }
    public void revive()
    {
        player.transform.position = player.transform.position + Vector3.up;
        player.Restart();
    }
}

