using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "WorklogTask", menuName = "Environment/Tasks/WorklogTask")]
    public class WorklogTask : Task {
        [SerializeField] private TextAsset jsonFile;

        public override void Execute() {
            WorkerList loadedData = JsonUtility.FromJson<WorkerList>(jsonFile.text);
            Computer computer = FindFirstObjectByType<Computer>();   
            computer.SetWorkers(loadedData.Employees);
        }
    }
}

