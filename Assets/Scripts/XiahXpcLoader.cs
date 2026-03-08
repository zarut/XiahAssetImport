using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class XiahXpcLoader //: MonoBehaviour
{
    //// Reference mem buffer from source
    //private const int MAX_FILE_MEM_BUFFER = (3 * 1024 * 1024);		// 2 Mega byte => Max size of BCF
    
    //[SerializeField]
    //private string PackageFile;
    //[SerializeField]
    //private CharacterPackageContainer[] ImportedContainers;

    //// Use this for initialization
    //private void Start()
    //{
    //    this.ImportedContainers = LoadXiahCharacterPackage();

    //    Debug.LogFormat("Imported containers count: {0}", this.ImportedContainers.Length);
    //}

    // Update is called once per frame
    private void Update()
    {

    }

    public CharacterPackageContainer[] LoadXiahCharacterPackage(string packageFileAssetsPath)
    {
        //if (this.PackageFile == null)
        //{
        //    return new CharacterPackageContainer[0];
        //}

        if (packageFileAssetsPath == null)
        {
            Debug.LogError("Package file assets path is null");
            return new CharacterPackageContainer[0];
        }

        //foreach (string packageFile in this.PackageFiles)
        //{
        //    // TODO: construct this with unity's paths
        //    string fullPackageFilePath = null;

        //    CharacterPackageContainer characterPackageContainer = this.LoadXiahCharacterPack(fullPackageFilePath);
        //}

        string fullPackageFilePath = Path.Combine(Application.dataPath, packageFileAssetsPath);

        CharacterPackageContainer[] characterPackageContainers = this.LoadXiahCharacterPack(fullPackageFilePath);

        return characterPackageContainers;
    }

    private CharacterPackageContainer[] LoadXiahCharacterPack(string fullPackageFilePath)
    {
        List<CharacterPackageContainer> characterPackageContainers = null;
        BinaryReader br = null;

        //try
        //{
        FileStream fs = new FileStream(fullPackageFilePath, FileMode.Open, FileAccess.Read);

        using (br = new BinaryReader(fs))
        {
            characterPackageContainers = new List<CharacterPackageContainer>();

            // Loading logic here
            Int32 characterCount = br.ReadInt32();

            Debug.LogFormat("Character count: {0}", characterCount);

            for (Int32 i = 0; i < characterCount; i++)
            {
                CharacterPackageContainer characterPackageContainer = new CharacterPackageContainer();

                characterPackageContainer.CharacterId = br.ReadInt32();
                characterPackageContainer.MeshDefinitionsCount = br.ReadUInt16();
                characterPackageContainer.AnimationDefinitionsCount = br.ReadUInt16();

                //Debug.LogFormat("Mesh count: {0}", characterPackageContainer.MeshDefinitionsCount);
                //Debug.LogFormat("Animation count: {0}", characterPackageContainer.AnimationDefinitionsCount);

                //Dictionary<Int32, CharacterMeshDefinition> characterMeshDefinitions = this.ReadMeshDefinitions(br, characterPackageContainer.MeshDefinitionsCount);
                //Dictionary<Int32, CharacterAnimationDefintion> characterAnimationDefintions = this.ReadAnimationDefinitions(br, characterPackageContainer.AnimationDefinitionsCount);

                CharacterMeshKvp[] characterMeshDefinitions = this.ReadMeshDefinitions(br, characterPackageContainer.MeshDefinitionsCount);
                CharacterAnimationKvp[] characterAnimationDefintions = this.ReadAnimationDefinitions(br, characterPackageContainer.AnimationDefinitionsCount);

                //characterPackageContainer.MeshDefinitions = characterMeshDefinitions;
                //characterPackageContainer.AnimationDefinitions = characterAnimationDefintions;

                characterPackageContainer.MeshDefinitionsKvps = characterMeshDefinitions;
                characterPackageContainer.AnimationDefinitionsKvps = characterAnimationDefintions;
                
                characterPackageContainers.Add(characterPackageContainer);
            }
        }

        fs = new FileStream(fullPackageFilePath, FileMode.Open, FileAccess.Read);

        using (br = new BinaryReader(fs))
        {
            foreach (CharacterPackageContainer characterPackageContainer in characterPackageContainers)
            {
                this.LoadMesh(fs, br, characterPackageContainer);
            }
        }
    
        //}
        //catch (Exception ex)
        //{
        //    Debug.LogError(ex);
        //}
        //finally
        //{
        //    if (br != null)
        //    {
        //        br.Close();
        //    }
        //}

        if (characterPackageContainers == null)
        {
            return null;
        }

        CharacterPackageContainer[] characterPackageContainersArray = characterPackageContainers.ToArray();

        return characterPackageContainersArray;
    }

    private CharacterMeshKvp[] ReadMeshDefinitions(BinaryReader binaryReader, UInt16 meshDefinitionsCount)
    {
        //Dictionary<Int32, CharacterMeshDefinition> meshDefinitions = new Dictionary<Int32, CharacterMeshDefinition>();
        List<CharacterMeshKvp> characterMeshKvps = new List<CharacterMeshKvp>();

        for (UInt16 i = 0; i < meshDefinitionsCount; i++)
        {
            CharacterMeshDefinition characterMeshDefinition = this.ReadMeshDefinition(binaryReader);
            //meshDefinitions.Add(characterMeshDefinition.MeshType, characterMeshDefinition);
            characterMeshKvps.Add(new CharacterMeshKvp { MeshType = characterMeshDefinition.MeshType, MeshDefinition = characterMeshDefinition });
        }

        //return meshDefinitions;
        return characterMeshKvps.ToArray();
    }

    private CharacterMeshDefinition ReadMeshDefinition(BinaryReader binaryReader)
    {
        CharacterMeshDefinition characterMeshDefinition = new CharacterMeshDefinition();
        characterMeshDefinition.MeshType = binaryReader.ReadUInt16();
        characterMeshDefinition.CharacterTextureCount = binaryReader.ReadUInt16();

        characterMeshDefinition.CharacterTextures = this.ReadCharacterTextureDefinitions(binaryReader, characterMeshDefinition.CharacterTextureCount);

        characterMeshDefinition.MeshSize[0] = binaryReader.ReadUInt16();
        characterMeshDefinition.MeshSize[1] = binaryReader.ReadUInt16();
        characterMeshDefinition.MeshSize[2] = binaryReader.ReadUInt16();

        characterMeshDefinition.LogicalBoneIndiciesCount = binaryReader.ReadUInt16();

        if (characterMeshDefinition.LogicalBoneIndiciesCount > 0)
        {
            characterMeshDefinition.LogicalBoneIndicies = new UInt16[characterMeshDefinition.LogicalBoneIndiciesCount];

            for (UInt16 i = 0; i < characterMeshDefinition.LogicalBoneIndiciesCount; i++)
            {
                characterMeshDefinition.LogicalBoneIndicies[i] = binaryReader.ReadUInt16();
            }
        }

        characterMeshDefinition.CharacterAnimationEffectsCount = binaryReader.ReadUInt16();

        if (characterMeshDefinition.CharacterAnimationEffectsCount > 0)
        {
            characterMeshDefinition.CharacterAnimationEffectsSize = binaryReader.ReadUInt32();
            characterMeshDefinition.CharacterAnimationEffects = this.ReadCharacterAnimationEffects(binaryReader, characterMeshDefinition.CharacterAnimationEffectsCount);
        }

        characterMeshDefinition.CharacterSkinnedMeshesCount = binaryReader.ReadUInt16();
        characterMeshDefinition.SkinMeshFileOffset = binaryReader.ReadUInt32();
        characterMeshDefinition.SkeletonFileOffset = binaryReader.ReadUInt32();

        return characterMeshDefinition;
    }

    private CharacterTextureDefinition[] ReadCharacterTextureDefinitions(BinaryReader binaryReader, UInt16 texturesCount)
    {
        CharacterTextureDefinition[] characterTextures = new CharacterTextureDefinition[texturesCount];

        for (UInt16 i = 0; i < texturesCount; i++)
        {
            characterTextures[i] = this.ReadCharacterTextureDefinition(binaryReader);
        }

        return characterTextures;
    }

    private CharacterTextureDefinition ReadCharacterTextureDefinition(BinaryReader binaryReader)
    {
        CharacterTextureDefinition characterTextureDefinition = new CharacterTextureDefinition();
        characterTextureDefinition.TextureType = binaryReader.ReadUInt16();
        characterTextureDefinition.SubTextureCount = binaryReader.ReadUInt16();
        characterTextureDefinition.CharacterSubTextureDefinitions = this.ReadCharacterSubTextureDefinitions(binaryReader, characterTextureDefinition.SubTextureCount);

        return characterTextureDefinition;
    }

    private CharacterSubTextureDefinition[] ReadCharacterSubTextureDefinitions(BinaryReader binaryReader, UInt16 subTexturesCount)
    {
        CharacterSubTextureDefinition[] characterSubTextures = new CharacterSubTextureDefinition[subTexturesCount];

        for (UInt16 i = 0; i < subTexturesCount; i++)
        {
            characterSubTextures[i] = this.ReadCharacterSubTextureDefinition(binaryReader);
        }

        return characterSubTextures;
    }

    private CharacterSubTextureDefinition ReadCharacterSubTextureDefinition(BinaryReader binaryReader)
    {
        CharacterSubTextureDefinition characterSubTextureDefinition = new CharacterSubTextureDefinition();
        characterSubTextureDefinition.TextureId = binaryReader.ReadInt32();
        characterSubTextureDefinition.IsAlpha = binaryReader.ReadByte();
        characterSubTextureDefinition.CullingMode = binaryReader.ReadByte();

        return characterSubTextureDefinition;
    }

    private CharacterAnimationEffect[] ReadCharacterAnimationEffects(BinaryReader binaryReader, UInt16 animationEffectsCount)
    {
        CharacterAnimationEffect[] characterAnimationEffects = new CharacterAnimationEffect[animationEffectsCount];

        for (UInt16 i = 0; i < animationEffectsCount; i++)
        {
            characterAnimationEffects[i] = this.ReadCharacterAnimationEffect(binaryReader);
        }

        return characterAnimationEffects;
    }

    private CharacterAnimationEffect ReadCharacterAnimationEffect(BinaryReader binaryReader)
    {
        CharacterAnimationEffect characterAnimationEffect = new CharacterAnimationEffect();

        characterAnimationEffect.nEffectID = binaryReader.ReadInt32();
        characterAnimationEffect.nPosX = binaryReader.ReadSByte();
        characterAnimationEffect.nPosY = binaryReader.ReadSByte();
        characterAnimationEffect.nPosZ = binaryReader.ReadSByte();
        characterAnimationEffect.nBoneIndex = binaryReader.ReadSByte();
        characterAnimationEffect.nStartTime = binaryReader.ReadUInt16();

        return characterAnimationEffect;
    }

    private CharacterAnimationKvp[] ReadAnimationDefinitions(BinaryReader binaryReader, UInt16 animationDefinitionsCount)
    {
        //Dictionary<Int32, CharacterAnimationDefintion> animationDefinitions = new Dictionary<Int32, CharacterAnimationDefintion>();
        List<CharacterAnimationKvp> characterAnimationKvps = new List<CharacterAnimationKvp>();

        for (UInt16 i = 0; i < animationDefinitionsCount; i++)
        {
            CharacterAnimationDefintion characterAnimationDefinition = this.ReadAnimationDefinition(binaryReader);
            Debug.LogFormat("Animation Type: {0}", characterAnimationDefinition.AnimationType);
            //animationDefinitions.Add(characterAnimationDefinition.AnimationType, characterAnimationDefinition);
            characterAnimationKvps.Add(new CharacterAnimationKvp { AnimationType = characterAnimationDefinition.AnimationType, AnimationDefinition = characterAnimationDefinition });
        }

        //return animationDefinitions;
        return characterAnimationKvps.ToArray();
    }

    private CharacterAnimationDefintion ReadAnimationDefinition(BinaryReader binaryReader)
    {
        CharacterAnimationDefintion characterAnimationDefinition = new CharacterAnimationDefintion();

        characterAnimationDefinition.AnimationType = binaryReader.ReadUInt16();
        characterAnimationDefinition.EffectCount = binaryReader.ReadUInt16();

        if (characterAnimationDefinition.EffectCount > 0)
        {
            characterAnimationDefinition.EffectDataSize = binaryReader.ReadUInt32();
            characterAnimationDefinition.EffectCharacterId = binaryReader.ReadInt32();

            characterAnimationDefinition.Effects = this.ReadCharacterAnimationEffects(binaryReader, characterAnimationDefinition.EffectCount);
        }

        characterAnimationDefinition.SoundsCount = binaryReader.ReadUInt16();

        if (characterAnimationDefinition.SoundsCount > 0)
        {
            characterAnimationDefinition.SoundsDataSize = binaryReader.ReadUInt32();
            characterAnimationDefinition.Sounds = this.ReadAnimationSounds(binaryReader, characterAnimationDefinition.SoundsCount);
        }

        characterAnimationDefinition.TimerTriggersCount = binaryReader.ReadUInt16();

        if (characterAnimationDefinition.TimerTriggersCount > 0)
        {
            characterAnimationDefinition.TimerTriggersDataSize = binaryReader.ReadUInt32();
            characterAnimationDefinition.TimerTriggers = this.ReadTimerTriggers(binaryReader, characterAnimationDefinition.TimerTriggersCount);
        }

        characterAnimationDefinition.AnimationFileOffset = binaryReader.ReadUInt32();

        return characterAnimationDefinition;
    }

    private CharacterAnimationSound[] ReadAnimationSounds(BinaryReader binaryReader, UInt16 soundsCount)
    {
        CharacterAnimationSound[] sounds = new CharacterAnimationSound[soundsCount];

        for (UInt16 i = 0; i < soundsCount; i++)
        {
            CharacterAnimationSound sound = this.ReadAnimationSound(binaryReader);
            sounds[i] = sound;
        }

        return sounds;
    }

    private CharacterAnimationSound ReadAnimationSound(BinaryReader binaryReader)
    {
        CharacterAnimationSound sound = new CharacterAnimationSound();

        sound.nSoundID = binaryReader.ReadInt32();
        sound.nEffectDBID = binaryReader.ReadInt32();

        return sound;
    }

    private CharacterTimerTrigger[] ReadTimerTriggers(BinaryReader binaryReader, UInt16 triggersCount)
    {
        CharacterTimerTrigger[] timerTriggers = new CharacterTimerTrigger[triggersCount];

        for (UInt16 i = 0; i < triggersCount; i++)
        {
            CharacterTimerTrigger timerTrigger = this.ReadTimerTrigger(binaryReader);
            timerTriggers[i] = timerTrigger;
        }

        return timerTriggers;
    }

    private CharacterTimerTrigger ReadTimerTrigger(BinaryReader binaryReader)
    {
        CharacterTimerTrigger timerTrigger = new CharacterTimerTrigger();

        timerTrigger.nType = binaryReader.ReadUInt16();
        timerTrigger.nStartTime = binaryReader.ReadUInt16();
        timerTrigger.nLength = binaryReader.ReadUInt16();

        return timerTrigger;
    }

    private void LoadMesh(FileStream fileStream, BinaryReader binaryReader, CharacterPackageContainer characterPackageContainer)
    {
        foreach (CharacterMeshKvp meshKvp in characterPackageContainer.MeshDefinitionsKvps)
        {
            CharacterMeshDefinition meshDefinition = meshKvp.MeshDefinition;
            fileStream.Seek(meshDefinition.SkinMeshFileOffset, SeekOrigin.Begin);

            meshDefinition.CharacterSkinnedMeshes = this.ReadSkinnedMeshes(fileStream, binaryReader, meshDefinition.CharacterSkinnedMeshesCount);
        }
    }

    private CharacterSkinnedMesh[] ReadSkinnedMeshes(FileStream fileStream, BinaryReader binaryReader, UInt16 skinnedMeshesCount)
    {
        CharacterSkinnedMesh[] skinnedMeshes = new CharacterSkinnedMesh[skinnedMeshesCount];

        for (UInt16 i = 0; i < skinnedMeshesCount; i++)
        {
            // Save the index of the position before skin mesh data was read, then use it to seek afterwards using data size
            long currentSkinnedMeshStartPosition = fileStream.Position;

            CharacterSkinnedMesh skinnedMesh = this.ReadSkinnedMesh(fileStream, binaryReader);
            skinnedMeshes[i] = skinnedMesh;

            // Next mesh offset is after the start of the current mesh, plus bytes read for the data size property, plus bytes read for the actual data size
            long nextSkinnedMeshOffset = currentSkinnedMeshStartPosition + sizeof(UInt32) + skinnedMesh.SkinMeshDataSize;

            fileStream.Seek(nextSkinnedMeshOffset, SeekOrigin.Begin);
        }

        return skinnedMeshes;
    }

    private CharacterSkinnedMesh ReadSkinnedMesh(FileStream fileStream, BinaryReader binaryReader)
    {
        CharacterSkinnedMesh characterSkinnedMesh = new CharacterSkinnedMesh();

        characterSkinnedMesh.SkinMeshDataSize = binaryReader.ReadUInt32();
        characterSkinnedMesh.IsPhysicMesh = binaryReader.ReadByte();
        characterSkinnedMesh.VertexCount = binaryReader.ReadUInt16();
        characterSkinnedMesh.FacesCount = binaryReader.ReadUInt16();

        bool isPhysicMesh = characterSkinnedMesh.IsPhysicMesh > 0;

        if (isPhysicMesh)
        {
            characterSkinnedMesh.SkinMeshVertices = new XiahSkinMeshVertex[characterSkinnedMesh.VertexCount];
        }
        else
        {
            characterSkinnedMesh.NormalVertices = new XiahVTNormal[characterSkinnedMesh.VertexCount];
        }

        for (UInt16 i = 0; i < characterSkinnedMesh.VertexCount; i++)
        {
            if (isPhysicMesh)
            {
                characterSkinnedMesh.SkinMeshVertices[i] = this.ReadSkinMeshVertex(binaryReader);
            }
            else
            {
                characterSkinnedMesh.NormalVertices[i] = this.ReadVTNormal(binaryReader);
            }
        }

        // According to source..
        int actualFaceCount = 3 * characterSkinnedMesh.FacesCount;
        characterSkinnedMesh.Faces = new UInt16[actualFaceCount];

        for (UInt16 i = 0; i < actualFaceCount; i++)
        {
            characterSkinnedMesh.Faces[i] = binaryReader.ReadUInt16();
        }

        return characterSkinnedMesh;
    }

    private XiahSkinMeshVertex ReadSkinMeshVertex(BinaryReader binaryReader)
    {
        XiahSkinMeshVertex xiahSkinMeshVertex = new XiahSkinMeshVertex();

        for (int i = 0; i < XiahSkinMeshVertex.PositionArraySize; i++)
        {
            xiahSkinMeshVertex.Position[i] = binaryReader.ReadSingle();
        }

        for (int i = 0; i < XiahSkinMeshVertex.WeightArraySize; i++)
        {
            xiahSkinMeshVertex.Weight[i] = binaryReader.ReadSingle();
        }

        xiahSkinMeshVertex.indices = binaryReader.ReadUInt32();

        for (int i = 0; i < XiahSkinMeshVertex.NormalArraySize; i++)
        {
            xiahSkinMeshVertex.Normal[i] = binaryReader.ReadSingle();
        }

        for (int i = 0; i < XiahSkinMeshVertex.TextureArraySize; i++)
        {
            xiahSkinMeshVertex.Texture[i] = binaryReader.ReadSingle();
        }

        return xiahSkinMeshVertex;
    }

    private XiahVTNormal ReadVTNormal(BinaryReader binaryReader)
    {
        XiahVTNormal xiahVTNormal = new XiahVTNormal();
        
        float positionX = binaryReader.ReadSingle();
        float positionY = binaryReader.ReadSingle();
        float positionZ = binaryReader.ReadSingle();

        xiahVTNormal.Position = new Vector3(positionX, positionY, positionZ);

        float normalX = binaryReader.ReadSingle();
        float normalY = binaryReader.ReadSingle();
        float normalZ = binaryReader.ReadSingle();

        xiahVTNormal.Normal = new Vector3(normalX, normalY, normalZ);

        float textureX = binaryReader.ReadSingle();
        float textureY = binaryReader.ReadSingle();

        xiahVTNormal.Texture = new Vector2(textureX, textureY);

        return xiahVTNormal;
    }
}
