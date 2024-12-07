using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClassesAndDelegates
{
    internal class GenericClass<T>
    {
        public GenericClass(T field, T value ) { this.Field = field; this.Value = value; }

        #region Properties
        public T Field { get; set; }
        public T Value { get; set; }
        #endregion


        public void ShowType() => Console.WriteLine($"The type of the field {Field} is {Field.GetType()}");

        public void Addition() => Console.WriteLine($"The addidtion of {Field} and {Value} is --> {(dynamic) Field + Value}");


    }
}
