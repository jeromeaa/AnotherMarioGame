
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCount : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject Warning;
    public GameObject Fireball;
    public Transform spawnfirepoint;
    public int spawntime=10;
    public int spawnfireball=5;
    public Transform spawnpoint;
    int i = 0;
    public static int score;
    public Text txt;
    public int changefire = 25;
    public int changebullet = 25;
    private void FixedUpdate()
    {
        i++;
        score = i / 50;
        txt.text = score.ToString();
        if (i % 50 == 0)
        {
            if (score % spawntime == 0)
            {
                Instantiate(Bullet, spawnpoint.position, spawnpoint.rotation);
                Instantiate(Warning);
            }
            if (score % spawnfireball == 0)
            {
                Instantiate(Fireball, spawnfirepoint.position, spawnfirepoint.rotation);
            }
            if (score % changefire == 0 && spawnfireball>1)
            {
                spawnfireball--;
            }
            if (score % changebullet == 0 && spawntime>2)
            {
                spawntime--;
            }

        }
    }
}
