/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;

namespace ElmSharp
{
    /// <summary>
    /// EcoreMainloop is a helper class, it provide functions relative Ecore's main loop.
    /// </summary>
    public static class EcoreMainloop
    {
        static readonly Dictionary<int, Func<bool>> _taskMap = new Dictionary<int, Func<bool>>();
        static readonly Object _taskLock = new Object();
        static int _newTaskId = 0;

        static Interop.Ecore.EcoreTaskCallback _nativeHandler;

        static EcoreMainloop()
        {
            Interop.Ecore.ecore_init();
            Interop.Ecore.ecore_main_loop_glib_integrate();
            _nativeHandler = NativeHandler;
        }

        /// <summary>
        /// Checks if you are calling this function from the main thread.
        /// </summary>
        /// <remarks>True is the calling function is the same thread, false otherwise.</remarks>
        public static bool IsMainThread => Interop.Eina.eina_main_loop_is();

        /// <summary>
        /// Runs the application main loop.
        /// </summary>
        public static void Begin()
        {
            Interop.Ecore.ecore_main_loop_begin();
        }

        /// <summary>
        /// Quits the main loop once all the events currently on the queue have been processed.
        /// </summary>
        public static void Quit()
        {
            Interop.Ecore.ecore_main_loop_quit();
        }

        /// <summary>
        /// Adds an idler handler.
        /// </summary>
        /// <param name="task">The action to call when idling</param>
        public static void Post(Action task)
        {
            int id = RegistHandler(() => { task(); return false; });
            Interop.Ecore.ecore_idler_add(_nativeHandler, (IntPtr)id);
        }

        /// <summary>
        /// Calls callback asynchronously in the main loop.
        /// </summary>
        /// <param name="task">The action wanted to be called</param>
        public static void PostAndWakeUp(Action task)
        {
            int id = RegistHandler(() => { task(); return false; });
            Interop.Ecore.ecore_main_loop_thread_safe_call_async(_nativeHandler, (IntPtr)id);
        }

        /// <summary>
        /// Calls callback synchronously in the main loop.
        /// </summary>
        /// <param name="task">The action wanted to be called</param>
        public static void Send(Action task)
        {
            int id = RegistHandler(() => { task(); return false; });
            Interop.Ecore.ecore_main_loop_thread_safe_call_sync(_nativeHandler, (IntPtr)id);
        }

        /// <summary>
        /// Creates a timer to call the given function in the given period of time.
        /// </summary>
        /// <param name="interval">The interval in seconds.</param>
        /// <param name="handler">The given function.</param>
        /// <returns>A timer object handler on success, NULL on failure.</returns>
        public static IntPtr AddTimer(double interval, Func<bool> handler)
        {
            int id = RegistHandler(handler);
            return Interop.Ecore.ecore_timer_add(interval, _nativeHandler, (IntPtr)id);
        }

        /// <summary>
        /// Removes the specified timer from the timer list.
        /// </summary>
        /// <param name="id">The specified timer handler</param>
        public static void RemoveTimer(IntPtr id)
        {
            int taskId = (int)Interop.Ecore.ecore_timer_del(id);
            _taskMap.Remove(taskId);
        }

        static int RegistHandler(Func<bool> task)
        {
            int taskId;
            lock (_taskLock)
            {
                taskId = _newTaskId++;
            }
            _taskMap[taskId] = task;
            return taskId;
        }

        static bool NativeHandler(IntPtr user_data)
        {
            int task_id = (int)user_data;
            Func<bool> userAction = null;
            _taskMap.TryGetValue(task_id, out userAction);
            if (userAction != null)
            {
                _taskMap.Remove(task_id);
                return userAction();
            }
            return false;
        }

    }
}
