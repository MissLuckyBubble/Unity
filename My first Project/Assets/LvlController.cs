using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LvlController : MonoBehaviour
{
    private Enemy[] _enemies;
    private static int _nextLevelIndex = 1;
    public Text lvlText;

    private void OnEnable()
    {

        _enemies = FindObjectsOfType<Enemy>();

    }


    // Update is called once per frame
    void Update()
    {
       int lvl = _nextLevelIndex;
       lvlText.text ="LVL: " + lvl;


        foreach (Enemy enemy in _enemies)
        {
            if (enemy != null)
                return;
        }

        _nextLevelIndex++;
        string nextLevelName = "Level" + _nextLevelIndex;
        SceneManager.LoadScene(nextLevelName); 
    }
}
