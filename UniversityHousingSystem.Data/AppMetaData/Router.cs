namespace UniversityHousingSystem.Data.AppMetaData
{
    public static class Router
    {
        public const string Root = "api/";
        public const string Version = "v1/";
        public const string Rule = Root + Version;

        public const string SingleRoute = "{id}";


        public static class EventRouting
        {
            public const string Prefix = Rule + "event/";

            public const string list = Prefix + "list";
            public const string coming = Prefix + "coming";
            public const string paginated = Prefix + "paginated";
            public const string GetById = Prefix + SingleRoute;

            public const string Create = Prefix + "create";
            public const string Update = Prefix + "update";
            public const string Delete = Prefix + SingleRoute;
        }

        public static class BuildingRouting
        {
            public const string Prefix = Rule + "buildings/";

            public const string List = Prefix + nameof(List);
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + nameof(Create);
            public const string Update = Prefix + nameof(Update);
            public const string Delete = Prefix + SingleRoute;
        }

        public static class RoomRouting
        {
            public const string Prefix = Rule + "rooms/";

            public const string List = Prefix + "list";
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "create";
            public const string Update = Prefix + "update";
            public const string Delete = Prefix + SingleRoute;
        }
        public static class GuardianRouting
        {
            public const string Prefix = Rule + "guardians/";

            public const string List = Prefix + "list";
            public const string GetByNationalId = Prefix + "{nationalId}";
            public const string Create = Prefix + "create";
            public const string Update = Prefix + "update";
            public const string Delete = Prefix + SingleRoute;
            public const string paginated = Prefix + "paginated";
        }
        public static class CollegeRouting
        {
            public const string Prefix = Rule + "colleges/";

            public const string List = Prefix + "list";
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "create";
            public const string Update = Prefix + "update";
            public const string Delete = Prefix + SingleRoute;
        }
        public static class CollegeDepartmentRouting
        {
            public const string Prefix = Rule + "collegesDepartments/";

            public const string List = Prefix + "list";
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "create";
            public const string Update = Prefix + "Update";
            public const string Delete = Prefix + SingleRoute;
        }
        public static class CountryRouting
        {
            public const string Prefix = Rule + "countries/";

            public const string List = Prefix + "list";

            public const string Governorates = Prefix + "{countryId}/governorates";
        }
        public static class GovernorateRouting
        {
            public const string Prefix = Rule + "Governorates/";

            public const string Cities = Prefix + "{governorateId}/cities";
        }
        public static class CityRouting
        {
            public const string Prefix = Rule + "cities/";

            public const string Villages = Prefix + "{cityId}/villages";
        }
        public static class OldStudentRouting
        {
            public const string Prefix = Rule + "old-student/";

            public const string list = Prefix + "list";
            public const string paginated = Prefix + "paginated";
            public const string GetById = Prefix + SingleRoute;

            public const string Create = Prefix + "create";
            public const string Update = Prefix + "update";
            public const string FullDelete = Prefix + "full-delete/" + SingleRoute;
        }
        public static class NewStudentRouting
        {
            public const string Prefix = Rule + "new-student/";

            public const string list = Prefix + "list";
            public const string paginated = Prefix + "paginated";
            public const string GetById = Prefix + SingleRoute;

            public const string Create = Prefix + "create";
            public const string Update = Prefix + "update";
            public const string FullDelete = Prefix + "full-delete/" + SingleRoute;
        }
        public static class AttendanceRouting
        {
            public const string Prefix = Rule + "attendance/";

            public const string paginated = Prefix + "paginated";

            public const string Create = Prefix + "scan";
        }
        public static class EmployeeRouting
        {
            public const string Prefix = Rule + "employee/";

            public const string list = Prefix + "list";
            public const string paginated = Prefix + "paginated";
            public const string GetById = Prefix + SingleRoute;

            public const string Create = Prefix + "create";
            public const string Update = Prefix + "update";
            public const string Delete = Prefix + SingleRoute;
        }
        public static class IssueTypeRouting
        {
            public const string Prefix = Rule + "issuetypes/";

            public const string List = Prefix + nameof(List);
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "create";
            public const string Update = Prefix + "update";
            public const string Delete = Prefix + SingleRoute;
        }
        public static class IssueRouting
        {
            public const string Prefix = Rule + "issue/";

            public const string List = Prefix + nameof(List);
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "create";
            public const string Update = Prefix + "update";
            public const string Delete = Prefix + SingleRoute;
        }
        public static class HighSchoolRouting
        {
            public const string Prefix = Rule + "high-school/";

            public const string List = Prefix + nameof(List);
        }

        public static class ViolationTypeRouting
        {
            public const string Prefix = Rule + "violationtypes/";

            public const string List = Prefix + nameof(List);
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "create";
            public const string Update = Prefix + "update";
            public const string Delete = Prefix + SingleRoute;
        }
        public static class ViolationRouting
        {
            public const string Prefix = Rule + "violations/";

            public const string List = Prefix + nameof(List);
            public const string GetById = Prefix + SingleRoute;
            public const string Create = Prefix + "create";
            public const string Update = Prefix + "update";
            public const string Delete = Prefix + SingleRoute;
        }
        public static class AuthenticationRouting
        {
            public const string Prefix = Rule + "authentication/";

            public const string ValidateToken = Prefix + "validateToken";

            public const string SignIn = Prefix + "sign-in";

            public const string RefreshToken = Prefix + "refresh-token";
        }
        public static class AuthorizationRouting
        {
            public const string Prefix = Rule + "authorization/";

            public const string CreateRole = Prefix + "role/create";
            public const string EditRole = Prefix + "role/edit";
            public const string DeleteRole = Prefix + "role/" + SingleRoute;

            public const string list = Prefix + "role/" + "list";
            public const string GetById = Prefix + "role/" + SingleRoute;
            public const string GetUserRoles = Prefix + "role/user-roles" + SingleRoute;
            public const string EditUserRoles = Prefix + "role/edit-user-roles";

        }
    }
}
