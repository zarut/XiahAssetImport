using System;
using UnityEngine;

[Serializable]
public class CharacterAnimationKvp
{
    [SerializeField]
    private Int32 animationType;
    [SerializeField]
    private CharacterAnimationDefintion animationDefinition;

    public Int32 AnimationType
    {
        get { return animationType; }
        set { animationType = value; }
    }
    
    public CharacterAnimationDefintion AnimationDefinition
    {
        get { return animationDefinition; }
        set { animationDefinition = value; }
    }

}
