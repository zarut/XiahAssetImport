using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CharacterMeshDefinition
{
    // Default array size of MeshSize is 3 according to source
    public const int MeshSizeArraySize = 3;

    [SerializeField]
    private ushort _meshType;
    [SerializeField]
    private ushort _characterTextureCount;
    [SerializeField]
    private CharacterTextureDefinition[] _characterTextures;
    [SerializeField]
    private ushort[] _meshSize;
    [SerializeField]
    private ushort _logicalBoneIndiciesCount;
    [SerializeField]
    private ushort[] _logicalBoneIndicies;
    [SerializeField]
    private ushort _characterAnimationEffectsCount;
    [SerializeField]
    private uint _characterAnimationEffectsSize;
    [SerializeField]
    private CharacterAnimationEffect[] _characterAnimationEffects;
    [SerializeField]
    private ushort _characterSkinnedMeshesCount;
    [SerializeField]
    private CharacterSkinnedMesh[] _characterSkinnedMeshes;
    [SerializeField]
    private CharacterSkeleton _characerSkeleton;
    [SerializeField]
    private uint _skinMeshFileOffset;
    [SerializeField]
    private uint _skeletonFileOffset;

    public UInt16 MeshType
    {
        get
        {
            return _meshType;
        }
        set
        {
            _meshType = value;
        }
    }
    public UInt16 CharacterTextureCount
    {
        get
        {
            return _characterTextureCount;
        }
        set
        {
            _characterTextureCount = value;
        }
    }               // texture ¼ö
    public CharacterTextureDefinition[] CharacterTextures
    {
        get
        {
            return _characterTextures;
        }
        set
        {
            _characterTextures = value;
        }
    }				// texture ¸®½ºÆ®
    public UInt16[] MeshSize
    {
        get
        {
            return _meshSize;
        }
        set
        {
            _meshSize = value;
        }
    }

    public UInt16 LogicalBoneIndiciesCount
    {
        get
        {
            return _logicalBoneIndiciesCount;
        }
        set
        {
            _logicalBoneIndiciesCount = value;
        }
    }   // bone index ¼ö
    public UInt16[] LogicalBoneIndicies
    {
        get
        {
            return _logicalBoneIndicies;
        }
        set
        {
            _logicalBoneIndicies = value;
        }
    }     // bone index¸®½ºÆ®

    public UInt16 CharacterAnimationEffectsCount
    {
        get
        {
            return _characterAnimationEffectsCount;
        }
        set
        {
            _characterAnimationEffectsCount = value;
        }
    }               // Mesh¿¡ ¿¬°áµÈ ÀÌÆåÆ® ¼ö, ¾ÆÀÌÅÛ ÀÌÆåÆ®
    public UInt32 CharacterAnimationEffectsSize
    {
        get
        {
            return _characterAnimationEffectsSize;
        }
        set
        {
            _characterAnimationEffectsSize = value;
        }
    }
    public CharacterAnimationEffect[] CharacterAnimationEffects
    {
        get
        {
            return _characterAnimationEffects;
        }
        set
        {
            _characterAnimationEffects = value;
        }
    }

    public UInt16 CharacterSkinnedMeshesCount
    {
        get
        {
            return _characterSkinnedMeshesCount;
        }
        set
        {
            _characterSkinnedMeshesCount = value;
        }
    }
    //
    public CharacterSkinnedMesh[] CharacterSkinnedMeshes
    {
        get
        {
            return _characterSkinnedMeshes;
        }
        set
        {
            _characterSkinnedMeshes = value;
        }
    }                // ½ÇÁ¦ Á¤º¸

    public CharacterSkeleton CharacerSkeleton
    {
        get
        {
            return _characerSkeleton;
        }
        set
        {
            _characerSkeleton = value;
        }
    }            // ½ÇÁ¦ skeletonÁ¤º¸

    public UInt32 SkinMeshFileOffset
    {
        get
        {
            return _skinMeshFileOffset;
        }
        set
        {
            _skinMeshFileOffset = value;
        }
    }
    public UInt32 SkeletonFileOffset
    {
        get
        {
            return _skeletonFileOffset;
        }
        set
        {
            _skeletonFileOffset = value;
        }
    }

    public CharacterMeshDefinition()
    {
        this.MeshType = 0;
        this.CharacterTextureCount = 0;
        this.CharacterTextures = null;
        
        this.MeshSize = new ushort[CharacterMeshDefinition.MeshSizeArraySize];

        this.LogicalBoneIndiciesCount = 0;
        this.LogicalBoneIndicies = null;

        this.CharacterAnimationEffectsCount = 0;
        this.CharacterAnimationEffectsSize = 0;
        this.CharacterAnimationEffects = null;

        this.CharacterSkinnedMeshesCount = 0;

        this.CharacterSkinnedMeshes = null;
        this.CharacerSkeleton = null;

        this.SkinMeshFileOffset = 0;
        this.SkeletonFileOffset = 0;
    }
}
