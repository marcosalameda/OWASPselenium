namespace CSGenio.core.persistence
{
    
    public interface IVersionReader
    {
        double GetDbVersion();

        double GetDbIndexVersion();

        int GetDbUpgradeVersion();
    }
}
    