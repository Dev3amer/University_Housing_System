namespace UniversityHousingSystem.Data.Resources
{
    public static class SharedResourcesKeys
    {
        #region General Response Messages
        public const string Success = "Operation completed successfully.";
        public const string Created = "{0} has been created successfully.";
        public const string Updated = "{0} has been updated successfully.";
        public const string Deleted = "{0} has been deleted successfully.";
        public const string NotFound = "{0} was not found in the system.";
        public const string TryAgain = "An error occurred. Please try again later.";
        public const string OperationFailed = "The {0} operation failed: {1}";
        #endregion

        #region Validation Messages
        public const string Required = "The {0} field is required.";
        public const string NotEmpty = "The {0} field cannot be empty.";
        public const string NotNull = "The {0} field cannot be null.";
        public const string MaxLength = "The {0} field cannot exceed {1} characters.";
        public const string MinLength = "The {0} field must be at least {1} characters.";
        public const string AcceptedRange = "The {0} field must be between {1} and {2}.";
        public const string GreaterThan = "The {0} field must be greater than {1}.";
        public const string GreaterThanOrEqual = "The {0} field must be greater than or equal to {1}.";
        public const string LessThan = "The {0} field must be less than {1}.";
        public const string LessThanOrEqual = "The {0} field must be less than or equal to {1}.";
        public const string Exist = "A {0} with this {1} already exists in the system.";
        public const string Invalid = "The provided {0} is invalid.";
        public const string InvalidFormat = "The {0} format is invalid. Expected format: {1}";
        #endregion

        #region Authentication & Authorization Messages
        public const string UnAuthorized = "Authentication required. Please log in to access this resource.";
        public const string Forbidden = "You do not have permission to access this resource.";
        public const string InvalidCredentials = "The provided credentials are incorrect.";
        public const string AccountLocked = "Your account has been locked. Please contact support.";
        public const string AccountDisabled = "This account has been disabled. Please contact support.";
        public const string SessionExpired = "Your session has expired. Please log in again.";

        // Token Related
        public const string InvalidToken = "The authentication token is invalid or malformed.";
        public const string ExpiredToken = "The authentication token expired at {0}.";
        public const string NotExpiredToken = "The current token is still valid until {0}.";
        public const string InvalidRefreshToken = "The refresh token is invalid or has been revoked.";
        public const string ExpiredRefreshToken = "The refresh token expired at {0}.";
        public const string TokenGenerated = "New access token generated. Expires at: {0}";
        #endregion

        #region User Management Messages
        public const string InvalidPhone = "The phone number {0} is invalid. Please use the format: {1}";
        public const string InvalidEmail = "The email address {0} is invalid.";
        public const string InvalidUserName = "Username must be {0} to {1} characters long and contain only letters and numbers.";
        public const string InvalidPassword = "The password does not meet security requirements.";
        public const string IncorrectPassword = "The provided password is incorrect.";
        public const string InvalidConfirmPassword = "The password and confirmation password do not match.";
        public const string PasswordRequirements = "Password must contain at least {0} characters, including uppercase, lowercase, numbers, and special characters.";
        public const string DeleteRoleWithUsersException = "Cannot delete role '{0}' as it is assigned to {1} users. Please reassign users first.";
        public const string UserRoleUpdated = "User role updated from {0} to {1} successfully.";
        #endregion

        #region Email Messages
        public const string EmailSent = "An email has been sent to {0} successfully.";
        public const string EmailNotConfirmed = "Please confirm your email address. Verification email sent to {0}.";
        public const string EmailConfirmed = "Email address {0} has been confirmed successfully.";
        public const string EmailAlreadyConfirmed = "Email address {0} was already confirmed on {1}.";
        public const string EmailNotFound = "No account found with email address {0}.";
        public const string IncorrectCode = "Invalid verification code. {0} attempts remaining.";
        public const string VerificationCodeSent = "A verification code has been sent to {0}. Code expires in {1} minutes.";
        #endregion

        #region File Operation Messages
        public const string FileEmpty = "The uploaded file is empty.";
        public const string FileSizeLimit = "The file size exceeds the maximum limit of {0}MB.";
        public const string FileTypeNotAllowed = "File type {0} is not allowed. Allowed types: {1}";
        public const string SavingError = "An error occurred while saving the file: {0}";
        public const string DeletingError = "An error occurred while deleting the file: {0}";
        public const string FileNotFound = "The requested file '{0}' was not found.";
        public const string FileUploadSuccess = "File '{0}' uploaded successfully. Size: {1}KB";
        #endregion

        #region Database Operation Messages
        public const string DatabaseError = "Database operation failed: {0}";
        public const string DuplicateEntry = "A record with {0} '{1}' already exists in the database.";
        public const string ReferenceConstraint = "Cannot delete {0} due to existing references in {1}.";
        public const string ConcurrencyConflict = "The record has been modified by another user. Last modified: {0}";
        public const string DataIntegrityViolation = "Data integrity violation detected in {0}. Details: {1}";
        public const string BackupSuccess = "Database backup completed successfully at {0}. File size: {1}MB";
        #endregion

        #region Payment Messages
        public const string PaymentSuccess = "Payment of {0} successfully processed. Transaction ID: {1}";
        public const string PaymentFailed = "Payment failed: {0}. Error code: {1}";
        public const string RefundIssued = "Refund of {0} issued for booking {1}. Processing time: {2} days";
        public const string InsufficientFunds = "Insufficient funds for payment of {0}. Available balance: {1}";
        #endregion
    }
}
