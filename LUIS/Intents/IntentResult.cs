namespace LUIS.Intents
{
    public class IntentResult
    {
        public static IntentResult Empty = new IntentResult();

        public string GoTo { get; }
        public object Parameters { get; }
        public bool IsEmpty { get; }

        private IntentResult()
        {
            IsEmpty = true;
        }

        public IntentResult(string goTo, object parameters = null)
        {
            GoTo = goTo;
            Parameters = parameters;
        }
    }
}
