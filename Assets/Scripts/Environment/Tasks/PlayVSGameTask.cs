using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Play VS Game Task", menuName = "Tasks/Computer/Play VS Game")]
    public sealed class PlayVSGameTask : Task {
        public override IEnumerator Execute(Computer computer) {
            SceneManager.LoadScene("VSGameScene", LoadSceneMode.Single);
            yield break;
        }
    }
}
