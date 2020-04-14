using UnityEngine;

public class Dargon : MonoBehaviour
{
    [Header("移動速度"), Range(0, 1000)]
    public float speed = 10;
    [Header("虛擬搖桿")]
    public Joystick joy;

    //第一種寫法：需要欄位
    //public Transform tra;

    /// <summary>
    /// 移動
    /// </summary>
    public void Move()
    {
        print("移動中~");

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
    }

    private void Update()
    {
        Move();
    }

}
