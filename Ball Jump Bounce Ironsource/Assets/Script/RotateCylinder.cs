using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCylinder : MonoBehaviour{
    
    [SerializeField]private float rotateSpeed = 0.2f;
    [SerializeField]private InputSystem input;
    private void Start() {
        input.onTouch += (d) =>{
            Roatate(d);
        };
    }
    
    private void Roatate(float yDelta){
        Quaternion y = Quaternion.Euler(0,-yDelta * rotateSpeed,0);
        transform.rotation = y * transform.rotation;
    }
   
}
