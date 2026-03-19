namespace MyDummyAPI.DTOs
{
    public class BranchDTO
    {
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
