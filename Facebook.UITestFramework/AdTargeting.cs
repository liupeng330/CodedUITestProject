using System.Collections.Generic;
using System.Runtime.Serialization;
using Common.UITestFramework.Utilities;

namespace Facebook.UITestFramework.Object
{
    [DataContract]
    public class ads_targeting
    {
        [DataMember(Name = "broad_age", EmitDefaultValue = false)]
        public int broad_age { get; set; }

        [DataMember(Name = "radius", EmitDefaultValue = false)]
        public int radius { get; set; }

        [DataMember(Name = "age_min", EmitDefaultValue = false)]
        public int age_min { get; set; }

        [DataMember(Name = "age_max", EmitDefaultValue = false)]
        public int age_max { get; set; }

        [DataMember(Name = "adgroup_id", EmitDefaultValue = false)]
        public long adgroup_id { get; set; }

        [DataMember(Name = "countries", EmitDefaultValue = false)]
        public List<string> countries { get; set; }

        [DataMember(Name = "locales", EmitDefaultValue = false)]
        public List<int> locales { get; set; }

        [DataMember(Name = "cities", EmitDefaultValue = false)]
        public List<ads_id_name_map> cities { get; set; }

        [DataMember(Name = "regions", EmitDefaultValue = false)]
        public List<ads_id_name_map> regions { get; set; }

        [DataMember(Name = "genders", EmitDefaultValue = false)]
        public List<int> genders { get; set; }

        [DataMember(Name = "college_networks", EmitDefaultValue = false)]
        public List<ads_id_name_map> college_networks { get; set; }

        [DataMember(Name = "work_networks", EmitDefaultValue = false)]
        public List<ads_id_name_map> work_networks { get; set; }

        [DataMember(Name = "education_statuses", EmitDefaultValue = false)]
        public List<int> education_statuses { get; set; }

        [DataMember(Name = "college_years", EmitDefaultValue = false)]
        public List<int> college_years { get; set; }

        [DataMember(Name = "college_majors", EmitDefaultValue = false)]
        public List<string> college_majors { get; set; }

        [DataMember(Name = "political_views", EmitDefaultValue = false)]
        public List<int> political_views { get; set; }

        [DataMember(Name = "relationship_statuses", EmitDefaultValue = false)]
        public List<int> relationship_statuses { get; set; }

        [DataMember(Name = "keywords", EmitDefaultValue = false)]
        public List<string> keywords { get; set; }

        [DataMember(Name = "interested_in", EmitDefaultValue = false)]
        public List<int> interested_in { get; set; }

        [DataMember(Name = "user_adclusters", EmitDefaultValue = false)]
        public List<ads_id_name_map> user_adclusters { get; set; }

        [DataMember(Name = "connections", EmitDefaultValue = false)]
        public List<string> connections { get; set; }

        [DataMember(Name = "excluded_connections", EmitDefaultValue = false)]
        public List<ads_id_name_map> excluded_connections { get; set; }

        [DataMember(Name = "friends_of_connections", EmitDefaultValue = false)]
        public List<string> friends_of_connections { get; set; }

        [DataMember(Name = "user_event", EmitDefaultValue = false)]
        public List<int> user_event { get; set; }

        public List<string> KeywordSuggestions { get; set; }

        public string ValidationError { get; set; }


        public static string SerializeToJsonString(ads_targeting obj)
        {
            return JsonSerializer.stringify(obj);
        }
    }

    [DataContract]
    public class ads_id_name_map
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public long id { get; set; }

        [DataMember(Name = "name", EmitDefaultValue = false)]
        public string name { get; set; }
    }
}
