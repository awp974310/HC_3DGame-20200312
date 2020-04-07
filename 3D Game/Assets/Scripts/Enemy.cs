using UnityEngine;

public class Enemy : MonoBehaviour
{
    /// <summary>
    /// 這是怪物的血量
    /// </summary>
    [Header("生命值")]
    public int hp = 50;

    //認識屬性Property
    //可以設定權限：唯讀、允許所有權限
    //get取得
    //set設定
    //不會顯示在屬性面板

    //允許所有權限
    ///<summary>
    ///攻擊力
    ///</summary>
    public int attack { get; set; }

    public int lv = 5;

    /// <summary>
    /// 設定唯獨屬性 預設值為0
    /// </summary>
    //public float def { get;}
    public float def
    {
        get
        {
            return lv * 5;
        }
    }
    public float mp
    {
        get
        {
            return lv * 12;
        }
    }

    /// <summary>
    /// C# 物件導向程式三大核心之一：封裝(繼承、多型)
    /// </summary>
    private float _damage;

    public float damage
    {
        get
        {
            return _damage;
        }
        set
        {
            //Mathf.Clamp夾值
            _damage = Mathf.Clamp(value - def,1,999999);
        }
    }
}
