using UnityEngine;

public class LearnField : MonoBehaviour
{
    //修飾詞 類型 名稱 (指定 值) ;
    //不指定：是值型為0、布林值 false、字串 ""
    public int speed = 10;
    public float jump = 50.5f;
    public string prop = "小刀";
    public bool complete = true;
    [Header("武器"),Tooltip("主要角色武器")]
    public string weapon = "飛刀";
    [Header("分數"),Range(0,100)]
    public float score = 60.5f;
}
