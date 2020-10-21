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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI
{
    /// <summary>
    /// RelativeLayout
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class RelativeLayout : LayoutGroup
    {

        /// <summary>
        /// LeftTargetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LeftTargetProperty = BindableProperty.CreateAttached("LeftTarget", typeof(View), typeof(RelativeLayout), null, propertyChanged: OnChildPropertyChanged);

        /// <summary>
        /// RightTargetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RightTargetProperty = BindableProperty.CreateAttached("RightTarget", typeof(View), typeof(RelativeLayout), null, propertyChanged: OnChildPropertyChanged);

        /// <summary>
        /// TopTargetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TopTargetProperty = BindableProperty.CreateAttached("TopTarget", typeof(View), typeof(RelativeLayout), null, propertyChanged: OnChildPropertyChanged);

        /// <summary>
        /// BottomTargetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BottomTargetProperty = BindableProperty.CreateAttached("BottomTarget", typeof(View), typeof(RelativeLayout), null, propertyChanged: OnChildPropertyChanged);

        /// <summary>
        /// LeftMultiplierProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LeftMultiplierProperty = BindableProperty.CreateAttached("LeftMultiplier", typeof(float), typeof(RelativeLayout), 0.0f, propertyChanged: OnChildPropertyChanged);

        /// <summary>
        /// RightMultiplierProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RightMultiplierProperty = BindableProperty.CreateAttached("RightMultiplier", typeof(float), typeof(RelativeLayout), 0.0f, propertyChanged: OnChildPropertyChanged);

        /// <summary>
        /// TopMultiplierProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TopMultiplierProperty = BindableProperty.CreateAttached("TopMultiplier", typeof(float), typeof(RelativeLayout), 0.0f, propertyChanged: OnChildPropertyChanged);

        /// <summary>
        /// BottomMultiplierProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty BottomMultiplierProperty = BindableProperty.CreateAttached("BottomMultiplier", typeof(float), typeof(RelativeLayout), 0.0f, propertyChanged: OnChildPropertyChanged);

        /// <summary>
        /// HorizontalAlignmentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HorizontalAlignmentProperty = BindableProperty.CreateAttached("HorizontalAlignment", typeof(Alignment), typeof(RelativeLayout), default(Alignment), propertyChanged: OnChildPropertyChanged);

        /// <summary>
        /// VerticalAlignmentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalAlignmentProperty = BindableProperty.CreateAttached("VerticalAlignment", typeof(Alignment), typeof(RelativeLayout), default(Alignment), propertyChanged: OnChildPropertyChanged);


        /// <summary>
        /// Constructor
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RelativeLayout()
        {
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Binding.TypeConverter(typeof(RelativeTargetConverter))]
        public static View GetLeftTarget(BindableObject view) => GetAttachedValue<View>(view, LeftTargetProperty);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Binding.TypeConverter(typeof(RelativeTargetConverter))]
        public static View GetRightTarget(BindableObject view) => GetAttachedValue<View>(view, RightTargetProperty);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Binding.TypeConverter(typeof(RelativeTargetConverter))]
        public static View GetTopTarget(BindableObject view) => GetAttachedValue<View>(view, TopTargetProperty);

        [EditorBrowsable(EditorBrowsableState.Never)]
        [Binding.TypeConverter(typeof(RelativeTargetConverter))]
        public static View GetBottomTarget(BindableObject view) => GetAttachedValue<View>(view, BottomTargetProperty);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static float GetLeftMultiplier(View view) => GetAttachedValue<float>(view, LeftMultiplierProperty);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static float GetRightMultiplier(View view) => GetAttachedValue<float>(view, RightMultiplierProperty);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static float GetTopMultiplier(View view) => GetAttachedValue<float>(view, TopMultiplierProperty);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static float GetBottomMultiplier(View view) => GetAttachedValue<float>(view, BottomMultiplierProperty);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Alignment GetHorizontalAlignment(View view) => GetAttachedValue<Alignment>(view, HorizontalAlignmentProperty);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static Alignment GetVerticalAlignment(View view) => GetAttachedValue<Alignment>(view, VerticalAlignmentProperty);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetLeftTarget(View view, View value) => SetAttachedValue(view, LeftTargetProperty, value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetRightTarget(View view, View value) => SetAttachedValue(view, RightTargetProperty, value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetTopTarget(View view, View value) => SetAttachedValue(view, TopTargetProperty, value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetBottomTarget(View view, View value) => SetAttachedValue(view, BottomTargetProperty, value);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetLeftMultiplier(View view, float value) => SetAttachedValue(view, LeftMultiplierProperty, value);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetRightMultiplier(View view, float value) => SetAttachedValue(view, RightMultiplierProperty, value);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetTopMultiplier(View view, float value) => SetAttachedValue(view, TopMultiplierProperty, value);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetBottomMultiplier(View view, float value) => SetAttachedValue(view, BottomMultiplierProperty, value);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetHorizontalAlignment(View view, Alignment value) => SetAttachedValue(view, HorizontalAlignmentProperty, value);
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetVerticalAlignment(View view, Alignment value) => SetAttachedValue(view, VerticalAlignmentProperty, value);

        /// <inheritdoc/>
        public override void Remove(LayoutItem layoutItem)
        {

        }

        private float CalculateRequiredSize(float originSize, float multiplier_l, float multiplier_r)
        {
            float multiplier = multiplier_r - multiplier_l;
            if (multiplier < float.Epsilon)
                return originSize;

            return originSize / multiplier;
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnMeasure(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
        {
            // Ensure layout respects it's given minimum size
            float maxWidth = SuggestedMinimumWidth.AsDecimal();
            float maxHeight = SuggestedMinimumHeight.AsDecimal();

            MeasuredSize.StateType childWidthState = MeasuredSize.StateType.MeasuredSizeOK;
            MeasuredSize.StateType childHeightState = MeasuredSize.StateType.MeasuredSizeOK;

            InitMultiplierCache();

            for (int i = 0; i < LayoutChildren.Count; i++)
            {
                LayoutItem childLayout = LayoutChildren[i];
                if (childLayout != null)
                {
                    MeasureChildWithMargins(childLayout, widthMeasureSpec, new LayoutLength(0), heightMeasureSpec, new LayoutLength(0));
                    (float leftMultiplier, float rightMultiplier) = CalculateHorizontalNormalizedMultiplier(childLayout.Owner);
                    (float topMultiplier, float bottomMultiplier) = CalculateVerticalNormalizedMultiplier(childLayout.Owner);

                    // Determine the width and height needed by the children using their given target and multiplier.
                    float childWidth = CalculateRequiredSize(childLayout.MeasuredWidth.Size.AsDecimal(), leftMultiplier, rightMultiplier);
                    float childHeight = CalculateRequiredSize(childLayout.MeasuredHeight.Size.AsDecimal(), topMultiplier, bottomMultiplier);

                    if (maxWidth < childWidth)
                        maxWidth = childWidth;

                    if (maxHeight < childHeight)
                        maxHeight = childHeight;

                    if (childLayout.MeasuredWidth.State == MeasuredSize.StateType.MeasuredSizeTooSmall)
                    {
                        childWidthState = MeasuredSize.StateType.MeasuredSizeTooSmall;
                    }
                    if (childLayout.MeasuredHeight.State == MeasuredSize.StateType.MeasuredSizeTooSmall)
                    {
                        childHeightState = MeasuredSize.StateType.MeasuredSizeTooSmall;
                    }
                }
            }

            SetMeasuredDimensions(ResolveSizeAndState(new LayoutLength(maxWidth), widthMeasureSpec, childWidthState),
                                  ResolveSizeAndState(new LayoutLength(maxHeight), heightMeasureSpec, childHeightState));
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnLayout(bool changed, LayoutLength left, LayoutLength top, LayoutLength right, LayoutLength bottom)
        {
            for (int i = 0; i < LayoutChildren.Count; i++)
            {
                LayoutItem childLayout = LayoutChildren[i];
                if ( childLayout != null )
                {
                    (float childLeft, float childWidth) = CalculateHorizontalGeometry(childLayout.Owner);
                    (float childTop, float childHeight) = CalculateVerticalGeometry(childLayout.Owner);

                    childLayout.Layout(new LayoutLength(childLeft), new LayoutLength(childTop),
                                       new LayoutLength(childLeft + childWidth), new LayoutLength(childTop + childHeight));
                }
            }
        }

        /// <summary>
        /// The alignment of the relative layout child.
        /// </summary>
        public enum Alignment
        {
            /// <summary>
            /// At the start of the container.
            /// </summary>
            Start = 0,
            /// <summary>
            /// At the center of the container
            /// </summary>
            Center = 1,
            /// <summary>
            /// At the end of the container.
            /// </summary>
            End = 2,
        }
    }

    // Extension Method of RelativeLayout.Alignment.
    internal static partial class RelativeLayoutAlignmentExtension
    {
        public static float ToFloat(this RelativeLayout.Alignment align)
        {
            return 0.5f * (float)align;
        }
    }

} // namespace
