using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuManager : MonoBehaviour
{
    /// <summary>
    /// 載入畫面
    /// </summary>
    [Header("載入畫面")]
    public GameObject gameloading;

    /// <summary>
    /// 載入文字
    /// </summary>
    [Header("載入文字")]
    public Text textloading;

    /// <summary>
    /// 載入進度條
    /// </summary>
    [Header("載入讀取條")]
    public Image imgloading;

    /// <summary>
    /// 開始載入遊戲場景
    /// </summary>
    public void StartLoading()
    {
        print("開始載入...");

        gameloading.SetActive(true);            //顯示載入畫面

        textloading.text = "87%";               //更新載入文字

        imgloading.fillAmount = 0.87f;          //更新載入進度條

        //SceneManager.LoadScene("關卡1");

        StartCoroutine(Loading());              //啟動協程
    }

    /// <summary>
    /// 協程方法：載入
    /// </summary>

    private IEnumerator Loading()
    {
        //SceneManager.LoadScene("關卡1");        //載入場景
        AsyncOperation load = SceneManager.LoadSceneAsync("關卡1");

        load.allowSceneActivation = false;      //關閉自動切換場景
                             
        while (load.progress < 1)
        {
            print("關卡進度：" + load.progress);

            textloading.text = (load.progress /0.9 * 100).ToString("F2") + "%";

            imgloading.fillAmount = load.progress;

            yield return null;                  //等待

            if(load.progress == 0.9f)
            {
                load.allowSceneActivation = true;      //允許自動切換場景
            }
        }
    }

    private void Start()
    {
        //螢幕.設定解析度(寬，高，是否全螢幕) - EXE 或網頁 (Build Settings)
        Screen.SetResolution(450, 800, false);
    }
}
