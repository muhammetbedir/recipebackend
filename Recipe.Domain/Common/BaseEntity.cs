
using static Recipe.Common.Enums.StatusEnums;

namespace Recipe.Domain.Models
{
    public class BaseEntity
    {
        public Guid Id { get; set; }
        public long VisibleId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public StatusEnum Status { get; set; }
    }
}
