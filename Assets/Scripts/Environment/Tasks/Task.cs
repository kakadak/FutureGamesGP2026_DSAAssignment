using System.Collections;
using UnityEngine;

namespace Environment.Tasks {
    public abstract class Task : ScriptableObject {
        public abstract IEnumerator Execute(Computer computer);
    }
}