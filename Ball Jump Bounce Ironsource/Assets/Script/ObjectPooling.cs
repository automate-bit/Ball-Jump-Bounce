using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField]private GameObject[] SpawnableGameObjects;
    [SerializeField]private GameObject spawnBall;
    [SerializeField]private Transform SpawnContainer;
    [SerializeField]private float HowManyObject;
    private void Awake() {
        for(int i = 0;i <= HowManyObject;i++)
        {
            Instantiate(spawnBall,SpawnContainer);
        }
    }
    private void Start() {
        for(int i = 0; i <= SpawnContainer.childCount; i++)
        {
            SpawnContainer.GetChild(i).gameObject.SetActive(false);
        }
    }
    public void spwan(Vector3 spwanPosition,Quaternion rotaion)
    {
        for(int i = 0; i <= SpawnContainer.childCount; i++)
        {
            if(!SpawnContainer.GetChild(i).gameObject.activeSelf)
            {
                SpawnContainer.GetChild(i).transform.position = spwanPosition;
                SpawnContainer.GetChild(i).transform.gameObject.SetActive(true);
            }
        }
    }

}
