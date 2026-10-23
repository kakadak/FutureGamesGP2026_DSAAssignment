using System.Collections;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Computer Initialize Task", menuName = "Tasks/Computer/Initialize")]
    public sealed class ComputerInitializeTask : Task {
        public override IEnumerator Execute(Computer computer) {
            computer.LoggedIn = false;
            computer.LoginRequested = false;
            computer.LoadingScreen.SetActive(false);
            computer.LoginScreen.SetActive(false);
            computer.DesktopScreen.SetActive(false);
            computer.PiratedGamesScreen.SetActive(false);
            computer.WorklogsScreen.SetActive(false);
            computer.DataCanvas.SetActive(false);
            yield break;
        }
    }
}
