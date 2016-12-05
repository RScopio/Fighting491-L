using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public float delay = 5f;
    public int SceneIndex = 1;
    public AudioClip GameOverSound;


    // Use this for initialization
    void Start()
    {
        SoundManager.instance.PlaySingle(GameOverSound);
        StartCoroutine(LoadLevelAfterDelay(delay));
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(SceneIndex);
    }
}
