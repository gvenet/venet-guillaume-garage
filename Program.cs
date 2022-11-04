namespace ft
{
    [Serializable]
    internal class Program
    {
        static void Main(string[] args)
        {
            Garage garage = new Garage();
            Menu menu = new Menu(garage);
            menu.Start();
        }
    }
}
