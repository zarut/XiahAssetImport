using System;
using UnityEngine;

[Serializable]
public class CharacterAnimationSound
{
    [SerializeField]
    private int _nSoundID;
    [SerializeField]
    private int _nEffectDBID;

    public Int32 nSoundID
    {
        get
        {
            return _nSoundID;
        }
        set
        {
            _nSoundID = value;
        }
    }       // ANIMATION2_SOUND table nID
    public Int32 nEffectDBID
    {
        get
        {
            return _nEffectDBID;
        }
        set
        {
            _nEffectDBID = value;
        }
    }

    public CharacterAnimationSound()
    {
        nSoundID = 0;
        nEffectDBID = 0;
    }
}
