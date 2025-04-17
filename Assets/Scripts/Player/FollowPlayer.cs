using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Makes whatever object this is attatched to follow the player, reference to player has to be parsed in elsewhere

    [Tooltip("The player's transform")]
    public Transform player;

    // Follow the player
    void Update()
    {
        if (player != null) { transform.position = player.position; }
    }
}
