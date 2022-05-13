using System.Runtime.Serialization;

namespace WebAPI.DataModel
{
    public class BaseDataModel
    {
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        // add IgnoreDataMemberAttribute will always ignore the field in json conversion
        [IgnoreDataMemberAttribute]
        public bool IsActive { get; set; }
    }
}
