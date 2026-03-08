using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class CharacterPackageContainer
{
    [SerializeField]
    private int _characterId;
    [SerializeField]
    private ushort _meshDefinitionsCount;
    [SerializeField]
    private ushort _animationDefinitionsCount;

    [SerializeField]
    private CharacterMeshKvp[] _meshDefinitionsKvps;
    [SerializeField]
    private CharacterAnimationKvp[] _animationDefinitionsKvps;

    private Dictionary<int, CharacterMeshDefinition> _meshDefinitions;
    private Dictionary<int, CharacterAnimationDefintion> _animationDefinitions;

    // variable
    public Int32 CharacterId
    {
        get
        {
            return _characterId;
        }
        set
        {
            _characterId = value;
        }
    }                   // character id
    public UInt16 MeshDefinitionsCount
    {
        get
        {
            return _meshDefinitionsCount;
        }
        set
        {
            _meshDefinitionsCount = value;
        }
    }                      // mesh¼ö
    public UInt16 AnimationDefinitionsCount
    {
        get
        {
            return _animationDefinitionsCount;
        }
        set
        {
            _animationDefinitionsCount = value;
        }
    }                       // animation¼ö

    public CharacterMeshKvp[] MeshDefinitionsKvps
    {
        get
        {
            return _meshDefinitionsKvps;
        }
        set
        {
            _meshDefinitionsKvps = value;
        }
    }
    public CharacterAnimationKvp[] AnimationDefinitionsKvps
    {
        get
        {
            return _animationDefinitionsKvps;
        }
        set
        {
            _animationDefinitionsKvps = value;
        }
    }

    public Dictionary<Int32, CharacterMeshDefinition> MeshDefinitions
    {
        get
        {
            return _meshDefinitions;
        }
        set
        {
            _meshDefinitions = value;
            _meshDefinitionsKvps = _meshDefinitions.Select(kvp => new CharacterMeshKvp { MeshType = kvp.Key, MeshDefinition = kvp.Value }).ToArray();
        }
    }
    public Dictionary<Int32, CharacterAnimationDefintion> AnimationDefinitions
    {
        get
        {
            return _animationDefinitions;
        }
        set
        {
            _animationDefinitions = value;
            _animationDefinitionsKvps = _animationDefinitions.Select(kvp => new CharacterAnimationKvp { AnimationType = kvp.Key, AnimationDefinition = kvp.Value }).ToArray();
        }
    }

    public CharacterPackageContainer()
    {
        // Much redundancy
    }

    //    // func
    //XIAHGE_API Res_Mesh*		GetMesh(int nMeshType);
    //Res_Animation* GetAnimation(int nAniType);

    //void Realize();

    //void Release(); // free memory of character data
    //void ReleaseMeshAll();
    //void ReleaseMesh(int nMeshType);
    //void ReleaseMesh(Res_Mesh* pResMesh);
    //void ReleaseAnimationAll();
    //void ReleaseAnimation(int nAniType);
    //void ReleaseAnimation(Res_Animation* pResAni)
}
