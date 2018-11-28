using System;
using System.Collections.Generic;
using System.Text;

namespace Design
{
    class TestUtil
    {
        public static void Verify(object expected, object actual)
        {
            string e = expected.ToString();
            string a = actual.ToString();
            Console.WriteLine($"{e.Equals(a)} Expected: {e} actual: {a}");
        }
    }
}
