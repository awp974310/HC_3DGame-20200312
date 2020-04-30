using UnityEngine;

public class Monster : MonoBehaviour
{
    [Header("怪物資料")]
    public MonsterData data;
    [Header("回復藥水")]
    public GameObject propHp;
    [Header("加速藥水")]
    public GameObject propSp;
    [Header("發射物件")]
    public GameObject bullet;

    //回復藥水掉落機率：30% (0.3)
    //Random.Range(0, 1) - 小於 0.3
    //if (隨機 <= 0.3) 掉落補血藥水

    private Animator ani;
    private float hp;
    private float timer;

    private void Start()
    {
        hp = data.hp;
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        Attack();
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param anme="damage">接收到的傷害值</param>
    public void Damage(float damage)
    {
        hp -= damage;

        if (hp <= 0) Dead();
    }

    private void Dead()
    {
        ani.SetBool("死亡開關", true);
        DropProp();
        Destroy(gameObject, 0.8f);
        GetComponent<SphereCollider>().enabled = false; //關閉碰撞器防止被鞭屍
    }

    /// <summary>
    /// 掉落道具
    /// </summary>
    private void DropProp()
    {
        float rHp = Random.Range(0f, 1f);
        //print("掉落回復藥水機率" + rHp);
        if (rHp <= 0.3f) Instantiate(propHp, transform.position + Vector3.right * Random.Range(-1f, 1f), Quaternion.identity);
        float rSp = Random.Range(0f, 1f);
        //print("掉落加速藥水機率" + rSp);
        if (rSp <= 0.3f) Instantiate(propSp, transform.position + Vector3.right * Random.Range(-1f, 1f), Quaternion.identity);
    }

    /// <summary>
    /// 攻擊：發射物件
    /// </summary>
    private void Attack()
    {
        timer += Time.deltaTime;

        if (timer >= data.cd)
        {
            timer = 0;

            GameObject temp = Instantiate(bullet, transform.position + transform.up*3 +transform.forward, Quaternion.identity);
            temp.AddComponent<Move>().speed = data.bulletSpeed;
            temp.AddComponent<Ball>().damage = data.attack;
            temp.GetComponent<Ball>().type = "怪物";

        }
        
    }
}
