using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Converters
{
    public class Converter<TInput, TOutput>
                        where TInput : class
                        where TOutput : class
    {
        private delegate TOutput ConvertAction(TInput objIn);

        static public TOutput Convert(TInput objIn)
        {
            var objOutput = (TOutput)Activator.CreateInstance(typeof(TOutput));

            var propsIn = typeof(TInput).GetProperties();
            var propsOut = typeof(TOutput).GetProperties();

            //props[0].Name

            foreach (var prop in propsIn)
            {
                foreach (var propOut in propsOut)
                {
                    if (propOut.Name == prop.Name)
                    {
                        if (objOutput != null)
                        {
                            propOut.SetValue(objOutput, prop.GetValue(objIn));
                        }                        
                    }
                }
            }

            return objOutput;
        }
    }
}
