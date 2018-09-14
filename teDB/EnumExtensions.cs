using System;
using System.ComponentModel;
using System.Reflection;


namespace teExtension
{
  /// <span class="code-SummaryComment"><summary></span>
  /// enum utilities. 
  /// - converts from a [Description(&quot;&quot;)] to an enum value
  /// - grabs the [Description(&quot;&quot;)] from an enum value
  /// 
  /// <span class="code-SummaryComment"></summary></span>
  public class EnumUtils<T>
  {
    public static string GetDescription(T enumValue, string defDesc)
    {

      FieldInfo fi = enumValue.GetType().GetField(enumValue.ToString());

      if (null != fi)
      {
        object[] attrs = fi.GetCustomAttributes
      (typeof(DescriptionAttribute), true);
        if (attrs != null && attrs.Length > 0)
          return ((DescriptionAttribute)attrs[0]).Description;
      }

      return defDesc;
    }

    public static string GetDescription(T enumValue)
    {
      return GetDescription(enumValue, string.Empty);
    }

    public static T FromDescription(string description)
    {
      Type t = typeof(T);
      foreach (FieldInfo fi in t.GetFields())
      {
        object[] attrs = fi.GetCustomAttributes
      (typeof(DescriptionAttribute), true);
        if (attrs != null && attrs.Length > 0)
        {
          foreach (DescriptionAttribute attr in attrs)
          {
            if (attr.Description.Equals(description))
              return (T)fi.GetValue(null);
          }
        }
      }
      return default(T);
    }
  }
}