using System.Collections;

namespace Environment.Tasks {
    [UnityEngine.CreateAssetMenu(fileName = "Return To Worklogs Task", menuName = "Tasks/Computer/Return To Worklogs")]
    public sealed class ReturnToWorklogsTask : Task {
        public override IEnumerator Execute(Computer computer) {
            computer.DataCanvas.SetActive(false);
            computer.WorklogsScreen.SetActive(true);
            Cameras.comand.CamChange(1);
            yield break;
        }
    }
}
