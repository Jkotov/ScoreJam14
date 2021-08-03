using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenLeaderboard : MonoBehaviour
{
    public void Open()
    {
        Application.OpenURL("https://infamy.dev/highscore/web?id=Pathmaker");
    }
}
