using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("地板陣列")]
    // 陣列
    public Transform[] terrains;
    [Header("地板移動速度"),Range(1f,50f)]
    public float speedTerrains = 30;

    /// <summary>
    /// 移動地板
    /// </summary>
    private void MoveTerrain()
    {
        for (int i = 0; i < terrains.Length; i++)
        {
            // 移動
            terrains[i].Translate(0, 0, -speedTerrains * Time.deltaTime);
            //如果地板.Z 小於 100
            if (terrains[i].position.z <= -100)
            {
                // 另一塊地板的前方 100 位置
                terrains[i].position = new Vector3(0, 0, terrains[1 - i].position.z + 100);
            }
        }
    }

    /// <summary>
    /// 固定禎數更新事件：50禎/秒
    /// </summary>
    private void FixedUpdate()
    {
        MoveTerrain();
    }
}
