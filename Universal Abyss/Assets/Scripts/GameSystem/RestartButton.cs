using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private int _buildIndex;

    public void ResetGame()
    {
        SceneManager.LoadScene(_buildIndex);
    }
}
