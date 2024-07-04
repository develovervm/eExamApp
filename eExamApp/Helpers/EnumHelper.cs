using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

namespace eExamApp.Helpers
{
    public static class EnumHelper
    {
        // Get the value of the description attribute if the   
        // enum has one, otherwise use the value.  
        public static string GetDescription<TEnum>(this TEnum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            if (fi != null)
            {
                var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

                if (attributes.Length > 0)
                {
                    return attributes[0].Description;
                }
            }

            return value.ToString();
        }

        /// <summary>
        /// Build a select list for an enum
        /// </summary>
        public static SelectList SelectListFor<T>() where T : struct
        {
            Type t = typeof(T);
            return !t.IsEnum ? null
                             : new SelectList(BuildSelectListItems(t), "Value", "Text");
        }

        /// <summary>
        /// Build a select list for an enum with a particular value selected 
        /// </summary>
        public static SelectList SelectListFor<T>(T selected) where T : struct
        {
            Type t = typeof(T);
            return !t.IsEnum ? null
                             : new SelectList(BuildSelectListItems(t), "Value", "Text", selected.ToString());
        }

        private static IEnumerable<SelectListItem> BuildSelectListItems(Type t)
        {
            return Enum.GetValues(t)
                       .Cast<Enum>()
                       .Select(e => new SelectListItem { Value = Convert.ToUInt32(e).ToString(), Text = e.GetDescription() });
        }
        
        public static List<SelectListItem> GetSelectedListItems<T>() where T : struct
        {
            Type t = typeof(T);
            var itemsList= SelectListFor<T>();
            List<SelectListItem> selectListItems = new List<SelectListItem>();
            foreach ( var item in itemsList)
            {
                selectListItems.Add(item);
            }
            return selectListItems;
        }
    }

    public enum Semesters : int
    {
        Select=0,
        I = 1,
        II = 2,
        III = 3,
        IV = 4,
        V = 5,
        VI = 6
    }
}
