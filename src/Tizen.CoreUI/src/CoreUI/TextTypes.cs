/*
 * Copyright 2019 by its authors. See AUTHORS.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

#pragma warning disable CS1591
using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
namespace CoreUI {
/// <summary>Bidirectionaltext type</summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.Wrapper.BindingEntity]
public enum TextBidirectionalType
{
/// <summary>Natural text type, same as neutral</summary>
/// <since_tizen> 6 </since_tizen>
Natural = 0,
/// <summary>Neutral text type, same as natural</summary>
/// <since_tizen> 6 </since_tizen>
Neutral = 0,
/// <summary>Left to right text type</summary>
/// <since_tizen> 6 </since_tizen>
Ltr = 1,
/// <summary>Right to left text type</summary>
/// <since_tizen> 6 </since_tizen>
Rtl = 2,
/// <summary>Inherit text type</summary>
/// <since_tizen> 6 </since_tizen>
Inherit = 3,
/// <summary>internal EVAS_BIDI_DIRECTION_ANY_RTL is not made for public. It should be opened to public when it is accepted to EFL upstream.</summary>
/// <since_tizen> 6 </since_tizen>
AnyRtl = 4,
}
}

