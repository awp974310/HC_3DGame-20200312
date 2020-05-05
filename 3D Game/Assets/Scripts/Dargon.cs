using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Dargon : MonoBehaviour
{
    [Header("移動速度"), Range(0, 1000)]
    public float speed = 10;
    [Header("虛擬搖桿")]
    public Joystick joy;
    [Header("火球")]
    public GameObject fireBall;
    [Header("攻擊冷卻時間")]
    public float cd = 1;
    [Header("延遲生成火球時間")]
    public float delayFire = 0.5f;
    [Header("火球移動速度"), Range(1, 5000)]
    public float speedFireBall = 500;
    [Header("攻擊力"), Range(1, 5000)]
    public float attack = 35;
    [Header("生命質"), Range(0, 100)]
    public float hp = 100;
    [Header("血條")]
    public Image hpBar;

    private GameManager gm;

    //第一種寫法：需要欄位
    //public Transform tra;

    /// <summary>
    /// 動畫控制器
    /// </summary>
    private Animator ani;
    /// <summary>
    /// 計時器
    /// </summary>
    private float timer;
    
    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        //第一種寫法
        //tra.Translate(0, 0, 1);
        //Time.deltaTime 一禎的時間
        //Input.GetAxis("Vertical"); - WS上下
        //水平：Horizontal

        //第二種寫法：僅限於Transform
        float v = Input.GetAxis("Vertical");
        float c = Input.GetAxis("Horizontal");
        transform.Translate(speed * Time.deltaTime * c, 0, speed * Time.deltaTime * v);

        float joyv = joy.Vertical;
        float joyc = joy.Horizontal;

        transform.Translate(speed * Time.deltaTime * joyc, 0, speed * Time.deltaTime * joyv);

        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, 36.5f, 56.5f);
        pos.z = Mathf.Clamp(pos.z, 20, 35);
        transform.position = pos;
    }

    /// <summary>
    /// 攻擊
    /// </summary>
    private void Attack()
    {
        timer += Time.deltaTime;                // 計時器 遞增
        if (timer >= cd)                        // 如果 計時器>= 冷卻
        {
            timer = 0;                          // 計時器 歸零
            ani.SetTrigger("攻擊觸發");         // 動畫控制器.設定處發氣("參數名稱")

            StartCoroutine(DelayFireBall());
        }
        
    }

    /// <summary>
    /// 延遲火球生成
    /// </summary>
    private IEnumerator DelayFireBall()
    {
        yield return new WaitForSeconds(delayFire);                 // 延遲火球生成

        Vector3 posFire = transform.position;                       // 火球座標 = 飛龍座標
        posFire.z += 5.2f;                                          // 微調 Z 軸
        posFire.y += 3f;

        GameObject temp = Instantiate(fireBall, posFire, Quaternion.identity);        // 生成(物件，座標，角度)

        temp.AddComponent<Ball>();
        temp.GetComponent<Ball>().damage = attack;
        temp.GetComponent<Ball>().type = "玩家";

        // Quaternion.identity Unity 角度類型 - 零角度

        temp.GetComponent<Rigidbody>().AddForce(0, 0, speedFireBall);
    }

    /// <summary>
    /// 吃掉加速藥水
    /// </summary>
    private void EatPropSp()
    {
        cd -= 0.15f;
        cd = Mathf.Clamp(cd, 0.6f, 100);
    }

    /// <summary>
    /// 吃掉回復藥水
    /// </summary>
    private void EatPropHp()
    {
        //hp += 20;
        //hp = Mathf.Clamp(hp, 0, 100);
        StartCoroutine(HpBarEffect());
    }

    /// <summary>
    /// 血條增加特效
    /// </summary>
    private IEnumerator HpBarEffect()
    {
        float hpAdd = hp + 20;

        while (hp < hpAdd)
        {
            hp++;
            hp = Mathf.Clamp(hp, 0, 100);
            hpBar.fillAmount = hp / 100;
            yield return null;
        }
    }

    /// <summary>
    /// 受傷
    /// </summary>
    /// <param name="damage">接收到傷害值</param>
    public void Damage(float damage)
    {
        hp -= damage;
        hpBar.fillAmount = hp / 100;
        if (hp <= 0) Dead();
    }

    /// <summary>
    /// 死亡
    /// </summary>
    public void Dead()
    {
        ani.SetBool("死亡開關", true);
        gm.Lose();
    }

    private void Start()
    {
        //取得原件<泛行>()
        ani = GetComponent<Animator>();
        hpBar.fillAmount = hp / 100;

        gm = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (ani.GetBool("死亡開關")) return;
        Attack();
        Move();
        //hpBar.fillAmount = hp / 100;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "加速藥水")
        {
            EatPropSp();
            Destroy(other.gameObject);
        }
        if (other.tag == "回復藥水")
        {
            EatPropHp();
            Destroy(other.gameObject);
        }
    }
}
