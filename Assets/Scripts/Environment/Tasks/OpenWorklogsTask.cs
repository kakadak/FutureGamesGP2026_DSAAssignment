using System.Collections;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Open Worklogs Task", menuName = "Tasks/Computer/Open Worklogs")]
    public sealed class OpenWorklogsTask : WorklogTask {
        public override IEnumerator Execute(Computer computer) {
            computer.WorklogsScreen.SetActive(true);
            computer.DesktopScreen.SetActive(false);
            yield break;
        }
    }
}
