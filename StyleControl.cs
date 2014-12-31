// ------------------------------------------------------------------------
// 
// This is free and unencumbered software released into the public domain.
// 
// Anyone is free to copy, modify, publish, use, compile, sell, or
// distribute this software, either in source code form or as a compiled
// binary, for any purpose, commercial or non-commercial, and by any
// means.
// 
// In jurisdictions that recognize copyright laws, the author or authors
// of this software dedicate any and all copyright interest in the
// software to the public domain. We make this dedication for the benefit
// of the public at large and to the detriment of our heirs and
// successors. We intend this dedication to be an overt act of
// relinquishment in perpetuity of all present and future rights to this
// software under copyright law.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS BE LIABLE FOR ANY CLAIM, DAMAGES OR
// OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
// ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
// OTHER DEALINGS IN THE SOFTWARE.
// 
// For more information, please refer to <http://unlicense.org/>
// 
// ------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace StyleViewer
{
	public class StyleControl : Control
	{
		public System.Drawing.Brush[][] Brushes;

		public StyleControl()
		{
			SetStyle(
				ControlStyles.UserPaint |
				ControlStyles.AllPaintingInWmPaint |
				ControlStyles.OptimizedDoubleBuffer, true);
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			base.OnPaint(e);


			if (Brushes != null)
			{
				System.Drawing.Brush[][] brushes = null;
				System.Threading.Interlocked.Exchange(ref brushes, Brushes);
				float y_unit = (float)Height / (float)brushes.Length;
				float y = Top;
				for (int i = 0; i < brushes.Length; i++)
				{
					if (i == (brushes.Length - 1))
						Render(e.Graphics, Left, y, Width, Top + Height - y, brushes[i]);
					else
						Render(e.Graphics, Left, y, Width, y_unit, brushes[i]);
					y += y_unit;
				}
			}
		}

		private static void Render(System.Drawing.Graphics graphics, float left, float top, float width, float height, System.Drawing.Brush[] brushes)
		{
			float x_unit = (float)width / (float)brushes.Length;
			float x = left;
			for (int i = 0; i < brushes.Length; i++)
			{
				if (i == (brushes.Length - 1))
					graphics.FillRectangle(brushes[i], x, top, left + width - x, height);
				else
					graphics.FillRectangle(brushes[i], x, top, x_unit, height);
				x += x_unit;
			}
		}

	}
}
