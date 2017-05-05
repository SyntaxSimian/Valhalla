using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FlightPaths
{
    public enum paths
    {
        hookFly,
        reverseHookFly
    }; 
    
    public static Vector3[] assignPath(ref Vector3[] flightPath, Vector3 player, paths pathSelect)
    {
        flightPath = new Vector3[1]; flightPath[0] = new Vector3(0, 0, 0);

        if (pathSelect == paths.hookFly)
        {
            flightPath = new Vector3[2];
            flightPath[0] = new Vector3(player.x + 25, player.y + Random.Range(-8, 8), 15);
            flightPath[1] = new Vector3(player.x - 25, player.y + Random.Range(-8, 8), 15);
        }

        if (pathSelect == paths.reverseHookFly)
        {
            flightPath = new Vector3[2];
            flightPath[0] = new Vector3(player.x - 25, player.y + Random.Range(-8, 8), 15);
            flightPath[1] = new Vector3(player.x + 25, player.y + Random.Range(-8, 8), 15);
        }
        return flightPath; 
    }
}
