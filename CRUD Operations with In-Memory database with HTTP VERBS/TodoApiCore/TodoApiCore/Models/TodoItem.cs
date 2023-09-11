namespace TodoApiCore.Models
{
    public class TodoItem
    {
        public long id { get; set; }
        public string? name { get; set; }
        public bool isCompleted { get; set; }
        public string? secret { get; set; }
    }
}
