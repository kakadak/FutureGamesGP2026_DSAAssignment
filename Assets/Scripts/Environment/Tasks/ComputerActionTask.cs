using System.Collections;
using UnityEngine;

namespace Environment.Tasks {
    public sealed class ComputerActionTask : Task {
        public override IEnumerator Execute(Computer computer) {
            Debug.Log("I am here!");
            yield break;
        }
    }
}
