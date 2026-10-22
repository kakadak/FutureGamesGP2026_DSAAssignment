using System.Collections;
using UnityEngine;

public class Tools : MonoBehaviour
{
    public static Tools use { get; private set; }

    private void Awake()
    {
        use = this;
    }

    public IEnumerator Wait(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
