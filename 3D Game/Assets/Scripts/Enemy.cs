using UnityEngine;

public class Enemy : MonoBehaviour
{
    /// <summary>
    /// 這是怪物的血量
    /// </summary>
    [Header("生命值")]
    public int hp = 50;

    //認是屬性Property
    //可以設定權限：唯讀、允許所有權限
    //get取得
    //set設定
    //不會顯示在屬性面板

    //允許所有權限
    ///<summary>
    ///攻擊力
    ///</summary>
    public int attack { get; set; }
}
