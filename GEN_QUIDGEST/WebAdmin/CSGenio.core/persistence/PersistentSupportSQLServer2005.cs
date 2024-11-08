using Quidgest.Persistence.Dialects;

namespace CSGenio.persistence
{
    /// <summary>
    /// Summary description for PersistentSupportSQLServer2005.
    /// </summary>
    /// <remarks>
    /// TODO: Esta classe está vazia mas vai ser necesário por aqui algumas diferenças na construção das queries
    /// </remarks>
    public class PersistentSupportSQLServer2005 : PersistentSupportSQLServer2000
    {
        /// <summary>
        /// Contructor
        /// </summary>
        public PersistentSupportSQLServer2005() : base() 
		{ 
			Dialect = new SqlServer2005Dialect();
		}
		
    }
}
