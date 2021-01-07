using System;
using System.Drawing;
using System.Drawing.Imaging;
using PayNowQR;

namespace PayNowConsoleGenerator
{
    class PayNowConsoleGenerator
    {
        static void Main(string[] args)
        {
            var QRCodeGenerator = PayNowQRGenerator.getInstance();
            var QRCodeImage = QRCodeGenerator.GeneratePayNowQRCode((decimal)10.0, "S8173711H");

            QRCodeImage.Save("QRCode.png", ImageFormat.Png);
        }
    }
}
