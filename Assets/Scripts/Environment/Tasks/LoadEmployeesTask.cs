using System.Collections;
using System;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Load Employees Task", menuName = "Tasks/Computer/Load Employees")]
    public sealed class LoadEmployeesTask : WorklogTask {
        public override IEnumerator Execute(Computer computer) {
            string json = computer.WorkersJsonText;
            WorkersJsonArray workerArray;
                workerArray = JsonUtility.FromJson<WorkersJsonArray>("{\"employees\":" + json + "}");

            Worker[] workers = new Worker[workerArray.employees.Length];
            for(int i = 0; i < workerArray.employees.Length; i++) {
                WorkerJson workerJson = workerArray.employees[i];
                Worker worker = new Worker();
                worker.Init(workerJson.name,workerJson.employeeId.ToString(),workerJson.hasEngineRoomClearance.ToString(),workerJson.lastEntranceInEngineRoom,workerJson.lastExitFromEngineRoom);
                workers[i] = worker;
            }

            computer.SetWorkers(workers);
            RefreshDisplay(computer);
            yield break;
        }

        [Serializable]
        private class WorkersJsonArray
        {
            public WorkerJson[] employees;
        }

        [Serializable]
        private class WorkerJson {
            public string name;
            public int employeeId;
            public bool hasEngineRoomClearance;
            public string lastEntranceInEngineRoom;
            public string lastExitFromEngineRoom;
        }
    }
}
