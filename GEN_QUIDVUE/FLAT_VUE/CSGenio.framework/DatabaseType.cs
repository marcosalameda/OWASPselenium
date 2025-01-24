using System;

namespace CSGenio.framework
{
	/// <summary>
	/// Database vendor
	/// </summary>
    public enum DatabaseType
	{
        ORACLE,
        SQLSERVER,
        SQLSERVERCOMPAT,
        SQLITE,
		MYSQL,
        ERRO
	}
	
	/// <summary>
    /// Primary key types
    /// </summary>
    public enum CodeType
    {
        NOT_KEY = 0,
        STRING_KEY,
        GUID_KEY,
        INT_KEY,
    };

}
