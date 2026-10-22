using UnityEngine;

public class Worker : MonoBehaviour
{
    public string Name;
    public string ID;
    public string Clearance;
    public string LastEntrance;
    public string LastExit;

    public void Init(string ReName, string ReID, string ReClearance, string ReLastEntrance, string ReLastExit)
    {
        Name = ReName;
        ID = ReID;
        Clearance = ReClearance;
        LastEntrance = ReLastEntrance;
        LastExit = ReLastExit;
    }



}
