using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class PlayManager : MonoBehaviour
{
    public GameObject player;
    private int lives = 0;
    public bool Dead = false;
    private Vector3 spawnPos;

    private void Awake()
    {
        Time.timeScale = 1.0f;
        spawnPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (lives < 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }

    public void UpdateDeath()
    {
        Dead = true;
        lives--;
        player.transform.position = new Vector3(spawnPos.x, spawnPos.y + 20, spawnPos.z);
        Debug.Log("You died");
        // NoDeath();
    }

    private async void NoDeath()
    {
        Time.timeScale = 0.5f;
        await Task.Delay(100);
        Dead = false;

        await Task.Delay(5000);
        Time.timeScale = 1.0f;
    }
}
