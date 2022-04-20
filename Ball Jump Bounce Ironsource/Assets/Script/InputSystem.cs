using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputSystem : MonoBehaviour{
    [SerializeField] private bool Onpc;
    [SerializeField] private bool isTouch;
    public Action<float> onTouch;
    public bool touchBegan;
    private void Update() {
        if (Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began){
                touchBegan = true;
            }
            if(touch.phase == TouchPhase.Moved){
                if(isTouch){
                    if(onTouch != null){
                        onTouch(touch.deltaPosition.x);
                    }
                }
                
            }
        }
    }

    public void setTouch(bool value){
        isTouch = value;
    }
    public bool GetTouch(){
        return isTouch;
    }
    


    
}
