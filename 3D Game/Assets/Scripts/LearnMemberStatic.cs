using UnityEngine;

public class LearnMemberStatic : MonoBehaviour
{
    float a = 0.5f;
    int b = 70;
    bool c = true;
    bool d = false;
    string e = "字串";
    float APIvalue = -145.5f;

    //修飾詞 類型 名稱 指定 值;
    //公開 public 允許所有文件存取：顯示在屬性面板
    public int score = 10;
    //私人 private 僅限此類別存取：不顯示在屬性面板
    private int speed = 99;

    public Camera cam; //定義一個類行為Camera的物件，名稱是cam

    //GameObject 儲存層面板或專案內的預置物
    public GameObject cube;
    public GameObject sphere;

    public SpriteRenderer logo;//定義物件logo

    public Transform camer;

    private void Start()
    {
        //使用靜態成員
        //靜態屬性 Static Properties
        //取得Get：類別.靜態屬性
        print(Random.value);
        //設定Set：類別.靜態屬性 = 值
        //不能設定Read Only 的屬性
        Time.timeScale = 0.5f;

        //使用靜態方法
        print(Random.Range(0.1f, 99.9f));   //第一個多載
        print(Random.Range(100, 500));      //第二個多載

        //練習一
        //使用靜態成員 -取得Pi
        print(Mathf.PI);
        //練習二
        //使用靜態成員 -數學.絕對值 -999:Mathf
        print(Mathf.Abs(APIvalue));

        //靜態：類別.成員
        print("攝影機數量：" + Camera.allCamerasCount);
        //非靜態：物件.成員
        print(cam.depth);

        //取得 非靜態屬性
        print(cube.layer);
        print(sphere.layer);
        Cursor.visible = false;//影藏滑鼠
        logo.flipX = true;//logo翻轉X軸
        print("去除小數點：" + Mathf.Floor(1.23456f));
        camer.Rotate(0,90,0);
    }
}
