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
/// <summary>CoreUI media player interface</summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.PlayerConcrete.NativeMethods]
[CoreUI.Wrapper.BindingEntity]
public interface IPlayer : 
    CoreUI.Wrapper.IWrapper, IDisposable
{
    /// <summary>Playback state of the media file.
    /// 
    /// This property sets the playback state of the object. Re-setting the current playback state has no effect.
    /// 
    /// If set to <c>false</c>, the object&apos;s <see cref="CoreUI.IPlayer.GetPlaybackProgress"/> property is, by default, reset to <c>0.0</c>. A class may alter this behavior, and it will be stated in the documentation for a class if such behavior changes should be expected.
    /// 
    /// Applying the <c>false</c> playing state also has the same effect as the player object reaching the end of its playback, which may invoke additional behavior based on a class&apos;s implementation.</summary>
    /// <returns><c>true</c> if playing, <c>false</c> otherwise.</returns>
    /// <since_tizen> 6 </since_tizen>
    bool GetPlaying();

    /// <summary>Playback state of the media file.
    /// 
    /// This property sets the playback state of the object. Re-setting the current playback state has no effect.
    /// 
    /// If set to <c>false</c>, the object&apos;s <see cref="CoreUI.IPlayer.GetPlaybackProgress"/> property is, by default, reset to <c>0.0</c>. A class may alter this behavior, and it will be stated in the documentation for a class if such behavior changes should be expected.
    /// 
    /// Applying the <c>false</c> playing state also has the same effect as the player object reaching the end of its playback, which may invoke additional behavior based on a class&apos;s implementation.</summary>
    /// <param name="playing"><c>true</c> if playing, <c>false</c> otherwise.</param>
    /// <returns>If <c>true</c>, the property change has succeeded.</returns>
    /// <since_tizen> 6 </since_tizen>
    bool SetPlaying(bool playing);

    /// <summary>Pause state of the media file.
    /// 
    /// This property sets the pause state of the media.  Re-setting the current pause state has no effect.
    /// 
    /// If <see cref="CoreUI.IPlayer.Playing"/> is set to <c>true</c>, this property can be used to pause and resume playback of the media without changing its <see cref="CoreUI.IPlayer.GetPlaybackProgress"/> property. This property cannot be changed if <see cref="CoreUI.IPlayer.Playing"/> is <c>false</c>.</summary>
    /// <returns><c>true</c> if paused, <c>false</c> otherwise.</returns>
    /// <since_tizen> 6 </since_tizen>
    bool GetPaused();

    /// <summary>Pause state of the media file.
    /// 
    /// This property sets the pause state of the media.  Re-setting the current pause state has no effect.
    /// 
    /// If <see cref="CoreUI.IPlayer.Playing"/> is set to <c>true</c>, this property can be used to pause and resume playback of the media without changing its <see cref="CoreUI.IPlayer.GetPlaybackProgress"/> property. This property cannot be changed if <see cref="CoreUI.IPlayer.Playing"/> is <c>false</c>.</summary>
    /// <param name="paused"><c>true</c> if paused, <c>false</c> otherwise.</param>
    /// <returns>If <c>true</c>, the property change has succeeded.</returns>
    /// <since_tizen> 6 </since_tizen>
    bool SetPaused(bool paused);

    /// <summary>Position in the media file.
    /// 
    /// This property sets the current position of the media file to <c>sec</c> seconds since the beginning of the media file. This only works on seekable streams. Setting the position doesn&apos;t change the <see cref="CoreUI.IPlayer.Playing"/> or <see cref="CoreUI.IPlayer.Paused"/> states of the media file.</summary>
    /// <param name="sec">The position (in seconds).</param>
    /// <since_tizen> 6 </since_tizen>
    void SetPlaybackPosition(double sec);

    /// <summary>How much of the file has been played.
    /// 
    /// This function gets the progress in playing the file, the return value is in the [0, 1] range.</summary>
    /// <returns>The progress within the [0, 1] range.</returns>
    /// <since_tizen> 6 </since_tizen>
    double GetPlaybackProgress();

    /// <summary>Control the playback speed of the media file.
    /// 
    /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
    /// <returns>The play speed in the [0, infinity) range.</returns>
    /// <since_tizen> 6 </since_tizen>
    double GetPlaybackSpeed();

    /// <summary>Control the playback speed of the media file.
    /// 
    /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
    /// <param name="speed">The play speed in the [0, infinity) range.</param>
    /// <since_tizen> 6 </since_tizen>
    void SetPlaybackSpeed(double speed);

    /// <summary>Playback state of the media file.
    /// 
    /// This property sets the playback state of the object. Re-setting the current playback state has no effect.
    /// 
    /// If set to <c>false</c>, the object&apos;s <see cref="CoreUI.IPlayer.GetPlaybackProgress"/> property is, by default, reset to <c>0.0</c>. A class may alter this behavior, and it will be stated in the documentation for a class if such behavior changes should be expected.
    /// 
    /// Applying the <c>false</c> playing state also has the same effect as the player object reaching the end of its playback, which may invoke additional behavior based on a class&apos;s implementation.</summary>
    /// <value><c>true</c> if playing, <c>false</c> otherwise.</value>
    /// <since_tizen> 6 </since_tizen>
    bool Playing {
        get;
        set;
    }

    /// <summary>Pause state of the media file.
    /// 
    /// This property sets the pause state of the media.  Re-setting the current pause state has no effect.
    /// 
    /// If <see cref="CoreUI.IPlayer.Playing"/> is set to <c>true</c>, this property can be used to pause and resume playback of the media without changing its <see cref="CoreUI.IPlayer.GetPlaybackProgress"/> property. This property cannot be changed if <see cref="CoreUI.IPlayer.Playing"/> is <c>false</c>.</summary>
    /// <value><c>true</c> if paused, <c>false</c> otherwise.</value>
    /// <since_tizen> 6 </since_tizen>
    bool Paused {
        get;
        set;
    }

    /// <summary>How much of the file has been played.
    /// 
    /// This function gets the progress in playing the file, the return value is in the [0, 1] range.</summary>
    /// <value>The progress within the [0, 1] range.</value>
    /// <since_tizen> 6 </since_tizen>
    double PlaybackProgress {
        get;
    }

    /// <summary>Control the playback speed of the media file.
    /// 
    /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
    /// <value>The play speed in the [0, infinity) range.</value>
    /// <since_tizen> 6 </since_tizen>
    double PlaybackSpeed {
        get;
        set;
    }

}

/// <summary>CoreUI media player interface</summary>
/// <since_tizen> 6 </since_tizen>
public sealed class PlayerConcrete :
    CoreUI.Wrapper.ObjectWrapper,
    IPlayer
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(PlayerConcrete))
            {
                return GetCoreUIClassStatic();
            }
            else
            {
                return CoreUI.Wrapper.ClassRegister.klassFromType[((object)this).GetType()];
            }
        }
    }

    /// <summary>Subclasses should override this constructor if they are expected to be instantiated from native code.
    /// Do not call this constructor directly.</summary>
    /// <param name="ch">Tag struct storing the native handle of the object being constructed.</param>
    private PlayerConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_player_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IPlayer"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private PlayerConcrete(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
    {
    }

#pragma warning disable CS0628
    /// <summary>Playback state of the media file.
    /// 
    /// This property sets the playback state of the object. Re-setting the current playback state has no effect.
    /// 
    /// If set to <c>false</c>, the object&apos;s <see cref="CoreUI.IPlayer.GetPlaybackProgress"/> property is, by default, reset to <c>0.0</c>. A class may alter this behavior, and it will be stated in the documentation for a class if such behavior changes should be expected.
    /// 
    /// Applying the <c>false</c> playing state also has the same effect as the player object reaching the end of its playback, which may invoke additional behavior based on a class&apos;s implementation.</summary>
    /// <returns><c>true</c> if playing, <c>false</c> otherwise.</returns>
    /// <since_tizen> 6 </since_tizen>
    public bool GetPlaying() {
        var _ret_var = CoreUI.PlayerConcrete.NativeMethods.efl_player_playing_get_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Playback state of the media file.
    /// 
    /// This property sets the playback state of the object. Re-setting the current playback state has no effect.
    /// 
    /// If set to <c>false</c>, the object&apos;s <see cref="CoreUI.IPlayer.GetPlaybackProgress"/> property is, by default, reset to <c>0.0</c>. A class may alter this behavior, and it will be stated in the documentation for a class if such behavior changes should be expected.
    /// 
    /// Applying the <c>false</c> playing state also has the same effect as the player object reaching the end of its playback, which may invoke additional behavior based on a class&apos;s implementation.</summary>
    /// <param name="playing"><c>true</c> if playing, <c>false</c> otherwise.</param>
    /// <returns>If <c>true</c>, the property change has succeeded.</returns>
    /// <since_tizen> 6 </since_tizen>
    public bool SetPlaying(bool playing) {
        var _ret_var = CoreUI.PlayerConcrete.NativeMethods.efl_player_playing_set_ptr.Value.Delegate(this.NativeHandle, playing);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Pause state of the media file.
    /// 
    /// This property sets the pause state of the media.  Re-setting the current pause state has no effect.
    /// 
    /// If <see cref="CoreUI.IPlayer.Playing"/> is set to <c>true</c>, this property can be used to pause and resume playback of the media without changing its <see cref="CoreUI.IPlayer.GetPlaybackProgress"/> property. This property cannot be changed if <see cref="CoreUI.IPlayer.Playing"/> is <c>false</c>.</summary>
    /// <returns><c>true</c> if paused, <c>false</c> otherwise.</returns>
    /// <since_tizen> 6 </since_tizen>
    public bool GetPaused() {
        var _ret_var = CoreUI.PlayerConcrete.NativeMethods.efl_player_paused_get_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Pause state of the media file.
    /// 
    /// This property sets the pause state of the media.  Re-setting the current pause state has no effect.
    /// 
    /// If <see cref="CoreUI.IPlayer.Playing"/> is set to <c>true</c>, this property can be used to pause and resume playback of the media without changing its <see cref="CoreUI.IPlayer.GetPlaybackProgress"/> property. This property cannot be changed if <see cref="CoreUI.IPlayer.Playing"/> is <c>false</c>.</summary>
    /// <param name="paused"><c>true</c> if paused, <c>false</c> otherwise.</param>
    /// <returns>If <c>true</c>, the property change has succeeded.</returns>
    /// <since_tizen> 6 </since_tizen>
    public bool SetPaused(bool paused) {
        var _ret_var = CoreUI.PlayerConcrete.NativeMethods.efl_player_paused_set_ptr.Value.Delegate(this.NativeHandle, paused);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Position in the media file.
    /// 
    /// This property sets the current position of the media file to <c>sec</c> seconds since the beginning of the media file. This only works on seekable streams. Setting the position doesn&apos;t change the <see cref="CoreUI.IPlayer.Playing"/> or <see cref="CoreUI.IPlayer.Paused"/> states of the media file.</summary>
    /// <param name="sec">The position (in seconds).</param>
    /// <since_tizen> 6 </since_tizen>
    public void SetPlaybackPosition(double sec) {
        CoreUI.PlayerConcrete.NativeMethods.efl_player_playback_position_set_ptr.Value.Delegate(this.NativeHandle, sec);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>How much of the file has been played.
    /// 
    /// This function gets the progress in playing the file, the return value is in the [0, 1] range.</summary>
    /// <returns>The progress within the [0, 1] range.</returns>
    /// <since_tizen> 6 </since_tizen>
    public double GetPlaybackProgress() {
        var _ret_var = CoreUI.PlayerConcrete.NativeMethods.efl_player_playback_progress_get_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Control the playback speed of the media file.
    /// 
    /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
    /// <returns>The play speed in the [0, infinity) range.</returns>
    /// <since_tizen> 6 </since_tizen>
    public double GetPlaybackSpeed() {
        var _ret_var = CoreUI.PlayerConcrete.NativeMethods.efl_player_playback_speed_get_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Control the playback speed of the media file.
    /// 
    /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
    /// <param name="speed">The play speed in the [0, infinity) range.</param>
    /// <since_tizen> 6 </since_tizen>
    public void SetPlaybackSpeed(double speed) {
        CoreUI.PlayerConcrete.NativeMethods.efl_player_playback_speed_set_ptr.Value.Delegate(this.NativeHandle, speed);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Playback state of the media file.
    /// 
    /// This property sets the playback state of the object. Re-setting the current playback state has no effect.
    /// 
    /// If set to <c>false</c>, the object&apos;s <see cref="CoreUI.IPlayer.GetPlaybackProgress"/> property is, by default, reset to <c>0.0</c>. A class may alter this behavior, and it will be stated in the documentation for a class if such behavior changes should be expected.
    /// 
    /// Applying the <c>false</c> playing state also has the same effect as the player object reaching the end of its playback, which may invoke additional behavior based on a class&apos;s implementation.</summary>
    /// <value><c>true</c> if playing, <c>false</c> otherwise.</value>
    /// <since_tizen> 6 </since_tizen>
    public bool Playing {
        get { return GetPlaying(); }
        set { SetPlaying(value); }
    }

    /// <summary>Pause state of the media file.
    /// 
    /// This property sets the pause state of the media.  Re-setting the current pause state has no effect.
    /// 
    /// If <see cref="CoreUI.IPlayer.Playing"/> is set to <c>true</c>, this property can be used to pause and resume playback of the media without changing its <see cref="CoreUI.IPlayer.GetPlaybackProgress"/> property. This property cannot be changed if <see cref="CoreUI.IPlayer.Playing"/> is <c>false</c>.</summary>
    /// <value><c>true</c> if paused, <c>false</c> otherwise.</value>
    /// <since_tizen> 6 </since_tizen>
    public bool Paused {
        get { return GetPaused(); }
        set { SetPaused(value); }
    }

    /// <summary>How much of the file has been played.
    /// 
    /// This function gets the progress in playing the file, the return value is in the [0, 1] range.</summary>
    /// <value>The progress within the [0, 1] range.</value>
    /// <since_tizen> 6 </since_tizen>
    public double PlaybackProgress {
        get { return GetPlaybackProgress(); }
    }

    /// <summary>Control the playback speed of the media file.
    /// 
    /// This function control the speed with which the media file will be played. 1.0 represents the normal speed, 2 double speed, 0.5 half speed and so on.</summary>
    /// <value>The play speed in the [0, infinity) range.</value>
    /// <since_tizen> 6 </since_tizen>
    public double PlaybackSpeed {
        get { return GetPlaybackSpeed(); }
        set { SetPlaybackSpeed(value); }
    }

#pragma warning restore CS0628
    private static IntPtr GetCoreUIClassStatic()
    {
        return CoreUI.PlayerConcrete.efl_player_interface_get();
    }

    /// <summary>Wrapper for native methods and virtual method delegates.
    /// For internal use by generated code only.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal new class NativeMethods : CoreUI.Wrapper.ObjectWrapper.NativeMethods
    {
        private static CoreUI.Wrapper.NativeModule Module = new CoreUI.Wrapper.NativeModule(CoreUI.Libs.CoreUI);

        /// <summary>Gets the list of Eo operations to override.
    /// </summary>
        /// <returns>The list of Eo operations to be overload.</returns>
        internal override System.Collections.Generic.List<CoreUIOpDescription> GetEoOps(System.Type type, bool includeInherited)
        {
            var descs = new System.Collections.Generic.List<CoreUIOpDescription>();
            var methods = CoreUI.Wrapper.Globals.GetUserMethods(type);

            if (efl_player_playing_get_static_delegate == null)
            {
                efl_player_playing_get_static_delegate = new efl_player_playing_get_delegate(playing_get);
            }

            if (methods.Contains("GetPlaying"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_playing_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_playing_get_static_delegate) });
            }

            if (efl_player_playing_set_static_delegate == null)
            {
                efl_player_playing_set_static_delegate = new efl_player_playing_set_delegate(playing_set);
            }

            if (methods.Contains("SetPlaying"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_playing_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_playing_set_static_delegate) });
            }

            if (efl_player_paused_get_static_delegate == null)
            {
                efl_player_paused_get_static_delegate = new efl_player_paused_get_delegate(paused_get);
            }

            if (methods.Contains("GetPaused"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_paused_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_paused_get_static_delegate) });
            }

            if (efl_player_paused_set_static_delegate == null)
            {
                efl_player_paused_set_static_delegate = new efl_player_paused_set_delegate(paused_set);
            }

            if (methods.Contains("SetPaused"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_paused_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_paused_set_static_delegate) });
            }

            if (efl_player_playback_position_set_static_delegate == null)
            {
                efl_player_playback_position_set_static_delegate = new efl_player_playback_position_set_delegate(playback_position_set);
            }

            if (methods.Contains("SetPlaybackPosition"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_playback_position_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_playback_position_set_static_delegate) });
            }

            if (efl_player_playback_progress_get_static_delegate == null)
            {
                efl_player_playback_progress_get_static_delegate = new efl_player_playback_progress_get_delegate(playback_progress_get);
            }

            if (methods.Contains("GetPlaybackProgress"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_playback_progress_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_playback_progress_get_static_delegate) });
            }

            if (efl_player_playback_speed_get_static_delegate == null)
            {
                efl_player_playback_speed_get_static_delegate = new efl_player_playback_speed_get_delegate(playback_speed_get);
            }

            if (methods.Contains("GetPlaybackSpeed"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_playback_speed_get"), func = Marshal.GetFunctionPointerForDelegate(efl_player_playback_speed_get_static_delegate) });
            }

            if (efl_player_playback_speed_set_static_delegate == null)
            {
                efl_player_playback_speed_set_static_delegate = new efl_player_playback_speed_set_delegate(playback_speed_set);
            }

            if (methods.Contains("SetPlaybackSpeed"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_player_playback_speed_set"), func = Marshal.GetFunctionPointerForDelegate(efl_player_playback_speed_set_static_delegate) });
            }

            if (includeInherited)
            {
                var all_interfaces = type.GetInterfaces();
                foreach (var iface in all_interfaces)
                {
                    var moredescs = ((CoreUI.Wrapper.NativeClass)iface.GetCustomAttributes(false)?.FirstOrDefault(attr => attr is CoreUI.Wrapper.NativeClass))?.GetEoOps(type, false);
                    if (moredescs != null)
                        descs.AddRange(moredescs);
                }
            }
            return descs;
        }

        /// <summary>Returns the Eo class for the native methods of this class.
        /// </summary>
        /// <returns>The native class pointer.</returns>
        internal override IntPtr GetCoreUIClass()
        {
            return CoreUI.PlayerConcrete.efl_player_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_player_playing_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_player_playing_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_player_playing_get_api_delegate> efl_player_playing_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_player_playing_get_api_delegate>(Module, "efl_player_playing_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool playing_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_player_playing_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPlayer)ws.Target).GetPlaying();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_player_playing_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_player_playing_get_delegate efl_player_playing_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_player_playing_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool playing);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_player_playing_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool playing);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_player_playing_set_api_delegate> efl_player_playing_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_player_playing_set_api_delegate>(Module, "efl_player_playing_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool playing_set(System.IntPtr obj, System.IntPtr pd, bool playing)
        {
            CoreUI.DataTypes.Log.Debug("function efl_player_playing_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPlayer)ws.Target).SetPlaying(playing);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_player_playing_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), playing);
            }
        }

        private static efl_player_playing_set_delegate efl_player_playing_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_player_paused_get_delegate(System.IntPtr obj, System.IntPtr pd);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_player_paused_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_player_paused_get_api_delegate> efl_player_paused_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_player_paused_get_api_delegate>(Module, "efl_player_paused_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool paused_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_player_paused_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPlayer)ws.Target).GetPaused();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_player_paused_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_player_paused_get_delegate efl_player_paused_get_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_player_paused_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.U1)] bool paused);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_player_paused_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.U1)] bool paused);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_player_paused_set_api_delegate> efl_player_paused_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_player_paused_set_api_delegate>(Module, "efl_player_paused_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool paused_set(System.IntPtr obj, System.IntPtr pd, bool paused)
        {
            CoreUI.DataTypes.Log.Debug("function efl_player_paused_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPlayer)ws.Target).SetPaused(paused);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_player_paused_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), paused);
            }
        }

        private static efl_player_paused_set_delegate efl_player_paused_set_static_delegate;

        
        private delegate void efl_player_playback_position_set_delegate(System.IntPtr obj, System.IntPtr pd,  double sec);

        
        internal delegate void efl_player_playback_position_set_api_delegate(System.IntPtr obj,  double sec);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_player_playback_position_set_api_delegate> efl_player_playback_position_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_player_playback_position_set_api_delegate>(Module, "efl_player_playback_position_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void playback_position_set(System.IntPtr obj, System.IntPtr pd, double sec)
        {
            CoreUI.DataTypes.Log.Debug("function efl_player_playback_position_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IPlayer)ws.Target).SetPlaybackPosition(sec);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_player_playback_position_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), sec);
            }
        }

        private static efl_player_playback_position_set_delegate efl_player_playback_position_set_static_delegate;

        
        private delegate double efl_player_playback_progress_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate double efl_player_playback_progress_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_player_playback_progress_get_api_delegate> efl_player_playback_progress_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_player_playback_progress_get_api_delegate>(Module, "efl_player_playback_progress_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static double playback_progress_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_player_playback_progress_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                double _ret_var = default(double);
                try
                {
                    _ret_var = ((IPlayer)ws.Target).GetPlaybackProgress();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_player_playback_progress_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_player_playback_progress_get_delegate efl_player_playback_progress_get_static_delegate;

        
        private delegate double efl_player_playback_speed_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate double efl_player_playback_speed_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_player_playback_speed_get_api_delegate> efl_player_playback_speed_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_player_playback_speed_get_api_delegate>(Module, "efl_player_playback_speed_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static double playback_speed_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_player_playback_speed_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                double _ret_var = default(double);
                try
                {
                    _ret_var = ((IPlayer)ws.Target).GetPlaybackSpeed();
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return _ret_var;
            }
            else
            {
                return efl_player_playback_speed_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_player_playback_speed_get_delegate efl_player_playback_speed_get_static_delegate;

        
        private delegate void efl_player_playback_speed_set_delegate(System.IntPtr obj, System.IntPtr pd,  double speed);

        
        internal delegate void efl_player_playback_speed_set_api_delegate(System.IntPtr obj,  double speed);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_player_playback_speed_set_api_delegate> efl_player_playback_speed_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_player_playback_speed_set_api_delegate>(Module, "efl_player_playback_speed_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void playback_speed_set(System.IntPtr obj, System.IntPtr pd, double speed)
        {
            CoreUI.DataTypes.Log.Debug("function efl_player_playback_speed_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IPlayer)ws.Target).SetPlaybackSpeed(speed);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_player_playback_speed_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), speed);
            }
        }

        private static efl_player_playback_speed_set_delegate efl_player_playback_speed_set_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

namespace CoreUI {
#pragma warning disable CS1591
/// <since_tizen> 6 </since_tizen>
public static class PlayerConcreteExtensionMethods {
    /// <since_tizen> 6 </since_tizen>
    public static CoreUI.BindableProperty<bool> Playing<T>(this CoreUI.UI.ItemFactory<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.IPlayer, T>magic = null) where T : CoreUI.IPlayer {
        return new CoreUI.BindableProperty<bool>("playing", fac);
    }

    /// <since_tizen> 6 </since_tizen>
    public static CoreUI.BindableProperty<bool> Paused<T>(this CoreUI.UI.ItemFactory<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.IPlayer, T>magic = null) where T : CoreUI.IPlayer {
        return new CoreUI.BindableProperty<bool>("paused", fac);
    }

    /// <since_tizen> 6 </since_tizen>
    public static CoreUI.BindableProperty<double> PlaybackSpeed<T>(this CoreUI.UI.ItemFactory<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.IPlayer, T>magic = null) where T : CoreUI.IPlayer {
        return new CoreUI.BindableProperty<double>("playback_speed", fac);
    }

}
#pragma warning restore CS1591
}

