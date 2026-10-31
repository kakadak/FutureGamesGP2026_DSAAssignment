using System.Collections;
using Environment.Tasks;
using UnityEngine;

namespace Environment {
    public class Computer : MonoBehaviour, IInteractable {
        [SerializeField] private Task testTask;
        [Header("StartupTasks")]
        [SerializeField] private Task camTask;
        [SerializeField] private Task loadTask;
        [SerializeField] private Task enterTask;

        private MyQueue<Task> computerQueue = new MyQueue<Task>();

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
        }
    }
}
