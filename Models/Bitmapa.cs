using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication7.Models
{
    public class BM
    {
        public FileContentResult CreateBitmap()
        {
            int wysokosc = 1080;
            int szerokosc = 1080;
            System.Random r = new System.Random();
            using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(szerokosc, wysokosc, System.Drawing.Imaging.PixelFormat.Format32bppRgb))
            {
                using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp))
                {
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.Clear(System.Drawing.Color.White);
                    g.DrawRectangle(System.Drawing.Pens.White, 1, 1, szerokosc - 3, wysokosc - 3);
                    g.DrawRectangle(System.Drawing.Pens.Gray, 2, 2, szerokosc - 3, wysokosc - 3);
                    g.DrawRectangle(System.Drawing.Pens.Black, 0, 0, szerokosc, wysokosc);
                    g.DrawString("Odswiez mnie!", new System.Drawing.Font("Arial", 10, System.Drawing.FontStyle.Bold),
                                  System.Drawing.SystemBrushes.WindowText, new System.Drawing.PointF(r.Next(50), r.Next(100)),
                new System.Drawing.StringFormat(System.Drawing.StringFormatFlags.DirectionVertical));
                    g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(r.Next(155), r.Next(255),
                        r.Next(255), r.Next(255))), r.Next(szerokosc), r.Next(wysokosc), 100, 50);
                    int x = r.Next(szerokosc);
                    g.FillRectangle(new System.Drawing.Drawing2D.LinearGradientBrush(new System.Drawing.Point(x, 0),
                        new System.Drawing.Point(x + 75, 100), System.Drawing.Color.FromArgb(128, 0, 0, r.Next(255)),
                        System.Drawing.Color.FromArgb(255, r.Next(192, 255), r.Next(192, 255), r.Next(255))), x, r.Next(wysokosc), 75, 50);
                    string filename = System.Guid.NewGuid().ToString("N");
                    bmp.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg);
                    byte[] bytes;
                    using (System.IO.FileStream stream = new System.IO.FileStream(filename, System.IO.FileMode.Open))
                    {
                        bytes = new byte[stream.Length];
                        stream.Read(bytes, 0, bytes.Length);
                    }
                    System.IO.File.Delete(filename);
                    return new FileContentResult(bytes, "image/gif");
                }
            }
        }
    }
}