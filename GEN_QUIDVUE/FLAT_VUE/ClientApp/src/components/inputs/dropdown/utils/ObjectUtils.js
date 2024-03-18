export default class ObjectUtils
{
	static equals(obj1, obj2, field)
	{
		if (field)
			return this.resolveFieldData(obj1, field) === this.resolveFieldData(obj2, field);
		return this.deepEquals(obj1, obj2);
	}

	static deepEquals(a, b)
	{
		if (a === b)
			return true;

		if (a && b && typeof a === 'object' && typeof b === 'object')
		{
			let arrA = Array.isArray(a),
				arrB = Array.isArray(b),
				length,
				key;

			if (arrA && arrB)
			{
				length = a.length;
				if (length !== b.length)
					return false;

				for (let i = length; i-- !== 0;)
					if (!this.deepEquals(a[i], b[i]))
						return false;
				return true;
			}

			if (arrA !== arrB)
				return false;

			let dateA = a instanceof Date,
				dateB = b instanceof Date;

			if (dateA !== dateB)
				return false;
			if (dateA && dateB)
				return a.getTime() === b.getTime();

			let regexpA = a instanceof RegExp,
				regexpB = b instanceof RegExp;

			if (regexpA !== regexpB)
				return false;
			if (regexpA && regexpB)
				return a.toString() === b.toString();

			let keys = Object.keys(a);
			length = keys.length;

			if (length !== Object.keys(b).length)
				return false;

			for (let i = length; i-- !== 0;)
				if (!Object.prototype.hasOwnProperty.call(b, keys[i]))
					return false;

			for (let i = length; i-- !== 0;)
			{
				key = keys[i];
				if (!this.deepEquals(a[key], b[key]))
					return false;
			}

			return true;
		}

		return false;
	}

	static resolveFieldData(data, field)
	{
		if (data && field)
		{
			if (field.indexOf('.') === -1)
				return data[field];
			else
			{
				let fields = field.split('.');
				let value = data;
				for (let i = 0, len = fields.length; i < len; ++i)
					value = value[fields[i]];
				return value;
			}
		}
		else
			return null;
	}
}