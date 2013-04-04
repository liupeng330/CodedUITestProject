using System.Runtime.Serialization;
using Common.UITestFramework.Utilities;

namespace Facebook.UITestFramework.Object
{
    [DataContract]
    public class ads_creative
    {
        [DataMember(Name = "creative_id", EmitDefaultValue=false)]
        public long creative_id { get; set; }

        [DataMember(Name = "type", EmitDefaultValue=false)]
        public string type { get; set; }

        [DataMember(Name = "title", EmitDefaultValue=false)]
        public string title { get; set; }

        [DataMember(Name = "body", EmitDefaultValue=false)]
        public string body { get; set; }

        [DataMember(Name = "image_hash", EmitDefaultValue=false)]
        public string image_hash { get; set; }

        [DataMember(Name = "image_file", EmitDefaultValue=false)]
        public string image_file { get; set; }

        [DataMember(Name = "image_url", EmitDefaultValue=false)]
        public string image_url { get; set; }

        [DataMember(Name = "link_url", EmitDefaultValue=false)]
        public string link_url { get; set; }

        [DataMember(Name = "link_type", EmitDefaultValue=false)]
        public string link_type { get; set; }

        [DataMember(Name = "preview_url", EmitDefaultValue=false)]
        public string preview_url { get; set; }

        [DataMember(Name = "adgroup_id", EmitDefaultValue=false)]
        public long adgroup_id { get; set; }

        [DataMember(Name = "object_id", EmitDefaultValue=false)]
        public long object_id { get; set; }

        //[DataMember(Name = "auto_update", EmitDefaultValue = false)]
        //public string auto_update { get; set; }

        public static string SerializeToJsonString(ads_creative obj)
        {
            return JsonSerializer.stringify(obj); 
        }
    }
}
