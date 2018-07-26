using System;
using System.Reflection;
using System.Runtime.Remoting;

/// <summary>
/// Descripción breve de HelperModel
/// </summary>
namespace Helpers
{ 
    public static class HelperModel
    {
        public enum PropertyType {
            String,
            Int32,
            Decimal,
            Boolean,
            DateTime
        }

        private const string modelLiteral = "Model";
        private static string CurrenAssembly {
            get {
                return Assembly.GetExecutingAssembly().GetName().Name;
            }
        }
        private static string TableNameTreatment(string str) {
            if (str.Length > 1) {
                var primeraMayuscula = char.ToUpper(str[0]) + str.Substring(1);

                if (primeraMayuscula.Contains("_")) {
                    var posGuion = primeraMayuscula.IndexOf("_");
                    var primeraParte = primeraMayuscula.Substring(0, posGuion);
                    var segundaParte = primeraMayuscula.Substring(posGuion + 1);
                    segundaParte = char.ToUpper(segundaParte[0]) + segundaParte.Substring(1);
                    return primeraParte + segundaParte;
                }
                return primeraMayuscula;
            }
            return str.ToUpper();
        }
 
        public static Object CreateNewModelInstanceByType(Type _type)
        {
            var bussinesAssembly = Assembly.GetAssembly(_type);
            ObjectHandle handle = Activator.CreateInstance(bussinesAssembly.GetName().Name, _type.Name);
            Object modelInstance = handle.Unwrap();
            return modelInstance;
        }
        public static PropertyInfo GetModelProperty(IModel model, string propertyName)
        {
            foreach (var modelProperty in model.GetType().GetProperties()) {
                if (propertyName.ToLower().Equals(modelProperty.Name.ToLower())) return modelProperty;
            }
            return null;
        }
    }
}