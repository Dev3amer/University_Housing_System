using QRCoder;
using UniversityHousingSystem.Service.Abstractions;

namespace UniversityHousingSystem.Service.implementation
{
    public class QRService : IQRService
    {
        public string GenerateAndSaveQRCodeForStudent(string qrText)
        {
            // Create directory if it doesn't exist
            string directoryPath = Path.Combine("wwwroot", "qrcodes");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Generate a unique filename
            string fileName = $"{Guid.NewGuid().ToString()}.png";
            string filePath = Path.Combine(directoryPath, fileName);

            // Generate QR code using PngByteQRCode (no System.Drawing dependency)
            QRCodeGenerator qrGenerator = new();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrText, QRCodeGenerator.ECCLevel.Q);
            PngByteQRCode qrCode = new(qrCodeData);
            byte[] qrCodeBytes = qrCode.GetGraphic(20);

            // Save the image to the file system
            File.WriteAllBytes(filePath, qrCodeBytes);

            // Return the relative path to store in the database
            return Path.Combine("qrcodes", fileName).Replace("\\", "/");
        }
    }
}
