using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceManager
{

    private int resourceTypeCount;
    private ResourceDefinition.ResourceType[] resourceName;
    private ResourceDefinition.ResourceStructure[] resource;

    public int GetResourceAmount(ResourceDefinition.ResourceType type)
    {
        return resource[(int)type].GetResourceAmount();
    }

    public int GetResourceIncrementAmount(ResourceDefinition.ResourceType type)
    {
        return resource[(int)type].GetResourceIncrementAmount();
    }

    private void SetResourceAmount(ResourceDefinition.ResourceType type, int amount)
    {
        resource[(int)type].SetResourceAmount(amount);
    }

    public void SetResourceIncrementAmount(ResourceDefinition.ResourceType type, int amount)
    {
        resource[(int)type].SetResourceIncrementAmount(amount);
    }

    private void IncreaseResourceAmount(ResourceDefinition.ResourceType type, int incAmount)
    {
        SetResourceAmount(type, GetResourceAmount(type) + incAmount);
    }

    private void InitializeResources()
    {
        foreach(ResourceDefinition.ResourceType type in resourceName)
        {
            resource[(int)type] = new ResourceDefinition.ResourceStructure(type, 0, 0);
        }
    }

    public void IncrementResourcesAmount()
    {
        foreach (ResourceDefinition.ResourceType type in resourceName)
        {
            IncreaseResourceAmount(type, GetResourceIncrementAmount(type));
        }
    }

    private void ReduceResourceAmount(ResourceDefinition.ResourceType type, int redAmount)
    {
        SetResourceAmount(type, GetResourceAmount(type) - redAmount);
    }

    public void ReduceResources(ConstructionManager.ResourceCost[] resourceCosts)
    {
        foreach(ConstructionManager.ResourceCost resourceCost in resourceCosts)
        {
            ReduceResourceAmount(resourceCost.resourceType, resourceCost.cost);
        }
    }

    public ResourceManager()
    {
        resourceName = (ResourceDefinition.ResourceType[])System.Enum.GetValues(typeof(ResourceDefinition.ResourceType));
        resourceTypeCount = resourceName.Length;
        resource = new ResourceDefinition.ResourceStructure[resourceTypeCount];
        InitializeResources();
    }
}
