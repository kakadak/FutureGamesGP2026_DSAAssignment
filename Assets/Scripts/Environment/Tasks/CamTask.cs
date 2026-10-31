using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "CamTask", menuName = "Environment/Tasks/Camtask")]
    public class CamTask : Task {
        public override void Execute() {
            CamCore.Instance.SwitchToCamera(1);
        }
    }
}
