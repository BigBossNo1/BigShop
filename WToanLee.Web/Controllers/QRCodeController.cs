using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZXing;

namespace WToanLee.Web.Controllers
{
    public class QRCodeController : Controller
    {
        // GET: QRCode
        public ActionResult GenerateQRCode(string data)
        {
            // Sử dụng thư viện ZXing để tạo QR code từ dữ liệu
            BarcodeWriter barcodeWriter = new BarcodeWriter();
            barcodeWriter.Format = BarcodeFormat.QR_CODE;
            Bitmap bitmap = barcodeWriter.Write(data);

            // Chuyển đổi Bitmap thành mảng byte để hiển thị trong trang web
            ImageConverter converter = new ImageConverter();
            byte[] imageBytes = (byte[])converter.ConvertTo(bitmap, typeof(byte[]));

            // Trả về hình ảnh dưới dạng file hình ảnh
            return File(imageBytes, "image/png");
        }

        public ActionResult QRCodeDetail(string link)
        {
            ViewBag.data = link;
            return View();
        }

    }
}