using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace teDB.Helper
{
  class HelperUtils
  {

    public static string GetDescription<T>(string fieldName)
    {
      string result;
      FieldInfo fi = typeof(T).GetField(fieldName.ToString());
      if (fi != null)
      {
        try
        {
          object[] descriptionAttrs = fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
          DescriptionAttribute description = (DescriptionAttribute)descriptionAttrs[0];
          result = (description.Description);
        }
        catch
        {
          result = null;
        }
      }
      else
      {
        result = null;
      }

      return result;
    }


    public static TOut GetConstFieldAttributeValue<T, TOut, TAttribute>(
      string fieldName,
      Func<TAttribute, TOut> valueSelector)
      where TAttribute : Attribute
    {
      var fieldInfo = typeof(T).GetField(fieldName, BindingFlags.Public | BindingFlags.Static);
      if (fieldInfo == null)
      {
        return default(TOut);
      }
      var att = fieldInfo.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;
      return att != null ? valueSelector(att) : default(TOut);
    }
  }
}
