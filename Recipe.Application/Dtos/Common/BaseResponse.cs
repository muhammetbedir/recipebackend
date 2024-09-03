using static Recipe.Common.Enums.StatusEnums;

namespace Recipe.Presentation.Dtos.Common
{
    public class BaseResponse
    {
        public Guid? Id { get; set; }
        public long VisibleId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public StatusEnum Status { get; set; }
    }
}
