using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayformBreak : MonoBehaviour
{
    public void BeakPlatfom()
    {

        gameObject.GetComponent<Rigidbody>().isKinematic = false;

    }
}
