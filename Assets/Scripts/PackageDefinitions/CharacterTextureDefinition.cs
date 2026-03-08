using System;
using UnityEngine;

[Serializable]
public class CharacterTextureDefinition
{
    [SerializeField]
    private ushort _textureType;
    [SerializeField]
    private ushort _subTextureCount;
    [SerializeField]
    private CharacterSubTextureDefinition[] _characterSubTextureDefinitions;

    public UInt16 TextureType
    {
        get
        {
            return _textureType;
        }
        set
        {
            _textureType = value;
        }
    }        // texture type
    public UInt16 SubTextureCount
    {
        get
        {
            return _subTextureCount;
        }
        set
        {
            _subTextureCount = value;
        }
    }   // texture sub °¹¼ö
    public CharacterSubTextureDefinition[] CharacterSubTextureDefinitions
    {
        get
        {
            return _characterSubTextureDefinitions;
        }
        set
        {
            _characterSubTextureDefinitions = value;
        }
    }   // texture sub ¸®½ºÆ®

    public CharacterTextureDefinition()
    {
        this.TextureType = 0;
        this.SubTextureCount = 0;
        this.CharacterSubTextureDefinitions = null;
    }
}
