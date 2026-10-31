using System.Collections;
using Environment.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Environment {
    public class Computer : MonoBehaviour, IInteractable {
        [SerializeField] private Task testTask;
        [Header("StartupTasks")]
        [SerializeField] private Task camTask;
        [SerializeField] private Task loadTask;
        [SerializeField] private Task enterTask;
        [SerializeField] private Task worklogTask;

        [Header("Data Storage")]
        [SerializeField] private Worker[] loadedWorkers;

        [Header("Worklogs")]
        [SerializeField] private GameObject worklogsSystem;
        [SerializeField] TextMeshProUGUI Name;
        [SerializeField] TextMeshProUGUI ID;
        [SerializeField] TextMeshProUGUI Clearance;
        [SerializeField] TextMeshProUGUI Entrance;
        [SerializeField] TextMeshProUGUI Exit;
        [SerializeField] private int index = 0;

        [Header("Sorts")]
        [SerializeField] private Task IDsort;
        [SerializeField] private Task Namesort;
        [SerializeField] private Task Entrancesort;
        [SerializeField] private Task Exitsort;
        [SerializeField] public Toggle LowHigh;

        


        private MyQueue<Task> computerQueue = new MyQueue<Task>();

        public Worker[] WorkerArray;

        public void SetWorkers(Worker[] workers) {
            WorkerArray = workers;
        }

        public void OnInteract() {
            computerQueue.Enqueue(testTask);
            computerQueue.Enqueue(camTask);
            computerQueue.Enqueue(loadTask);
            computerQueue.Enqueue(enterTask);

            StartCoroutine(ProcessQueue());
        }

        private IEnumerator ProcessQueue() {
            while(computerQueue.Count > 0) {
                Task runTask = computerQueue.Dequeue();
                runTask.Execute();
                if(runTask is LoadingTask loadingTask) {
                    yield return new WaitUntil(() => loadingTask.IsDone);
                }
            }
        }

        public void Enter() {
            CamCore.Instance.SwitchToCamera(2);
            computerQueue.Enqueue(worklogTask);
            worklogsSystem.SetActive(true);
            StartCoroutine(ProcessQueue());
            index = 0;
            Name.text = "Name: " + WorkerArray[index].Name;
            ID.text = "ID: " + WorkerArray[index].EmployeeId.ToString();
            Clearance.text = "Clearance: " + WorkerArray[index].HasEngineRoomClearance.ToString();
            Entrance.text = "Entrance: " + WorkerArray[index].LastEntranceInEngineRoom;
            Exit.text = "Exit: " + WorkerArray[index].LastExitFromEngineRoom;
        }
        public void Left() {
            if(index != 0) {
                index -= 1;
                Name.text = "Name: " + WorkerArray[index].Name;
                ID.text = "ID: " + WorkerArray[index].EmployeeId.ToString();
                Clearance.text = "Clearance: " + WorkerArray[index].HasEngineRoomClearance.ToString();
                Entrance.text = "Entrance: " + WorkerArray[index].LastEntranceInEngineRoom;
                Exit.text = "Exit: " + WorkerArray[index].LastExitFromEngineRoom;
            }
        }
        public void Right() {
            if(index != WorkerArray.Length - 1) {
                index += 1;
                Name.text = "Name: " + WorkerArray[index].Name;
                ID.text = "ID: " + WorkerArray[index].EmployeeId.ToString();
                Clearance.text = "Clearance: " + WorkerArray[index].HasEngineRoomClearance.ToString();
                Entrance.text = "Entrance: " + WorkerArray[index].LastEntranceInEngineRoom;
                Exit.text = "Exit: " + WorkerArray[index].LastExitFromEngineRoom;
            }

        }
        public void Sort() {
            CamCore.Instance.SwitchToCamera(3);
        }
        public void NameSorting() {
            computerQueue.Enqueue(Namesort);
        }
        public void IDSorting() {
            computerQueue.Enqueue(IDsort);
        }
        public void EntranceSorting() {
            computerQueue.Enqueue(Entrancesort);
        }
        public void ExitSorting() {
            computerQueue.Enqueue(Exitsort);
        }
        public void Back() {
            CamCore.Instance.SwitchToCamera(2);
            StartCoroutine(ProcessQueue());
            index = 0;
            Name.text = "Name: " + WorkerArray[index].Name;
            ID.text = "ID: " + WorkerArray[index].EmployeeId.ToString();
            Clearance.text = "Clearance: " + WorkerArray[index].HasEngineRoomClearance.ToString();
            Entrance.text = "Entrance: " + WorkerArray[index].LastEntranceInEngineRoom;
            Exit.text = "Exit: " + WorkerArray[index].LastExitFromEngineRoom;
        }


    }
}
