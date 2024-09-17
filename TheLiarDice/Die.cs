public class Die
{
    private static Random _random = new Random();
    public int FaceValue { get; private set; }

    public Die()
    {
        Roll();
    }

    public void Roll()
    {
        FaceValue = _random.Next(1, 6); // Die has faces from 1 to 5
    }
}