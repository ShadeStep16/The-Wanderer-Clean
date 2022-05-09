using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyCluster : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //if this enemy group (cluster) is empty (no more enemies here), destroy the empty cluster
        if (transform.childCount <= 0)
        {
            Destroy(gameObject);
        }
    }
}
