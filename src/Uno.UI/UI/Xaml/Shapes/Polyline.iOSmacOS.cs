﻿using System;
using CoreGraphics;
using Uno.Media;
using Windows.Foundation;

namespace Windows.UI.Xaml.Shapes
{
	public partial class Polyline : Shape
	{
		/// <inheritdoc />
		protected override Size MeasureOverride(Size availableSize)
			=> MeasureAbsoluteShape(availableSize, GetPath());

		/// <inheritdoc />
		protected override Size ArrangeOverride(Size finalSize)
			=> ArrangeAbsoluteShape(finalSize, GetPath());

		private CGPath GetPath()
		{
			var coords = Points;

			if (coords != null && coords.Count > 1)
			{
				var streamGeometry = GeometryHelper.Build(c =>
				{
					c.BeginFigure(coords[0], true, false);
					for (var i = 1; i < coords.Count; i++)
					{
						c.LineTo(coords[i], true, false);
					}
				});

				return streamGeometry.ToCGPath();
			}

			return null;
		}
	}
}
