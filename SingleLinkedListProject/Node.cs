namespace SingleLinkedListProject
{
    public class Node
    {
        public int Info { get; set; }
        public Node Link { get; set; }

        public Node(int i)
        {
            Info = i;
            Link = null;
        }
    }
}