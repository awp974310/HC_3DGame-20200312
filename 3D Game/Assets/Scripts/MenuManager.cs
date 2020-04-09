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

        gameloading.SetActive(true);

        textloading.text = "87%";

        imgloading.fillAmount = 0.87f;

        SceneManager.LoadScene("關卡1");

        StartCoroutine(Loading());
    }

    private IEnumerator Loading()
    {
        print("載入中...");
        yield return null;
        print("載入中..........");
    }
}
