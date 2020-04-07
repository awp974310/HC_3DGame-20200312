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

        enemy2.lv = 99;

        //設定屬性
        enemy1.attack = 999;
        enemy2.damage = 50;
        //唯獨屬性不能設定
        //enemy2.def = 20;
        //取得屬性
        print("怪物1的攻擊力：" + enemy1.attack);

        print("怪物2的防禦力：" + enemy2.def);

        print("怪物2的魔力值：" + enemy2.mp);

        print("怪物2的等級：" + enemy2.lv);

        print("對怪物2造成的傷害：" + enemy2.damage);
    }
}
