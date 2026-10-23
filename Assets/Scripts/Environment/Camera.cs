using UnityEngine;

public class Cameras : MonoBehaviour
{
    public static Cameras comand { get; private set; }

    public Camera[] Camlog;

    private void Awake()
    {
        CamChange(0);
        comand = this;
    }

    public void CamChange(int cam)
    {
        for (int i = 0; i < Camlog.Length; i++)
        {
            Camlog[i].enabled = (i == cam);
        }
    }
}
