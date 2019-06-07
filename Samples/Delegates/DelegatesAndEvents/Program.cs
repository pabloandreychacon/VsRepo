using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    class Program
    {
        static void Main(string[] args)
        {
            // variable que referencian methods como en javascript para ejecutarlo mediante la variable
            // debe ser de la misma firma y retornar lo mismo
            var testName = new Test();
            testName.NameChanged += new NameChangedDelegate(OnNameChanged);
            // se puede escribir reducida
            testName.NameChanged += OnNameChangedAsterisks;
            // cambio #1
            testName.Name = "#1";
            // cambio #2
            testName.Name = "#2";
            Console.ReadKey();
        }

        // antes de usar eventargs en el delegate
        //static void OnNameChanged(string existingName, string newName) {
        static void OnNameChanged(object sender, NamedChangedEventArgs args)
        {
            //Console.WriteLine($"Cambiando el nombre  de {existingName} to {newName}");
            Console.WriteLine($"Cambiando el nombre  de {args.ExistingName} to {args.NewName}");
        }

        // antes de usar eventargs en el delegate
        //static void OnNameChangedAsterisks(string existingName, string newName)
        static void OnNameChangedAsterisks(object sender, NamedChangedEventArgs args)
        {
            Console.WriteLine("***");
        }
    }

    // original
    //delegate void NameChangedDelegate(string name, string value);
    // with events args
    delegate void NameChangedDelegate(object sender, NamedChangedEventArgs args);

    class Test
    {
        public Test()
        {
            _name = "empty";
        }
        // se declara una variable de tipo delegate creada previamente
        //public NameChangedDelegate NameChanged;
        // la convertimos en evento
        public event NameChangedDelegate NameChanged;
        private string _name;
        public string Name {
            get { return _name; }
            set {
                if (!string.IsNullOrEmpty(value))
                {
                    if (_name != value)
                    {
                        NamedChangedEventArgs args = new NamedChangedEventArgs();
                        args.ExistingName = _name;
                        args.NewName = value;

                        //antes de usar event args en el delegate
                        //NameChanged(_name, value);
                        NameChanged(this, args);
                    }
                    _name = value;
                }
            }
        }
    }

    class NamedChangedEventArgs : EventArgs
    {
        public string ExistingName { get; set; }
        public string NewName { get; set; }
    }
}
