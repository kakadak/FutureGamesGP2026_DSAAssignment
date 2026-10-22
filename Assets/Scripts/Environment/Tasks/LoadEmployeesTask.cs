using System.Collections;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Load Employees Task", menuName = "Tasks/Computer/Load Employees")]
    public sealed class LoadEmployeesTask : WorklogTask {
        public override IEnumerator Execute(Computer computer) {
            RefreshDisplay(computer);
            yield break;
        }
    }
}