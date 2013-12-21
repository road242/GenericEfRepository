namespace GenericEfRepository.Tests.Helper
{
    using System.ComponentModel;
    using System.Diagnostics;

    public static class DebugHelper
    {
        /// <summary>
        /// Prints class name and public properties (name + value) for Debug porposes.
        /// </summary>
        /// <param name="o">object containg data to print in debug mode</param>
        [Conditional("DEBUG")]
        public static void DebugPrint(this object o)
        {
            var className = TypeDescriptor.GetClassName(o);
            Debug.WriteLine(string.Format("\nObject of class: {0}", className));

            var properties = TypeDescriptor.GetProperties(o);
            foreach (PropertyDescriptor property in properties)
            {
                var value = property.GetValue(o);
                if (value != null)
                {
                    var propertyNameAsString = property.DisplayName;
                    var propertyValueAsString = value.ToString();
                    Debug.WriteLine(@" - {0}: {1}", propertyNameAsString, propertyValueAsString);
                }
            }
            Debug.WriteLine("\n");
        }
    }
}