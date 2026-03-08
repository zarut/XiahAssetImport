using System;
using UnityEngine;

[Serializable]
public class CharacterAnimationEffect
{
    [SerializeField]
    private int _nEffectID;
    [SerializeField]
    private sbyte _nPosX;
    [SerializeField]
    private sbyte _nPosY;
    [SerializeField]
    private sbyte _nPosZ;
    [SerializeField]
    private sbyte _nBoneIndex;
    [SerializeField]
    private ushort _nStartTime;

    public Int32 nEffectID
    {
        get
        {
            return _nEffectID;
        }
        set
        {
            _nEffectID = value;
        }
    }
    public sbyte nPosX
    {
        get
        {
            return _nPosX;
        }
        set
        {
            _nPosX = value;
        }
    }
    public sbyte nPosY
    {
        get
        {
            return _nPosY;
        }
        set
        {
            _nPosY = value;
        }
    }
    public sbyte nPosZ
    {
        get
        {
            return _nPosZ;
        }
        set
        {
            _nPosZ = value;
        }
    }
    public sbyte nBoneIndex
    {
        get
        {
            return _nBoneIndex;
        }
        set
        {
            _nBoneIndex = value;
        }
    }
    public UInt16 nStartTime
    {
        get
        {
            return _nStartTime;
        }
        set
        {
            _nStartTime = value;
        }
    }

    public CharacterAnimationEffect()
    {
        nEffectID = 0;
        nPosX = 0;
        nPosY = 0;
        nPosZ = 0;
        nBoneIndex = 0;
        nStartTime = 0;
    }
}
