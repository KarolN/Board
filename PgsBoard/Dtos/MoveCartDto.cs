namespace PgsBoard.Dtos
{
    public class MoveCartDto
    {
        public long CartId { get; set; }
        public int NewPosition { get; set; }
        public long NewListId { get; set; }
    }
}