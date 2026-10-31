using System;

[Serializable]
public class Worker {
    public string Name;
    public int EmployeeId;
    public bool HasEngineRoomClearance;
    public string LastEntranceInEngineRoom;
    public string LastExitFromEngineRoom;
}

[Serializable]
public class WorkerList {
    public Worker[] Employees;
}
