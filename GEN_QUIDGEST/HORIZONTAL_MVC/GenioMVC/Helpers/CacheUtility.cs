using System;
using System.Web.Caching;
using System.Web.Security;

namespace GenioMVC.Helpers
{
    [Obsolete("Use QCache instead")]
	public class CacheUtility
	{
		public static void Add(Cache cache, string key, object value)
		{
			cache.Insert(
				key,
				value,
				null,
				System.Web.Caching.Cache.NoAbsoluteExpiration,
				FormsAuthentication.Timeout,
				System.Web.Caching.CacheItemPriority.Default,
				null);
		}

		public static void Remove(Cache cache, string key)
		{
			cache.Remove(key);
		}

		public static object Get(Cache cache, string key)
		{
			return cache.Get(key);
		}
	}
}
