namespace RESTGenio;


    /// <summary>
    /// Enumerated values of Actividade
	///
	/// When used in LogicalCondition wrap it in a EnumValue
    /// </summary>
    public enum ArrayActividade
    {
        /// <summary>
        /// Active
        /// </summary>
        V1,
        /// <summary>
        /// Inactivo
        /// </summary>
        V0
    }

    /// <summary>
    /// Enumerated values of ArticleTypes
    /// </summary>
    public enum ArrayArticleTypes
    {
        /// <summary>
        /// Very mobile
        /// </summary>
        B,
        /// <summary>
        /// Vehicle
        /// </summary>
        V,
        /// <summary>
        /// Property
        /// </summary>
        I
    }

    /// <summary>
    /// Enumerated values of Availability
    /// </summary>
    public enum ArrayAvailability
    {
        /// <summary>
        /// Disponível
        /// </summary>
        A,
        /// <summary>
        /// Descontinuado
        /// </summary>
        D,
        /// <summary>
        /// Sem existências
        /// </summary>
        O
    }

public static class RESTArrays
{
    //------------------------
	// Actividade
	//------------------------
    private static readonly Dictionary<string, ArrayActividade?> ArrayActividadeMapById = new() {
        { "1", ArrayActividade.V1 },
        { "0", ArrayActividade.V0 },
	};		
    public static ArrayActividade? GetArrayActividadeValueById(string id) => ArrayActividadeMapById.TryGetValue(id, out var value) ? value : null;
        
	private static readonly string[] m_actividadeMapByValue = new string[] { "1", "0" };
	public static string GetArrayActividadeIdByValue(ArrayActividade? value) => value is null ? "" : m_actividadeMapByValue[(int)value];

    //------------------------
	// ArticleTypes
	//------------------------
    private static readonly Dictionary<string, ArrayArticleTypes?> ArrayArticleTypesMapById = new() {
        { "B", ArrayArticleTypes.B },
        { "V", ArrayArticleTypes.V },
        { "I", ArrayArticleTypes.I },
	};		
    public static ArrayArticleTypes? GetArrayArticleTypesValueById(string id) => ArrayArticleTypesMapById.TryGetValue(id, out var value) ? value : null;
        
	private static readonly string[] m_articletypesMapByValue = new string[] { "B", "V", "I" };
	public static string GetArrayArticleTypesIdByValue(ArrayArticleTypes? value) => value is null ? "" : m_articletypesMapByValue[(int)value];

    //------------------------
	// Availability
	//------------------------
    private static readonly Dictionary<string, ArrayAvailability?> ArrayAvailabilityMapById = new() {
        { "A", ArrayAvailability.A },
        { "D", ArrayAvailability.D },
        { "O", ArrayAvailability.O },
	};		
    public static ArrayAvailability? GetArrayAvailabilityValueById(string id) => ArrayAvailabilityMapById.TryGetValue(id, out var value) ? value : null;
        
	private static readonly string[] m_availabilityMapByValue = new string[] { "A", "D", "O" };
	public static string GetArrayAvailabilityIdByValue(ArrayAvailability? value) => value is null ? "" : m_availabilityMapByValue[(int)value];

}