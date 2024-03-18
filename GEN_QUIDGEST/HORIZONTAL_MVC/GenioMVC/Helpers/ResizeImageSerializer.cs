using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Web;

namespace GenioMVC.Helpers
{
	/// <summary>
	/// Allows the resize of the serialized image
	/// </summary>
	public class ResizeImageSerializer : JsonConverter
	{
		private int _width;
		private int _height;
		private bool _resizeImage;
		private bool _useEmptyImage;
		private bool _maintainRatio;

		public ResizeImageSerializer()
		{
			_resizeImage = false;
			_useEmptyImage = false;
			_maintainRatio = false;
		}

		public ResizeImageSerializer(bool useEmptyImage)
		{
			_resizeImage = false;
			_useEmptyImage = useEmptyImage;
			_maintainRatio = false;
		}

		public ResizeImageSerializer(int width, int height)
		{
			_width = width;
			_height = height;
			_resizeImage = true;
			_useEmptyImage = false;
			_maintainRatio = false;
		}

		public ResizeImageSerializer(int width, int height, bool useEmptyImage)
		{
			_width = width;
			_height = height;
			_resizeImage = true;
			_useEmptyImage = useEmptyImage;
			_maintainRatio = false;
		}

		public ResizeImageSerializer(int width, int height, bool useEmptyImage, bool maintainRatio)
		{
			_width = width;
			_height = height;
			_resizeImage = true;
			_useEmptyImage = useEmptyImage;
			_maintainRatio = maintainRatio;
		}

		public ResizeImageSerializer(int width, int height, bool useEmptyImage, bool maintainRatio, bool resizeImage)
		{
			_width = width;
			_height = height;
			_resizeImage = resizeImage;
			_useEmptyImage = useEmptyImage;
			_maintainRatio = maintainRatio;
		}

		// If the image is an svg or gif, doesn't resize it. Otherwise, the svg won't work and the gif will be a static image.
		private static readonly string[] notResizableImageFormats = { "unknown", "xml", "svg+xml", "gif" };
		private string GetImageFormat(byte[] img)
		{
			var imageFormat = "unknown";

			if (img == null || img.Length == 0)
				return imageFormat;

			// Convert the byte array to a string.
			string fileContent = Encoding.UTF8.GetString(img);

			// SVG is a subset of XML, must be checked first.
			if (IsValidSvg(fileContent))
				imageFormat = "svg+xml";
			// Not an SVG, check if it is regular XML.
			else if (IsValidXml(fileContent))
				imageFormat = "xml";
			// Everything else.
			else
			{
				using (var ms = new System.IO.MemoryStream(img))
				{
					try
					{
						using (System.Drawing.Image image = System.Drawing.Image.FromStream(ms))
						{
							if (ImageFormat.Jpeg.Equals(image.RawFormat))
								imageFormat = "jpeg";
							else if (ImageFormat.Png.Equals(image.RawFormat))
								imageFormat = "png";
							else if (ImageFormat.Gif.Equals(image.RawFormat))
								imageFormat = "gif";
							else if (ImageFormat.Icon.Equals(image.RawFormat))
								imageFormat = "ico";
							else if (ImageFormat.Bmp.Equals(image.RawFormat))
								imageFormat = "bmp";
						}
					}
					catch
					{
						// For other formats (for example: ".webp").
						return imageFormat;
					}
				}
			}

			return imageFormat;
		}

		private static bool IsValidXml(string xmlContent)
		{
			return xmlContent.StartsWith("<?xml");
		}

		private bool IsValidSvg(string svgContent)
		{
			// Check if the content contains the SVG root element and namespace.
			bool containsSvgRootElement = svgContent.Contains("<svg");
			bool containsSvgNamespace = svgContent.Contains("http://www.w3.org/2000/svg");

			// Check if the file content indicates SVG.
			return containsSvgRootElement && containsSvgNamespace;
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			byte[] image = (byte[]) value;

			if (_useEmptyImage && (image == null || image.Length == 0))
			{
				var path = HttpContext.Current.Server.MapPath("~/Content/img/no_img.png");
				if (!System.IO.File.Exists(path))
					path = HttpContext.Current.Server.MapPath("~/ClientApp/dist/Content/img/no_img.png");

				if (System.IO.File.Exists(path))
					image = System.IO.File.ReadAllBytes(path);
			}

			var imageFormat = GetImageFormat(image);

			if (_resizeImage)
			{
				// Resize image
				if (image != null && image.Length > 0 && _width > 0 && _height > 0)
				{
					// If the image is an svg or gif, doesn't resize it. Otherwise, the svg won't work and the gif will be a static image.
					// We should think on replacing the below "if" by a thumbnail on the database.

					if (!notResizableImageFormats.Contains(imageFormat))
					{
						using (var ms = new System.IO.MemoryStream(image))
						{
							using (System.Drawing.Image _Image = System.Drawing.Image.FromStream(ms))
							{
								int scaledWidth = _width;
								int scaledHeight = _height;
								if (_maintainRatio)
								{
									decimal scale = Math.Min((decimal) _width / _Image.Width, (decimal) _height / _Image.Height);
									scaledWidth = (int) (_Image.Width * scale);
									scaledHeight = (int) (_Image.Height * scale);
								}

								using (System.Drawing.Image _ResizedImage = new System.Drawing.Bitmap(_Image, new System.Drawing.Size(scaledWidth, scaledHeight)))
								{
									image = (byte[]) new System.Drawing.ImageConverter().ConvertTo(_ResizedImage, typeof(byte[]));
								}
							}
						}
					}
				}
			}

			JToken t = JToken.FromObject(new { data = image ?? new byte[0], encoding = "base64", dataFormat = imageFormat });
			t.WriteTo(writer);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			byte[] _value = reader.ReadAsBytes();
			return _value;
		}

		public override bool CanConvert(Type objectType)
		{
			return typeof(byte[]).IsAssignableFrom(objectType);
		}
	}
}
