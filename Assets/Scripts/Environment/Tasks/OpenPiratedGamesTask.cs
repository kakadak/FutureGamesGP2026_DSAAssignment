using System.Collections;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Open Pirated Games Task", menuName = "Tasks/Computer/Open Pirated Games")]
    public sealed class OpenPiratedGamesTask : Task {
        public override IEnumerator Execute(Computer computer) {
            computer.PiratedGamesScreen.SetActive(true);
            computer.DesktopScreen.SetActive(false);
            yield break;
        }
    }
}