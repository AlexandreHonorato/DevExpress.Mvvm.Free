using System;

#if MVVM && !NETFX_CORE
namespace DevExpress.Mvvm.Native {
    public static class GuardHelper {
#else
namespace DevExpress.Utils {
    public static class Guard {
#endif
        public static void ArgumentNotNull(object value, string name) {
            if (Object.ReferenceEquals(value, null))
                ThrowArgumentNullException(name);
        }
        public static void ArgumentNonNegative(int value, string name) {
            if (value < 0)
                ThrowArgumentException(name, value);
        }
        public static void ArgumentPositive(int value, string name) {
            if (value <= 0)
                ThrowArgumentException(name, value);
        }
        public static void ArgumentNonNegative(float value, string name) {
            if (value < 0)
                ThrowArgumentException(name, value);
        }
        public static void ArgumentPositive(float value, string name) {
            if (value <= 0)
                ThrowArgumentException(name, value);
        }
        public static void ArgumentNonNegative(double value, string name) {
            if (value < 0)
                ThrowArgumentException(name, value);
        }
        public static void ArgumentPositive(double value, string name) {
            if (value <= 0)
                ThrowArgumentException(name, value);
        }
        public static void ArgumentIsNotNullOrEmpty(string value, string name) {
            if (string.IsNullOrEmpty(value))
                ThrowArgumentException(name, value);
        }
        public static TValue ArgumentMatchType<TValue>(object value, string name) {
            try {
                return (TValue)value;
            } catch(InvalidCastException e) {
                ThrowArgumentException(name, value, e);
                throw new InvalidOperationException();
            }
        }
        static void ThrowArgumentException(string propName, object val, Exception innerException = null) {
            string valueStr =
                Object.ReferenceEquals(val, string.Empty) ? "String.Empty" :
                Object.ReferenceEquals(val, null) ? "null" :
                val.ToString();
            string s = String.Format("'{0}' is not a valid value for '{1}'", valueStr, propName);
            throw new ArgumentException(s, innerException);
        }
        static void ThrowArgumentNullException(string propName) {
            throw new ArgumentNullException(propName);
        }
    }
}