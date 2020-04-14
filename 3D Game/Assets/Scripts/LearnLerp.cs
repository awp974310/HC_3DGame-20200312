using UnityEngine;

public class LearnLerp : MonoBehaviour
{
    public float A = 0, B = 100;

    public Vector2 v2a = new Vector2(0, 0);
    public Vector2 v2b = new Vector2(1000, 1000);
    private void Start()
    {
        print(Mathf.Lerp(A, B, 0.1f));
    }
    private void Update()
    {
        A = Mathf.Lerp(A, B, 0.1f);
        v2a = Vector2.Lerp(v2a, v2b, 0.1f);
    }
}
