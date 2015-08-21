public class Sheeps
{
    const int MaxCount = 6;

    public class Sheep
    {
        internal void GetColor(bool isBlack)
        {
            string sheepColor = isBlack.ToString();
            Console.WriteLine(sheepColor);
        }
    }

    public static void Main()
    {
        Sheeps.Sheep sheep = new Sheeps.Sheep();
        sheep.GetColor(true);
    }
}