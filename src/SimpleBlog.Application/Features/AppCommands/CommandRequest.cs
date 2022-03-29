namespace SimpleBlog.Application.Features.AppCommands
{
    public class CommandRequest
    {
        public string[]? CommandIds { get; set; }

        public bool AddToAllFunctions { get; set; }
    }
}