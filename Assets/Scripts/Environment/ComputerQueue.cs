using System.Collections;
using Environment.Tasks;
using UnityEngine;

namespace Environment {
    public sealed class ComputerTaskQueue : MonoBehaviour {
        [Header("Tasks")]
        [SerializeField] private Task initializationTask;
        [SerializeField] private Task[] startupTasks;
        [SerializeField] private Task piratedGamesTask;
        [SerializeField] private Task openWorklogsTask;
        [SerializeField] private Task returnToDesktopTask;
        [SerializeField] private Task playVSGameTask;

        private readonly global::Environment.Queue<Task> tasks = new global::Environment.Queue<Task>();
        private Computer computer;
        private Coroutine queueCoroutine;

        public int Count => tasks.Count;
        public Task Peek() => tasks.Peek();
        public bool IsRunning { get; private set; }
        public Task ActiveTask { get; private set; }

        public void EnqueueInitializationTasks(Computer targetComputer) {
            computer = targetComputer;
            Enqueue(initializationTask);
            StartQueueIfNeeded();
        }

        public void EnqueueStartupTasks(Computer targetComputer) {
            computer = targetComputer;
            if(startupTasks != null) {
                foreach(Task task in startupTasks)
                    Enqueue(task);
            }
            StartQueueIfNeeded();
        }

        //Shortlinks :D
        public void EnqueuePiratedGamesTask(Computer targetComputer) => EnqueueAndStart(piratedGamesTask, targetComputer);
        public void EnqueueOpenWorklogsTask(Computer targetComputer) => EnqueueAndStart(openWorklogsTask, targetComputer);
        public void EnqueueReturnToDesktopTask(Computer targetComputer) => EnqueueAndStart(returnToDesktopTask, targetComputer);
        public void EnqueuePlayVSGameTask(Computer targetComputer) => EnqueueAndStart(playVSGameTask, targetComputer);

        private void EnqueueAndStart(Task task, Computer targetComputer) {
            computer = targetComputer;
            Enqueue(task);
            StartQueueIfNeeded();
        }

        private void Enqueue(Task task) {
            if(task != null)
                tasks.Enqueue(task);
        }

        private void StartQueueIfNeeded() {
            if(IsRunning || tasks.Count == 0) {
                Debug.Log("No diabito no tasks");
                return;
            }

            IsRunning = true;
            queueCoroutine = StartCoroutine(RunTaskQueue());
        }

        private IEnumerator RunTaskQueue() {
            while(TryDequeue(out Task task)) {
                yield return task.Execute(computer);
                CompleteCurrentTask();
            }
            Complete();
            queueCoroutine = null;
        }

        private bool TryDequeue(out Task task) {
            if(tasks.Count == 0) {
                task = null;
                ActiveTask = null;
                Debug.Log("Nonono mame theres no Tasks!");
                return false;
            }

            task = tasks.Dequeue();
            ActiveTask = task;
            return true;
        }

        private void CompleteCurrentTask() {
            ActiveTask = null;
        }

        private void Complete() {
            ActiveTask = null;
            IsRunning = false;
        }

        public void CancelQueue() {
            if(queueCoroutine != null)
                StopCoroutine(queueCoroutine);
            queueCoroutine = null;
            tasks.Clear();
            ActiveTask = null;
            IsRunning = false;
        }
    }
}
