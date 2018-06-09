using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpawnPoint : MonoBehaviour {

    [SerializeField]
    public ESpawnPointIdentifiers Identifier;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, 1);
    }
}
