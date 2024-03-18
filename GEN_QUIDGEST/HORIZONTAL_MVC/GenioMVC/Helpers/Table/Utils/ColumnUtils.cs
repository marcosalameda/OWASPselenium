using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

using GenioMVC.Helpers.Table.Columns;

namespace GenioMVC.Helpers.Table.Utils
{
    public static class ColumnUtils
    {
        #region Builder
        
        private static Type GetTypeFromMemberInfo<TMember>(MemberInfo member, Func<TMember, Type> func) where TMember : MemberInfo
        {
            if (member is TMember)
            {
                return func((TMember)member);
            }
            return null;
        }

        public static Type GetTypeFromMemberExpression(MemberExpression memberExpression)
        {
            if (memberExpression == null) return null;

            var dataType = GetTypeFromMemberInfo(memberExpression.Member, (PropertyInfo p) => p.PropertyType);
            if (dataType == null) dataType = GetTypeFromMemberInfo(memberExpression.Member, (MethodInfo m) => m.ReturnType);
            if (dataType == null) dataType = GetTypeFromMemberInfo(memberExpression.Member, (FieldInfo f) => f.FieldType);

            return dataType;
        }

        #endregion



        public static string CalculateColumnWidth(int columnSize, int tableSize)
        {
            return (((double)columnSize / (double)tableSize) * 100.0).ToString().Replace(",", ".");
        }

        public static string GetCellStyle<TModel>(ITableColumnInternal<TModel> tc) where TModel : class
        {
            // set inline styles
            string inlineStyle = tc.ColumnHtmlAttributes.ContainsKey("style") ? tc.ColumnHtmlAttributes["style"] : string.Empty;
            foreach (var item in tc.ColumnInlineCssStyles)
            {
                inlineStyle += (string.IsNullOrEmpty(inlineStyle) || inlineStyle.Trim().EndsWith(";") ? "" : "; ") + item.Key + ": " + item.Value;
            }
            
            return inlineStyle;
        }
    }
}