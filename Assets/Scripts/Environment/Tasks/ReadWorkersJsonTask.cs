using System.Collections;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Read Workers Json Task", menuName = "Tasks/Computer/Read Workers Json")]
    public sealed class ReadWorkersJsonTask : Task {
        public override IEnumerator Execute(Computer computer) {
            computer.SetWorkersJsonText(computer.WorkersJson.text);
            yield break;
        }
    }
}
