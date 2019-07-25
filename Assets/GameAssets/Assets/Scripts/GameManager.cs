using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {

    public static GameManager _instance;//为了访问此脚本（其他脚本可访问此脚本），进行单遍历
    private Vector3 originPos; //初始化的位置

    public GameObject win;
    public GameObject lose;

    public GameObject[] stars;

    public int starsNum = 0;

    private int totalNum = 9;
    public player thePlayer;


    private void Awake()
    {
        _instance = this;
    }
    void Start () {

        //在游戏运行时，首先遍历一遍PlayerController脚本
        player thePlayer = FindObjectOfType<player>();

    }
    
    // Update is called once per frame
    void Update () {
        
    }


    /// 调用方法Respawn开启携程方法RespawnCo，完成等待复活事件
    public void Respawn()
    {
        //开启携程RespawnCo
        StartCoroutine("RespawnCo");
        
    }


    /// <summary>
    /// 携程，等待X秒后复活角色
    /// </summary>
    /// <returns></returns>
    public IEnumerator RespawnCo()
    {
        
        //隐藏角色
        thePlayer.gameObject.SetActive(false);
        //等待X秒后执行
        
        yield return new WaitForSeconds(2);
        //把复活碰撞点的位置传给角色，让角色在复活碰撞点复活
        
        thePlayer.transform.position = thePlayer.RespawnPosition;
        //显示角色
        
        thePlayer.gameObject.SetActive(true);
    }
    //重新开始游戏
    public void Replay() {
        SaveData();
        SceneManager.LoadScene(2);
    }
    //回到选择界面
    public void Home() {
        SaveData();
        SceneManager.LoadScene(1);
    }
   
    public void ShowStars() {
        StartCoroutine("show");
    }

//携程
    IEnumerator show() {
        for (; starsNum <3; starsNum++)
        {
            if (starsNum >= stars.Length) {
                break;
            }
            yield return new WaitForSeconds(0.2f);
            stars[starsNum].SetActive(true);
        }
        print(starsNum);
    }


    public void SaveData() {
        if (starsNum > PlayerPrefs.GetInt(PlayerPrefs.GetString("nowLevel"))){
            PlayerPrefs.SetInt(PlayerPrefs.GetString("nowLevel"), starsNum);
        }
        //存储所有的星星个数
        int sum = 0;        
        for (int i = 1; i <= totalNum; i++) {
            sum += PlayerPrefs.GetInt("level" + i.ToString());
        }
       

        PlayerPrefs.SetInt("totalNum",sum);
        //print(PlayerPrefs.GetInt("totalNum"));
    }
}


