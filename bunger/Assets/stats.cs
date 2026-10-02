using UnityEngine;

public class Stats : StatManager
{
    public static int weapondamage;
    public static int xplevel;
    public static float playerspeed;
    public static float attackspeed;
    public static int elitecounter;
    public static int killcounter;
    public static int score;
    public static float xpneeded;
    public static int orbgive;
    void Start()
    {
        weapondamage = 5;
        xplevel = 0;
        playerspeed = 1.5f;
        attackspeed = 1f;
        elitecounter = 0;
        killcounter = 0;
        score = 0;
        xpneeded = 0;
        orbgive = 10;
    }
}
