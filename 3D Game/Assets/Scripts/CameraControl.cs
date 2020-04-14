using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform dragon;


    /// <summary>
    /// 追蹤飛龍
    /// </summary>
    private void Track()
    {
        Vector3 draPos = dragon.position;

        transform.position = Vector3.Lerp(transform.position, draPos, 0.3f);
    }

    private void LateUpdate()
    {
        Track();
    }
}
