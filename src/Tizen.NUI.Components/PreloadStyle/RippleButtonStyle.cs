/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.Components;
using Tizen.NUI.Components.Extension;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Describes Button Animation used in OneUI_Watch2.X
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class RippleButtonStyle : OverlayAnimationButtonStyle
    {
        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override ButtonExtension CreateExtension()
        {
            return new RippleButtonExtension();
        }
    }

    /// <summary>
    /// OverlayAnimationButtonExtension class is a extended ButtonExtension class that make the overlay image blinking on a Button pressed.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class RippleButtonExtension : OverlayAnimationButtonExtension
    {
        private Animation PressAnimation { get; set; }

        /// <summary>
        /// Creates a new instance of a OverlayAnimationButtonExtension.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RippleButtonExtension() : base()
        {
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnControlStateChanged(Button button, ControlStates previousState)
        {
            if (button.ControlState != ControlStates.Pressed)
            {
                return;
            }
            
            button.ClippingMode = ClippingModeType.ClipChildren;

            var overlayImage = button.GetCurrentOverlayImage(this);
            Vector2 position = TouchInfo.GetLocalPosition(0);
            overlayImage.Position2D = new Position2D((int)position.X - overlayImage.Size2D.Width / 2, (int)position.Y - overlayImage.Size2D.Height / 2);

            base.OnControlStateChanged(button, previousState);
        }
    }
}