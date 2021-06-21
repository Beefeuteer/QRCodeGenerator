using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using ZXing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace QRCodeSample
{
    public partial class QCCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        // Event to generate the QC Code
        protected void btnQCGenerate_Click(object sender, EventArgs e)
        {
            GenerateMyQCCode(txtQCCode.Text);
        }
        protected void btnQCRead_Click(object sender, EventArgs e)
        {
            ReadQRCode();
        }
        
        protected void btnQCdownload_click(object sender, EventArgs e)
        {
           DownloadQRCode();
        }
        
        private void GenerateMyQCCode(string txtQCCode)
        {
            var QCwriter = new BarcodeWriter();
            QCwriter.Format = BarcodeFormat.QR_CODE;
            var result = QCwriter.Write(txtQCCode);
            string path = Server.MapPath("~/images/MyQRImagee.jpg");
            var barcodeBitmap = new Bitmap(result);

            using (MemoryStream memory = new MemoryStream())
            {
                using (FileStream fs = new FileStream(path,FileMode.Create, FileAccess.ReadWrite))
                {
                    barcodeBitmap.Save(memory, ImageFormat.Jpeg);
                    byte[] bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            imgageQRCode.Visible = true;
            imgageQRCode.ImageUrl = "~/images/MyQRImagee.jpg";

        }

        private void ReadQRCode()
        {
            var QCreader = new BarcodeReader();
            string QCfilename = Path.Combine(Request.MapPath
               ("~/images"), "MyQRImagee.jpg");
            var QCresult = QCreader.Decode(new Bitmap(QCfilename));
            if (QCresult != null)
            {
                lblQRCode.Text = "My QR Code: " + QCresult.Text;
            }
        }
        
        private void DownloadQRCode()
        {
          
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(new Uri("https://localhost:44375/images/MyQRImagee.jpg") , @"C:\QRCODEDOWNLOADS\MyQRImagebeef.jpg");
            }
        
        }
        
    }


}