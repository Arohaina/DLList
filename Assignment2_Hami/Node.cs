public class Node
{
    public string Word { get; set; }
    public int Length { get; set; }

    public Node Next { get; set; }
    public Node Prev { get; set; }

    public Node(string word)
    {
        Word = word;
        Length = word.Length;

        Next = null;
        Prev = null;
    }

    public string ToPrint()
    {
        return Word.ToString();
    }
}
