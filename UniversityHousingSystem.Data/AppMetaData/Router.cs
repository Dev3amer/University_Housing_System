namespace UniversityHousingSystem.Data.AppMetaData
{
    public static class Router
    {
        public const string Root = "Api/";
        public const string Version = "V1/";
        public const string Rule = Root + Version;

        public const string SingleRoute = "{id}";


        public static class EventRouting
        {
            public const string Prefix = Rule + "Event/";

            public const string list = Prefix + "List";
            public const string coming = Prefix + "coming";
            public const string paginated = Prefix + "paginated";
            public const string GetById = Prefix + SingleRoute;

            public const string Create = Prefix + "Create";
            public const string Update = Prefix + "Update";
            public const string Delete = Prefix + SingleRoute;
        }

        public static class BuildingRouting
        {
            public const string Prefix = Rule + "Buildings/";

            public const string List = Prefix + nameof(List);
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + nameof(Create);
            public const string Update = Prefix + nameof(Update);
            public const string Delete = Prefix + SingleRoute;
        }

        public static class RoomRouting
        {
            public const string Prefix = Rule + "Rooms/";

            public const string List = Prefix + "List";
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Update = Prefix + "Update";
            public const string Delete = Prefix + SingleRoute;
        }
        public static class GuardianRouting
        {
            public const string Prefix = Rule + "Guardians/";

            public const string List = Prefix + "List";
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Update = Prefix + "Update";
            public const string Delete = Prefix + SingleRoute;
        }
        public static class CollegeRouting
        {
            public const string Prefix = Rule + "Colleges/";

            public const string List = Prefix + "List";
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Update = Prefix + "Update";
            public const string Delete = Prefix + SingleRoute;
        }
        public static class CollegeDepartmentRouting
        {
            public const string Prefix = Rule + "CollegesDepartments/";

            public const string List = Prefix + "List";
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "Create";
            public const string Update = Prefix + "Update";
            public const string Delete = Prefix + SingleRoute;
        }
        public static class GovernorateRouting
        {
            public const string Prefix = Rule + "Governorates/";

            public const string List = "List";
        }
        public static class CityRouting
        {
            public const string Prefix = Rule + "Cities/";

            public const string List = "List";
        }
    }
}
