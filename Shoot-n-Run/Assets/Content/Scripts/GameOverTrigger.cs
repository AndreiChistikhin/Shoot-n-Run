using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out PlayerMovement player))
        {
            Debug.Log("Player defeat");
            SceneManager.LoadScene("SampleScene");
        }
    }
}
