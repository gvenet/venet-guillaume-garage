namespace ft
{
    [Serializable]
    public class Utils
    {

        public class ExceptionDecimalAttendu : Exception
        {
            public ExceptionDecimalAttendu()
                : base("Erreur de type, decimal attendu")
            {
            }
        }

        public class ExceptionIntAttendu : Exception
        {
            public ExceptionIntAttendu()
                : base("Erreur de type, int attendu")
            {
            }
        }

        public class MenuException : Exception
        {
            public MenuException()
                : base("Erreur, ne contient pas l'input")
            {
            }
        }

        public Utils() { }

        public T GetChoix<T>(String message,List<int>? range = null)
        {
            Console.Write(message);
            String? input = Console.ReadLine();
            if (typeof(T) == typeof(Decimal))
            {
                Decimal decNb;

                if (!Decimal.TryParse(input,out decNb))
                    throw new ExceptionDecimalAttendu();
                else if (decNb < 0)
                    throw new Exception("Erreur, valeur negative");
                return (T)Convert.ChangeType(decNb,typeof(T));
            }
            else if (typeof(T) == typeof(Int32))
            {
                Int32 intNb;
                if (!Int32.TryParse(input,out intNb))
                    throw new ExceptionIntAttendu();
                else if (range != null && !range.Contains(intNb))
                    throw new MenuException();
                else if (intNb < 0)
                    throw new Exception("Erreur, valeur negative");
                return (T)Convert.ChangeType(intNb,typeof(T));
            }
            else
            {
                if (input == "" | input == null)
                    throw new Exception("Erreur, input vide");
                return (T)Convert.ChangeType(input,typeof(T))!;
            }
        }

        public void printRed(String message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        public void printBlue(String message)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(message);
            Console.ResetColor();
        }



    }
}