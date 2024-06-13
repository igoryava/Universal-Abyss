using UnityEngine;
using UnityEngine.SceneManagement;

public class RestoreGameProgress : MonoBehaviour
{
    [SerializeField] private int _buildindex;
    public void RestoreGame()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(_buildindex);
    }
}
