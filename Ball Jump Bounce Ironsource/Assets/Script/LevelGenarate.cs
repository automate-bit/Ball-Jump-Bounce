using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenarate : MonoBehaviour
{
    [SerializeField]private GameObject[] Platfoms;
    [SerializeField]private Transform PlatformContainer;
    float firstStep;
    float middleStep;
    int continuousPlatform;
    [SerializeField]private Material bae;
    [SerializeField]private Material platorm;
    [SerializeField]private Material obstacle;
    [SerializeField]private Color Bae;
    [SerializeField]private Color PlatformColor;
    [SerializeField]private Color ObstacleColor;
    [SerializeField]private Transform MainCylinder;
    [SerializeField]private Transform cylinder;
    [SerializeField]private GameData gameData;

    private void Awake() {
        bae.color = Bae;
        platorm.color = PlatformColor;
        obstacle.color = ObstacleColor;
    }
    private void Start() {
        firstStep = Random.Range(5,10);
        middleStep = Random.Range(2,6);
        continuousPlatform = Random.Range(0,11);
        float y = 23.5f-3.0f;
        if(gameData.level < 7)
        {
            MainCylinder.position = new Vector3(0,25,0);
            cylinder.position = new Vector3(cylinder.transform.position.x,-23,cylinder.transform.position.z);
            for(int i = 0; i < 14;i++)
            {
                Instantiate(Platfoms[Random.Range(0,2)],new Vector3(0,y,0),Quaternion.Euler(0,i+5,0),PlatformContainer);
                y = y - 3.0f;

            }
        }
        else if(gameData.level < 20)
        {
            for(int i = 0; i < 24;i++)
            {
                Instantiate(Platfoms[Random.Range(0,7)],new Vector3(0,y,0),Quaternion.Euler(0,Random.Range(0,360),0),PlatformContainer);
                y = y - 3.0f;
            }
        }
        else if(gameData.level < 50)
        {
            for(int i = 0; i < 24;i++)
            {
                Instantiate(Platfoms[Random.Range(0,9)],new Vector3(0,y,0),Quaternion.Euler(0,Random.Range(0,360),0),PlatformContainer);
                y = y - 3.0f;
            }
        }
        else if(gameData.level < 1000)
        {
            for(int i = 0; i < 24;i++)
            {
                Instantiate(Platfoms[Random.Range(0,Platfoms.Length)],new Vector3(0,y,0),Quaternion.Euler(0,Random.Range(0,360),0),PlatformContainer);
                y = y - 3.0f;
            }
        }
                

    }
}
