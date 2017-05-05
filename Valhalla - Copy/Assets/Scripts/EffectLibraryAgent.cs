using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EffectLibraryAgent
{
    static EffectLibrary eLib;
    public static void setEffectLibrary(EffectLibrary effectLibrary)
    {
        eLib = effectLibrary;
    }

    public enum Effects
    {
        BulletImpact1,
        BulletTracer1,
        ExplosionEnemySmall
    }

    public static void PlayEffect(Effects effectToPlay, Vector3 position)
    {
        switch(effectToPlay)
        {
            case Effects.BulletImpact1:
                {
                    eLib.SpawnImpact(position);
                    break;
                }
            case Effects.ExplosionEnemySmall:
                {
                    eLib.SpawnSmallEnemyKill(position);
                    break;
                }
        }
    }
}
