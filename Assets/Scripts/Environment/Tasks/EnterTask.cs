using UnityEngine;
using UnityEngine.UI;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "EnterTask", menuName = "Environment/Tasks/EnterTask")]
    public class EnterTask : Task {
        public override void Execute() {
            Button[] buttons = FindObjectsByType<Button>(FindObjectsInactive.Include, FindObjectsSortMode.None);

            foreach(Button btn in buttons) {
                if(btn.gameObject.name == "Enter") {
                    btn.gameObject.SetActive(true);
                    break;
                }
            }
        }
    }
}
