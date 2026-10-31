using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "QuickSortIDTask", menuName = "Environment/Tasks/QuickSortIDTask")]
    public class QuickSortWorkersIDTask : Task {
        public override void Execute() {
            Computer computer = FindFirstObjectByType<Computer>();
            QuickSortID(computer.WorkerArray, 0, computer.WorkerArray.Length - 1, computer);
            computer.Left();
        }

        private void QuickSortID(Worker[] array, int low, int high, Computer computer) {
            if(low >= high) return;

            int pivot = array[high].EmployeeId;
            int i = low - 1;

            for(int j = low; j < high; j++) {
                if(computer.LowHigh.isOn) {
                    if(array[j].EmployeeId < pivot) {
                        i++;
                        Worker temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
                else {
                    if(array[j].EmployeeId > pivot) {
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

            QuickSortID(array, low, pivotIndex - 1, computer);
            QuickSortID(array, pivotIndex + 1, high, computer);
        }
    }
}
