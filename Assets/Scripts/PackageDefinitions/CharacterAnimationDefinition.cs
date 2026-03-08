using System;
using UnityEngine;

[Serializable]
public class CharacterAnimationDefintion
{
    [SerializeField]
    private ushort _animationType;
    [SerializeField]
    private CharacterSkeletonAnimation _skeletonAnimation;
    [SerializeField]
    private ushort _effectCount;
    [SerializeField]
    private uint _effectDataSize;
    [SerializeField]
    private int _effectCharacterId;
    [SerializeField]
    private CharacterAnimationEffect[] _effects;
    [SerializeField]
    private uint _soundsDataSize;
    [SerializeField]
    private ushort _soundsCount;
    [SerializeField]
    private CharacterAnimationSound[] _sounds;
    [SerializeField]
    private uint _timerTriggersDataSize;
    [SerializeField]
    private ushort _timerTriggersCount;
    [SerializeField]
    private CharacterTimerTrigger[] _timerTriggers;
    [SerializeField]
    private uint _animationFileOffset;

    public UInt16 AnimationType
    {
        get
        {
            return _animationType;
        }
        set
        {
            _animationType = value;
        }
    }

    public CharacterSkeletonAnimation SkeletonAnimation
    {
        get
        {
            return _skeletonAnimation;
        }
        set
        {
            _skeletonAnimation = value;
        }
    }

    public UInt16 EffectCount
    {
        get
        {
            return _effectCount;
        }
        set
        {
            _effectCount = value;
        }
    }
    public UInt32 EffectDataSize
    {
        get
        {
            return _effectDataSize;
        }
        set
        {
            _effectDataSize = value;
        }
    }         // effect_ptr µ¥ÀÌÅ¸ »çÀÌÁî. + int
    public Int32 EffectCharacterId
    {
        get
        {
            return _effectCharacterId;
        }
        set
        {
            _effectCharacterId = value;
        }
    }
    public CharacterAnimationEffect[] Effects
    {
        get
        {
            return _effects;
        }
        set
        {
            _effects = value;
        }
    }

    public UInt32 SoundsDataSize
    {
        get
        {
            return _soundsDataSize;
        }
        set
        {
            _soundsDataSize = value;
        }
    }          // sound_ptr data size
    public UInt16 SoundsCount
    {
        get
        {
            return _soundsCount;
        }
        set
        {
            _soundsCount = value;
        }
    }
    public CharacterAnimationSound[] Sounds
    {
        get
        {
            return _sounds;
        }
        set
        {
            _sounds = value;
        }
    }

    public UInt32 TimerTriggersDataSize
    {
        get
        {
            return _timerTriggersDataSize;
        }
        set
        {
            _timerTriggersDataSize = value;
        }
    }            // trigger_ptr data size
    public UInt16 TimerTriggersCount
    {
        get
        {
            return _timerTriggersCount;
        }
        set
        {
            _timerTriggersCount = value;
        }
    }
    public CharacterTimerTrigger[] TimerTriggers
    {
        get
        {
            return _timerTriggers;
        }
        set
        {
            _timerTriggers = value;
        }
    }

    public UInt32 AnimationFileOffset
    {
        get
        {
            return _animationFileOffset;
        }
        set
        {
            _animationFileOffset = value;
        }
    }

    public CharacterAnimationDefintion()
    {
        AnimationType = 0;
        SkeletonAnimation = null;           // ½ÇÁ¦ animation Á¤º¸

        EffectCount = 0;
        EffectDataSize = 0;
        EffectCharacterId = 0;
        Effects = null;

        SoundsDataSize = 0;
        SoundsCount = 0;
        Sounds = null;

        TimerTriggersDataSize = 0;
        TimerTriggersCount = 0;
        TimerTriggers = null;

        AnimationFileOffset = 0;
    }
}
