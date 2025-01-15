namespace BT
{
    public abstract class Node
    {
        public Node runningNode { get; set; }
        public abstract NodeState Evaluate();
    }
}