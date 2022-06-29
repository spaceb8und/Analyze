using System;

namespace BeOrNotToBe
{
    using System;

    class Program
    {
        struct IntValue
        {
            public int? Value;
            
            /// <summary>
            /// Свойство, лямбда выражение возвращает True, когда Value проинициализировано/содержит
            /// значение типа int (не null)
            /// </summary>
            public bool HasValue => Value is not null;
        }

        static void Main(string[] args) {
            IntValue intValue = new IntValue();
            Console.WriteLine(intValue.HasValue == intValue.Value.HasValue);

            intValue.Value = 1;
            Console.WriteLine(intValue.HasValue == intValue.Value.HasValue);

            intValue.Value = -1;
            Console.WriteLine(intValue.HasValue == intValue.Value.HasValue);

            intValue.Value = 0;
            Console.WriteLine(intValue.HasValue == intValue.Value.HasValue);

            intValue.Value = null;
            Console.WriteLine(intValue.HasValue == intValue.Value.HasValue);

            Console.ReadKey();
        }
    }
}