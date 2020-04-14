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
using Tizen.NUI.Binding;

namespace Tizen.NUI
{
    /// <summary>
    /// Interface that provides style properties for Lottie playing in Button.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class LottieStyle : ViewStyle
    {
        private string lottieUrl;
        private Selector<LottieFrameInfo> playRangeSelector;

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlayRangeSelectorProperty = BindableProperty.Create("PlayRangeSelector", typeof(Selector<LottieFrameInfo>), typeof(LottieStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (LottieStyle)bindable;
            if (null == viewStyle.playRangeSelector) viewStyle.playRangeSelector = new Selector<LottieFrameInfo>();
            viewStyle.playRangeSelector.Clone(null == newValue ? new Selector<LottieFrameInfo>() : (Selector<LottieFrameInfo>)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (LottieStyle)bindable;
            return viewStyle.playRangeSelector;
        });

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LottieUrlProperty = BindableProperty.Create(nameof(LottieUrl), typeof(string), typeof(LottieStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var viewStyle = (LottieStyle)bindable;
            viewStyle.lottieUrl = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var viewStyle = (LottieStyle)bindable;
            return viewStyle.lottieUrl;
        });

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string LottieUrl
        {
            get
            {
                string playRange = (string)GetValue(LottieUrlProperty);
                return playRange ?? (lottieUrl = "");
            }
            set => SetValue(LottieUrlProperty, value);
        }


        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<LottieFrameInfo> PlayRange
        {
            get
            {
                Selector<LottieFrameInfo> playRange = (Selector<LottieFrameInfo>)GetValue(PlayRangeSelectorProperty);
                return playRange ?? (playRangeSelector = new Selector<LottieFrameInfo>());
            }
            set => SetValue(PlayRangeSelectorProperty, value);
        }

    }
}
