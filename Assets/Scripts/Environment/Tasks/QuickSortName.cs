using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "QuickSortNameTask", menuName = "Environment/Tasks/QuickSortNameTask")]
    public class QuickSortNameTask : Task {
        public override void Execute() {
            Computer computer = FindFirstObjectByType<Computer>();
            if(computer == null || computer.WorkerArray == null || computer.WorkerArray.Length == 0) return;

            QuickSort(computer.WorkerArray, 0, computer.WorkerArray.Length - 1);
            computer.Left();
        }

        private void QuickSort(Worker[] array, int low, int high) {
            if(low >= high) return;

            string pivot = array[high].Name;
            int i = low - 1;

            for(int j = low; j < high; j++) {
                if(string.Compare(array[j].Name, pivot) < 0) {
                    i++;
                    Worker temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }

            Worker swap = array[i + 1];
            array[i + 1] = array[high];
            array[high] = swap;

            int pivotIndex = i + 1;

            QuickSort(array, low, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, high);
        }
    }
}
