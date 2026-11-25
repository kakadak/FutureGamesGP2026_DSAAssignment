using System.Collections.Generic;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "SearchTask", menuName = "Environment/Tasks/SearchTask")]
    public class DateSearchTask : Task {
        public override void Execute() {
            Computer computer = FindFirstObjectByType<Computer>();
            string queryFrom = computer.SearchInput.text.Trim();
            string queryTo = computer.SearchInput2.text.Trim();

            if(string.IsNullOrEmpty(queryFrom) && string.IsNullOrEmpty(queryTo)) {
                computer.Restore();
                return;
            }

            queryFrom = NormalizeStartQuery(queryFrom);
            queryTo = NormalizeEndQuery(queryTo);

            Worker[] foundWorkers;

            if(computer.SearchModeDropdown.value == 1) {
                foundWorkers = SearchInArray(computer.AllWorkers, queryFrom, queryTo);
            }
            else {
                BinaryTree tree = new BinaryTree();
                tree.Insert(computer.AllWorkers);
                foundWorkers = tree.SearchRange(queryFrom, queryTo);
            }

            computer.Results(foundWorkers);
        }

        private string NormalizeStartQuery(string input) {
            if(string.IsNullOrEmpty(input)) return "0000-01-01T00:00:00";
            input = input.Replace(' ', 'T');

            if(input.Length == 10) return input + "T00:00:00";
            if(input.Length == 13) return input + ":00:00";
            if(input.Length == 16) return input + ":00";
            return input;
        }

        private string NormalizeEndQuery(string input) {
            if(string.IsNullOrEmpty(input)) return "9999-12-31T23:59:59";
            input = input.Replace(' ', 'T');

            if(input.Length == 10) return input + "T23:59:59";
            if(input.Length == 13) return input + ":59:59";
            if(input.Length == 16) return input + ":59";
            return input;
        }

        private Worker[] SearchInArray(Worker[] source, string startDate, string endDate) {
            if(source == null || source.Length == 0) {
                return new Worker[0];
            }

            Worker[] sortedWorkers = new Worker[source.Length];
            for(int i = 0; i < source.Length; i++) {
                sortedWorkers[i] = source[i];
            }

            QuickSort(sortedWorkers, 0, sortedWorkers.Length - 1);

            int firstIndex = FindFirstIndex(sortedWorkers, startDate);
            if(firstIndex == -1) {
                return new Worker[0];
            }

            List<Worker> results = new List<Worker>();
            for(int i = firstIndex; i < sortedWorkers.Length; i++) {
                string workerDate = sortedWorkers[i].LastEntranceInEngineRoom;
                if(string.Compare(workerDate, endDate) <= 0) {
                    results.Add(sortedWorkers[i]);
                }
                else {
                    break;
                }
            }

            return results.ToArray();
        }

        private int FindFirstIndex(Worker[] array, string targetDate) {
            int left = 0;
            int right = array.Length - 1;
            int resultIndex = -1;

            while(left <= right) {
                int mid = left + (right - left) / 2;
                string midDate = array[mid].LastEntranceInEngineRoom;
                int compare = string.Compare(midDate, targetDate);

                if(compare >= 0) {
                    resultIndex = mid;
                    right = mid - 1;
                }
                else {
                    left = mid + 1;
                }
            }

            return resultIndex;
        }

        private void QuickSort(Worker[] array, int low, int high) {
            if(low >= high) return;

            string pivot = array[high].LastEntranceInEngineRoom;
            int i = low - 1;

            for(int j = low; j < high; j++) {
                if(string.Compare(array[j].LastEntranceInEngineRoom, pivot) < 0) {
                    i++;
                    Worker temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
                else if(string.Compare(array[j].LastEntranceInEngineRoom, pivot) == 0) {
                    if(array[j].EmployeeId < array[high].EmployeeId) {
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

            QuickSort(array, low, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, high);
        }
    }
}
