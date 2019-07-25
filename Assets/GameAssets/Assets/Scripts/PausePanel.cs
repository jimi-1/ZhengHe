using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausePanel : MonoBehaviour
{

    public GameObject button;
    public GameObject button1;

    private void Awake()
    {
  
    }


    public void Retry() {

        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }
    /// <summary>
    /// 点击了pause按钮
    /// </summary>
    public void Pause()
    {
     Time.timeScale = 0;
     button.SetActive(false);
     button1.SetActive(true);
    }

    public void going()
    {
     Time.timeScale = 1;
     button.SetActive(true);
     button1.SetActive(false);       
    }

 
    /// <summary>
    /// 点击了继续按钮
    /// </summary>
    public void Resume() {
        //1、播放resume动画
        Time.timeScale = 1;
    }

    public void Home()
    {
        Time.timeScale = 1;
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }


    /// <summary>
    /// pause动画播放完调用
    /// </summary>

    /// <summary>
    /// resume动画播放完调用
    /// </summary>

   
}
