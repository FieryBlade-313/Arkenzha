using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeatherEffect
{

    public struct EffectsDeclaration
    {
        public EffectInfo.EffectType effectType;
        public ResourceDefinition.ResourceType targetResourceType;
        public float resourceProductionMultipler;
        public float constructionCostMultiplier;
    }

    private EffectInfo[] effects;

    public WeatherEffect(int numEffects, EffectsDeclaration[] effectsRaw)
    {
        effects = new EffectInfo[numEffects];
        for(int i=0;i<numEffects;i++)
        {
            effects[i] = ConvertDeclarationtoEffectInfo(effectsRaw[i]);
        }
    }

    private EffectInfo ConvertDeclarationtoEffectInfo(EffectsDeclaration effectsDeclaration)
    {
        switch(effectsDeclaration.effectType)
        {
            case EffectInfo.EffectType.ResourceProduction:
                {
                    return new EffectInfo(effectsDeclaration.effectType, effectsDeclaration.targetResourceType, effectsDeclaration.resourceProductionMultipler);
                }

            case EffectInfo.EffectType.ConstructionCost:
                {
                    return new EffectInfo(effectsDeclaration.effectType, effectsDeclaration.constructionCostMultiplier);
                }
        }

        return null;
    }
}
