using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableDoor : MonoBehaviour, IInteractable {

    [SerializeField]
    private string NextAreaName;
    [SerializeField]
    private ESpawnPointIdentifiers NextAreaSpawnPointIdentifier;

    private SceneTransitionManager sceneTransitionManager;



    void Start () {
        sceneTransitionManager = GameObject.FindObjectOfType<SceneTransitionManager>();
	}

    public void GoToNextArea()
    {
        sceneTransitionManager.StartSceneTransition(NextAreaName, NextAreaSpawnPointIdentifier);
    }
}
