namespace PgsBoard.Dtos
{
    public class UpdateCartPositionDto
    {
        public long CartId { get; set; }
        public int NewPosition { get; set; }
    }
}