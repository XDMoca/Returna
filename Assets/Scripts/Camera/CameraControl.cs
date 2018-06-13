using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    [HideInInspector]
    public Transform player;

    [SerializeField]
    private float DistanceFromPlayer;
    [SerializeField]
    private float CameraAngle;

    void Awake () {
	}
	
	void LateUpdate () {
        if (player == null)
            return;
        transform.position = player.position + (Quaternion.Euler(CameraAngle, 0, 0) * new Vector3(0, DistanceFromPlayer, 0));
        transform.LookAt(player.position);
	}
}
