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
/// <summary>Interface for 2D containers which arrange their elements on a table with rows and columns.
/// 
/// Elements can be positioned on a specific row and column, or they can be simply added to the table using <see cref="CoreUI.IPack.Pack"/> and the container will chose where to put them.</summary>
/// <since_tizen> 6 </since_tizen>
[CoreUI.PackTableConcrete.NativeMethods]
[CoreUI.Wrapper.BindingEntity]
public interface IPackTable : 
    CoreUI.IPack,
    CoreUI.Wrapper.IWrapper, IDisposable
{
    /// <summary>column of the <c>subobj</c> in this container.</summary>
    /// <param name="subobj">Child object</param>
    /// <param name="col">Column number</param>
    /// <param name="colspan">Column span</param>
    /// <returns>Returns false if item is not a child</returns>
    /// <since_tizen> 6 </since_tizen>
    bool GetTableCellColumn(CoreUI.Gfx.IEntity subobj, out int col, out int colspan);

    /// <summary>column of the <c>subobj</c> in this container.</summary>
    /// <param name="subobj">Child object</param>
    /// <param name="col">Column number</param>
    /// <param name="colspan">Column span</param>
    /// <since_tizen> 6 </since_tizen>
    void SetTableCellColumn(CoreUI.Gfx.IEntity subobj, int col, int colspan);

    /// <summary>row of the <c>subobj</c> in this container.</summary>
    /// <param name="subobj">Child object</param>
    /// <param name="row">Row number</param>
    /// <param name="rowspan">Row span</param>
    /// <returns>Returns false if item is not a child</returns>
    /// <since_tizen> 6 </since_tizen>
    bool GetTableCellRow(CoreUI.Gfx.IEntity subobj, out int row, out int rowspan);

    /// <summary>row of the <c>subobj</c> in this container.</summary>
    /// <param name="subobj">Child object</param>
    /// <param name="row">Row number</param>
    /// <param name="rowspan">Row span</param>
    /// <since_tizen> 6 </since_tizen>
    void SetTableCellRow(CoreUI.Gfx.IEntity subobj, int row, int rowspan);

    /// <summary>Combines <see cref="CoreUI.IPackTable.TableColumns"/> and <see cref="CoreUI.IPackTable.TableRows"/></summary>
    /// <param name="cols">Number of columns</param>
    /// <param name="rows">Number of rows</param>
    /// <since_tizen> 6 </since_tizen>
    void GetTableSize(out int cols, out int rows);

    /// <summary>Combines <see cref="CoreUI.IPackTable.TableColumns"/> and <see cref="CoreUI.IPackTable.TableRows"/></summary>
    /// <param name="cols">Number of columns</param>
    /// <param name="rows">Number of rows</param>
    /// <since_tizen> 6 </since_tizen>
    void SetTableSize(int cols, int rows);

    /// <summary>Specifies the amount of columns the table will have when the fill direction is horizontal. If it is vertical, the amount of columns depends on the amount of cells added and <see cref="CoreUI.IPackTable.TableRows"/>.</summary>
    /// <returns>Amount of columns.</returns>
    /// <since_tizen> 6 </since_tizen>
    int GetTableColumns();

    /// <summary>Specifies the amount of columns the table will have when the fill direction is horizontal. If it is vertical, the amount of columns depends on the amount of cells added and <see cref="CoreUI.IPackTable.TableRows"/>.</summary>
    /// <param name="cols">Amount of columns.</param>
    /// <since_tizen> 6 </since_tizen>
    void SetTableColumns(int cols);

    /// <summary>Specifies the amount of rows the table will have when the fill direction is vertical. If it is horizontal, the amount of rows depends on the amount of cells added and <see cref="CoreUI.IPackTable.TableColumns"/>.</summary>
    /// <returns>Amount of rows.</returns>
    /// <since_tizen> 6 </since_tizen>
    int GetTableRows();

    /// <summary>Specifies the amount of rows the table will have when the fill direction is vertical. If it is horizontal, the amount of rows depends on the amount of cells added and <see cref="CoreUI.IPackTable.TableColumns"/>.</summary>
    /// <param name="rows">Amount of rows.</param>
    /// <since_tizen> 6 </since_tizen>
    void SetTableRows(int rows);

    /// <summary>Pack object at a given location in the table.
    /// 
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="CoreUI.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="subobj">A child object to pack in this table.</param>
    /// <param name="col">Column number</param>
    /// <param name="row">Row number</param>
    /// <param name="colspan">0 means 1, -1 means <see cref="CoreUI.IPackTable.TableColumns"/></param>
    /// <param name="rowspan">0 means 1, -1 means <see cref="CoreUI.IPackTable.TableRows"/></param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    bool PackTable(CoreUI.Gfx.IEntity subobj, int col, int row, int colspan, int rowspan);

    /// <summary>Returns all objects at a given position in this table.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="col">Column number</param>
    /// <param name="row">Row number</param>
    /// <param name="below">If <c>true</c> get objects spanning over this cell.</param>
    /// <returns>Iterator to table contents</returns>
    IEnumerable<CoreUI.Gfx.IEntity> GetTableContents(int col, int row, bool below);

    /// <summary>Returns a child at a given position, see <see cref="CoreUI.IPackTable.GetTableContents"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="col">Column number</param>
    /// <param name="row">Row number</param>
    /// <returns>Child object</returns>
    CoreUI.Gfx.IEntity GetTableContent(int col, int row);

    /// <summary>Combines <see cref="CoreUI.IPackTable.TableColumns"/> and <see cref="CoreUI.IPackTable.TableRows"/></summary>
    /// <value>Number of columns</value>
    /// <since_tizen> 6 </since_tizen>
    (int, int) TableSize {
        get;
        set;
    }

    /// <summary>Specifies the amount of columns the table will have when the fill direction is horizontal. If it is vertical, the amount of columns depends on the amount of cells added and <see cref="CoreUI.IPackTable.TableRows"/>.</summary>
    /// <value>Amount of columns.</value>
    /// <since_tizen> 6 </since_tizen>
    int TableColumns {
        get;
        set;
    }

    /// <summary>Specifies the amount of rows the table will have when the fill direction is vertical. If it is horizontal, the amount of rows depends on the amount of cells added and <see cref="CoreUI.IPackTable.TableColumns"/>.</summary>
    /// <value>Amount of rows.</value>
    /// <since_tizen> 6 </since_tizen>
    int TableRows {
        get;
        set;
    }

}

/// <summary>Interface for 2D containers which arrange their elements on a table with rows and columns.
/// 
/// Elements can be positioned on a specific row and column, or they can be simply added to the table using <see cref="CoreUI.IPack.Pack"/> and the container will chose where to put them.</summary>
/// <since_tizen> 6 </since_tizen>
public sealed class PackTableConcrete :
    CoreUI.Wrapper.ObjectWrapper,
    IPackTable,
    CoreUI.IContainer,
    CoreUI.IPack
{
    /// <summary>Pointer to the native class description.</summary>
    public override System.IntPtr NativeClass
    {
        get
        {
            if (((object)this).GetType() == typeof(PackTableConcrete))
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
    private PackTableConcrete(ConstructingHandle ch) : base(ch)
    {
    }

    [System.Runtime.InteropServices.DllImport("libefl.so.1")] internal static extern System.IntPtr
        efl_pack_table_interface_get();

    /// <summary>Initializes a new instance of the <see cref="IPackTable"/> class.
    /// Internal usage: This is used when interacting with C code and should not be used directly.</summary>
    /// <param name="wh">The native pointer to be wrapped.</param>
    private PackTableConcrete(CoreUI.Wrapper.WrappingHandle wh) : base(wh)
    {
    }


    /// <summary>Sent after a new sub-object was added.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.ContainerContentAddedEventArgs"/></value>
    public event EventHandler<CoreUI.ContainerContentAddedEventArgs> ContentAddedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.ContainerContentAddedEventArgs{ arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Gfx.EntityConcrete) });
            string key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_CONTAINER_EVENT_CONTENT_ADDED";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event ContentAddedEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnContentAddedEvent(CoreUI.ContainerContentAddedEventArgs e)
    {
        IntPtr info = e.arg.NativeHandle;
CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_CONTAINER_EVENT_CONTENT_ADDED", info, null);
    }

    /// <summary>Sent after a sub-object was removed, before unref.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <value><see cref="CoreUI.ContainerContentRemovedEventArgs"/></value>
    public event EventHandler<CoreUI.ContainerContentRemovedEventArgs> ContentRemovedEvent
    {
        add
        {
            CoreUI.EventCb callerCb = GetInternalEventCallback(value, info => new CoreUI.ContainerContentRemovedEventArgs{ arg = (CoreUI.Wrapper.Globals.CreateWrapperFor(info) as CoreUI.Gfx.EntityConcrete) });
            string key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
            AddNativeEventHandler(CoreUI.Libs.CoreUI, key, callerCb, value);
        }

        remove
        {
            string key = "_EFL_CONTAINER_EVENT_CONTENT_REMOVED";
            RemoveNativeEventHandler(CoreUI.Libs.CoreUI, key, value);
        }
    }

    /// <summary>Method to raise event ContentRemovedEvent.
    /// </summary>
    /// <param name="e">Event to raise.</param>
    /// <since_tizen> 6 </since_tizen>
    public void OnContentRemovedEvent(CoreUI.ContainerContentRemovedEventArgs e)
    {
        IntPtr info = e.arg.NativeHandle;
CallNativeEventCallback(CoreUI.Libs.CoreUI, "_EFL_CONTAINER_EVENT_CONTENT_REMOVED", info, null);
    }

#pragma warning disable CS0628
    /// <summary>column of the <c>subobj</c> in this container.</summary>
    /// <param name="subobj">Child object</param>
    /// <param name="col">Column number</param>
    /// <param name="colspan">Column span</param>
    /// <returns>Returns false if item is not a child</returns>
    /// <since_tizen> 6 </since_tizen>
    public bool GetTableCellColumn(CoreUI.Gfx.IEntity subobj, out int col, out int colspan) {
        var _ret_var = CoreUI.PackTableConcrete.NativeMethods.efl_pack_table_cell_column_get_ptr.Value.Delegate(this.NativeHandle, subobj, out col, out colspan);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>column of the <c>subobj</c> in this container.</summary>
    /// <param name="subobj">Child object</param>
    /// <param name="col">Column number</param>
    /// <param name="colspan">Column span</param>
    /// <since_tizen> 6 </since_tizen>
    public void SetTableCellColumn(CoreUI.Gfx.IEntity subobj, int col, int colspan) {
        CoreUI.PackTableConcrete.NativeMethods.efl_pack_table_cell_column_set_ptr.Value.Delegate(this.NativeHandle, subobj, col, colspan);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>row of the <c>subobj</c> in this container.</summary>
    /// <param name="subobj">Child object</param>
    /// <param name="row">Row number</param>
    /// <param name="rowspan">Row span</param>
    /// <returns>Returns false if item is not a child</returns>
    /// <since_tizen> 6 </since_tizen>
    public bool GetTableCellRow(CoreUI.Gfx.IEntity subobj, out int row, out int rowspan) {
        var _ret_var = CoreUI.PackTableConcrete.NativeMethods.efl_pack_table_cell_row_get_ptr.Value.Delegate(this.NativeHandle, subobj, out row, out rowspan);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>row of the <c>subobj</c> in this container.</summary>
    /// <param name="subobj">Child object</param>
    /// <param name="row">Row number</param>
    /// <param name="rowspan">Row span</param>
    /// <since_tizen> 6 </since_tizen>
    public void SetTableCellRow(CoreUI.Gfx.IEntity subobj, int row, int rowspan) {
        CoreUI.PackTableConcrete.NativeMethods.efl_pack_table_cell_row_set_ptr.Value.Delegate(this.NativeHandle, subobj, row, rowspan);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Combines <see cref="CoreUI.IPackTable.TableColumns"/> and <see cref="CoreUI.IPackTable.TableRows"/></summary>
    /// <param name="cols">Number of columns</param>
    /// <param name="rows">Number of rows</param>
    /// <since_tizen> 6 </since_tizen>
    public void GetTableSize(out int cols, out int rows) {
        CoreUI.PackTableConcrete.NativeMethods.efl_pack_table_size_get_ptr.Value.Delegate(this.NativeHandle, out cols, out rows);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Combines <see cref="CoreUI.IPackTable.TableColumns"/> and <see cref="CoreUI.IPackTable.TableRows"/></summary>
    /// <param name="cols">Number of columns</param>
    /// <param name="rows">Number of rows</param>
    /// <since_tizen> 6 </since_tizen>
    public void SetTableSize(int cols, int rows) {
        CoreUI.PackTableConcrete.NativeMethods.efl_pack_table_size_set_ptr.Value.Delegate(this.NativeHandle, cols, rows);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Specifies the amount of columns the table will have when the fill direction is horizontal. If it is vertical, the amount of columns depends on the amount of cells added and <see cref="CoreUI.IPackTable.TableRows"/>.</summary>
    /// <returns>Amount of columns.</returns>
    /// <since_tizen> 6 </since_tizen>
    public int GetTableColumns() {
        var _ret_var = CoreUI.PackTableConcrete.NativeMethods.efl_pack_table_columns_get_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Specifies the amount of columns the table will have when the fill direction is horizontal. If it is vertical, the amount of columns depends on the amount of cells added and <see cref="CoreUI.IPackTable.TableRows"/>.</summary>
    /// <param name="cols">Amount of columns.</param>
    /// <since_tizen> 6 </since_tizen>
    public void SetTableColumns(int cols) {
        CoreUI.PackTableConcrete.NativeMethods.efl_pack_table_columns_set_ptr.Value.Delegate(this.NativeHandle, cols);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Specifies the amount of rows the table will have when the fill direction is vertical. If it is horizontal, the amount of rows depends on the amount of cells added and <see cref="CoreUI.IPackTable.TableColumns"/>.</summary>
    /// <returns>Amount of rows.</returns>
    /// <since_tizen> 6 </since_tizen>
    public int GetTableRows() {
        var _ret_var = CoreUI.PackTableConcrete.NativeMethods.efl_pack_table_rows_get_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Specifies the amount of rows the table will have when the fill direction is vertical. If it is horizontal, the amount of rows depends on the amount of cells added and <see cref="CoreUI.IPackTable.TableColumns"/>.</summary>
    /// <param name="rows">Amount of rows.</param>
    /// <since_tizen> 6 </since_tizen>
    public void SetTableRows(int rows) {
        CoreUI.PackTableConcrete.NativeMethods.efl_pack_table_rows_set_ptr.Value.Delegate(this.NativeHandle, rows);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        
    }

    /// <summary>Pack object at a given location in the table.
    /// 
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="CoreUI.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="subobj">A child object to pack in this table.</param>
    /// <param name="col">Column number</param>
    /// <param name="row">Row number</param>
    /// <param name="colspan">0 means 1, -1 means <see cref="CoreUI.IPackTable.TableColumns"/></param>
    /// <param name="rowspan">0 means 1, -1 means <see cref="CoreUI.IPackTable.TableRows"/></param>
    /// <returns><c>true</c> on success, <c>false</c> otherwise</returns>
    public bool PackTable(CoreUI.Gfx.IEntity subobj, int col, int row, int colspan, int rowspan) {
        var _ret_var = CoreUI.PackTableConcrete.NativeMethods.efl_pack_table_ptr.Value.Delegate(this.NativeHandle, subobj, col, row, colspan, rowspan);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Returns all objects at a given position in this table.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="col">Column number</param>
    /// <param name="row">Row number</param>
    /// <param name="below">If <c>true</c> get objects spanning over this cell.</param>
    /// <returns>Iterator to table contents</returns>
    public IEnumerable<CoreUI.Gfx.IEntity> GetTableContents(int col, int row, bool below) {
        var _ret_var = CoreUI.PackTableConcrete.NativeMethods.efl_pack_table_contents_get_ptr.Value.Delegate(this.NativeHandle, col, row, below);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return CoreUI.Wrapper.Globals.IteratorToIEnumerable<CoreUI.Gfx.IEntity>(_ret_var);
    }

    /// <summary>Returns a child at a given position, see <see cref="CoreUI.IPackTable.GetTableContents"/>.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="col">Column number</param>
    /// <param name="row">Row number</param>
    /// <returns>Child object</returns>
    public CoreUI.Gfx.IEntity GetTableContent(int col, int row) {
        var _ret_var = CoreUI.PackTableConcrete.NativeMethods.efl_pack_table_content_get_ptr.Value.Delegate(this.NativeHandle, col, row);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Begin iterating over this object&apos;s contents.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Iterator on object&apos;s content.</returns>
    public IEnumerable<CoreUI.Gfx.IEntity> IterateContent() {
        var _ret_var = CoreUI.ContainerConcrete.NativeMethods.efl_content_iterate_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return CoreUI.Wrapper.Globals.IteratorToIEnumerable<CoreUI.Gfx.IEntity>(_ret_var);
    }

    /// <summary>Returns the number of contained sub-objects.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns>Number of sub-objects.</returns>
    public int ContentCount() {
        var _ret_var = CoreUI.ContainerConcrete.NativeMethods.efl_content_count_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Removes all packed sub-objects and unreferences them.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
    public bool ClearPack() {
        var _ret_var = CoreUI.PackConcrete.NativeMethods.efl_pack_clear_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Removes all packed sub-objects without unreferencing them.
    /// 
    /// Use with caution.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <returns><c>true</c> on success, <c>false</c> otherwise.</returns>
    public bool UnpackAll() {
        var _ret_var = CoreUI.PackConcrete.NativeMethods.efl_pack_unpack_all_ptr.Value.Delegate(this.NativeHandle);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Removes an existing sub-object from the container without deleting it.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="subobj">The sub-object to unpack.</param>
    /// <returns><c>false</c> if <c>subobj</c> wasn&apos;t in the container or couldn&apos;t be removed.</returns>
    public bool Unpack(CoreUI.Gfx.IEntity subobj) {
        var _ret_var = CoreUI.PackConcrete.NativeMethods.efl_pack_unpack_ptr.Value.Delegate(this.NativeHandle, subobj);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Adds a sub-object to this container.
    /// 
    /// Depending on the container this will either fill in the default spot, replacing any already existing element or append to the end of the container if there is no default part.
    /// 
    /// When this container is deleted, it will request deletion of the given <c>subobj</c>. Use <see cref="CoreUI.IPack.Unpack"/> to remove <c>subobj</c> from this container without deleting it.</summary>
    /// <since_tizen> 6 </since_tizen>
    /// <param name="subobj">The object to pack.</param>
    /// <returns><c>false</c> if <c>subobj</c> could not be packed.</returns>
    public bool Pack(CoreUI.Gfx.IEntity subobj) {
        var _ret_var = CoreUI.PackConcrete.NativeMethods.efl_pack_ptr.Value.Delegate(this.NativeHandle, subobj);
        CoreUI.DataTypes.Error.RaiseIfUnhandledException();
        return _ret_var;
    }

    /// <summary>Combines <see cref="CoreUI.IPackTable.TableColumns"/> and <see cref="CoreUI.IPackTable.TableRows"/></summary>
    /// <value>Number of columns</value>
    /// <since_tizen> 6 </since_tizen>
    public (int, int) TableSize {
        get {
            int _out_cols = default(int);
            int _out_rows = default(int);
            GetTableSize(out _out_cols, out _out_rows);
            return (_out_cols, _out_rows);
        }
        set { SetTableSize( value.Item1,  value.Item2); }
    }

    /// <summary>Specifies the amount of columns the table will have when the fill direction is horizontal. If it is vertical, the amount of columns depends on the amount of cells added and <see cref="CoreUI.IPackTable.TableRows"/>.</summary>
    /// <value>Amount of columns.</value>
    /// <since_tizen> 6 </since_tizen>
    public int TableColumns {
        get { return GetTableColumns(); }
        set { SetTableColumns(value); }
    }

    /// <summary>Specifies the amount of rows the table will have when the fill direction is vertical. If it is horizontal, the amount of rows depends on the amount of cells added and <see cref="CoreUI.IPackTable.TableColumns"/>.</summary>
    /// <value>Amount of rows.</value>
    /// <since_tizen> 6 </since_tizen>
    public int TableRows {
        get { return GetTableRows(); }
        set { SetTableRows(value); }
    }

#pragma warning restore CS0628
    private static IntPtr GetCoreUIClassStatic()
    {
        return CoreUI.PackTableConcrete.efl_pack_table_interface_get();
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

            if (efl_pack_table_cell_column_get_static_delegate == null)
            {
                efl_pack_table_cell_column_get_static_delegate = new efl_pack_table_cell_column_get_delegate(table_cell_column_get);
            }

            if (methods.Contains("GetTableCellColumn"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_table_cell_column_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_cell_column_get_static_delegate) });
            }

            if (efl_pack_table_cell_column_set_static_delegate == null)
            {
                efl_pack_table_cell_column_set_static_delegate = new efl_pack_table_cell_column_set_delegate(table_cell_column_set);
            }

            if (methods.Contains("SetTableCellColumn"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_table_cell_column_set"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_cell_column_set_static_delegate) });
            }

            if (efl_pack_table_cell_row_get_static_delegate == null)
            {
                efl_pack_table_cell_row_get_static_delegate = new efl_pack_table_cell_row_get_delegate(table_cell_row_get);
            }

            if (methods.Contains("GetTableCellRow"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_table_cell_row_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_cell_row_get_static_delegate) });
            }

            if (efl_pack_table_cell_row_set_static_delegate == null)
            {
                efl_pack_table_cell_row_set_static_delegate = new efl_pack_table_cell_row_set_delegate(table_cell_row_set);
            }

            if (methods.Contains("SetTableCellRow"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_table_cell_row_set"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_cell_row_set_static_delegate) });
            }

            if (efl_pack_table_size_get_static_delegate == null)
            {
                efl_pack_table_size_get_static_delegate = new efl_pack_table_size_get_delegate(table_size_get);
            }

            if (methods.Contains("GetTableSize"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_table_size_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_size_get_static_delegate) });
            }

            if (efl_pack_table_size_set_static_delegate == null)
            {
                efl_pack_table_size_set_static_delegate = new efl_pack_table_size_set_delegate(table_size_set);
            }

            if (methods.Contains("SetTableSize"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_table_size_set"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_size_set_static_delegate) });
            }

            if (efl_pack_table_columns_get_static_delegate == null)
            {
                efl_pack_table_columns_get_static_delegate = new efl_pack_table_columns_get_delegate(table_columns_get);
            }

            if (methods.Contains("GetTableColumns"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_table_columns_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_columns_get_static_delegate) });
            }

            if (efl_pack_table_columns_set_static_delegate == null)
            {
                efl_pack_table_columns_set_static_delegate = new efl_pack_table_columns_set_delegate(table_columns_set);
            }

            if (methods.Contains("SetTableColumns"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_table_columns_set"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_columns_set_static_delegate) });
            }

            if (efl_pack_table_rows_get_static_delegate == null)
            {
                efl_pack_table_rows_get_static_delegate = new efl_pack_table_rows_get_delegate(table_rows_get);
            }

            if (methods.Contains("GetTableRows"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_table_rows_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_rows_get_static_delegate) });
            }

            if (efl_pack_table_rows_set_static_delegate == null)
            {
                efl_pack_table_rows_set_static_delegate = new efl_pack_table_rows_set_delegate(table_rows_set);
            }

            if (methods.Contains("SetTableRows"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_table_rows_set"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_rows_set_static_delegate) });
            }

            if (efl_pack_table_static_delegate == null)
            {
                efl_pack_table_static_delegate = new efl_pack_table_delegate(pack_table);
            }

            if (methods.Contains("PackTable"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_table"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_static_delegate) });
            }

            if (efl_pack_table_contents_get_static_delegate == null)
            {
                efl_pack_table_contents_get_static_delegate = new efl_pack_table_contents_get_delegate(table_contents_get);
            }

            if (methods.Contains("GetTableContents"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_table_contents_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_contents_get_static_delegate) });
            }

            if (efl_pack_table_content_get_static_delegate == null)
            {
                efl_pack_table_content_get_static_delegate = new efl_pack_table_content_get_delegate(table_content_get);
            }

            if (methods.Contains("GetTableContent"))
            {
                descs.Add(new CoreUIOpDescription() {api_func = CoreUI.Wrapper.FunctionInterop.LoadFunctionPointer(Module.Module, "efl_pack_table_content_get"), func = Marshal.GetFunctionPointerForDelegate(efl_pack_table_content_get_static_delegate) });
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
            return CoreUI.PackTableConcrete.efl_pack_table_interface_get();
        }

        #pragma warning disable CA1707, CS1591, SA1300, SA1600

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_table_cell_column_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity subobj,  out int col,  out int colspan);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_pack_table_cell_column_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity subobj,  out int col,  out int colspan);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_pack_table_cell_column_get_api_delegate> efl_pack_table_cell_column_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_pack_table_cell_column_get_api_delegate>(Module, "efl_pack_table_cell_column_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool table_cell_column_get(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.IEntity subobj, out int col, out int colspan)
        {
            CoreUI.DataTypes.Log.Debug("function efl_pack_table_cell_column_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                col = default(int);colspan = default(int);bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPackTable)ws.Target).GetTableCellColumn(subobj, out col, out colspan);
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
                return efl_pack_table_cell_column_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), subobj, out col, out colspan);
            }
        }

        private static efl_pack_table_cell_column_get_delegate efl_pack_table_cell_column_get_static_delegate;

        
        private delegate void efl_pack_table_cell_column_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity subobj,  int col,  int colspan);

        
        internal delegate void efl_pack_table_cell_column_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity subobj,  int col,  int colspan);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_pack_table_cell_column_set_api_delegate> efl_pack_table_cell_column_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_pack_table_cell_column_set_api_delegate>(Module, "efl_pack_table_cell_column_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void table_cell_column_set(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.IEntity subobj, int col, int colspan)
        {
            CoreUI.DataTypes.Log.Debug("function efl_pack_table_cell_column_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IPackTable)ws.Target).SetTableCellColumn(subobj, col, colspan);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_pack_table_cell_column_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), subobj, col, colspan);
            }
        }

        private static efl_pack_table_cell_column_set_delegate efl_pack_table_cell_column_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_table_cell_row_get_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity subobj,  out int row,  out int rowspan);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_pack_table_cell_row_get_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity subobj,  out int row,  out int rowspan);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_pack_table_cell_row_get_api_delegate> efl_pack_table_cell_row_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_pack_table_cell_row_get_api_delegate>(Module, "efl_pack_table_cell_row_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool table_cell_row_get(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.IEntity subobj, out int row, out int rowspan)
        {
            CoreUI.DataTypes.Log.Debug("function efl_pack_table_cell_row_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                row = default(int);rowspan = default(int);bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPackTable)ws.Target).GetTableCellRow(subobj, out row, out rowspan);
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
                return efl_pack_table_cell_row_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), subobj, out row, out rowspan);
            }
        }

        private static efl_pack_table_cell_row_get_delegate efl_pack_table_cell_row_get_static_delegate;

        
        private delegate void efl_pack_table_cell_row_set_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity subobj,  int row,  int rowspan);

        
        internal delegate void efl_pack_table_cell_row_set_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity subobj,  int row,  int rowspan);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_pack_table_cell_row_set_api_delegate> efl_pack_table_cell_row_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_pack_table_cell_row_set_api_delegate>(Module, "efl_pack_table_cell_row_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void table_cell_row_set(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.IEntity subobj, int row, int rowspan)
        {
            CoreUI.DataTypes.Log.Debug("function efl_pack_table_cell_row_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IPackTable)ws.Target).SetTableCellRow(subobj, row, rowspan);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_pack_table_cell_row_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), subobj, row, rowspan);
            }
        }

        private static efl_pack_table_cell_row_set_delegate efl_pack_table_cell_row_set_static_delegate;

        
        private delegate void efl_pack_table_size_get_delegate(System.IntPtr obj, System.IntPtr pd,  out int cols,  out int rows);

        
        internal delegate void efl_pack_table_size_get_api_delegate(System.IntPtr obj,  out int cols,  out int rows);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_pack_table_size_get_api_delegate> efl_pack_table_size_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_pack_table_size_get_api_delegate>(Module, "efl_pack_table_size_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void table_size_get(System.IntPtr obj, System.IntPtr pd, out int cols, out int rows)
        {
            CoreUI.DataTypes.Log.Debug("function efl_pack_table_size_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                cols = default(int);rows = default(int);
                try
                {
                    ((IPackTable)ws.Target).GetTableSize(out cols, out rows);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_pack_table_size_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), out cols, out rows);
            }
        }

        private static efl_pack_table_size_get_delegate efl_pack_table_size_get_static_delegate;

        
        private delegate void efl_pack_table_size_set_delegate(System.IntPtr obj, System.IntPtr pd,  int cols,  int rows);

        
        internal delegate void efl_pack_table_size_set_api_delegate(System.IntPtr obj,  int cols,  int rows);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_pack_table_size_set_api_delegate> efl_pack_table_size_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_pack_table_size_set_api_delegate>(Module, "efl_pack_table_size_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void table_size_set(System.IntPtr obj, System.IntPtr pd, int cols, int rows)
        {
            CoreUI.DataTypes.Log.Debug("function efl_pack_table_size_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IPackTable)ws.Target).SetTableSize(cols, rows);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_pack_table_size_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), cols, rows);
            }
        }

        private static efl_pack_table_size_set_delegate efl_pack_table_size_set_static_delegate;

        
        private delegate int efl_pack_table_columns_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate int efl_pack_table_columns_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_pack_table_columns_get_api_delegate> efl_pack_table_columns_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_pack_table_columns_get_api_delegate>(Module, "efl_pack_table_columns_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static int table_columns_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_pack_table_columns_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                int _ret_var = default(int);
                try
                {
                    _ret_var = ((IPackTable)ws.Target).GetTableColumns();
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
                return efl_pack_table_columns_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_pack_table_columns_get_delegate efl_pack_table_columns_get_static_delegate;

        
        private delegate void efl_pack_table_columns_set_delegate(System.IntPtr obj, System.IntPtr pd,  int cols);

        
        internal delegate void efl_pack_table_columns_set_api_delegate(System.IntPtr obj,  int cols);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_pack_table_columns_set_api_delegate> efl_pack_table_columns_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_pack_table_columns_set_api_delegate>(Module, "efl_pack_table_columns_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void table_columns_set(System.IntPtr obj, System.IntPtr pd, int cols)
        {
            CoreUI.DataTypes.Log.Debug("function efl_pack_table_columns_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IPackTable)ws.Target).SetTableColumns(cols);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_pack_table_columns_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), cols);
            }
        }

        private static efl_pack_table_columns_set_delegate efl_pack_table_columns_set_static_delegate;

        
        private delegate int efl_pack_table_rows_get_delegate(System.IntPtr obj, System.IntPtr pd);

        
        internal delegate int efl_pack_table_rows_get_api_delegate(System.IntPtr obj);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_pack_table_rows_get_api_delegate> efl_pack_table_rows_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_pack_table_rows_get_api_delegate>(Module, "efl_pack_table_rows_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static int table_rows_get(System.IntPtr obj, System.IntPtr pd)
        {
            CoreUI.DataTypes.Log.Debug("function efl_pack_table_rows_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                int _ret_var = default(int);
                try
                {
                    _ret_var = ((IPackTable)ws.Target).GetTableRows();
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
                return efl_pack_table_rows_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)));
            }
        }

        private static efl_pack_table_rows_get_delegate efl_pack_table_rows_get_static_delegate;

        
        private delegate void efl_pack_table_rows_set_delegate(System.IntPtr obj, System.IntPtr pd,  int rows);

        
        internal delegate void efl_pack_table_rows_set_api_delegate(System.IntPtr obj,  int rows);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_pack_table_rows_set_api_delegate> efl_pack_table_rows_set_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_pack_table_rows_set_api_delegate>(Module, "efl_pack_table_rows_set");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static void table_rows_set(System.IntPtr obj, System.IntPtr pd, int rows)
        {
            CoreUI.DataTypes.Log.Debug("function efl_pack_table_rows_set was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                
                try
                {
                    ((IPackTable)ws.Target).SetTableRows(rows);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                
            }
            else
            {
                efl_pack_table_rows_set_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), rows);
            }
        }

        private static efl_pack_table_rows_set_delegate efl_pack_table_rows_set_static_delegate;

        [return: MarshalAs(UnmanagedType.U1)]
        private delegate bool efl_pack_table_delegate(System.IntPtr obj, System.IntPtr pd, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity subobj,  int col,  int row,  int colspan,  int rowspan);

        [return: MarshalAs(UnmanagedType.U1)]
        internal delegate bool efl_pack_table_api_delegate(System.IntPtr obj, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))] CoreUI.Gfx.IEntity subobj,  int col,  int row,  int colspan,  int rowspan);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_pack_table_api_delegate> efl_pack_table_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_pack_table_api_delegate>(Module, "efl_pack_table");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static bool pack_table(System.IntPtr obj, System.IntPtr pd, CoreUI.Gfx.IEntity subobj, int col, int row, int colspan, int rowspan)
        {
            CoreUI.DataTypes.Log.Debug("function efl_pack_table was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                bool _ret_var = default(bool);
                try
                {
                    _ret_var = ((IPackTable)ws.Target).PackTable(subobj, col, row, colspan, rowspan);
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
                return efl_pack_table_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), subobj, col, row, colspan, rowspan);
            }
        }

        private static efl_pack_table_delegate efl_pack_table_static_delegate;

        
        private delegate System.IntPtr efl_pack_table_contents_get_delegate(System.IntPtr obj, System.IntPtr pd,  int col,  int row, [MarshalAs(UnmanagedType.U1)] bool below);

        
        internal delegate System.IntPtr efl_pack_table_contents_get_api_delegate(System.IntPtr obj,  int col,  int row, [MarshalAs(UnmanagedType.U1)] bool below);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_pack_table_contents_get_api_delegate> efl_pack_table_contents_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_pack_table_contents_get_api_delegate>(Module, "efl_pack_table_contents_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static System.IntPtr table_contents_get(System.IntPtr obj, System.IntPtr pd, int col, int row, bool below)
        {
            CoreUI.DataTypes.Log.Debug("function efl_pack_table_contents_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                IEnumerable<CoreUI.Gfx.IEntity> _ret_var = null;
                try
                {
                    _ret_var = ((IPackTable)ws.Target).GetTableContents(col, row, below);
                }
                catch (Exception e)
                {
                    CoreUI.DataTypes.Log.Warning($"Callback error: {e.ToString()}");
                    CoreUI.DataTypes.Error.Set(CoreUI.DataTypes.Error.UNHANDLED_EXCEPTION);
                }

                return CoreUI.Wrapper.Globals.IEnumerableToIterator(_ret_var, true);
            }
            else
            {
                return efl_pack_table_contents_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), col, row, below);
            }
        }

        private static efl_pack_table_contents_get_delegate efl_pack_table_contents_get_static_delegate;

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
        private delegate CoreUI.Gfx.IEntity efl_pack_table_content_get_delegate(System.IntPtr obj, System.IntPtr pd,  int col,  int row);

        [return:MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef=typeof(CoreUI.Wrapper.MarshalEoNoMove))]
        internal delegate CoreUI.Gfx.IEntity efl_pack_table_content_get_api_delegate(System.IntPtr obj,  int col,  int row);

        internal static readonly CoreUI.Wrapper.FunctionWrapper<efl_pack_table_content_get_api_delegate> efl_pack_table_content_get_ptr = new CoreUI.Wrapper.FunctionWrapper<efl_pack_table_content_get_api_delegate>(Module, "efl_pack_table_content_get");

        [SuppressMessage("Microsoft.Reliability", "CA2000:DisposeObjectsBeforeLosingScope", Justification = "The instantiated objects can be stored in the called Managed API method.")]
        private static CoreUI.Gfx.IEntity table_content_get(System.IntPtr obj, System.IntPtr pd, int col, int row)
        {
            CoreUI.DataTypes.Log.Debug("function efl_pack_table_content_get was called");
            var ws = CoreUI.Wrapper.Globals.GetWrapperSupervisor(obj);
            if (ws != null)
            {
                CoreUI.Gfx.IEntity _ret_var = default(CoreUI.Gfx.IEntity);
                try
                {
                    _ret_var = ((IPackTable)ws.Target).GetTableContent(col, row);
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
                return efl_pack_table_content_get_ptr.Value.Delegate(CoreUI.Wrapper.Globals.Super(obj, CoreUI.Wrapper.Globals.GetClass(obj)), col, row);
            }
        }

        private static efl_pack_table_content_get_delegate efl_pack_table_content_get_static_delegate;

        #pragma warning restore CA1707, CS1591, SA1300, SA1600

}
}
}

namespace CoreUI {
#pragma warning disable CS1591
/// <since_tizen> 6 </since_tizen>
public static class PackTableConcreteExtensionMethods {
    /// <since_tizen> 6 </since_tizen>
    public static CoreUI.BindableProperty<int> TableColumns<T>(this CoreUI.UI.ItemFactory<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.IPackTable, T>magic = null) where T : CoreUI.IPackTable {
        return new CoreUI.BindableProperty<int>("table_columns", fac);
    }

    /// <since_tizen> 6 </since_tizen>
    public static CoreUI.BindableProperty<int> TableRows<T>(this CoreUI.UI.ItemFactory<T> fac, CoreUI.Csharp.ExtensionTag<CoreUI.IPackTable, T>magic = null) where T : CoreUI.IPackTable {
        return new CoreUI.BindableProperty<int>("table_rows", fac);
    }

}
#pragma warning restore CS1591
}

