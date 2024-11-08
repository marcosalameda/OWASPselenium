using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Serialization;

namespace GenioMVC.Models.Navigation
{
	/// <summary>
	/// Represents a level of history
	/// </summary>
	public class HistoryLevel
	{
		[JsonIgnore]
		private readonly object m_lock = new object();
		[JsonProperty]
		public string uniqueIdentifier { get; private set; }

		[JsonProperty]
		public int Level { get; private set; }

		/// <summary>
		/// The map of entries (values associated to the key)
		/// </summary>
		[JsonProperty]
		private ConcurrentDictionary<string, object> Entries { get; set; }

		/*
			TODO:
			If we are going to refactor things it would be better than we never allowed the Entries to be iterated directly.
			We should have methods to search for an entry that avoid this need.
			For example, in this case we could have a method for CheckEntryByPrefix("_filtro") that would return a list of those keys.
			This would increase isolation of the History objects and centralize control over their access.
		*/
		[JsonIgnore]
		public ICollection<string> EntriesKeys
		{
			get
			{
				return Entries?.Keys ?? new List<string>();
			}
		}

		public ReadOnlyDictionary<string, object> GetEntries()
		{
			return new ReadOnlyDictionary<string, object>(Entries);;
		}

		public ConcurrentDictionary<string, object> GetEntriesClone()
		{
			return CloneData(Entries);
		}

		/// <summary>
		/// The mode of the form for this level
		/// </summary>
		[JsonProperty]
		public FormMode FormMode { get; private set; }

		/// <summary>
		/// The location of the form for this level
		/// </summary>
		[JsonProperty]
		public NavigationLocation Location { get; private set; }

		/// <summary>
		/// Caches the human key descriptor for usage in breadcrumbs
		/// </summary>
		public string HumanRoutingDescriptionCache { get; set; }

		/// <summary>
		/// Is a nested context?
		/// </summary>
		[JsonProperty]
		public bool IsNestedContext { get; private set; }

		public HistoryLevel()
		{
			Entries = new ConcurrentDictionary<string, object>();
		}

		public HistoryLevel(NavigationLocation location, FormMode formMode, bool nestedContext = false, int level = 0) : this()
		{
			Location = location;
			FormMode = formMode;
			IsNestedContext = nestedContext;
			Entries = new ConcurrentDictionary<string, object>();
			Level = level;
		}

		/// <summary>
		/// Sets the location for this HistoryLevel
		/// </summary>
		/// <param name="location">The location of the form for this level</param>
		public void SetLocation(NavigationLocation location)
		{
			lock (m_lock)
			{
				this.Location = location;
			}
		}

		/// <summary>
		/// Sets the form mode for this HistoryLevel
		/// </summary>
		/// <param name="mode">The mode of the form for this level</param>
		public void SetMode(FormMode mode)
		{
			lock (m_lock)
			{
				this.FormMode = mode;
			}
		}

		/// <summary>
		/// Deep copy of any kind of object
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="source"></param>
		/// <returns></returns>
		/// <exception cref="ArgumentNullException"></exception>
		private T CloneData<T>(T source)
		{
			if (Object.ReferenceEquals(source, null))
				throw new ArgumentNullException("source", "Error during navigation cloning");

			var serializedData = Helpers.NavigationSerializer.Serialize(source);
			var clonedData = Helpers.NavigationSerializer.Deserialize<T>(serializedData);

			return clonedData;
		}

		/// <summary>
		/// Deep copy of the HistoryLevel object
		/// </summary>
		/// <returns>HistoryLevel</returns>
		public HistoryLevel Clone()
		{
			lock (m_lock)
			{
				return CloneData(this);
			}
		}

		/// <summary>
		/// Remove all Entries in this history level
		/// </summary>
		internal void ClearEntries()
		{
			Entries.Clear();
		}

		/// <summary>
		/// Set Entry by key
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		public void SetEntry(string key, object value)
		{
			Entries.AddOrUpdate(key, value, (k, oldValue) => value);
		}

		/// <summary>
		/// Check if Entries contains Key
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		public bool CheckEntry(string key)
		{
			return Entries != null && Entries.ContainsKey(key);
		}

		/// <summary>
		/// Get Entry by key
		/// </summary>
		/// <param name="key"></param>
		/// <returns>return null if not contains key</returns>
		public object GetEntry(string key)
		{
			if (Entries.TryGetValue(key, out object value))
				return value;
			return null;
		}

		/// <summary>
		/// Get Entry of specific type by key
		/// </summary>
		/// <param name="key"></param>
		/// <returns>return null if not contains key</returns>
		public T GetEntry<T>(string key)
		{
			object hValue = GetEntry(key);

			if (hValue is Newtonsoft.Json.Linq.JObject jObjValue)
			{
				// The «NameValueCollection» needs a special conversion from the JObject.
				if (typeof(T) == typeof(System.Collections.Specialized.NameValueCollection))
				{
					try
					{
						var result = new System.Collections.Specialized.NameValueCollection();
						var jObj = jObjValue.ToObject<Dictionary<string, string[]>>();

						foreach (var item in jObj)
							foreach (var itemValue in item.Value)
								result.Add(item.Key, itemValue);

						return (T)(result as object);
					}
					catch
					{
						return (T)(null as object);
					}
				}

				return jObjValue.ToObject<T>();
			}
			else if (hValue is Newtonsoft.Json.Linq.JToken jTokenValue)
				return jTokenValue.ToObject<T>();
			// Just to avoid cast errors if there is a case where the correct type of value was not provided
			else if (hValue?.GetType() == typeof(object[]) && typeof(T) != typeof(object[]) && typeof(T).IsArray)
				return Newtonsoft.Json.Linq.JToken.FromObject(hValue).ToObject<T>();

			return (T)hValue;
		}

		/// <summary>
		/// Remove Entry by key
		/// </summary>
		/// <param name="key"></param>
		public void RemoveEntry(string key)
		{
			lock(m_lock)
			{
				Entries.TryRemove(key, out object value);
			}
		}

		/// <summary>
		/// Replace entries
		/// </summary>
		/// <param name="key"></param>
		/// <param name="value"></param>
		public void ReplaceEntries(IDictionary<string, object> newEntries)
		{
			lock (m_lock)
			{
				Entries = new ConcurrentDictionary<string, object>(newEntries);
			}
		}

		/// <summary>
		/// MH (06-11-2015) - To que for possivel usar fields das tables nos titulos,
		/// apareceu necesidade de change também o string do menu de navegação.
		/// </summary>
		/// <param name="name"></param>
		public void redefineLocName(string name)
		{
			lock (m_lock)
			{
				this.Location = this.Location.redefineName(name);
			}
		}
	}
}
