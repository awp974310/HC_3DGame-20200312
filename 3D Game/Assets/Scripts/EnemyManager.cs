using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Enemy enemy1, enemy2;
    private void Start()
    {
        //查看欄位
        print("怪物1的血量："+enemy1.hp);
        //設定欄位
        enemy2.hp = 50000;

        //設定屬性
        enemy1.attack = 999;
        //取得屬性
        print("怪物1的攻擊力：" + enemy1.attack);
    }
}
