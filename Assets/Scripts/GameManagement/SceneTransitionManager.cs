using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour {

    private Animator animator;
    private GameObject player;
    private string nextSceneName;
    private ESpawnPointIdentifiers nextSceneSpawnPointIdentifier;

    [SerializeField]
    private GameObject playerPrefab;

    void Start () {
        animator = GetComponent<Animator>();
        SceneManager.sceneLoaded += OnLevelLoaded;

        if (player == null)
        {
            player = GameObject.Instantiate(playerPrefab, Vector3.zero, Quaternion.identity);
            Camera.main.GetComponent<CameraControl>().player = player.transform;
        }
        DontDestroyOnLoad(player);
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(Camera.main.gameObject);
    }


    public void StartSceneTransition(string NextAreaName, ESpawnPointIdentifiers NextAreaSpawnPointIdentifier)
    {
        print(NextAreaName);
        nextSceneName = NextAreaName;
        nextSceneSpawnPointIdentifier = NextAreaSpawnPointIdentifier;
        animator.SetTrigger("FadeOut");
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(nextSceneName);
    }

    public void OnLevelLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        AreaSpawnPoint spawnPoint = FindObjectsOfType<AreaSpawnPoint>().Where(sP => sP.Identifier == nextSceneSpawnPointIdentifier).FirstOrDefault();
        player.transform.position = spawnPoint.transform.position;
        animator.SetTrigger("FadeIn");
    }
}
