using UnityEngine;

public class ConstructionManager
{

    private ResourceDefinition.ResourceType[] resourceName;
    public struct ResourceCost
    {
        public ResourceDefinition.ResourceType resourceType;
        public int cost;
    }

    public ResourceCost[] GetConstructionCost(TileDefinition.TileStructure tile)
    {
        ResourceCost[] resourceCosts = new ResourceCost[resourceName.Length];

        int cost = 1 << tile.tileLevel - 1;
        
        int i = 0;

        foreach( ResourceDefinition.ResourceType type in resourceName )
        {
            resourceCosts[i++] = new ResourceCost() { resourceType = type, cost = cost };
        }

        return resourceCosts;
    }

    private bool canConstruct(ResourceCost[] resourceCosts, ResourceManager resourceManager)
    {
        foreach(ResourceCost resourceCost in resourceCosts)
        {
            if (resourceManager.GetResourceAmount(resourceCost.resourceType) < resourceCost.cost)
                return false;
        }
        return true;
    }

    public void Construct(TileDefinition.TileStructure tile, ResourceManager resourceManager)
    {
        ResourceCost[] resourceCosts = GetConstructionCost(tile);
        
        if(canConstruct(resourceCosts, resourceManager))
        {
            resourceManager.ReduceResources(resourceCosts);
        }
    }

    public ConstructionManager()
    {
        resourceName = resourceName = (ResourceDefinition.ResourceType[])System.Enum.GetValues(typeof(ResourceDefinition.ResourceType));
    }
}
