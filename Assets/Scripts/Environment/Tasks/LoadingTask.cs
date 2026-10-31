using System.Collections;
using UnityEngine;
using TMPro;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Loading Task", menuName = "Environment/Tasks/Loading Task")]
    public class LoadingTask : Task {
        private float speed = 0.5f;
        public bool IsDone { get; private set; }

        public override void Execute() {
            IsDone = false;
            TaskRunner.Instance.StartCoroutine(AnimateLoadingRoutine());
        }

        private IEnumerator AnimateLoadingRoutine() {
            TextMeshProUGUI loadingText = FindFirstObjectByType<TextMeshProUGUI>(FindObjectsInactive.Include);
            loadingText.gameObject.SetActive(true);

            for(int i = 0; i < 3; i++) {
                loadingText.text = "Loading";
                yield return new WaitForSeconds(speed);

                loadingText.text = "Loading.";
                yield return new WaitForSeconds(speed);

                loadingText.text = "Loading..";
                yield return new WaitForSeconds(speed);

                loadingText.text = "Loading...";
                yield return new WaitForSeconds(speed);
            }

            loadingText.gameObject.SetActive(false);
            IsDone = true;
        }
    }
}
