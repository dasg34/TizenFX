// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class Elementary
    {
        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_image_add(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_image_object_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_image_object_size_get(IntPtr obj, out int w, out int h);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_image_preload_disabled_set(IntPtr obj, bool disabled);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_image_file_set(IntPtr obj, string file, string group);

        [DllImport(Libraries.Elementary)]
        internal static extern void _elm_image_file_get(IntPtr obj, out IntPtr file, out IntPtr group);
        internal static string elm_image_file_get(IntPtr obj)
        {
            IntPtr file;
            IntPtr group;
            _elm_image_file_get(obj, out file, out group);
            return Marshal.PtrToStringAnsi(file);
        }

        [DllImport(Libraries.Elementary)]
        internal static unsafe extern bool elm_image_memfile_set(IntPtr obj, byte* img, long size, IntPtr format, IntPtr key);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_image_smooth_set(IntPtr obj, bool smooth);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_image_smooth_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_image_resizable_set(IntPtr obj, bool up, bool down);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_image_resizable_get(IntPtr obj, out bool up, out bool down);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_image_no_scale_set(IntPtr obj, bool no_scale);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_image_no_scale_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_image_aspect_fixed_set(IntPtr obj, bool value);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_image_aspect_fixed_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_image_fill_outside_set(IntPtr obj, bool fill_outside);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_image_fill_outside_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_image_animated_available_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_image_animated_set(IntPtr obj, bool anim);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_image_animated_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_image_animated_play_set(IntPtr obj, bool play);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_image_animated_play_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_image_prescale_set(IntPtr obj, int size);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_image_prescale_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_image_editable_set(IntPtr obj, bool set);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_image_editable_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_image_orient_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_image_orient_set(IntPtr obj, int orient);

        [DllImport(Libraries.Elementary)]
        internal static extern IntPtr elm_icon_add(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern bool elm_icon_standard_set(IntPtr obj, string name);

        [DllImport(Libraries.Elementary, EntryPoint = "elm_icon_standard_get", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true, CharSet = CharSet.Ansi)]
        internal static extern IntPtr _elm_icon_standard_get(IntPtr obj);
        internal static string elm_icon_standard_get(IntPtr obj)
        {
            var text = _elm_icon_standard_get(obj);
            return Marshal.PtrToStringAnsi(text);
        }

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_icon_thumb_set(IntPtr obj, string file, string group);

        [DllImport(Libraries.Elementary)]
        internal static extern int elm_icon_order_lookup_get(IntPtr obj);

        [DllImport(Libraries.Elementary)]
        internal static extern void elm_icon_order_lookup_set(IntPtr obj, int order);
    }
}

