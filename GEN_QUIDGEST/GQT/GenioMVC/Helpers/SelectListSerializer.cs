using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web.Mvc;

namespace GenioMVC.Helpers
{
	/// <summary>
	/// Redefine serialization of list elements
	/// </summary>
	public class SelectListSerializer : JsonConverter<SelectList>
	{
		public override SelectList ReadJson(JsonReader reader, Type objectType, SelectList existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			var array = JArray.Load(reader);
			return new SelectList(array.Values<object>(), "key", "value");
		}

		public override void WriteJson(JsonWriter writer, SelectList value, JsonSerializer serializer)
		{
			var items = value?.Select(item => new { key = item.Value, value = item.Text });

			JToken t = JToken.FromObject(items);
			t.WriteTo(writer);
		}
	}

	/// <summary>
	/// The «NameValueCollection» requires its own serializer not to be serialized as if it were an array.
	/// TODO: Separate to own file or change the name of that.
	/// </summary>
	public class NameValueCollectionSerializer : JsonConverter<NameValueCollection>
	{
		public override NameValueCollection ReadJson(JsonReader reader, Type objectType, NameValueCollection existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			try
			{
				var result = new NameValueCollection();
				var jObj = JObject.Load(reader);
				var dictionary = jObj?.ToObject<Dictionary<string, string[]>>();
				if (dictionary != null)
				{
					foreach (var item in dictionary)
						foreach (var itemValue in item.Value)
							result.Add(item.Key, itemValue);
				}
				else return null;

				return result;
			}
			catch
			{
				return null;
			}
		}

		public override void WriteJson(JsonWriter writer, NameValueCollection value, JsonSerializer serializer)
		{
			var items = value?.AllKeys.ToDictionary(k => k, k => value.GetValues(k));

			JToken t = JToken.FromObject(items);
			t.WriteTo(writer);
		}
	}

	/// <summary>
	/// Stack serialization with inverted order - because the stack is a LIFO (last in-first out) collection
	/// It is needed to serialize and deserialize the list of objects in the same order.
	/// TODO: Separate to own file or change the name of that.
	/// </summary>
	public class ConcurrentStackConverter<T> : JsonConverter<ConcurrentStack<T>>
	{
		public override ConcurrentStack<T> ReadJson(JsonReader reader, Type objectType, ConcurrentStack<T> existingValue, bool hasExistingValue, JsonSerializer serializer)
		{
			try
			{
				var result = serializer.Deserialize<T[]>(reader);
				return new ConcurrentStack<T>(result ?? Enumerable.Empty<T>());
			}
			catch
			{
				return new ConcurrentStack<T>();
			}
		}

		public override void WriteJson(JsonWriter writer, ConcurrentStack<T> value, JsonSerializer serializer)
		{
			var _value = value?.Reverse<T>().ToArray<T>() ?? Enumerable.Empty<T>();
			serializer.Serialize(writer, _value);
		}
	}
}
