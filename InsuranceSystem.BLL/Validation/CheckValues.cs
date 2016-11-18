using InsuranceSystem.BLL.Infrastructure;

namespace InsuranceSystem.BLL.Validation
{
    internal static class CheckValues
    {
       public static void CheckForNull(int? id)
        {
            if (id == null)
                throw new ValidationException("id is null", "");
        }
        public static void CheckForNull<T>(T item)
        {
            if (item == null)
                throw new ValidationException("item not found", "");
        }
        public static void CheckForNull(string item)
        {
            if (string.IsNullOrEmpty(item))
                throw new ValidationException("item is null", "");
        }
    }
}
