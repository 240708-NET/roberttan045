namespace CephalonSimarisApp.Characters
{
    public class CephalonSimaris
    {
        public string Name { get; set; }

        public CephalonSimaris(string name)
        {
            Name = name;
        }

        public string GreetUser(string userName)
        {
            return $"Greetings, {userName}. I am {Name}, the Cephalon of the Sanctuary.";
        }

        public string RespondToQuery(string query)
        {
            switch (query.ToLower())
            {
                case "knowledge":
                    return "Knowledge is the path to enlightenment. What do you seek to know?";
                case "quest":
                    return "Ah, a quest! The Sanctuary has many mysteries. Explore and document everything.";
                default:
                    return "I am not sure how to respond to that. Ask me about 'knowledge' or 'quest'.";
            }
        }
    }
}