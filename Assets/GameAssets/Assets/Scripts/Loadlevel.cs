using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loadlevel : MonoBehaviour {

//绑定在场景2的相机上，用于加载所选关卡
    private void Awake()
    {
        Instantiate(Resources.Load(PlayerPrefs.GetString("nowLevel"))); 
    }
}
