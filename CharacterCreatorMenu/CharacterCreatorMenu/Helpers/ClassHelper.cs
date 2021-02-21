using CharacterCreatorMenu.Attributes;
using System;
using System.Linq;

namespace CharacterCreatorMenu.Helpers
{
    public static class ClassHelper
    {
        public static object InvokeMethod<T>(Enum type, object[] parameters)
        {
            var typeName = $"{typeof(T).Namespace}.{type}";

            var classType = Type.GetType(typeName);
            var classInstance = Activator.CreateInstance(classType);

            var methods = classType.GetMethods();
            var method = methods.FirstOrDefault(x => x.GetCustomAttributes(false).Any(a => a.GetType().FullName == typeof(MethodToInvoke).FullName));
            var methodParameters = parameters;

            return method.Invoke(classInstance, methodParameters);
        }
    }
}
