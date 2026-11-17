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

            if(string.IsNullOrEmpty(queryFrom)) {
                queryFrom = "0000-01-01";
            }
            if(string.IsNullOrEmpty(queryTo)) {
                queryTo = "9999-12-31";
            }

            BinaryTree tree = new BinaryTree();
            foreach(Worker worker in computer.AllWorkers) {
                tree.Insert(worker);
            }

            Worker[] foundWorkers = tree.SearchRange(queryFrom, queryTo);
            computer.Results(foundWorkers);
        }
    }
}
