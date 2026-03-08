using System;
using UnityEngine;

[Serializable]
public class CharacterSubTextureDefinition
{
    [SerializeField]
    private int _textureId;
    [SerializeField]
    private byte _isAlpha;
    [SerializeField]
    private byte _cullingMode;

    public Int32 TextureId
    {
        get
        {
            return _textureId;
        }
        set
        {
            _textureId = value;
        }
    }     // Resource ID (TetxureID)
    public byte IsAlpha
    {
        get
        {
            return _isAlpha;
        }
        set
        {
            _isAlpha = value;
        }
    }     // Alpha BlendingÀÌ¸é 1 ¾Æ´Ï¸é 0
    public byte CullingMode
    {
        get
        {
            return _cullingMode;
        }
        set
        {
            _cullingMode = value;
        }
    }        // Backface CullingÀÌ µé¾î°¡¸é 1 ¾Æ´Ï¸é 0

    public CharacterSubTextureDefinition()
    {
        this.TextureId = 0;
        this.IsAlpha = 0;
        this.CullingMode = 0;
    }
}
