namespace tp3_prog
{
    public class Line
    {
        public string Action { get; set; }
        public string Result { get; set; }
        public int InteractionId { get; set; }
        public Line(int interactionId, string action, string result)
        {
            InteractionId = interactionId;
            Action = action;
            Result = result;
        }
    }
}