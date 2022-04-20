using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "GameData")]
public class GameData : ScriptableObject {

    public int level;

    public void LevelNext()
    {
        level += 1;
    }
    public void LevelDecrese()
    {
        level -= 1;
    }
}
