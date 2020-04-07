using UnityEngine;

public class CarManager : MonoBehaviour
{
    public Car car1;

    public void Start()
    {
        car1.Drive(30);
        car1.Drive(70, dir:"去幼兒園的路上");
        car1.Drive(119.9f,"叭~~ 碰! 啪! 框! 磅(翻車聲)","已失去目標");

        print("一台快車是否有開冷氣？" + car1.Aircontrol());

        car1.Fly();
        car1.Fly(200);
    }
}
