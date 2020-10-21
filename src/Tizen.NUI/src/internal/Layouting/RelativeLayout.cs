/* Copyright (c) 2019 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using System.Collections.Generic;
using System.Globalization;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI
{
    // Methods and Properties for calculation.
    public partial class RelativeLayout
    {
        private readonly Dictionary<View, (float left, float right)> HorizontalMultiplierCache = new Dictionary<View, (float, float)>();
        private readonly Dictionary<View, (float top, float bottom)> VerticalMultiplierCache = new Dictionary<View, (float, float)>();
        private readonly Dictionary<View, (float position, float length)> HorizontalGeometryCache = new Dictionary<View, (float, float)>();
        private readonly Dictionary<View, (float position, float length)> VerticalGeometryCache = new Dictionary<View, (float, float)>();

        private float NormalizeMultiplier(float value, float start, float end) => start + (end - start) * value;

        private void InitMultiplierCache()
        {
            HorizontalMultiplierCache.Clear();
            VerticalMultiplierCache.Clear();
            HorizontalGeometryCache.Clear();
            VerticalGeometryCache.Clear();
        }

        private (float left, float right) CalculateHorizontalNormalizedMultiplier(View view)
        {
            if (view == Owner)
                return (0.0f, 1.0f);

            if (HorizontalMultiplierCache.TryGetValue(view, out (float left, float right) cachedValue))
                return (cachedValue.left, cachedValue.right);

            View leftTarget = GetLeftTarget(view) ?? Owner;
            View rightTarget = GetRightTarget(view) ?? Owner;
            float leftMultiplier = GetLeftMultiplier(view);
            float rightMultiplier = GetRightMultiplier(view);

            (float left, float right) leftTargetMultiplier = CalculateHorizontalNormalizedMultiplier(leftTarget);
            (float left, float right) rightTargetMultiplier = CalculateHorizontalNormalizedMultiplier(rightTarget);

            float leftNormalizeMultiplier = NormalizeMultiplier(leftMultiplier, leftTargetMultiplier.left, leftTargetMultiplier.right);
            float rightNormalizeMultiplier = NormalizeMultiplier(rightMultiplier, rightTargetMultiplier.left, rightTargetMultiplier.right);

            HorizontalMultiplierCache.Add(view, (leftNormalizeMultiplier, rightNormalizeMultiplier));

            return (leftNormalizeMultiplier, rightNormalizeMultiplier);
        }

        private (float top, float bottom) CalculateVerticalNormalizedMultiplier(View view)
        {
            if (view == Owner)
                return (0.0f, 1.0f);

            if (VerticalMultiplierCache.TryGetValue(view, out (float top, float bottom) cachedValue))
                return (cachedValue.top, cachedValue.bottom);

            View topTarget = GetTopTarget(view) ?? Owner;
            View bottomTarget = GetBottomTarget(view) ?? Owner;
            float topMultiplier = GetTopMultiplier(view);
            float bottomMultiplier = GetBottomMultiplier(view);

            (float top, float bottom) topTargetMultiplier = CalculateVerticalNormalizedMultiplier(topTarget);
            (float top, float bottom) bottomTargetMultiplier = CalculateVerticalNormalizedMultiplier(bottomTarget);

            float topNormalizeMultiplier = NormalizeMultiplier(topMultiplier, topTargetMultiplier.top, topTargetMultiplier.bottom);
            float bottomNormalizeMultiplier = NormalizeMultiplier(bottomMultiplier, bottomTargetMultiplier.top, bottomTargetMultiplier.bottom);

            VerticalMultiplierCache.Add(view, (topNormalizeMultiplier, bottomNormalizeMultiplier));

            return (topNormalizeMultiplier, bottomNormalizeMultiplier);
        }

        private (float left, float width) CalculateHorizontalGeometry(View view)
        {
            if (view == Owner)
                return (0.0f, MeasuredWidth.Size.AsDecimal());

            if (HorizontalGeometryCache.TryGetValue(view, out (float position, float legnth) cachedValue))
                return (cachedValue.position, cachedValue.legnth);

            View leftTarget = GetLeftTarget(view) ?? Owner;
            View rightTarget = GetRightTarget(view) ?? Owner;
            float leftMultiplier = GetLeftMultiplier(view);
            float rightMultiplier = GetRightMultiplier(view);

            (float position, float legnth) leftGeometry = CalculateHorizontalGeometry(leftTarget);
            (float position, float legnth) rightGeometry = CalculateHorizontalGeometry(rightTarget);

            float spaceLeft = leftGeometry.position + (leftGeometry.legnth * leftMultiplier);
            float spaceRight = rightGeometry.position + (rightGeometry.legnth * rightMultiplier);

            float horizontalAlignment = GetHorizontalAlignment(view).ToFloat();

            float width;
            if (view.Layout.MeasuredWidth.Size.AsDecimal() < float.Epsilon)
                width = spaceRight - spaceLeft;
            else
                width = view.Layout.MeasuredWidth.Size.AsDecimal();

            HorizontalGeometryCache.Add(view, (spaceLeft + ((spaceRight - spaceLeft) - width) * horizontalAlignment, width));

            return (spaceLeft + ((spaceRight - spaceLeft) - width) * horizontalAlignment, width);
        }
        private (float top, float height) CalculateVerticalGeometry(View view)
        {
            if (view == Owner)
                return (0.0f, MeasuredHeight.Size.AsDecimal());

            if (VerticalGeometryCache.TryGetValue(view, out (float position, float legnth) cachedValue))
                return (cachedValue.position, cachedValue.legnth);

            View topTarget = GetTopTarget(view) ?? Owner;
            View bottomTarget = GetBottomTarget(view) ?? Owner;
            float topMultiplier = GetTopMultiplier(view);
            float bottomMultiplier = GetBottomMultiplier(view);

            (float position, float legnth) topGeometry = CalculateVerticalGeometry(topTarget);
            (float position, float legnth) bottomGeometry = CalculateVerticalGeometry(bottomTarget);

            float spaceTop = topGeometry.position + (topGeometry.legnth * topMultiplier);
            float spaceBottom = bottomGeometry.position + (bottomGeometry.legnth * bottomMultiplier);

            float verticalAlignment = GetVerticalAlignment(view).ToFloat();

            float height;
            if (view.Layout.MeasuredHeight.Size.AsDecimal() < float.Epsilon)
                height = spaceBottom - spaceTop;
            else
                height = view.Layout.MeasuredHeight.Size.AsDecimal();

            VerticalGeometryCache.Add(view, (spaceTop + ((spaceBottom - spaceTop) - height) * verticalAlignment, height));

            return (spaceTop + ((spaceBottom - spaceTop) - height) * verticalAlignment, height);
        }
        class RelativeTargetConverter : TypeConverter, IExtendedTypeConverter
        {
            object IExtendedTypeConverter.ConvertFromInvariantString(string value, IServiceProvider serviceProvider)
            {
                if (serviceProvider == null)
                    throw new ArgumentNullException(nameof(serviceProvider));

                object target = null;

                if (serviceProvider.GetService(typeof(IReferenceProvider)) is IReferenceProvider referenceProvider)
                    target = referenceProvider.FindByName(value);

                if (target == null)
                    throw new ArgumentException($"Can't resolve name '{value}' on Element", nameof(value));

                return target;
            }

            public override object ConvertFromInvariantString(string value)
            {
                throw new NotImplementedException();
            }

            public object ConvertFrom(CultureInfo culture, object value, IServiceProvider serviceProvider)
            {
                throw new NotImplementedException();
            }
        }
    }

} // namespace
