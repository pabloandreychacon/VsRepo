using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class Generics
    {
        public class Person : IEnumerable
        {
            public int Age { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public Person() { }
            public Person(string firstName, string lastName, int age)
            {
                Age = age;
                FirstName = firstName;
                LastName = lastName;
            }
            public override string ToString()
            {
                return string.Format("Name: {0} {1}, Age: {2}",
                FirstName, LastName, Age);
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }
        // A generic Point structure.
        public struct Point<T>
        {
            // Generic state date.
            private T xPos;
            private T yPos;
            // Generic constructor.
            public Point(T xVal, T yVal)
            {
                xPos = xVal;
                yPos = yVal;
            }
            // Generic properties.
            public T X
            {
                get { return xPos; }
                set { xPos = value; }
            }
            public T Y
            {
                get { return yPos; }
                set { yPos = value; }
            }
            public override string ToString()
            {
                return string.Format("[{0}, {1}]", xPos, yPos);
            }
            // Reset fields to the default value of the
            // type parameter.
            public void ResetPoint()
            {
                xPos = default(T);
                yPos = default(T);
            }
        }
        // A generic Coordenada class.
        public class Coordenada<T>
        {
            // Generic state date.
            private T xPos;
            private T yPos;
            // Generic constructor.
            public Coordenada(T xVal, T yVal)
            {
                xPos = xVal;
                yPos = yVal;
            }
            // Generic properties.
            public T X
            {
                get { return xPos; }
                set { xPos = value; }
            }
            public T Y
            {
                get { return yPos; }
                set { yPos = value; }
            }
            public override string ToString()
            {
                return string.Format("[{0}, {1}]", xPos, yPos);
            }
            // Reset fields to the default value of the
            // type parameter.
            public void ResetCoord()
            {
                xPos = default(T); // default value of type parameter
                yPos = default(T);
            }
        }

        //private readonly IList<T> list = new List<T>();

        public static void Swap<T>(ref T a, ref T b)
        {
            Console.WriteLine("You sent the Swap() method a {0}",
            typeof(T));
            T temp;
            temp = a;
            a = b;
            b = temp;
        }

        public static void DisplayBaseClass<T>()
        {
            Console.WriteLine("Base class of {0} is: {1}.",
            typeof(T), typeof(T).BaseType);
        }

        //public static List<T1> GetSnapshot<T1>(List<Proveedore> pl) where T1 : new()
        //{
        //    var result = new List<T1>();
        //    for (int i = 0; i < pl.Count; i++)
        //    {
        //        result.Add(
        //            new T1()
        //        );
        //    }
        //    return result;

        //}
        
    }
}
