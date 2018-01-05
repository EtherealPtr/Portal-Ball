using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public string nextLevel;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TheGameManager.instance.IncrementLevel(1);
            FindObjectOfType<AudioControl>().PlayAudioFile("TeleportSound");
            SceneManager.LoadScene(nextLevel);
        }
    }
}
