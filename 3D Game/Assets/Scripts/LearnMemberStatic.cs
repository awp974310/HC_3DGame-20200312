using UnityEngine;

public class LearnMemberStatic : MonoBehaviour
{
    float a = 0.5f;
    int b = 70;
    bool c = true;
    bool d = false;
    string e = "字串";

    //修飾詞 類型 名稱 指定 值;
    //公開 public 允許所有文件存取：顯示在屬性面板
    public int score = 10;
    //私人 private 僅限此類別存取
    private int speed = 99;

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
    }
}
