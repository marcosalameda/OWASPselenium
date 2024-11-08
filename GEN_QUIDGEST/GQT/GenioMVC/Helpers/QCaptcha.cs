using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;

namespace GenioMVC.Helpers
{
	/// <summary>
	/// A simplified version of the captcha.
	/// To stop using libraries that require a "key" or license.
	/// </summary>
	public class QCaptcha
	{
		private int Height { get; set; }

		private int Width { get; set; }

		private int CaptchaLength { get; set; }

		public QCaptcha()
		{
			Height = 35;
			Width = 120;
			CaptchaLength = 6;
		}

		public QCaptcha(int Height, int Width, int CaptchaLength)
		{
			this.Height = Height;
			this.Width = Width;
			this.CaptchaLength = CaptchaLength;
		}

		/// <summary>
		/// Generates a captcha key and put in the stream the corresponding image
		/// </summary>
		/// <param name="stream"></param>
		/// <returns></returns>
		public string Generate(Stream stream)
		{
			string captcha = GenerateRandomString();

			using (Bitmap bmp = new Bitmap(Width, Height))
			{
				Random rnd = new Random();
				RectangleF rectf = new RectangleF(rnd.Next(10, 20), rnd.Next(2, 5), 0, 0);

				using (Graphics g = Graphics.FromImage(bmp))
				{
					g.Clear(Color.White);
					g.SmoothingMode = SmoothingMode.AntiAlias;
					g.InterpolationMode = InterpolationMode.HighQualityBicubic;
					g.PixelOffsetMode = PixelOffsetMode.HighQuality;
					Bezier(g, rnd);
					Lines(g, rnd);
					g.DrawString(captcha, new Font("Times New Roman", 26, FontStyle.Bold), Brushes.Black, rectf);
					Noise(bmp, rnd);
					g.Flush();

					bmp.Save(stream, ImageFormat.Jpeg);
				}
			}

			return captcha;
		}

		private string GenerateRandomString()
		{
			Random random = new Random();
			var combination = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

			var captchaText = new string(
				Enumerable.Repeat(combination, CaptchaLength)
						  .Select(s => s[random.Next(s.Length)])
						  .ToArray());

			return captchaText;
		}

		private Color RandomColor()
		{
			int r, g, b;
			byte[] bytes1 = new byte[3];
			Random rnd1 = new Random();
			rnd1.NextBytes(bytes1);
			r = Convert.ToInt16(bytes1[0]);
			g = Convert.ToInt16(bytes1[1]);
			b = Convert.ToInt16(bytes1[2]);
			return Color.FromArgb(r, g, b);
		}

		private void Bezier(Graphics g, Random rnd)
		{
			Point start = new Point(rnd.Next(10, 55), rnd.Next(1, 45));
			Point control1 = new Point(20, 20);
			Point control2 = new Point(25, 80);
			Point finish = new Point(rnd.Next(70, 130), 8);
			g.DrawBezier(new Pen(Color.Black, 2), start, control1, control2, finish);
		}

		private void Lines(Graphics g, Random rnd)
		{
			var pen = new Pen(Color.Black, 1.7F);
			var flag = rnd.Next(0, 1);

			if (flag == 0)
			{
				var width1 = 15 + rnd.Next(-20, 20);
				var height1 = 0;
				var width2 = 30 + rnd.Next(-20, 20);
				var height2 = 45;
				g.DrawLine(pen, width1, height1, width2, height2);
				g.DrawLine(pen, width1 + 30, height1, width2 + 30, height2);
				g.DrawLine(pen, width1 + 60, height1, width2 + 60, height2);
				g.DrawLine(pen, width1 + 90, height1, width2 + 90, height2);
			}
		}

		private void Noise(Bitmap bmp, Random rnd)
		{
			for (int x = 0; x < bmp.Width; x++)
			{
				for (int y = 0; y < bmp.Height; y++)
				{
					if (rnd.Next(100) <= 22)
						bmp.SetPixel(x, y, Color.Gray);
				}
			}
		}

		/// <summary>
		/// Defines the captcha cache in the list, which will later be written to the session.
		/// </summary>
		/// <param name="captchaId"></param>
		/// <param name="captchaCode"></param>
		/// <param name="sessionCache"></param>
		/// <returns></returns>
		public static Dictionary<string, string> SetCaptcha(string captchaId, string captchaCode, Dictionary<string, string> sessionCache)
		{
			var captchaCache = sessionCache ?? new Dictionary<string, string>();
			if (string.IsNullOrWhiteSpace(captchaId))
				return captchaCache;

			if (captchaCache.ContainsKey(captchaId))
				captchaCache.Remove(captchaId);

			if (!string.IsNullOrWhiteSpace(captchaCode))
				captchaCache.Add(captchaId, captchaCode);
			return captchaCache;
		}

		/// <summary>
		/// Checks whether the text entered by the user is valid
		/// </summary>
		/// <param name="userEnteredCaptchaCode"></param>
		/// <param name="captchaId"></param>
		/// <param name="session"></param>
		/// <returns></returns>
		public static bool Validate(string userEnteredCaptchaCode, string captchaId, HttpSessionStateBase session)
		{
			if (session == null || string.IsNullOrWhiteSpace(userEnteredCaptchaCode) || string.IsNullOrWhiteSpace(captchaId))
				return false;

			var captchaCache = (Dictionary<string, string>)session["qCaptcha"];
			if (captchaCache == null || !captchaCache.ContainsKey(captchaId))
				return false;

			return string.Equals(userEnteredCaptchaCode, captchaCache[captchaId]);
		}
	}
}
