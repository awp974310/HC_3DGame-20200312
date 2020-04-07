using UnityEngine;

public class Car : MonoBehaviour
{
    //方法語法：修飾詞 傳回類型 方法名稱(參數) {  }
    //void 無傳回：使用此方法不會傳回任何值
    //參數語法：類型 名稱
    /// <summary>
    /// 開車，直達幼兒園
    /// </summary>
    public void Drive(float speed, string sound = "嘟嘟嘟",string dir ="幼兒園")
    {
        print("沒時間解釋了，快上車！ " + sound);
        print("本班車直達幼兒園，時速 " + speed + "公里");
        print("行徑目標：" + dir);
    }

    public bool Aircontrol()
    {
        print("冷氣開起來");
        return true;
    }

    public void Fly()
    {
        print("車子飛高高");
    }

    public void Fly(int height)
    {
        print("車子飛很高，目前高度：" + height + "公尺");
    }
}
