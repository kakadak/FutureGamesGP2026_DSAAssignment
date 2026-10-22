using System.Collections;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Return To Desktop Task", menuName = "Tasks/Computer/Return To Desktop")]
    public sealed class ReturnToDesktopTask : Task {
        public override IEnumerator Execute(Computer computer) {
            computer.LoginScreen.SetActive(false);
            computer.PiratedGamesScreen.SetActive(false);
            computer.WorklogsScreen.SetActive(false);
            computer.DesktopScreen.SetActive(true);
            yield break;
        }
    }
}