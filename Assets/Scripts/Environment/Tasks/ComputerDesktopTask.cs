using System.Collections;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Computer Desktop Task", menuName = "Tasks/Computer/Show Desktop")]
    public sealed class ComputerDesktopTask : Task {
        public override IEnumerator Execute(Computer computer) {
            computer.DesktopScreen.SetActive(true);
            yield break;
        }
    }
}
