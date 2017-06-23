namespace Scalable.Shared.Model
{
    public class NotesFormArgs
    {
        public string Caption { get; set; }
        public string Title { get; set; }
        public bool ReadOnly { get; set; }
        public string Notes { get; set; }
        public bool IsRtf { get; set; }
        public bool Required { get; set; }
    }
}
