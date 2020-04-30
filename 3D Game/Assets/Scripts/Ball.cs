using UnityEngine;

public class Ball : MonoBehaviour
{
    /// <summary>
    /// 玩家：可以攻擊怪物
    /// 怪物：可以攻擊玩家
    /// </summary>
    public string type;
    public float damage;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "怪物" && type=="玩家")
        {
            other.GetComponent<Monster>().Damage(damage);
            Destroy(gameObject);
        }
        if (other.name == "飛龍" && type=="怪物")
        {
            other.GetComponent<Dargon>().Damage(damage);
            Destroy(gameObject);
        }
    }
}
