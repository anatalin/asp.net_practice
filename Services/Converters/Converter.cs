using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Converters
{
    public class Converter<T,TProxy>
                        where T: class 
                        where TProxy: class
    {
        static public TProxy ToProxy(T obj)
        {
            var objProxy = (TProxy)Activator.CreateInstance(typeof(TProxy));

            var props = typeof(T).GetProperties();
            var propsProxy = typeof(TProxy).GetProperties();

            //props[0].Name

            foreach (var prop in props)
            {
                foreach (var propProxy in propsProxy)
                {
                    if (propProxy.Name == prop.Name)
                    {
                        if (objProxy != null)
                        {
                            propProxy.SetValue(objProxy, prop.GetValue(obj));
                        }                        
                    }
                }
            }

            return objProxy;
        }
    }
}
