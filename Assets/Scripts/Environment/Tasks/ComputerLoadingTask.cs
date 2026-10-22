using System.Collections;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Computer Loading Task", menuName = "Tasks/Computer/Loading")]
    public sealed class ComputerLoadingTask : Task {
        public override IEnumerator Execute(Computer computer) {
            if(computer.LoadingScreen != null) computer.LoadingScreen.SetActive(true);
            if(computer.LoginScreen != null) computer.LoginScreen.SetActive(false);
            if(computer.DesktopScreen != null) computer.DesktopScreen.SetActive(false);

            string[] frames = { "Loading", "Loading.", "Loading..", "Loading...", "Loading", "Loading.", "Loading..", "Loading..." };
            foreach(string frame in frames) {
                if(computer.LoadingLabel != null)
                    computer.LoadingLabel.text = frame;
                yield return new WaitForSeconds(0.25f);
            }

            if(computer.LoadingScreen != null)
                computer.LoadingScreen.SetActive(false);
        }
    }
}