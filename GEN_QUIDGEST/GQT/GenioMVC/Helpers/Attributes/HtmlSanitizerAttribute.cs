using System;
using System.ComponentModel;
using System.Web.Mvc;

namespace GenioMVC.Helpers.Attributes
{
    /// <summary>
    /// Attribute used to mark ViewModel fields so that the value is sanitized and dangerous HTML is removed from the string to reduce the probability of XSS attacks.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class HtmlSanitizerAttribute : Attribute
    {
        /// <summary>
        /// Determines whether to sanitize the HTML document or body fragment. If enabled, even if only a fragment is given, a whole document will be returned.
        /// </summary>
        private bool IsDocument { get; set;}

        /// <summary>
        /// Sanitizes the specified HTML content
        /// </summary>
        public HtmlSanitizerAttribute() { }

        /// <summary>
        /// Sanitizes the specified HTML fragment or document
        /// </summary>
        /// <param name="isDocument">Determines whether to sanitize the HTML document or body fragment. If enabled, even if only a fragment is given, a whole document will be returned.</param>
        public HtmlSanitizerAttribute(bool isDocument) => IsDocument = isDocument;

        public void SetProperty(PropertyDescriptor propertyDescriptor, ref object value)
        {
            if (propertyDescriptor.PropertyType == typeof(string) && value != null && value is string plainText)
			{
                // In the case of using TinyMCE, the content is the full HTML of a document
                value = HtmlSanitizerHelper.SanitizeHTML(plainText, IsDocument);
            }
        }
    }
}