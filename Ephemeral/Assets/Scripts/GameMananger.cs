using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMananger : MonoBehaviour
{
    public Player player;
    private void Awake()
    {
        player.LoadPlayer();
    }
}
