using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "QuickSortEntranceTask", menuName = "Environment/Tasks/QuickSortEntranceTask")]
    public class QuickSortEntranceTask : Task {
        public override void Execute() {
            Computer computer = FindFirstObjectByType<Computer>();
            QuickSort(computer.WorkerArray, 0, computer.WorkerArray.Length - 1, computer);
            computer.Left();
        }

        private void QuickSort(Worker[] array, int low, int high, Computer computer) {
            if(low >= high) return;

            string pivot = array[high].LastEntranceInEngineRoom;
            int i = low - 1;

            for(int j = low; j < high; j++) {
                if(computer.LowHigh.isOn) {
                    if(string.Compare(array[j].LastEntranceInEngineRoom, pivot) < 0) {
                        i++;
                        Worker temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
                else {
                    if(string.Compare(array[j].LastEntranceInEngineRoom, pivot) > 0) {
                        i++;
                        Worker temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }

                }
            }

            Worker swap = array[i + 1];
            array[i + 1] = array[high];
            array[high] = swap;

            int pivotIndex = i + 1;

            QuickSort(array, low, pivotIndex - 1, computer);
            QuickSort(array, pivotIndex + 1, high, computer);
        }
    }
}
