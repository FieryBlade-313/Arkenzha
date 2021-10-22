using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectInfo
{
    public enum EffectType
    {
        ResourceProduction,
        ConstructionCost,
    }

    public struct ResourceProductionEffect
    {
        public ResourceDefinition.ResourceType targetResourceType;
        public float resourceProductionMultipler;
    }

    public struct ConstructionTimeEffect
    {
        public float constructionTimeMultiplier;
    }

    private ResourceProductionEffect resourceProductionEffect;
    private ConstructionTimeEffect constructionTimeEffect;

    public EffectInfo(EffectType type, float value)
    {
        switch (type)
        {
            case EffectType.ConstructionCost:
                {
                    constructionTimeEffect.constructionTimeMultiplier = value;
                }
                break;
        }
    }

    public EffectInfo(EffectType type, ResourceDefinition.ResourceType resourceType, float value)
    {
        switch (type)
        {
            case EffectType.ResourceProduction:
                {
                    resourceProductionEffect.resourceProductionMultipler = value;
                    resourceProductionEffect.targetResourceType = resourceType;
                }
                break;
        }
    }
}
