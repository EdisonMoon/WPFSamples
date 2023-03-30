using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DeepCopy.Helper
{
    public class DeepCopyHelper
    {
        // 使用反射深拷贝对象
        public static T DeepClone<T>(T obj) where T : class
        {
            if (obj == null)
                return null;

            Type type = obj.GetType();
            if (type.IsValueType || type == typeof(string))
                return obj;

            if (type.IsArray)
            {
                Type elementType = Type.GetType(
                    type.FullName.Replace("[]", string.Empty));
                var array = obj as Array;
                Array copied = Array.CreateInstance(elementType, array.Length);
                for (int i = 0; i < array.Length; i++)
                {
                    copied.SetValue(DeepClone(array.GetValue(i)), i);
                }
                return (T)(object)copied;
            }

            //如果是List<>类型，遍历元素并递归调用深拷贝方法
            if (typeof(IList).IsAssignableFrom(type))
            {
                Type elementType = type.GetGenericArguments()[0];
                var list = obj as IList;
                IList copied = Activator.CreateInstance(obj.GetType()) as IList;
                foreach (var element in list)
                {
                    copied.Add(DeepClone(element));
                }
                return (T)copied;
            }

            //利用反射创建新对象，并递归调用深拷贝方法
            object result = Activator.CreateInstance(obj.GetType());
            foreach (FieldInfo field in type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                object fieldValue = field.GetValue(obj);
                if (fieldValue == null)
                    continue;

                field.SetValue(result, DeepClone(fieldValue));
            }

            foreach (PropertyInfo property in type.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                if (!property.CanWrite || !property.CanRead)
                    continue;
                object propertyValue = property.GetValue(obj, null);
                if (propertyValue == null)
                    continue;

                property.SetValue(result, DeepClone(propertyValue), null);
            }
            return (T)result;
        }



    }
}
