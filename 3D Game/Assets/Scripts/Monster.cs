using UnityEngine;

public class Monster : MonoBehaviour
{
    [Header("怪物資料")]
    public MonsterData data;

    public Animator ani;

    private void Start()
    {
        ani = GetComponent<Animator>();
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param anme="damage">接收到的傷害值</param>
    public void Damage(float damage)
    {
        data.hp -= damage;

        if (data.hp <= 0) Dead();
    }

    private void Dead()
    {
        ani.SetBool("死亡開關", true);
    }
}
