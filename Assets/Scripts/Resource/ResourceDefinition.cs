public static class ResourceDefinition
{
    public enum ResourceType
    {
        Food,
        Gold,
        Stone,
        Wood
    }

    public struct ResourceStructure
    {
        public ResourceDefinition.ResourceType resourceType;
        private int resourceAmount;
        private int incrementAmount;

        public ResourceStructure(ResourceDefinition.ResourceType resourceType, int resourceAmount, int incrementAmount)
        {
            this.resourceType = resourceType;
            this.resourceAmount = resourceAmount;
            this.incrementAmount = incrementAmount;

        }

        public void SetResourceAmount(int resourceAmount)
        {
            this.resourceAmount = resourceAmount;
        }

        public void SetResourceIncrementAmount(int incrementAmount)
        {
            this.incrementAmount = incrementAmount;
        }

        public int GetResourceAmount()
        {
            return resourceAmount;
        }

        public int GetResourceIncrementAmount()
        {
            return incrementAmount;
        }
    }
}
