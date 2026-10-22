using System.Collections;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Change Worklog Page Task", menuName = "Tasks/Computer/Change Worklog Page")]
    public sealed class ChangeWorklogPageTask : WorklogTask {
        [SerializeField] private int direction;

        public override IEnumerator Execute(Computer computer) {
            RefreshDisplay(computer);
            yield break;
        }
    }
}