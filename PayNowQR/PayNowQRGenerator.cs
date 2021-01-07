using System;
using System.Drawing;
using QRCoder;

namespace PayNowQR
{
    public class PayNowQRGenerator
    {
        private PayNowQRGenerator() 
        {
            qrCodeGenerator = new QRCodeGenerator();
        }

        private static PayNowQRGenerator instance;
        private QRCodeGenerator qrCodeGenerator;

        public static PayNowQRGenerator getInstance()
        {
            if (instance == null)
            {
                return new PayNowQRGenerator();
            }
            else return instance;
        }

        public Bitmap GeneratePayNowQRCode (decimal amount, string refId)
        {
            
            var qrCodeString = GeneratePayNowPayLoadString();
            // Error correction level is H because PayNow requires the logo to be 30% of the QR code.
            QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode(qrCodeString,QRCodeGenerator.ECCLevel.H);
            QRCode qrCode = new QRCode(qrCodeData);
            
            // Revisit the pixel per module. It is more of a resolution for the output bitmap.
            // Paynow logo code set to RGB(124,26,120) according to PayNow Specs
            return qrCode.GetGraphic(20, Color.FromArgb(124,26,120), Color.White, (Bitmap)Bitmap.FromFile("Paynow.png"), 30);
        }

        private string GeneratePayNowPayLoadString()
        {
            // Hard code first
            return "00020101021126550009SG.PAYNOW010100216+62123456789012303010040820201231052512345678901234567890123455204581453037025802SG5916FOOD XYZ PTE LTD6009SINGAPORE61060810066304A96F";
        }

        private string GenerateMerchantAccountInfo ()
        {
            return "";
        }
    }
}
