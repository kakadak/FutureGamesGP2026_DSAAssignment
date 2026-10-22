using Environment;
using UnityEngine;

namespace Environment.Tasks {
    public abstract class WorklogTask : Task {
        protected void RefreshDisplay(Computer computer) {
            foreach(GameObject icon in computer.WorklogIcons) {
                if(icon != null)
                    icon.SetActive(true);
            }
        }
    }
}