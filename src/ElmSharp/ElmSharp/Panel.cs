using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElmSharp
{
    public enum PanelDirection
    {
        /// <summary>
        /// Top to bottom
        /// </summary>
        Top = 0,
        /// <summary>
        /// Bottom to top
        /// </summary>
        Bottom,
        /// <summary>
        /// Left to right
        /// </summary>
        Left,
        /// <summary>
        /// Right to left
        /// </summary>
        Right,
    }

    public class Panel : Layout
    {
        public Panel(EvasObject parent) : base(parent)
        {
        }

        public bool IsOpen
        {
            get
            {
                return !Interop.Elementary.elm_panel_hidden_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_panel_hidden_set(Handle, !value);
            }
        }

        public PanelDirection Direction
        {
            get
            {
                return (PanelDirection)Interop.Elementary.elm_panel_orient_get(Handle);
            }
            set
            {
                Interop.Elementary.elm_panel_orient_set(Handle, (int)value);
            }
        }

        public void SetScrollable(bool enable)
        {
            Interop.Elementary.elm_panel_scrollable_set(Handle, enable);
        }

        public void SetScrollableArea(double ratio)
        {
            Interop.Elementary.elm_panel_scrollable_content_size_set(Handle, ratio);
        }

        public void Toggle()
        {
            Interop.Elementary.elm_panel_toggle(Handle);
        }

        internal override IntPtr CreateHandle(EvasObject parent)
        {
            return Interop.Elementary.elm_panel_add(parent);
        }
    }
}
