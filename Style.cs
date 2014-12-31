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

namespace StyleViewer
{
	public class Style
	{
		public static readonly float MINIMUM_FONT_SIZE = 8f;
		public static readonly float DEFAULT_FONT_SIZE = 9;
		public static readonly float MAXIMUM_FONT_SIZE = 28f;

		private System.Drawing.Graphics _graphics = System.Drawing.Graphics.FromImage(new System.Drawing.Bitmap(1, 1));
		private System.Drawing.Color _backColor = System.Drawing.Color.Black;
		private System.Drawing.Brush _backBrush = System.Drawing.Brushes.Black;
		private System.Drawing.Color _foreColor = System.Drawing.Color.White;
		private System.Drawing.Brush _foreBrush = System.Drawing.Brushes.White;
		private System.Drawing.Pen _forePen = System.Drawing.Pens.White;
		private System.Drawing.Color _borderColor = System.Drawing.Color.DimGray;
		private System.Drawing.Pen _borderPen = System.Drawing.Pens.DimGray;
		private System.Drawing.Pen _selectedPen;
		private string _fontName;
		private System.Drawing.Font _font;
		private System.Drawing.Font _titleFont;

		public Style(System.Drawing.Font font) : this(font, font) { }
		public Style(System.Drawing.Font font, System.Drawing.Font titleFont) { _fontName = font.Name; _font = font; _titleFont = titleFont; _selectedPen = new System.Drawing.Pen(new System.Drawing.Drawing2D.HatchBrush(System.Drawing.Drawing2D.HatchStyle.Percent40, System.Drawing.Color.FromArgb(63, _foreColor))); }

		public System.Drawing.Graphics Graphics { get { return _graphics; } }

		public System.Drawing.Color BackColor { get { return _backColor; } set { _backColor = value; _backBrush = new System.Drawing.SolidBrush(_backColor); } }
		public System.Drawing.Brush BackBrush { get { return _backBrush; } }

		public System.Drawing.Color ForeColor { get { return _foreColor; } set { _foreColor = value; _foreBrush = new System.Drawing.SolidBrush(_foreColor); _forePen = new System.Drawing.Pen(_foreBrush); _selectedPen = new System.Drawing.Pen(new System.Drawing.Drawing2D.HatchBrush(System.Drawing.Drawing2D.HatchStyle.Percent40, System.Drawing.Color.FromArgb(63, _foreColor))); } }
		public System.Drawing.Brush ForeBrush { get { return _foreBrush; } }
		public System.Drawing.Pen ForePen { get { return _forePen; } }

		public System.Drawing.Color BorderColor { get { return _borderColor; } set { _borderColor = value; _borderPen = new System.Drawing.Pen(new System.Drawing.SolidBrush(_borderColor)); } }
		public System.Drawing.Pen BorderPen { get { return _borderPen; } }

		public System.Drawing.Pen SelectedPen { get { return _selectedPen; } }

		public string FontName { get { return _fontName; } set { _fontName = value; } }
		public System.Drawing.Font Font { get { return _font; } set { _font = value; } }
		public System.Drawing.Font TitleFont { get { return _titleFont; } set { _titleFont = value; } }

		public System.Drawing.SizeF MeasureString(string s) { return MeasureString(s, _font); }
		public System.Drawing.SizeF MeasureString(string s, System.Drawing.Font font) { return _graphics.MeasureString(s, font, new System.Drawing.PointF(0, 0), new System.Drawing.StringFormat(System.Drawing.StringFormatFlags.MeasureTrailingSpaces | System.Drawing.StringFormatFlags.NoWrap)); }

		public static System.Drawing.Color[] Colors(string name, int count)
		{
			#region ColorScheme

			//TODO this sucks.
			count = System.Math.Max(count, 3);

			switch (name)
			{
				case "Accent":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(127,201,127),
										System.Drawing.Color.FromArgb(190,174,212),
										System.Drawing.Color.FromArgb(253,192,134),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(127,201,127),
										System.Drawing.Color.FromArgb(190,174,212),
										System.Drawing.Color.FromArgb(253,192,134),
										System.Drawing.Color.FromArgb(255,255,153),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(127,201,127),
										System.Drawing.Color.FromArgb(190,174,212),
										System.Drawing.Color.FromArgb(253,192,134),
										System.Drawing.Color.FromArgb(255,255,153),
										System.Drawing.Color.FromArgb(56,108,176),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(127,201,127),
										System.Drawing.Color.FromArgb(190,174,212),
										System.Drawing.Color.FromArgb(253,192,134),
										System.Drawing.Color.FromArgb(255,255,153),
										System.Drawing.Color.FromArgb(56,108,176),
										System.Drawing.Color.FromArgb(240,2,127),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(127,201,127),
										System.Drawing.Color.FromArgb(190,174,212),
										System.Drawing.Color.FromArgb(253,192,134),
										System.Drawing.Color.FromArgb(255,255,153),
										System.Drawing.Color.FromArgb(56,108,176),
										System.Drawing.Color.FromArgb(240,2,127),
										System.Drawing.Color.FromArgb(191,91,23),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(127,201,127),
										System.Drawing.Color.FromArgb(190,174,212),
										System.Drawing.Color.FromArgb(253,192,134),
										System.Drawing.Color.FromArgb(255,255,153),
										System.Drawing.Color.FromArgb(56,108,176),
										System.Drawing.Color.FromArgb(240,2,127),
										System.Drawing.Color.FromArgb(191,91,23),
										System.Drawing.Color.FromArgb(102,102,102),
									};
								}
						}
					}
				case "Blues":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(222,235,247),
										System.Drawing.Color.FromArgb(158,202,225),
										System.Drawing.Color.FromArgb(49,130,189),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(239,243,255),
										System.Drawing.Color.FromArgb(189,215,231),
										System.Drawing.Color.FromArgb(107,174,214),
										System.Drawing.Color.FromArgb(33,113,181),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(239,243,255),
										System.Drawing.Color.FromArgb(189,215,231),
										System.Drawing.Color.FromArgb(107,174,214),
										System.Drawing.Color.FromArgb(49,130,189),
										System.Drawing.Color.FromArgb(8,81,156),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(239,243,255),
										System.Drawing.Color.FromArgb(198,219,239),
										System.Drawing.Color.FromArgb(158,202,225),
										System.Drawing.Color.FromArgb(107,174,214),
										System.Drawing.Color.FromArgb(49,130,189),
										System.Drawing.Color.FromArgb(8,81,156),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(239,243,255),
										System.Drawing.Color.FromArgb(198,219,239),
										System.Drawing.Color.FromArgb(158,202,225),
										System.Drawing.Color.FromArgb(107,174,214),
										System.Drawing.Color.FromArgb(66,146,198),
										System.Drawing.Color.FromArgb(33,113,181),
										System.Drawing.Color.FromArgb(8,69,148),
									};
								}
							case 8:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(247,251,255),
										System.Drawing.Color.FromArgb(222,235,247),
										System.Drawing.Color.FromArgb(198,219,239),
										System.Drawing.Color.FromArgb(158,202,225),
										System.Drawing.Color.FromArgb(107,174,214),
										System.Drawing.Color.FromArgb(66,146,198),
										System.Drawing.Color.FromArgb(33,113,181),
										System.Drawing.Color.FromArgb(8,69,148),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(247,251,255),
										System.Drawing.Color.FromArgb(222,235,247),
										System.Drawing.Color.FromArgb(198,219,239),
										System.Drawing.Color.FromArgb(158,202,225),
										System.Drawing.Color.FromArgb(107,174,214),
										System.Drawing.Color.FromArgb(66,146,198),
										System.Drawing.Color.FromArgb(33,113,181),
										System.Drawing.Color.FromArgb(8,81,156),
										System.Drawing.Color.FromArgb(8,48,107),
									};
								}
						}
					}
				case "BrBG":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(216,179,101),
										System.Drawing.Color.FromArgb(245,245,245),
										System.Drawing.Color.FromArgb(90,180,172),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(166,97,26),
										System.Drawing.Color.FromArgb(223,194,125),
										System.Drawing.Color.FromArgb(128,205,193),
										System.Drawing.Color.FromArgb(1,133,113),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(166,97,26),
										System.Drawing.Color.FromArgb(223,194,125),
										System.Drawing.Color.FromArgb(245,245,245),
										System.Drawing.Color.FromArgb(128,205,193),
										System.Drawing.Color.FromArgb(1,133,113),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(140,81,10),
										System.Drawing.Color.FromArgb(216,179,101),
										System.Drawing.Color.FromArgb(246,232,195),
										System.Drawing.Color.FromArgb(199,234,229),
										System.Drawing.Color.FromArgb(90,180,172),
										System.Drawing.Color.FromArgb(1,102,94),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(140,81,10),
										System.Drawing.Color.FromArgb(216,179,101),
										System.Drawing.Color.FromArgb(246,232,195),
										System.Drawing.Color.FromArgb(245,245,245),
										System.Drawing.Color.FromArgb(199,234,229),
										System.Drawing.Color.FromArgb(90,180,172),
										System.Drawing.Color.FromArgb(1,102,94),
									};
								}
							case 8:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(140,81,10),
										System.Drawing.Color.FromArgb(191,129,45),
										System.Drawing.Color.FromArgb(223,194,125),
										System.Drawing.Color.FromArgb(246,232,195),
										System.Drawing.Color.FromArgb(199,234,229),
										System.Drawing.Color.FromArgb(128,205,193),
										System.Drawing.Color.FromArgb(53,151,143),
										System.Drawing.Color.FromArgb(1,102,94),
									};
								}
							case 9:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(140,81,10),
										System.Drawing.Color.FromArgb(191,129,45),
										System.Drawing.Color.FromArgb(223,194,125),
										System.Drawing.Color.FromArgb(246,232,195),
										System.Drawing.Color.FromArgb(245,245,245),
										System.Drawing.Color.FromArgb(199,234,229),
										System.Drawing.Color.FromArgb(128,205,193),
										System.Drawing.Color.FromArgb(53,151,143),
										System.Drawing.Color.FromArgb(1,102,94),
									};
								}
							case 10:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(84,48,5),
										System.Drawing.Color.FromArgb(140,81,10),
										System.Drawing.Color.FromArgb(191,129,45),
										System.Drawing.Color.FromArgb(223,194,125),
										System.Drawing.Color.FromArgb(246,232,195),
										System.Drawing.Color.FromArgb(199,234,229),
										System.Drawing.Color.FromArgb(128,205,193),
										System.Drawing.Color.FromArgb(53,151,143),
										System.Drawing.Color.FromArgb(1,102,94),
										System.Drawing.Color.FromArgb(0,60,48),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(84,48,5),
										System.Drawing.Color.FromArgb(140,81,10),
										System.Drawing.Color.FromArgb(191,129,45),
										System.Drawing.Color.FromArgb(223,194,125),
										System.Drawing.Color.FromArgb(246,232,195),
										System.Drawing.Color.FromArgb(245,245,245),
										System.Drawing.Color.FromArgb(199,234,229),
										System.Drawing.Color.FromArgb(128,205,193),
										System.Drawing.Color.FromArgb(53,151,143),
										System.Drawing.Color.FromArgb(1,102,94),
										System.Drawing.Color.FromArgb(0,60,48),
									};
								}
						}
					}
				case "BuGn":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(229,245,249),
										System.Drawing.Color.FromArgb(153,216,201),
										System.Drawing.Color.FromArgb(44,162,95),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(237,248,251),
										System.Drawing.Color.FromArgb(178,226,226),
										System.Drawing.Color.FromArgb(102,194,164),
										System.Drawing.Color.FromArgb(35,139,69),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(237,248,251),
										System.Drawing.Color.FromArgb(178,226,226),
										System.Drawing.Color.FromArgb(102,194,164),
										System.Drawing.Color.FromArgb(44,162,95),
										System.Drawing.Color.FromArgb(0,109,44),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(237,248,251),
										System.Drawing.Color.FromArgb(204,236,230),
										System.Drawing.Color.FromArgb(153,216,201),
										System.Drawing.Color.FromArgb(102,194,164),
										System.Drawing.Color.FromArgb(44,162,95),
										System.Drawing.Color.FromArgb(0,109,44),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(237,248,251),
										System.Drawing.Color.FromArgb(204,236,230),
										System.Drawing.Color.FromArgb(153,216,201),
										System.Drawing.Color.FromArgb(102,194,164),
										System.Drawing.Color.FromArgb(65,174,118),
										System.Drawing.Color.FromArgb(35,139,69),
										System.Drawing.Color.FromArgb(0,88,36),
									};
								}
							case 8:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(247,252,253),
										System.Drawing.Color.FromArgb(229,245,249),
										System.Drawing.Color.FromArgb(204,236,230),
										System.Drawing.Color.FromArgb(153,216,201),
										System.Drawing.Color.FromArgb(102,194,164),
										System.Drawing.Color.FromArgb(65,174,118),
										System.Drawing.Color.FromArgb(35,139,69),
										System.Drawing.Color.FromArgb(0,88,36),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(247,252,253),
										System.Drawing.Color.FromArgb(229,245,249),
										System.Drawing.Color.FromArgb(204,236,230),
										System.Drawing.Color.FromArgb(153,216,201),
										System.Drawing.Color.FromArgb(102,194,164),
										System.Drawing.Color.FromArgb(65,174,118),
										System.Drawing.Color.FromArgb(35,139,69),
										System.Drawing.Color.FromArgb(0,109,44),
										System.Drawing.Color.FromArgb(0,68,27),
									};
								}
						}
					}
				case "BuPu":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(224,236,244),
										System.Drawing.Color.FromArgb(158,188,218),
										System.Drawing.Color.FromArgb(136,86,167),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(237,248,251),
										System.Drawing.Color.FromArgb(179,205,227),
										System.Drawing.Color.FromArgb(140,150,198),
										System.Drawing.Color.FromArgb(136,65,157),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(237,248,251),
										System.Drawing.Color.FromArgb(179,205,227),
										System.Drawing.Color.FromArgb(140,150,198),
										System.Drawing.Color.FromArgb(136,86,167),
										System.Drawing.Color.FromArgb(129,15,124),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(237,248,251),
										System.Drawing.Color.FromArgb(191,211,230),
										System.Drawing.Color.FromArgb(158,188,218),
										System.Drawing.Color.FromArgb(140,150,198),
										System.Drawing.Color.FromArgb(136,86,167),
										System.Drawing.Color.FromArgb(129,15,124),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(237,248,251),
										System.Drawing.Color.FromArgb(191,211,230),
										System.Drawing.Color.FromArgb(158,188,218),
										System.Drawing.Color.FromArgb(140,150,198),
										System.Drawing.Color.FromArgb(140,107,177),
										System.Drawing.Color.FromArgb(136,65,157),
										System.Drawing.Color.FromArgb(110,1,107),
									};
								}
							case 8:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(247,252,253),
										System.Drawing.Color.FromArgb(224,236,244),
										System.Drawing.Color.FromArgb(191,211,230),
										System.Drawing.Color.FromArgb(158,188,218),
										System.Drawing.Color.FromArgb(140,150,198),
										System.Drawing.Color.FromArgb(140,107,177),
										System.Drawing.Color.FromArgb(136,65,157),
										System.Drawing.Color.FromArgb(110,1,107),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(247,252,253),
										System.Drawing.Color.FromArgb(224,236,244),
										System.Drawing.Color.FromArgb(191,211,230),
										System.Drawing.Color.FromArgb(158,188,218),
										System.Drawing.Color.FromArgb(140,150,198),
										System.Drawing.Color.FromArgb(140,107,177),
										System.Drawing.Color.FromArgb(136,65,157),
										System.Drawing.Color.FromArgb(129,15,124),
										System.Drawing.Color.FromArgb(77,0,75),
									};
								}
						}
					}
				case "Dark2":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(27,158,119),
										System.Drawing.Color.FromArgb(217,95,2),
										System.Drawing.Color.FromArgb(117,112,179),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(27,158,119),
										System.Drawing.Color.FromArgb(217,95,2),
										System.Drawing.Color.FromArgb(117,112,179),
										System.Drawing.Color.FromArgb(231,41,138),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(27,158,119),
										System.Drawing.Color.FromArgb(217,95,2),
										System.Drawing.Color.FromArgb(117,112,179),
										System.Drawing.Color.FromArgb(231,41,138),
										System.Drawing.Color.FromArgb(102,166,30),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(27,158,119),
										System.Drawing.Color.FromArgb(217,95,2),
										System.Drawing.Color.FromArgb(117,112,179),
										System.Drawing.Color.FromArgb(231,41,138),
										System.Drawing.Color.FromArgb(102,166,30),
										System.Drawing.Color.FromArgb(230,171,2),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(27,158,119),
										System.Drawing.Color.FromArgb(217,95,2),
										System.Drawing.Color.FromArgb(117,112,179),
										System.Drawing.Color.FromArgb(231,41,138),
										System.Drawing.Color.FromArgb(102,166,30),
										System.Drawing.Color.FromArgb(230,171,2),
										System.Drawing.Color.FromArgb(166,118,29),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(27,158,119),
										System.Drawing.Color.FromArgb(217,95,2),
										System.Drawing.Color.FromArgb(117,112,179),
										System.Drawing.Color.FromArgb(231,41,138),
										System.Drawing.Color.FromArgb(102,166,30),
										System.Drawing.Color.FromArgb(230,171,2),
										System.Drawing.Color.FromArgb(166,118,29),
										System.Drawing.Color.FromArgb(102,102,102),
									};
								}
						}
					}
				case "GnBu":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(224,243,219),
										System.Drawing.Color.FromArgb(168,221,181),
										System.Drawing.Color.FromArgb(67,162,202),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(240,249,232),
										System.Drawing.Color.FromArgb(186,228,188),
										System.Drawing.Color.FromArgb(123,204,196),
										System.Drawing.Color.FromArgb(43,140,190),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(240,249,232),
										System.Drawing.Color.FromArgb(186,228,188),
										System.Drawing.Color.FromArgb(123,204,196),
										System.Drawing.Color.FromArgb(67,162,202),
										System.Drawing.Color.FromArgb(8,104,172),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(240,249,232),
										System.Drawing.Color.FromArgb(204,235,197),
										System.Drawing.Color.FromArgb(168,221,181),
										System.Drawing.Color.FromArgb(123,204,196),
										System.Drawing.Color.FromArgb(67,162,202),
										System.Drawing.Color.FromArgb(8,104,172),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(240,249,232),
										System.Drawing.Color.FromArgb(204,235,197),
										System.Drawing.Color.FromArgb(168,221,181),
										System.Drawing.Color.FromArgb(123,204,196),
										System.Drawing.Color.FromArgb(78,179,211),
										System.Drawing.Color.FromArgb(43,140,190),
										System.Drawing.Color.FromArgb(8,88,158),
									};
								}
							case 8:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(247,252,240),
										System.Drawing.Color.FromArgb(224,243,219),
										System.Drawing.Color.FromArgb(204,235,197),
										System.Drawing.Color.FromArgb(168,221,181),
										System.Drawing.Color.FromArgb(123,204,196),
										System.Drawing.Color.FromArgb(78,179,211),
										System.Drawing.Color.FromArgb(43,140,190),
										System.Drawing.Color.FromArgb(8,88,158),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(247,252,240),
										System.Drawing.Color.FromArgb(224,243,219),
										System.Drawing.Color.FromArgb(204,235,197),
										System.Drawing.Color.FromArgb(168,221,181),
										System.Drawing.Color.FromArgb(123,204,196),
										System.Drawing.Color.FromArgb(78,179,211),
										System.Drawing.Color.FromArgb(43,140,190),
										System.Drawing.Color.FromArgb(8,104,172),
										System.Drawing.Color.FromArgb(8,64,129),
									};
								}
						}
					}
				case "Greens":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(229,245,224),
										System.Drawing.Color.FromArgb(161,217,155),
										System.Drawing.Color.FromArgb(49,163,84),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(237,248,233),
										System.Drawing.Color.FromArgb(186,228,179),
										System.Drawing.Color.FromArgb(116,196,118),
										System.Drawing.Color.FromArgb(35,139,69),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(237,248,233),
										System.Drawing.Color.FromArgb(186,228,179),
										System.Drawing.Color.FromArgb(116,196,118),
										System.Drawing.Color.FromArgb(49,163,84),
										System.Drawing.Color.FromArgb(0,109,44),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(237,248,233),
										System.Drawing.Color.FromArgb(199,233,192),
										System.Drawing.Color.FromArgb(161,217,155),
										System.Drawing.Color.FromArgb(116,196,118),
										System.Drawing.Color.FromArgb(49,163,84),
										System.Drawing.Color.FromArgb(0,109,44),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(237,248,233),
										System.Drawing.Color.FromArgb(199,233,192),
										System.Drawing.Color.FromArgb(161,217,155),
										System.Drawing.Color.FromArgb(116,196,118),
										System.Drawing.Color.FromArgb(65,171,93),
										System.Drawing.Color.FromArgb(35,139,69),
										System.Drawing.Color.FromArgb(0,90,50),
									};
								}
							case 8:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(247,252,245),
										System.Drawing.Color.FromArgb(229,245,224),
										System.Drawing.Color.FromArgb(199,233,192),
										System.Drawing.Color.FromArgb(161,217,155),
										System.Drawing.Color.FromArgb(116,196,118),
										System.Drawing.Color.FromArgb(65,171,93),
										System.Drawing.Color.FromArgb(35,139,69),
										System.Drawing.Color.FromArgb(0,90,50),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(247,252,245),
										System.Drawing.Color.FromArgb(229,245,224),
										System.Drawing.Color.FromArgb(199,233,192),
										System.Drawing.Color.FromArgb(161,217,155),
										System.Drawing.Color.FromArgb(116,196,118),
										System.Drawing.Color.FromArgb(65,171,93),
										System.Drawing.Color.FromArgb(35,139,69),
										System.Drawing.Color.FromArgb(0,109,44),
										System.Drawing.Color.FromArgb(0,68,27),
									};
								}
						}
					}
				case "Greys":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(240,240,240),
										System.Drawing.Color.FromArgb(189,189,189),
										System.Drawing.Color.FromArgb(99,99,99),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(247,247,247),
										System.Drawing.Color.FromArgb(204,204,204),
										System.Drawing.Color.FromArgb(150,150,150),
										System.Drawing.Color.FromArgb(82,82,82),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(247,247,247),
										System.Drawing.Color.FromArgb(204,204,204),
										System.Drawing.Color.FromArgb(150,150,150),
										System.Drawing.Color.FromArgb(99,99,99),
										System.Drawing.Color.FromArgb(37,37,37),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(247,247,247),
										System.Drawing.Color.FromArgb(217,217,217),
										System.Drawing.Color.FromArgb(189,189,189),
										System.Drawing.Color.FromArgb(150,150,150),
										System.Drawing.Color.FromArgb(99,99,99),
										System.Drawing.Color.FromArgb(37,37,37),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(247,247,247),
										System.Drawing.Color.FromArgb(217,217,217),
										System.Drawing.Color.FromArgb(189,189,189),
										System.Drawing.Color.FromArgb(150,150,150),
										System.Drawing.Color.FromArgb(115,115,115),
										System.Drawing.Color.FromArgb(82,82,82),
										System.Drawing.Color.FromArgb(37,37,37),
									};
								}
							case 8:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,255,255),
										System.Drawing.Color.FromArgb(240,240,240),
										System.Drawing.Color.FromArgb(217,217,217),
										System.Drawing.Color.FromArgb(189,189,189),
										System.Drawing.Color.FromArgb(150,150,150),
										System.Drawing.Color.FromArgb(115,115,115),
										System.Drawing.Color.FromArgb(82,82,82),
										System.Drawing.Color.FromArgb(37,37,37),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,255,255),
										System.Drawing.Color.FromArgb(240,240,240),
										System.Drawing.Color.FromArgb(217,217,217),
										System.Drawing.Color.FromArgb(189,189,189),
										System.Drawing.Color.FromArgb(150,150,150),
										System.Drawing.Color.FromArgb(115,115,115),
										System.Drawing.Color.FromArgb(82,82,82),
										System.Drawing.Color.FromArgb(37,37,37),
										System.Drawing.Color.FromArgb(0,0,0),
									};
								}
						}
					}
				case "Oranges":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(254,230,206),
										System.Drawing.Color.FromArgb(253,174,107),
										System.Drawing.Color.FromArgb(230,85,13),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(254,237,222),
										System.Drawing.Color.FromArgb(253,190,133),
										System.Drawing.Color.FromArgb(253,141,60),
										System.Drawing.Color.FromArgb(217,71,1),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(254,237,222),
										System.Drawing.Color.FromArgb(253,190,133),
										System.Drawing.Color.FromArgb(253,141,60),
										System.Drawing.Color.FromArgb(230,85,13),
										System.Drawing.Color.FromArgb(166,54,3),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(254,237,222),
										System.Drawing.Color.FromArgb(253,208,162),
										System.Drawing.Color.FromArgb(253,174,107),
										System.Drawing.Color.FromArgb(253,141,60),
										System.Drawing.Color.FromArgb(230,85,13),
										System.Drawing.Color.FromArgb(166,54,3),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(254,237,222),
										System.Drawing.Color.FromArgb(253,208,162),
										System.Drawing.Color.FromArgb(253,174,107),
										System.Drawing.Color.FromArgb(253,141,60),
										System.Drawing.Color.FromArgb(241,105,19),
										System.Drawing.Color.FromArgb(217,72,1),
										System.Drawing.Color.FromArgb(140,45,4),
									};
								}
							case 8:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,245,235),
										System.Drawing.Color.FromArgb(254,230,206),
										System.Drawing.Color.FromArgb(253,208,162),
										System.Drawing.Color.FromArgb(253,174,107),
										System.Drawing.Color.FromArgb(253,141,60),
										System.Drawing.Color.FromArgb(241,105,19),
										System.Drawing.Color.FromArgb(217,72,1),
										System.Drawing.Color.FromArgb(140,45,4),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,245,235),
										System.Drawing.Color.FromArgb(254,230,206),
										System.Drawing.Color.FromArgb(253,208,162),
										System.Drawing.Color.FromArgb(253,174,107),
										System.Drawing.Color.FromArgb(253,141,60),
										System.Drawing.Color.FromArgb(241,105,19),
										System.Drawing.Color.FromArgb(217,72,1),
										System.Drawing.Color.FromArgb(166,54,3),
										System.Drawing.Color.FromArgb(127,39,4),
									};
								}
						}
					}
				case "OrRd":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(254,232,200),
										System.Drawing.Color.FromArgb(253,187,132),
										System.Drawing.Color.FromArgb(227,74,51),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(254,240,217),
										System.Drawing.Color.FromArgb(253,204,138),
										System.Drawing.Color.FromArgb(252,141,89),
										System.Drawing.Color.FromArgb(215,48,31),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(254,240,217),
										System.Drawing.Color.FromArgb(253,204,138),
										System.Drawing.Color.FromArgb(252,141,89),
										System.Drawing.Color.FromArgb(227,74,51),
										System.Drawing.Color.FromArgb(179,0,0),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(254,240,217),
										System.Drawing.Color.FromArgb(253,212,158),
										System.Drawing.Color.FromArgb(253,187,132),
										System.Drawing.Color.FromArgb(252,141,89),
										System.Drawing.Color.FromArgb(227,74,51),
										System.Drawing.Color.FromArgb(179,0,0),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(254,240,217),
										System.Drawing.Color.FromArgb(253,212,158),
										System.Drawing.Color.FromArgb(253,187,132),
										System.Drawing.Color.FromArgb(252,141,89),
										System.Drawing.Color.FromArgb(239,101,72),
										System.Drawing.Color.FromArgb(215,48,31),
										System.Drawing.Color.FromArgb(153,0,0),
									};
								}
							case 8:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,247,236),
										System.Drawing.Color.FromArgb(254,232,200),
										System.Drawing.Color.FromArgb(253,212,158),
										System.Drawing.Color.FromArgb(253,187,132),
										System.Drawing.Color.FromArgb(252,141,89),
										System.Drawing.Color.FromArgb(239,101,72),
										System.Drawing.Color.FromArgb(215,48,31),
										System.Drawing.Color.FromArgb(153,0,0),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,247,236),
										System.Drawing.Color.FromArgb(254,232,200),
										System.Drawing.Color.FromArgb(253,212,158),
										System.Drawing.Color.FromArgb(253,187,132),
										System.Drawing.Color.FromArgb(252,141,89),
										System.Drawing.Color.FromArgb(239,101,72),
										System.Drawing.Color.FromArgb(215,48,31),
										System.Drawing.Color.FromArgb(179,0,0),
										System.Drawing.Color.FromArgb(127,0,0),
									};
								}
						}
					}
				case "Paired":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(166,206,227),
										System.Drawing.Color.FromArgb(31,120,180),
										System.Drawing.Color.FromArgb(178,223,138),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(166,206,227),
										System.Drawing.Color.FromArgb(31,120,180),
										System.Drawing.Color.FromArgb(178,223,138),
										System.Drawing.Color.FromArgb(51,160,44),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(166,206,227),
										System.Drawing.Color.FromArgb(31,120,180),
										System.Drawing.Color.FromArgb(178,223,138),
										System.Drawing.Color.FromArgb(51,160,44),
										System.Drawing.Color.FromArgb(251,154,153),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(166,206,227),
										System.Drawing.Color.FromArgb(31,120,180),
										System.Drawing.Color.FromArgb(178,223,138),
										System.Drawing.Color.FromArgb(51,160,44),
										System.Drawing.Color.FromArgb(251,154,153),
										System.Drawing.Color.FromArgb(227,26,28),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(166,206,227),
										System.Drawing.Color.FromArgb(31,120,180),
										System.Drawing.Color.FromArgb(178,223,138),
										System.Drawing.Color.FromArgb(51,160,44),
										System.Drawing.Color.FromArgb(251,154,153),
										System.Drawing.Color.FromArgb(227,26,28),
										System.Drawing.Color.FromArgb(253,191,111),
									};
								}
							case 8:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(166,206,227),
										System.Drawing.Color.FromArgb(31,120,180),
										System.Drawing.Color.FromArgb(178,223,138),
										System.Drawing.Color.FromArgb(51,160,44),
										System.Drawing.Color.FromArgb(251,154,153),
										System.Drawing.Color.FromArgb(227,26,28),
										System.Drawing.Color.FromArgb(253,191,111),
										System.Drawing.Color.FromArgb(255,127,0),
									};
								}
							case 9:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(166,206,227),
										System.Drawing.Color.FromArgb(31,120,180),
										System.Drawing.Color.FromArgb(178,223,138),
										System.Drawing.Color.FromArgb(51,160,44),
										System.Drawing.Color.FromArgb(251,154,153),
										System.Drawing.Color.FromArgb(227,26,28),
										System.Drawing.Color.FromArgb(253,191,111),
										System.Drawing.Color.FromArgb(255,127,0),
										System.Drawing.Color.FromArgb(202,178,214),
									};
								}
							case 10:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(166,206,227),
										System.Drawing.Color.FromArgb(31,120,180),
										System.Drawing.Color.FromArgb(178,223,138),
										System.Drawing.Color.FromArgb(51,160,44),
										System.Drawing.Color.FromArgb(251,154,153),
										System.Drawing.Color.FromArgb(227,26,28),
										System.Drawing.Color.FromArgb(253,191,111),
										System.Drawing.Color.FromArgb(255,127,0),
										System.Drawing.Color.FromArgb(202,178,214),
										System.Drawing.Color.FromArgb(106,61,154),
									};
								}
							case 11:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(166,206,227),
										System.Drawing.Color.FromArgb(31,120,180),
										System.Drawing.Color.FromArgb(178,223,138),
										System.Drawing.Color.FromArgb(51,160,44),
										System.Drawing.Color.FromArgb(251,154,153),
										System.Drawing.Color.FromArgb(227,26,28),
										System.Drawing.Color.FromArgb(253,191,111),
										System.Drawing.Color.FromArgb(255,127,0),
										System.Drawing.Color.FromArgb(202,178,214),
										System.Drawing.Color.FromArgb(106,61,154),
										System.Drawing.Color.FromArgb(255,255,153),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(166,206,227),
										System.Drawing.Color.FromArgb(31,120,180),
										System.Drawing.Color.FromArgb(178,223,138),
										System.Drawing.Color.FromArgb(51,160,44),
										System.Drawing.Color.FromArgb(251,154,153),
										System.Drawing.Color.FromArgb(227,26,28),
										System.Drawing.Color.FromArgb(253,191,111),
										System.Drawing.Color.FromArgb(255,127,0),
										System.Drawing.Color.FromArgb(202,178,214),
										System.Drawing.Color.FromArgb(106,61,154),
										System.Drawing.Color.FromArgb(255,255,153),
										System.Drawing.Color.FromArgb(177,89,40),
									};
								}
						}
					}
				case "Pastel1":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(251,180,174),
										System.Drawing.Color.FromArgb(179,205,227),
										System.Drawing.Color.FromArgb(204,235,197),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(251,180,174),
										System.Drawing.Color.FromArgb(179,205,227),
										System.Drawing.Color.FromArgb(204,235,197),
										System.Drawing.Color.FromArgb(222,203,228),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(251,180,174),
										System.Drawing.Color.FromArgb(179,205,227),
										System.Drawing.Color.FromArgb(204,235,197),
										System.Drawing.Color.FromArgb(222,203,228),
										System.Drawing.Color.FromArgb(254,217,166),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(251,180,174),
										System.Drawing.Color.FromArgb(179,205,227),
										System.Drawing.Color.FromArgb(204,235,197),
										System.Drawing.Color.FromArgb(222,203,228),
										System.Drawing.Color.FromArgb(254,217,166),
										System.Drawing.Color.FromArgb(255,255,204),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(251,180,174),
										System.Drawing.Color.FromArgb(179,205,227),
										System.Drawing.Color.FromArgb(204,235,197),
										System.Drawing.Color.FromArgb(222,203,228),
										System.Drawing.Color.FromArgb(254,217,166),
										System.Drawing.Color.FromArgb(255,255,204),
										System.Drawing.Color.FromArgb(229,216,189),
									};
								}
							case 8:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(251,180,174),
										System.Drawing.Color.FromArgb(179,205,227),
										System.Drawing.Color.FromArgb(204,235,197),
										System.Drawing.Color.FromArgb(222,203,228),
										System.Drawing.Color.FromArgb(254,217,166),
										System.Drawing.Color.FromArgb(255,255,204),
										System.Drawing.Color.FromArgb(229,216,189),
										System.Drawing.Color.FromArgb(253,218,236),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(251,180,174),
										System.Drawing.Color.FromArgb(179,205,227),
										System.Drawing.Color.FromArgb(204,235,197),
										System.Drawing.Color.FromArgb(222,203,228),
										System.Drawing.Color.FromArgb(254,217,166),
										System.Drawing.Color.FromArgb(255,255,204),
										System.Drawing.Color.FromArgb(229,216,189),
										System.Drawing.Color.FromArgb(253,218,236),
										System.Drawing.Color.FromArgb(242,242,242),
									};
								}
						}
					}
				case "Pastel2":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(179,226,205),
										System.Drawing.Color.FromArgb(253,205,172),
										System.Drawing.Color.FromArgb(203,213,232),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(179,226,205),
										System.Drawing.Color.FromArgb(253,205,172),
										System.Drawing.Color.FromArgb(203,213,232),
										System.Drawing.Color.FromArgb(244,202,228),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(179,226,205),
										System.Drawing.Color.FromArgb(253,205,172),
										System.Drawing.Color.FromArgb(203,213,232),
										System.Drawing.Color.FromArgb(244,202,228),
										System.Drawing.Color.FromArgb(230,245,201),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(179,226,205),
										System.Drawing.Color.FromArgb(253,205,172),
										System.Drawing.Color.FromArgb(203,213,232),
										System.Drawing.Color.FromArgb(244,202,228),
										System.Drawing.Color.FromArgb(230,245,201),
										System.Drawing.Color.FromArgb(255,242,174),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(179,226,205),
										System.Drawing.Color.FromArgb(253,205,172),
										System.Drawing.Color.FromArgb(203,213,232),
										System.Drawing.Color.FromArgb(244,202,228),
										System.Drawing.Color.FromArgb(230,245,201),
										System.Drawing.Color.FromArgb(255,242,174),
										System.Drawing.Color.FromArgb(241,226,204),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(179,226,205),
										System.Drawing.Color.FromArgb(253,205,172),
										System.Drawing.Color.FromArgb(203,213,232),
										System.Drawing.Color.FromArgb(244,202,228),
										System.Drawing.Color.FromArgb(230,245,201),
										System.Drawing.Color.FromArgb(255,242,174),
										System.Drawing.Color.FromArgb(241,226,204),
										System.Drawing.Color.FromArgb(204,204,204),
									};
								}
						}
					}
				case "PiYG":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(233,163,201),
										System.Drawing.Color.FromArgb(247,247,247),
										System.Drawing.Color.FromArgb(161,215,106),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(208,28,139),
										System.Drawing.Color.FromArgb(241,182,218),
										System.Drawing.Color.FromArgb(184,225,134),
										System.Drawing.Color.FromArgb(77,172,38),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(208,28,139),
										System.Drawing.Color.FromArgb(241,182,218),
										System.Drawing.Color.FromArgb(247,247,247),
										System.Drawing.Color.FromArgb(184,225,134),
										System.Drawing.Color.FromArgb(77,172,38),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(197,27,125),
										System.Drawing.Color.FromArgb(233,163,201),
										System.Drawing.Color.FromArgb(253,224,239),
										System.Drawing.Color.FromArgb(230,245,208),
										System.Drawing.Color.FromArgb(161,215,106),
										System.Drawing.Color.FromArgb(77,146,33),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(197,27,125),
										System.Drawing.Color.FromArgb(233,163,201),
										System.Drawing.Color.FromArgb(253,224,239),
										System.Drawing.Color.FromArgb(247,247,247),
										System.Drawing.Color.FromArgb(230,245,208),
										System.Drawing.Color.FromArgb(161,215,106),
										System.Drawing.Color.FromArgb(77,146,33),
									};
								}
							case 8:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(197,27,125),
										System.Drawing.Color.FromArgb(222,119,174),
										System.Drawing.Color.FromArgb(241,182,218),
										System.Drawing.Color.FromArgb(253,224,239),
										System.Drawing.Color.FromArgb(230,245,208),
										System.Drawing.Color.FromArgb(184,225,134),
										System.Drawing.Color.FromArgb(127,188,65),
										System.Drawing.Color.FromArgb(77,146,33),
									};
								}
							case 9:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(197,27,125),
										System.Drawing.Color.FromArgb(222,119,174),
										System.Drawing.Color.FromArgb(241,182,218),
										System.Drawing.Color.FromArgb(253,224,239),
										System.Drawing.Color.FromArgb(247,247,247),
										System.Drawing.Color.FromArgb(230,245,208),
										System.Drawing.Color.FromArgb(184,225,134),
										System.Drawing.Color.FromArgb(127,188,65),
										System.Drawing.Color.FromArgb(77,146,33),
									};
								}
							case 10:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(142,1,82),
										System.Drawing.Color.FromArgb(197,27,125),
										System.Drawing.Color.FromArgb(222,119,174),
										System.Drawing.Color.FromArgb(241,182,218),
										System.Drawing.Color.FromArgb(253,224,239),
										System.Drawing.Color.FromArgb(230,245,208),
										System.Drawing.Color.FromArgb(184,225,134),
										System.Drawing.Color.FromArgb(127,188,65),
										System.Drawing.Color.FromArgb(77,146,33),
										System.Drawing.Color.FromArgb(39,100,25),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(142,1,82),
										System.Drawing.Color.FromArgb(197,27,125),
										System.Drawing.Color.FromArgb(222,119,174),
										System.Drawing.Color.FromArgb(241,182,218),
										System.Drawing.Color.FromArgb(253,224,239),
										System.Drawing.Color.FromArgb(247,247,247),
										System.Drawing.Color.FromArgb(230,245,208),
										System.Drawing.Color.FromArgb(184,225,134),
										System.Drawing.Color.FromArgb(127,188,65),
										System.Drawing.Color.FromArgb(77,146,33),
										System.Drawing.Color.FromArgb(39,100,25),
									};
								}
						}
					}
				case "PRGn":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(175,141,195),
										System.Drawing.Color.FromArgb(247,247,247),
										System.Drawing.Color.FromArgb(127,191,123),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(123,50,148),
										System.Drawing.Color.FromArgb(194,165,207),
										System.Drawing.Color.FromArgb(166,219,160),
										System.Drawing.Color.FromArgb(0,136,55),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(123,50,148),
										System.Drawing.Color.FromArgb(194,165,207),
										System.Drawing.Color.FromArgb(247,247,247),
										System.Drawing.Color.FromArgb(166,219,160),
										System.Drawing.Color.FromArgb(0,136,55),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(118,42,131),
										System.Drawing.Color.FromArgb(175,141,195),
										System.Drawing.Color.FromArgb(231,212,232),
										System.Drawing.Color.FromArgb(217,240,211),
										System.Drawing.Color.FromArgb(127,191,123),
										System.Drawing.Color.FromArgb(27,120,55),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(118,42,131),
										System.Drawing.Color.FromArgb(175,141,195),
										System.Drawing.Color.FromArgb(231,212,232),
										System.Drawing.Color.FromArgb(247,247,247),
										System.Drawing.Color.FromArgb(217,240,211),
										System.Drawing.Color.FromArgb(127,191,123),
										System.Drawing.Color.FromArgb(27,120,55),
									};
								}
							case 8:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(118,42,131),
										System.Drawing.Color.FromArgb(153,112,171),
										System.Drawing.Color.FromArgb(194,165,207),
										System.Drawing.Color.FromArgb(231,212,232),
										System.Drawing.Color.FromArgb(217,240,211),
										System.Drawing.Color.FromArgb(166,219,160),
										System.Drawing.Color.FromArgb(90,174,97),
										System.Drawing.Color.FromArgb(27,120,55),
									};
								}
							case 9:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(118,42,131),
										System.Drawing.Color.FromArgb(153,112,171),
										System.Drawing.Color.FromArgb(194,165,207),
										System.Drawing.Color.FromArgb(231,212,232),
										System.Drawing.Color.FromArgb(247,247,247),
										System.Drawing.Color.FromArgb(217,240,211),
										System.Drawing.Color.FromArgb(166,219,160),
										System.Drawing.Color.FromArgb(90,174,97),
										System.Drawing.Color.FromArgb(27,120,55),
									};
								}
							case 10:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(64,0,75),
										System.Drawing.Color.FromArgb(118,42,131),
										System.Drawing.Color.FromArgb(153,112,171),
										System.Drawing.Color.FromArgb(194,165,207),
										System.Drawing.Color.FromArgb(231,212,232),
										System.Drawing.Color.FromArgb(217,240,211),
										System.Drawing.Color.FromArgb(166,219,160),
										System.Drawing.Color.FromArgb(90,174,97),
										System.Drawing.Color.FromArgb(27,120,55),
										System.Drawing.Color.FromArgb(0,68,27),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(64,0,75),
										System.Drawing.Color.FromArgb(118,42,131),
										System.Drawing.Color.FromArgb(153,112,171),
										System.Drawing.Color.FromArgb(194,165,207),
										System.Drawing.Color.FromArgb(231,212,232),
										System.Drawing.Color.FromArgb(247,247,247),
										System.Drawing.Color.FromArgb(217,240,211),
										System.Drawing.Color.FromArgb(166,219,160),
										System.Drawing.Color.FromArgb(90,174,97),
										System.Drawing.Color.FromArgb(27,120,55),
										System.Drawing.Color.FromArgb(0,68,27),
									};
								}
						}
					}
				case "PuBu":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(236,231,242),
										System.Drawing.Color.FromArgb(166,189,219),
										System.Drawing.Color.FromArgb(43,140,190),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(241,238,246),
										System.Drawing.Color.FromArgb(189,201,225),
										System.Drawing.Color.FromArgb(116,169,207),
										System.Drawing.Color.FromArgb(5,112,176),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(241,238,246),
										System.Drawing.Color.FromArgb(189,201,225),
										System.Drawing.Color.FromArgb(116,169,207),
										System.Drawing.Color.FromArgb(43,140,190),
										System.Drawing.Color.FromArgb(4,90,141),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(241,238,246),
										System.Drawing.Color.FromArgb(208,209,230),
										System.Drawing.Color.FromArgb(166,189,219),
										System.Drawing.Color.FromArgb(116,169,207),
										System.Drawing.Color.FromArgb(43,140,190),
										System.Drawing.Color.FromArgb(4,90,141),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(241,238,246),
										System.Drawing.Color.FromArgb(208,209,230),
										System.Drawing.Color.FromArgb(166,189,219),
										System.Drawing.Color.FromArgb(116,169,207),
										System.Drawing.Color.FromArgb(54,144,192),
										System.Drawing.Color.FromArgb(5,112,176),
										System.Drawing.Color.FromArgb(3,78,123),
									};
								}
							case 8:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,247,251),
										System.Drawing.Color.FromArgb(236,231,242),
										System.Drawing.Color.FromArgb(208,209,230),
										System.Drawing.Color.FromArgb(166,189,219),
										System.Drawing.Color.FromArgb(116,169,207),
										System.Drawing.Color.FromArgb(54,144,192),
										System.Drawing.Color.FromArgb(5,112,176),
										System.Drawing.Color.FromArgb(3,78,123),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,247,251),
										System.Drawing.Color.FromArgb(236,231,242),
										System.Drawing.Color.FromArgb(208,209,230),
										System.Drawing.Color.FromArgb(166,189,219),
										System.Drawing.Color.FromArgb(116,169,207),
										System.Drawing.Color.FromArgb(54,144,192),
										System.Drawing.Color.FromArgb(5,112,176),
										System.Drawing.Color.FromArgb(4,90,141),
										System.Drawing.Color.FromArgb(2,56,88),
									};
								}
						}
					}
				case "PuBuGn":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(236,226,240),
										System.Drawing.Color.FromArgb(166,189,219),
										System.Drawing.Color.FromArgb(28,144,153),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(246,239,247),
										System.Drawing.Color.FromArgb(189,201,225),
										System.Drawing.Color.FromArgb(103,169,207),
										System.Drawing.Color.FromArgb(2,129,138),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(246,239,247),
										System.Drawing.Color.FromArgb(189,201,225),
										System.Drawing.Color.FromArgb(103,169,207),
										System.Drawing.Color.FromArgb(28,144,153),
										System.Drawing.Color.FromArgb(1,108,89),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(246,239,247),
										System.Drawing.Color.FromArgb(208,209,230),
										System.Drawing.Color.FromArgb(166,189,219),
										System.Drawing.Color.FromArgb(103,169,207),
										System.Drawing.Color.FromArgb(28,144,153),
										System.Drawing.Color.FromArgb(1,108,89),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(246,239,247),
										System.Drawing.Color.FromArgb(208,209,230),
										System.Drawing.Color.FromArgb(166,189,219),
										System.Drawing.Color.FromArgb(103,169,207),
										System.Drawing.Color.FromArgb(54,144,192),
										System.Drawing.Color.FromArgb(2,129,138),
										System.Drawing.Color.FromArgb(1,100,80),
									};
								}
							case 8:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,247,251),
										System.Drawing.Color.FromArgb(236,226,240),
										System.Drawing.Color.FromArgb(208,209,230),
										System.Drawing.Color.FromArgb(166,189,219),
										System.Drawing.Color.FromArgb(103,169,207),
										System.Drawing.Color.FromArgb(54,144,192),
										System.Drawing.Color.FromArgb(2,129,138),
										System.Drawing.Color.FromArgb(1,100,80),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,247,251),
										System.Drawing.Color.FromArgb(236,226,240),
										System.Drawing.Color.FromArgb(208,209,230),
										System.Drawing.Color.FromArgb(166,189,219),
										System.Drawing.Color.FromArgb(103,169,207),
										System.Drawing.Color.FromArgb(54,144,192),
										System.Drawing.Color.FromArgb(2,129,138),
										System.Drawing.Color.FromArgb(1,108,89),
										System.Drawing.Color.FromArgb(1,70,54),
									};
								}
						}
					}
				case "PuOr":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(241,163,64),
										System.Drawing.Color.FromArgb(247,247,247),
										System.Drawing.Color.FromArgb(153,142,195),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(230,97,1),
										System.Drawing.Color.FromArgb(253,184,99),
										System.Drawing.Color.FromArgb(178,171,210),
										System.Drawing.Color.FromArgb(94,60,153),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(230,97,1),
										System.Drawing.Color.FromArgb(253,184,99),
										System.Drawing.Color.FromArgb(247,247,247),
										System.Drawing.Color.FromArgb(178,171,210),
										System.Drawing.Color.FromArgb(94,60,153),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(179,88,6),
										System.Drawing.Color.FromArgb(241,163,64),
										System.Drawing.Color.FromArgb(254,224,182),
										System.Drawing.Color.FromArgb(216,218,235),
										System.Drawing.Color.FromArgb(153,142,195),
										System.Drawing.Color.FromArgb(84,39,136),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(179,88,6),
										System.Drawing.Color.FromArgb(241,163,64),
										System.Drawing.Color.FromArgb(254,224,182),
										System.Drawing.Color.FromArgb(247,247,247),
										System.Drawing.Color.FromArgb(216,218,235),
										System.Drawing.Color.FromArgb(153,142,195),
										System.Drawing.Color.FromArgb(84,39,136),
									};
								}
							case 8:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(179,88,6),
										System.Drawing.Color.FromArgb(224,130,20),
										System.Drawing.Color.FromArgb(253,184,99),
										System.Drawing.Color.FromArgb(254,224,182),
										System.Drawing.Color.FromArgb(216,218,235),
										System.Drawing.Color.FromArgb(178,171,210),
										System.Drawing.Color.FromArgb(128,115,172),
										System.Drawing.Color.FromArgb(84,39,136),
									};
								}
							case 9:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(179,88,6),
										System.Drawing.Color.FromArgb(224,130,20),
										System.Drawing.Color.FromArgb(253,184,99),
										System.Drawing.Color.FromArgb(254,224,182),
										System.Drawing.Color.FromArgb(247,247,247),
										System.Drawing.Color.FromArgb(216,218,235),
										System.Drawing.Color.FromArgb(178,171,210),
										System.Drawing.Color.FromArgb(128,115,172),
										System.Drawing.Color.FromArgb(84,39,136),
									};
								}
							case 10:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(127,59,8),
										System.Drawing.Color.FromArgb(179,88,6),
										System.Drawing.Color.FromArgb(224,130,20),
										System.Drawing.Color.FromArgb(253,184,99),
										System.Drawing.Color.FromArgb(254,224,182),
										System.Drawing.Color.FromArgb(216,218,235),
										System.Drawing.Color.FromArgb(178,171,210),
										System.Drawing.Color.FromArgb(128,115,172),
										System.Drawing.Color.FromArgb(84,39,136),
										System.Drawing.Color.FromArgb(45,0,75),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(127,59,8),
										System.Drawing.Color.FromArgb(179,88,6),
										System.Drawing.Color.FromArgb(224,130,20),
										System.Drawing.Color.FromArgb(253,184,99),
										System.Drawing.Color.FromArgb(254,224,182),
										System.Drawing.Color.FromArgb(247,247,247),
										System.Drawing.Color.FromArgb(216,218,235),
										System.Drawing.Color.FromArgb(178,171,210),
										System.Drawing.Color.FromArgb(128,115,172),
										System.Drawing.Color.FromArgb(84,39,136),
										System.Drawing.Color.FromArgb(45,0,75),
									};
								}
						}
					}
				case "PuRd":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(231,225,239),
										System.Drawing.Color.FromArgb(201,148,199),
										System.Drawing.Color.FromArgb(221,28,119),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(241,238,246),
										System.Drawing.Color.FromArgb(215,181,216),
										System.Drawing.Color.FromArgb(223,101,176),
										System.Drawing.Color.FromArgb(206,18,86),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(241,238,246),
										System.Drawing.Color.FromArgb(215,181,216),
										System.Drawing.Color.FromArgb(223,101,176),
										System.Drawing.Color.FromArgb(221,28,119),
										System.Drawing.Color.FromArgb(152,0,67),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(241,238,246),
										System.Drawing.Color.FromArgb(212,185,218),
										System.Drawing.Color.FromArgb(201,148,199),
										System.Drawing.Color.FromArgb(223,101,176),
										System.Drawing.Color.FromArgb(221,28,119),
										System.Drawing.Color.FromArgb(152,0,67),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(241,238,246),
										System.Drawing.Color.FromArgb(212,185,218),
										System.Drawing.Color.FromArgb(201,148,199),
										System.Drawing.Color.FromArgb(223,101,176),
										System.Drawing.Color.FromArgb(231,41,138),
										System.Drawing.Color.FromArgb(206,18,86),
										System.Drawing.Color.FromArgb(145,0,63),
									};
								}
							case 8:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(247,244,249),
										System.Drawing.Color.FromArgb(231,225,239),
										System.Drawing.Color.FromArgb(212,185,218),
										System.Drawing.Color.FromArgb(201,148,199),
										System.Drawing.Color.FromArgb(223,101,176),
										System.Drawing.Color.FromArgb(231,41,138),
										System.Drawing.Color.FromArgb(206,18,86),
										System.Drawing.Color.FromArgb(145,0,63),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(247,244,249),
										System.Drawing.Color.FromArgb(231,225,239),
										System.Drawing.Color.FromArgb(212,185,218),
										System.Drawing.Color.FromArgb(201,148,199),
										System.Drawing.Color.FromArgb(223,101,176),
										System.Drawing.Color.FromArgb(231,41,138),
										System.Drawing.Color.FromArgb(206,18,86),
										System.Drawing.Color.FromArgb(152,0,67),
										System.Drawing.Color.FromArgb(103,0,31),
									};
								}
						}
					}
				case "Purples":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(239,237,245),
										System.Drawing.Color.FromArgb(188,189,220),
										System.Drawing.Color.FromArgb(117,107,177),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(242,240,247),
										System.Drawing.Color.FromArgb(203,201,226),
										System.Drawing.Color.FromArgb(158,154,200),
										System.Drawing.Color.FromArgb(106,81,163),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(242,240,247),
										System.Drawing.Color.FromArgb(203,201,226),
										System.Drawing.Color.FromArgb(158,154,200),
										System.Drawing.Color.FromArgb(117,107,177),
										System.Drawing.Color.FromArgb(84,39,143),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(242,240,247),
										System.Drawing.Color.FromArgb(218,218,235),
										System.Drawing.Color.FromArgb(188,189,220),
										System.Drawing.Color.FromArgb(158,154,200),
										System.Drawing.Color.FromArgb(117,107,177),
										System.Drawing.Color.FromArgb(84,39,143),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(242,240,247),
										System.Drawing.Color.FromArgb(218,218,235),
										System.Drawing.Color.FromArgb(188,189,220),
										System.Drawing.Color.FromArgb(158,154,200),
										System.Drawing.Color.FromArgb(128,125,186),
										System.Drawing.Color.FromArgb(106,81,163),
										System.Drawing.Color.FromArgb(74,20,134),
									};
								}
							case 8:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(252,251,253),
										System.Drawing.Color.FromArgb(239,237,245),
										System.Drawing.Color.FromArgb(218,218,235),
										System.Drawing.Color.FromArgb(188,189,220),
										System.Drawing.Color.FromArgb(158,154,200),
										System.Drawing.Color.FromArgb(128,125,186),
										System.Drawing.Color.FromArgb(106,81,163),
										System.Drawing.Color.FromArgb(74,20,134),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(252,251,253),
										System.Drawing.Color.FromArgb(239,237,245),
										System.Drawing.Color.FromArgb(218,218,235),
										System.Drawing.Color.FromArgb(188,189,220),
										System.Drawing.Color.FromArgb(158,154,200),
										System.Drawing.Color.FromArgb(128,125,186),
										System.Drawing.Color.FromArgb(106,81,163),
										System.Drawing.Color.FromArgb(84,39,143),
										System.Drawing.Color.FromArgb(63,0,125),
									};
								}
						}
					}
				case "RdBu":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(239,138,98),
										System.Drawing.Color.FromArgb(247,247,247),
										System.Drawing.Color.FromArgb(103,169,207),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(202,0,32),
										System.Drawing.Color.FromArgb(244,165,130),
										System.Drawing.Color.FromArgb(146,197,222),
										System.Drawing.Color.FromArgb(5,113,176),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(202,0,32),
										System.Drawing.Color.FromArgb(244,165,130),
										System.Drawing.Color.FromArgb(247,247,247),
										System.Drawing.Color.FromArgb(146,197,222),
										System.Drawing.Color.FromArgb(5,113,176),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(178,24,43),
										System.Drawing.Color.FromArgb(239,138,98),
										System.Drawing.Color.FromArgb(253,219,199),
										System.Drawing.Color.FromArgb(209,229,240),
										System.Drawing.Color.FromArgb(103,169,207),
										System.Drawing.Color.FromArgb(33,102,172),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(178,24,43),
										System.Drawing.Color.FromArgb(239,138,98),
										System.Drawing.Color.FromArgb(253,219,199),
										System.Drawing.Color.FromArgb(247,247,247),
										System.Drawing.Color.FromArgb(209,229,240),
										System.Drawing.Color.FromArgb(103,169,207),
										System.Drawing.Color.FromArgb(33,102,172),
									};
								}
							case 8:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(178,24,43),
										System.Drawing.Color.FromArgb(214,96,77),
										System.Drawing.Color.FromArgb(244,165,130),
										System.Drawing.Color.FromArgb(253,219,199),
										System.Drawing.Color.FromArgb(209,229,240),
										System.Drawing.Color.FromArgb(146,197,222),
										System.Drawing.Color.FromArgb(67,147,195),
										System.Drawing.Color.FromArgb(33,102,172),
									};
								}
							case 9:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(178,24,43),
										System.Drawing.Color.FromArgb(214,96,77),
										System.Drawing.Color.FromArgb(244,165,130),
										System.Drawing.Color.FromArgb(253,219,199),
										System.Drawing.Color.FromArgb(247,247,247),
										System.Drawing.Color.FromArgb(209,229,240),
										System.Drawing.Color.FromArgb(146,197,222),
										System.Drawing.Color.FromArgb(67,147,195),
										System.Drawing.Color.FromArgb(33,102,172),
									};
								}
							case 10:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(103,0,31),
										System.Drawing.Color.FromArgb(178,24,43),
										System.Drawing.Color.FromArgb(214,96,77),
										System.Drawing.Color.FromArgb(244,165,130),
										System.Drawing.Color.FromArgb(253,219,199),
										System.Drawing.Color.FromArgb(209,229,240),
										System.Drawing.Color.FromArgb(146,197,222),
										System.Drawing.Color.FromArgb(67,147,195),
										System.Drawing.Color.FromArgb(33,102,172),
										System.Drawing.Color.FromArgb(5,48,97),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(103,0,31),
										System.Drawing.Color.FromArgb(178,24,43),
										System.Drawing.Color.FromArgb(214,96,77),
										System.Drawing.Color.FromArgb(244,165,130),
										System.Drawing.Color.FromArgb(253,219,199),
										System.Drawing.Color.FromArgb(247,247,247),
										System.Drawing.Color.FromArgb(209,229,240),
										System.Drawing.Color.FromArgb(146,197,222),
										System.Drawing.Color.FromArgb(67,147,195),
										System.Drawing.Color.FromArgb(33,102,172),
										System.Drawing.Color.FromArgb(5,48,97),
									};
								}
						}
					}
				case "RdGy":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(239,138,98),
										System.Drawing.Color.FromArgb(255,255,255),
										System.Drawing.Color.FromArgb(153,153,153),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(202,0,32),
										System.Drawing.Color.FromArgb(244,165,130),
										System.Drawing.Color.FromArgb(186,186,186),
										System.Drawing.Color.FromArgb(64,64,64),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(202,0,32),
										System.Drawing.Color.FromArgb(244,165,130),
										System.Drawing.Color.FromArgb(255,255,255),
										System.Drawing.Color.FromArgb(186,186,186),
										System.Drawing.Color.FromArgb(64,64,64),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(178,24,43),
										System.Drawing.Color.FromArgb(239,138,98),
										System.Drawing.Color.FromArgb(253,219,199),
										System.Drawing.Color.FromArgb(224,224,224),
										System.Drawing.Color.FromArgb(153,153,153),
										System.Drawing.Color.FromArgb(77,77,77),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(178,24,43),
										System.Drawing.Color.FromArgb(239,138,98),
										System.Drawing.Color.FromArgb(253,219,199),
										System.Drawing.Color.FromArgb(255,255,255),
										System.Drawing.Color.FromArgb(224,224,224),
										System.Drawing.Color.FromArgb(153,153,153),
										System.Drawing.Color.FromArgb(77,77,77),
									};
								}
							case 8:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(178,24,43),
										System.Drawing.Color.FromArgb(214,96,77),
										System.Drawing.Color.FromArgb(244,165,130),
										System.Drawing.Color.FromArgb(253,219,199),
										System.Drawing.Color.FromArgb(224,224,224),
										System.Drawing.Color.FromArgb(186,186,186),
										System.Drawing.Color.FromArgb(135,135,135),
										System.Drawing.Color.FromArgb(77,77,77),
									};
								}
							case 9:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(178,24,43),
										System.Drawing.Color.FromArgb(214,96,77),
										System.Drawing.Color.FromArgb(244,165,130),
										System.Drawing.Color.FromArgb(253,219,199),
										System.Drawing.Color.FromArgb(255,255,255),
										System.Drawing.Color.FromArgb(224,224,224),
										System.Drawing.Color.FromArgb(186,186,186),
										System.Drawing.Color.FromArgb(135,135,135),
										System.Drawing.Color.FromArgb(77,77,77),
									};
								}
							case 10:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(103,0,31),
										System.Drawing.Color.FromArgb(178,24,43),
										System.Drawing.Color.FromArgb(214,96,77),
										System.Drawing.Color.FromArgb(244,165,130),
										System.Drawing.Color.FromArgb(253,219,199),
										System.Drawing.Color.FromArgb(224,224,224),
										System.Drawing.Color.FromArgb(186,186,186),
										System.Drawing.Color.FromArgb(135,135,135),
										System.Drawing.Color.FromArgb(77,77,77),
										System.Drawing.Color.FromArgb(26,26,26),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(103,0,31),
										System.Drawing.Color.FromArgb(178,24,43),
										System.Drawing.Color.FromArgb(214,96,77),
										System.Drawing.Color.FromArgb(244,165,130),
										System.Drawing.Color.FromArgb(253,219,199),
										System.Drawing.Color.FromArgb(255,255,255),
										System.Drawing.Color.FromArgb(224,224,224),
										System.Drawing.Color.FromArgb(186,186,186),
										System.Drawing.Color.FromArgb(135,135,135),
										System.Drawing.Color.FromArgb(77,77,77),
										System.Drawing.Color.FromArgb(26,26,26),
									};
								}
						}
					}
				case "RdPu":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(253,224,221),
										System.Drawing.Color.FromArgb(250,159,181),
										System.Drawing.Color.FromArgb(197,27,138),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(254,235,226),
										System.Drawing.Color.FromArgb(251,180,185),
										System.Drawing.Color.FromArgb(247,104,161),
										System.Drawing.Color.FromArgb(174,1,126),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(254,235,226),
										System.Drawing.Color.FromArgb(251,180,185),
										System.Drawing.Color.FromArgb(247,104,161),
										System.Drawing.Color.FromArgb(197,27,138),
										System.Drawing.Color.FromArgb(122,1,119),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(254,235,226),
										System.Drawing.Color.FromArgb(252,197,192),
										System.Drawing.Color.FromArgb(250,159,181),
										System.Drawing.Color.FromArgb(247,104,161),
										System.Drawing.Color.FromArgb(197,27,138),
										System.Drawing.Color.FromArgb(122,1,119),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(254,235,226),
										System.Drawing.Color.FromArgb(252,197,192),
										System.Drawing.Color.FromArgb(250,159,181),
										System.Drawing.Color.FromArgb(247,104,161),
										System.Drawing.Color.FromArgb(221,52,151),
										System.Drawing.Color.FromArgb(174,1,126),
										System.Drawing.Color.FromArgb(122,1,119),
									};
								}
							case 8:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,247,243),
										System.Drawing.Color.FromArgb(253,224,221),
										System.Drawing.Color.FromArgb(252,197,192),
										System.Drawing.Color.FromArgb(250,159,181),
										System.Drawing.Color.FromArgb(247,104,161),
										System.Drawing.Color.FromArgb(221,52,151),
										System.Drawing.Color.FromArgb(174,1,126),
										System.Drawing.Color.FromArgb(122,1,119),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,247,243),
										System.Drawing.Color.FromArgb(253,224,221),
										System.Drawing.Color.FromArgb(252,197,192),
										System.Drawing.Color.FromArgb(250,159,181),
										System.Drawing.Color.FromArgb(247,104,161),
										System.Drawing.Color.FromArgb(221,52,151),
										System.Drawing.Color.FromArgb(174,1,126),
										System.Drawing.Color.FromArgb(122,1,119),
										System.Drawing.Color.FromArgb(73,0,106),
									};
								}
						}
					}
				case "Reds":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(254,224,210),
										System.Drawing.Color.FromArgb(252,146,114),
										System.Drawing.Color.FromArgb(222,45,38),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(254,229,217),
										System.Drawing.Color.FromArgb(252,174,145),
										System.Drawing.Color.FromArgb(251,106,74),
										System.Drawing.Color.FromArgb(203,24,29),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(254,229,217),
										System.Drawing.Color.FromArgb(252,174,145),
										System.Drawing.Color.FromArgb(251,106,74),
										System.Drawing.Color.FromArgb(222,45,38),
										System.Drawing.Color.FromArgb(165,15,21),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(254,229,217),
										System.Drawing.Color.FromArgb(252,187,161),
										System.Drawing.Color.FromArgb(252,146,114),
										System.Drawing.Color.FromArgb(251,106,74),
										System.Drawing.Color.FromArgb(222,45,38),
										System.Drawing.Color.FromArgb(165,15,21),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(254,229,217),
										System.Drawing.Color.FromArgb(252,187,161),
										System.Drawing.Color.FromArgb(252,146,114),
										System.Drawing.Color.FromArgb(251,106,74),
										System.Drawing.Color.FromArgb(239,59,44),
										System.Drawing.Color.FromArgb(203,24,29),
										System.Drawing.Color.FromArgb(153,0,13),
									};
								}
							case 8:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,245,240),
										System.Drawing.Color.FromArgb(254,224,210),
										System.Drawing.Color.FromArgb(252,187,161),
										System.Drawing.Color.FromArgb(252,146,114),
										System.Drawing.Color.FromArgb(251,106,74),
										System.Drawing.Color.FromArgb(239,59,44),
										System.Drawing.Color.FromArgb(203,24,29),
										System.Drawing.Color.FromArgb(153,0,13),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,245,240),
										System.Drawing.Color.FromArgb(254,224,210),
										System.Drawing.Color.FromArgb(252,187,161),
										System.Drawing.Color.FromArgb(252,146,114),
										System.Drawing.Color.FromArgb(251,106,74),
										System.Drawing.Color.FromArgb(239,59,44),
										System.Drawing.Color.FromArgb(203,24,29),
										System.Drawing.Color.FromArgb(165,15,21),
										System.Drawing.Color.FromArgb(103,0,13),
									};
								}
						}
					}
				case "RdYlBu":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(252,141,89),
										System.Drawing.Color.FromArgb(255,255,191),
										System.Drawing.Color.FromArgb(145,191,219),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(215,25,28),
										System.Drawing.Color.FromArgb(253,174,97),
										System.Drawing.Color.FromArgb(171,217,233),
										System.Drawing.Color.FromArgb(44,123,182),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(215,25,28),
										System.Drawing.Color.FromArgb(253,174,97),
										System.Drawing.Color.FromArgb(255,255,191),
										System.Drawing.Color.FromArgb(171,217,233),
										System.Drawing.Color.FromArgb(44,123,182),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(215,48,39),
										System.Drawing.Color.FromArgb(252,141,89),
										System.Drawing.Color.FromArgb(254,224,144),
										System.Drawing.Color.FromArgb(224,243,248),
										System.Drawing.Color.FromArgb(145,191,219),
										System.Drawing.Color.FromArgb(69,117,180),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(215,48,39),
										System.Drawing.Color.FromArgb(252,141,89),
										System.Drawing.Color.FromArgb(254,224,144),
										System.Drawing.Color.FromArgb(255,255,191),
										System.Drawing.Color.FromArgb(224,243,248),
										System.Drawing.Color.FromArgb(145,191,219),
										System.Drawing.Color.FromArgb(69,117,180),
									};
								}
							case 8:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(215,48,39),
										System.Drawing.Color.FromArgb(244,109,67),
										System.Drawing.Color.FromArgb(253,174,97),
										System.Drawing.Color.FromArgb(254,224,144),
										System.Drawing.Color.FromArgb(224,243,248),
										System.Drawing.Color.FromArgb(171,217,233),
										System.Drawing.Color.FromArgb(116,173,209),
										System.Drawing.Color.FromArgb(69,117,180),
									};
								}
							case 9:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(215,48,39),
										System.Drawing.Color.FromArgb(244,109,67),
										System.Drawing.Color.FromArgb(253,174,97),
										System.Drawing.Color.FromArgb(254,224,144),
										System.Drawing.Color.FromArgb(255,255,191),
										System.Drawing.Color.FromArgb(224,243,248),
										System.Drawing.Color.FromArgb(171,217,233),
										System.Drawing.Color.FromArgb(116,173,209),
										System.Drawing.Color.FromArgb(69,117,180),
									};
								}
							case 10:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(165,0,38),
										System.Drawing.Color.FromArgb(215,48,39),
										System.Drawing.Color.FromArgb(244,109,67),
										System.Drawing.Color.FromArgb(253,174,97),
										System.Drawing.Color.FromArgb(254,224,144),
										System.Drawing.Color.FromArgb(224,243,248),
										System.Drawing.Color.FromArgb(171,217,233),
										System.Drawing.Color.FromArgb(116,173,209),
										System.Drawing.Color.FromArgb(69,117,180),
										System.Drawing.Color.FromArgb(49,54,149),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(165,0,38),
										System.Drawing.Color.FromArgb(215,48,39),
										System.Drawing.Color.FromArgb(244,109,67),
										System.Drawing.Color.FromArgb(253,174,97),
										System.Drawing.Color.FromArgb(254,224,144),
										System.Drawing.Color.FromArgb(255,255,191),
										System.Drawing.Color.FromArgb(224,243,248),
										System.Drawing.Color.FromArgb(171,217,233),
										System.Drawing.Color.FromArgb(116,173,209),
										System.Drawing.Color.FromArgb(69,117,180),
										System.Drawing.Color.FromArgb(49,54,149),
									};
								}
						}
					}
				case "RdYlGn":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(252,141,89),
										System.Drawing.Color.FromArgb(255,255,191),
										System.Drawing.Color.FromArgb(145,207,96),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(215,25,28),
										System.Drawing.Color.FromArgb(253,174,97),
										System.Drawing.Color.FromArgb(166,217,106),
										System.Drawing.Color.FromArgb(26,150,65),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(215,25,28),
										System.Drawing.Color.FromArgb(253,174,97),
										System.Drawing.Color.FromArgb(255,255,191),
										System.Drawing.Color.FromArgb(166,217,106),
										System.Drawing.Color.FromArgb(26,150,65),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(215,48,39),
										System.Drawing.Color.FromArgb(252,141,89),
										System.Drawing.Color.FromArgb(254,224,139),
										System.Drawing.Color.FromArgb(217,239,139),
										System.Drawing.Color.FromArgb(145,207,96),
										System.Drawing.Color.FromArgb(26,152,80),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(215,48,39),
										System.Drawing.Color.FromArgb(252,141,89),
										System.Drawing.Color.FromArgb(254,224,139),
										System.Drawing.Color.FromArgb(255,255,191),
										System.Drawing.Color.FromArgb(217,239,139),
										System.Drawing.Color.FromArgb(145,207,96),
										System.Drawing.Color.FromArgb(26,152,80),
									};
								}
							case 8:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(215,48,39),
										System.Drawing.Color.FromArgb(244,109,67),
										System.Drawing.Color.FromArgb(253,174,97),
										System.Drawing.Color.FromArgb(254,224,139),
										System.Drawing.Color.FromArgb(217,239,139),
										System.Drawing.Color.FromArgb(166,217,106),
										System.Drawing.Color.FromArgb(102,189,99),
										System.Drawing.Color.FromArgb(26,152,80),
									};
								}
							case 9:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(215,48,39),
										System.Drawing.Color.FromArgb(244,109,67),
										System.Drawing.Color.FromArgb(253,174,97),
										System.Drawing.Color.FromArgb(254,224,139),
										System.Drawing.Color.FromArgb(255,255,191),
										System.Drawing.Color.FromArgb(217,239,139),
										System.Drawing.Color.FromArgb(166,217,106),
										System.Drawing.Color.FromArgb(102,189,99),
										System.Drawing.Color.FromArgb(26,152,80),
									};
								}
							case 10:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(165,0,38),
										System.Drawing.Color.FromArgb(215,48,39),
										System.Drawing.Color.FromArgb(244,109,67),
										System.Drawing.Color.FromArgb(253,174,97),
										System.Drawing.Color.FromArgb(254,224,139),
										System.Drawing.Color.FromArgb(217,239,139),
										System.Drawing.Color.FromArgb(166,217,106),
										System.Drawing.Color.FromArgb(102,189,99),
										System.Drawing.Color.FromArgb(26,152,80),
										System.Drawing.Color.FromArgb(0,104,55),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(165,0,38),
										System.Drawing.Color.FromArgb(215,48,39),
										System.Drawing.Color.FromArgb(244,109,67),
										System.Drawing.Color.FromArgb(253,174,97),
										System.Drawing.Color.FromArgb(254,224,139),
										System.Drawing.Color.FromArgb(255,255,191),
										System.Drawing.Color.FromArgb(217,239,139),
										System.Drawing.Color.FromArgb(166,217,106),
										System.Drawing.Color.FromArgb(102,189,99),
										System.Drawing.Color.FromArgb(26,152,80),
										System.Drawing.Color.FromArgb(0,104,55),
									};
								}
						}
					}
				case "Set1":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(228,26,28),
										System.Drawing.Color.FromArgb(55,126,184),
										System.Drawing.Color.FromArgb(77,175,74),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(228,26,28),
										System.Drawing.Color.FromArgb(55,126,184),
										System.Drawing.Color.FromArgb(77,175,74),
										System.Drawing.Color.FromArgb(152,78,163),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(228,26,28),
										System.Drawing.Color.FromArgb(55,126,184),
										System.Drawing.Color.FromArgb(77,175,74),
										System.Drawing.Color.FromArgb(152,78,163),
										System.Drawing.Color.FromArgb(255,127,0),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(228,26,28),
										System.Drawing.Color.FromArgb(55,126,184),
										System.Drawing.Color.FromArgb(77,175,74),
										System.Drawing.Color.FromArgb(152,78,163),
										System.Drawing.Color.FromArgb(255,127,0),
										System.Drawing.Color.FromArgb(255,255,51),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(228,26,28),
										System.Drawing.Color.FromArgb(55,126,184),
										System.Drawing.Color.FromArgb(77,175,74),
										System.Drawing.Color.FromArgb(152,78,163),
										System.Drawing.Color.FromArgb(255,127,0),
										System.Drawing.Color.FromArgb(255,255,51),
										System.Drawing.Color.FromArgb(166,86,40),
									};
								}
							case 8:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(228,26,28),
										System.Drawing.Color.FromArgb(55,126,184),
										System.Drawing.Color.FromArgb(77,175,74),
										System.Drawing.Color.FromArgb(152,78,163),
										System.Drawing.Color.FromArgb(255,127,0),
										System.Drawing.Color.FromArgb(255,255,51),
										System.Drawing.Color.FromArgb(166,86,40),
										System.Drawing.Color.FromArgb(247,129,191),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(228,26,28),
										System.Drawing.Color.FromArgb(55,126,184),
										System.Drawing.Color.FromArgb(77,175,74),
										System.Drawing.Color.FromArgb(152,78,163),
										System.Drawing.Color.FromArgb(255,127,0),
										System.Drawing.Color.FromArgb(255,255,51),
										System.Drawing.Color.FromArgb(166,86,40),
										System.Drawing.Color.FromArgb(247,129,191),
										System.Drawing.Color.FromArgb(153,153,153),
									};
								}
						}
					}
				case "Set2":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(102,194,165),
										System.Drawing.Color.FromArgb(252,141,98),
										System.Drawing.Color.FromArgb(141,160,203),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(102,194,165),
										System.Drawing.Color.FromArgb(252,141,98),
										System.Drawing.Color.FromArgb(141,160,203),
										System.Drawing.Color.FromArgb(231,138,195),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(102,194,165),
										System.Drawing.Color.FromArgb(252,141,98),
										System.Drawing.Color.FromArgb(141,160,203),
										System.Drawing.Color.FromArgb(231,138,195),
										System.Drawing.Color.FromArgb(166,216,84),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(102,194,165),
										System.Drawing.Color.FromArgb(252,141,98),
										System.Drawing.Color.FromArgb(141,160,203),
										System.Drawing.Color.FromArgb(231,138,195),
										System.Drawing.Color.FromArgb(166,216,84),
										System.Drawing.Color.FromArgb(255,217,47),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(102,194,165),
										System.Drawing.Color.FromArgb(252,141,98),
										System.Drawing.Color.FromArgb(141,160,203),
										System.Drawing.Color.FromArgb(231,138,195),
										System.Drawing.Color.FromArgb(166,216,84),
										System.Drawing.Color.FromArgb(255,217,47),
										System.Drawing.Color.FromArgb(229,196,148),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(102,194,165),
										System.Drawing.Color.FromArgb(252,141,98),
										System.Drawing.Color.FromArgb(141,160,203),
										System.Drawing.Color.FromArgb(231,138,195),
										System.Drawing.Color.FromArgb(166,216,84),
										System.Drawing.Color.FromArgb(255,217,47),
										System.Drawing.Color.FromArgb(229,196,148),
										System.Drawing.Color.FromArgb(179,179,179),
									};
								}
						}
					}
				case "Set3":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(141,211,199),
										System.Drawing.Color.FromArgb(255,255,179),
										System.Drawing.Color.FromArgb(190,186,218),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(141,211,199),
										System.Drawing.Color.FromArgb(255,255,179),
										System.Drawing.Color.FromArgb(190,186,218),
										System.Drawing.Color.FromArgb(251,128,114),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(141,211,199),
										System.Drawing.Color.FromArgb(255,255,179),
										System.Drawing.Color.FromArgb(190,186,218),
										System.Drawing.Color.FromArgb(251,128,114),
										System.Drawing.Color.FromArgb(128,177,211),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(141,211,199),
										System.Drawing.Color.FromArgb(255,255,179),
										System.Drawing.Color.FromArgb(190,186,218),
										System.Drawing.Color.FromArgb(251,128,114),
										System.Drawing.Color.FromArgb(128,177,211),
										System.Drawing.Color.FromArgb(253,180,98),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(141,211,199),
										System.Drawing.Color.FromArgb(255,255,179),
										System.Drawing.Color.FromArgb(190,186,218),
										System.Drawing.Color.FromArgb(251,128,114),
										System.Drawing.Color.FromArgb(128,177,211),
										System.Drawing.Color.FromArgb(253,180,98),
										System.Drawing.Color.FromArgb(179,222,105),
									};
								}
							case 8:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(141,211,199),
										System.Drawing.Color.FromArgb(255,255,179),
										System.Drawing.Color.FromArgb(190,186,218),
										System.Drawing.Color.FromArgb(251,128,114),
										System.Drawing.Color.FromArgb(128,177,211),
										System.Drawing.Color.FromArgb(253,180,98),
										System.Drawing.Color.FromArgb(179,222,105),
										System.Drawing.Color.FromArgb(252,205,229),
									};
								}
							case 9:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(141,211,199),
										System.Drawing.Color.FromArgb(255,255,179),
										System.Drawing.Color.FromArgb(190,186,218),
										System.Drawing.Color.FromArgb(251,128,114),
										System.Drawing.Color.FromArgb(128,177,211),
										System.Drawing.Color.FromArgb(253,180,98),
										System.Drawing.Color.FromArgb(179,222,105),
										System.Drawing.Color.FromArgb(252,205,229),
										System.Drawing.Color.FromArgb(217,217,217),
									};
								}
							case 10:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(141,211,199),
										System.Drawing.Color.FromArgb(255,255,179),
										System.Drawing.Color.FromArgb(190,186,218),
										System.Drawing.Color.FromArgb(251,128,114),
										System.Drawing.Color.FromArgb(128,177,211),
										System.Drawing.Color.FromArgb(253,180,98),
										System.Drawing.Color.FromArgb(179,222,105),
										System.Drawing.Color.FromArgb(252,205,229),
										System.Drawing.Color.FromArgb(217,217,217),
										System.Drawing.Color.FromArgb(188,128,189),
									};
								}
							case 11:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(141,211,199),
										System.Drawing.Color.FromArgb(255,255,179),
										System.Drawing.Color.FromArgb(190,186,218),
										System.Drawing.Color.FromArgb(251,128,114),
										System.Drawing.Color.FromArgb(128,177,211),
										System.Drawing.Color.FromArgb(253,180,98),
										System.Drawing.Color.FromArgb(179,222,105),
										System.Drawing.Color.FromArgb(252,205,229),
										System.Drawing.Color.FromArgb(217,217,217),
										System.Drawing.Color.FromArgb(188,128,189),
										System.Drawing.Color.FromArgb(204,235,197),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(141,211,199),
										System.Drawing.Color.FromArgb(255,255,179),
										System.Drawing.Color.FromArgb(190,186,218),
										System.Drawing.Color.FromArgb(251,128,114),
										System.Drawing.Color.FromArgb(128,177,211),
										System.Drawing.Color.FromArgb(253,180,98),
										System.Drawing.Color.FromArgb(179,222,105),
										System.Drawing.Color.FromArgb(252,205,229),
										System.Drawing.Color.FromArgb(217,217,217),
										System.Drawing.Color.FromArgb(188,128,189),
										System.Drawing.Color.FromArgb(204,235,197),
										System.Drawing.Color.FromArgb(255,237,111),
									};
								}
						}
					}
				case "Spectral":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(252,141,89),
										System.Drawing.Color.FromArgb(255,255,191),
										System.Drawing.Color.FromArgb(153,213,148),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(215,25,28),
										System.Drawing.Color.FromArgb(253,174,97),
										System.Drawing.Color.FromArgb(171,221,164),
										System.Drawing.Color.FromArgb(43,131,186),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(215,25,28),
										System.Drawing.Color.FromArgb(253,174,97),
										System.Drawing.Color.FromArgb(255,255,191),
										System.Drawing.Color.FromArgb(171,221,164),
										System.Drawing.Color.FromArgb(43,131,186),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(213,62,79),
										System.Drawing.Color.FromArgb(252,141,89),
										System.Drawing.Color.FromArgb(254,224,139),
										System.Drawing.Color.FromArgb(230,245,152),
										System.Drawing.Color.FromArgb(153,213,148),
										System.Drawing.Color.FromArgb(50,136,189),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(213,62,79),
										System.Drawing.Color.FromArgb(252,141,89),
										System.Drawing.Color.FromArgb(254,224,139),
										System.Drawing.Color.FromArgb(255,255,191),
										System.Drawing.Color.FromArgb(230,245,152),
										System.Drawing.Color.FromArgb(153,213,148),
										System.Drawing.Color.FromArgb(50,136,189),
									};
								}
							case 8:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(213,62,79),
										System.Drawing.Color.FromArgb(244,109,67),
										System.Drawing.Color.FromArgb(253,174,97),
										System.Drawing.Color.FromArgb(254,224,139),
										System.Drawing.Color.FromArgb(230,245,152),
										System.Drawing.Color.FromArgb(171,221,164),
										System.Drawing.Color.FromArgb(102,194,165),
										System.Drawing.Color.FromArgb(50,136,189),
									};
								}
							case 9:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(213,62,79),
										System.Drawing.Color.FromArgb(244,109,67),
										System.Drawing.Color.FromArgb(253,174,97),
										System.Drawing.Color.FromArgb(254,224,139),
										System.Drawing.Color.FromArgb(255,255,191),
										System.Drawing.Color.FromArgb(230,245,152),
										System.Drawing.Color.FromArgb(171,221,164),
										System.Drawing.Color.FromArgb(102,194,165),
										System.Drawing.Color.FromArgb(50,136,189),
									};
								}
							case 10:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(158,1,66),
										System.Drawing.Color.FromArgb(213,62,79),
										System.Drawing.Color.FromArgb(244,109,67),
										System.Drawing.Color.FromArgb(253,174,97),
										System.Drawing.Color.FromArgb(254,224,139),
										System.Drawing.Color.FromArgb(230,245,152),
										System.Drawing.Color.FromArgb(171,221,164),
										System.Drawing.Color.FromArgb(102,194,165),
										System.Drawing.Color.FromArgb(50,136,189),
										System.Drawing.Color.FromArgb(94,79,162),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(158,1,66),
										System.Drawing.Color.FromArgb(213,62,79),
										System.Drawing.Color.FromArgb(244,109,67),
										System.Drawing.Color.FromArgb(253,174,97),
										System.Drawing.Color.FromArgb(254,224,139),
										System.Drawing.Color.FromArgb(255,255,191),
										System.Drawing.Color.FromArgb(230,245,152),
										System.Drawing.Color.FromArgb(171,221,164),
										System.Drawing.Color.FromArgb(102,194,165),
										System.Drawing.Color.FromArgb(50,136,189),
										System.Drawing.Color.FromArgb(94,79,162),
									};
								}
						}
					}
				case "YlGn":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(247,252,185),
										System.Drawing.Color.FromArgb(173,221,142),
										System.Drawing.Color.FromArgb(49,163,84),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,255,204),
										System.Drawing.Color.FromArgb(194,230,153),
										System.Drawing.Color.FromArgb(120,198,121),
										System.Drawing.Color.FromArgb(35,132,67),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,255,204),
										System.Drawing.Color.FromArgb(194,230,153),
										System.Drawing.Color.FromArgb(120,198,121),
										System.Drawing.Color.FromArgb(49,163,84),
										System.Drawing.Color.FromArgb(0,104,55),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,255,204),
										System.Drawing.Color.FromArgb(217,240,163),
										System.Drawing.Color.FromArgb(173,221,142),
										System.Drawing.Color.FromArgb(120,198,121),
										System.Drawing.Color.FromArgb(49,163,84),
										System.Drawing.Color.FromArgb(0,104,55),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,255,204),
										System.Drawing.Color.FromArgb(217,240,163),
										System.Drawing.Color.FromArgb(173,221,142),
										System.Drawing.Color.FromArgb(120,198,121),
										System.Drawing.Color.FromArgb(65,171,93),
										System.Drawing.Color.FromArgb(35,132,67),
										System.Drawing.Color.FromArgb(0,90,50),
									};
								}
							case 8:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,255,229),
										System.Drawing.Color.FromArgb(247,252,185),
										System.Drawing.Color.FromArgb(217,240,163),
										System.Drawing.Color.FromArgb(173,221,142),
										System.Drawing.Color.FromArgb(120,198,121),
										System.Drawing.Color.FromArgb(65,171,93),
										System.Drawing.Color.FromArgb(35,132,67),
										System.Drawing.Color.FromArgb(0,90,50),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,255,229),
										System.Drawing.Color.FromArgb(247,252,185),
										System.Drawing.Color.FromArgb(217,240,163),
										System.Drawing.Color.FromArgb(173,221,142),
										System.Drawing.Color.FromArgb(120,198,121),
										System.Drawing.Color.FromArgb(65,171,93),
										System.Drawing.Color.FromArgb(35,132,67),
										System.Drawing.Color.FromArgb(0,104,55),
										System.Drawing.Color.FromArgb(0,69,41),
									};
								}
						}
					}
				case "YlGnBu":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(237,248,177),
										System.Drawing.Color.FromArgb(127,205,187),
										System.Drawing.Color.FromArgb(44,127,184),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,255,204),
										System.Drawing.Color.FromArgb(161,218,180),
										System.Drawing.Color.FromArgb(65,182,196),
										System.Drawing.Color.FromArgb(34,94,168),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,255,204),
										System.Drawing.Color.FromArgb(161,218,180),
										System.Drawing.Color.FromArgb(65,182,196),
										System.Drawing.Color.FromArgb(44,127,184),
										System.Drawing.Color.FromArgb(37,52,148),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,255,204),
										System.Drawing.Color.FromArgb(199,233,180),
										System.Drawing.Color.FromArgb(127,205,187),
										System.Drawing.Color.FromArgb(65,182,196),
										System.Drawing.Color.FromArgb(44,127,184),
										System.Drawing.Color.FromArgb(37,52,148),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,255,204),
										System.Drawing.Color.FromArgb(199,233,180),
										System.Drawing.Color.FromArgb(127,205,187),
										System.Drawing.Color.FromArgb(65,182,196),
										System.Drawing.Color.FromArgb(29,145,192),
										System.Drawing.Color.FromArgb(34,94,168),
										System.Drawing.Color.FromArgb(12,44,132),
									};
								}
							case 8:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,255,217),
										System.Drawing.Color.FromArgb(237,248,177),
										System.Drawing.Color.FromArgb(199,233,180),
										System.Drawing.Color.FromArgb(127,205,187),
										System.Drawing.Color.FromArgb(65,182,196),
										System.Drawing.Color.FromArgb(29,145,192),
										System.Drawing.Color.FromArgb(34,94,168),
										System.Drawing.Color.FromArgb(12,44,132),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,255,217),
										System.Drawing.Color.FromArgb(237,248,177),
										System.Drawing.Color.FromArgb(199,233,180),
										System.Drawing.Color.FromArgb(127,205,187),
										System.Drawing.Color.FromArgb(65,182,196),
										System.Drawing.Color.FromArgb(29,145,192),
										System.Drawing.Color.FromArgb(34,94,168),
										System.Drawing.Color.FromArgb(37,52,148),
										System.Drawing.Color.FromArgb(8,29,88),
									};
								}
						}
					}
				case "YlOrBr":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,247,188),
										System.Drawing.Color.FromArgb(254,196,79),
										System.Drawing.Color.FromArgb(217,95,14),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,255,212),
										System.Drawing.Color.FromArgb(254,217,142),
										System.Drawing.Color.FromArgb(254,153,41),
										System.Drawing.Color.FromArgb(204,76,2),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,255,212),
										System.Drawing.Color.FromArgb(254,217,142),
										System.Drawing.Color.FromArgb(254,153,41),
										System.Drawing.Color.FromArgb(217,95,14),
										System.Drawing.Color.FromArgb(153,52,4),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,255,212),
										System.Drawing.Color.FromArgb(254,227,145),
										System.Drawing.Color.FromArgb(254,196,79),
										System.Drawing.Color.FromArgb(254,153,41),
										System.Drawing.Color.FromArgb(217,95,14),
										System.Drawing.Color.FromArgb(153,52,4),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,255,212),
										System.Drawing.Color.FromArgb(254,227,145),
										System.Drawing.Color.FromArgb(254,196,79),
										System.Drawing.Color.FromArgb(254,153,41),
										System.Drawing.Color.FromArgb(236,112,20),
										System.Drawing.Color.FromArgb(204,76,2),
										System.Drawing.Color.FromArgb(140,45,4),
									};
								}
							case 8:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,255,229),
										System.Drawing.Color.FromArgb(255,247,188),
										System.Drawing.Color.FromArgb(254,227,145),
										System.Drawing.Color.FromArgb(254,196,79),
										System.Drawing.Color.FromArgb(254,153,41),
										System.Drawing.Color.FromArgb(236,112,20),
										System.Drawing.Color.FromArgb(204,76,2),
										System.Drawing.Color.FromArgb(140,45,4),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,255,229),
										System.Drawing.Color.FromArgb(255,247,188),
										System.Drawing.Color.FromArgb(254,227,145),
										System.Drawing.Color.FromArgb(254,196,79),
										System.Drawing.Color.FromArgb(254,153,41),
										System.Drawing.Color.FromArgb(236,112,20),
										System.Drawing.Color.FromArgb(204,76,2),
										System.Drawing.Color.FromArgb(153,52,4),
										System.Drawing.Color.FromArgb(102,37,6),
									};
								}
						}
					}
				case "YlOrRd":
					{
						switch (count)
						{
							case 3:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,237,160),
										System.Drawing.Color.FromArgb(254,178,76),
										System.Drawing.Color.FromArgb(240,59,32),
									};
								}
							case 4:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,255,178),
										System.Drawing.Color.FromArgb(254,204,92),
										System.Drawing.Color.FromArgb(253,141,60),
										System.Drawing.Color.FromArgb(227,26,28),
									};
								}
							case 5:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,255,178),
										System.Drawing.Color.FromArgb(254,204,92),
										System.Drawing.Color.FromArgb(253,141,60),
										System.Drawing.Color.FromArgb(240,59,32),
										System.Drawing.Color.FromArgb(189,0,38),
									};
								}
							case 6:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,255,178),
										System.Drawing.Color.FromArgb(254,217,118),
										System.Drawing.Color.FromArgb(254,178,76),
										System.Drawing.Color.FromArgb(253,141,60),
										System.Drawing.Color.FromArgb(240,59,32),
										System.Drawing.Color.FromArgb(189,0,38),
									};
								}
							case 7:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,255,178),
										System.Drawing.Color.FromArgb(254,217,118),
										System.Drawing.Color.FromArgb(254,178,76),
										System.Drawing.Color.FromArgb(253,141,60),
										System.Drawing.Color.FromArgb(252,78,42),
										System.Drawing.Color.FromArgb(227,26,28),
										System.Drawing.Color.FromArgb(177,0,38),
									};
								}
							case 8:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,255,204),
										System.Drawing.Color.FromArgb(255,237,160),
										System.Drawing.Color.FromArgb(254,217,118),
										System.Drawing.Color.FromArgb(254,178,76),
										System.Drawing.Color.FromArgb(253,141,60),
										System.Drawing.Color.FromArgb(252,78,42),
										System.Drawing.Color.FromArgb(227,26,28),
										System.Drawing.Color.FromArgb(177,0,38),
									};
								}
							default:
								{
									return new System.Drawing.Color[] {
										System.Drawing.Color.FromArgb(255,255,204),
										System.Drawing.Color.FromArgb(255,237,160),
										System.Drawing.Color.FromArgb(254,217,118),
										System.Drawing.Color.FromArgb(254,178,76),
										System.Drawing.Color.FromArgb(253,141,60),
										System.Drawing.Color.FromArgb(252,78,42),
										System.Drawing.Color.FromArgb(227,26,28),
										System.Drawing.Color.FromArgb(189,0,38),
										System.Drawing.Color.FromArgb(128,0,38),
									};
								}
						}
					}
				default:
					{
						throw new System.Exception("Invalid color scheme: " + name);
					}
			}

			#endregion
		}

		public static System.Drawing.Brush[] Brushes(string name, int count)
		{
			System.Drawing.Color[] colors = Colors(name, count);
			System.Drawing.Brush[] brushes = new System.Drawing.Brush[colors.Length];
			for (int i = 0; i < brushes.Length; i++)
				brushes[i] = new System.Drawing.SolidBrush(colors[i]);
			return brushes;
		}

		public static System.Drawing.Pen[] Pens(string name, int count)
		{
			System.Drawing.Color[] colors = Colors(name, count);
			System.Drawing.Pen[] pens = new System.Drawing.Pen[colors.Length];
			for (int i = 0; i < pens.Length; i++)
				pens[i] = new System.Drawing.Pen(colors[i]);
			return pens;
		}

	}
}
