using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoadManager : MonoBehaviour {

    [SerializeField]
    private GameObject GameManagerPrefab;
    [SerializeField]
    private GameObject CameraPrefab;

    void Start () {
        GameObject gameManager = GameObject.FindGameObjectWithTag(Constants.Tags.GameController);
        if(gameManager == null)
        {
            GameObject.Instantiate(CameraPrefab);
            GameObject.Instantiate(GameManagerPrefab);
        }
	}
}
