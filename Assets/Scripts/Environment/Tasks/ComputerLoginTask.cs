using System.Collections;
using UnityEngine;

namespace Environment.Tasks {
    [CreateAssetMenu(fileName = "Computer Login Task", menuName = "Tasks/Computer/Login")]
    public sealed class ComputerLoginTask : Task {
        public override IEnumerator Execute(Computer computer) {
            computer.LoginScreen.SetActive(true);
            while(!computer.LoggedIn) {
                if(computer.LoginRequested) {
                    computer.LoginRequested = false;
                    if(computer.PasswordInput.text == "Chicken") {
                        computer.LoggedIn = true;
                        computer.PasswordInput.text = "";
                        computer.LoginPlaceholder.text = "Access granted";
                        
                    }
                    else {
                        computer.PasswordInput.text = "";
                        computer.LoginPlaceholder.text = "You have demencia";
                    }
                }
                yield return null;
            }
            computer.LoginScreen.SetActive(false);
        }
    }
}
