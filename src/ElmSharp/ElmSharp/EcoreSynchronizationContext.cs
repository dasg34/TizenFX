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

using System.Threading;

namespace ElmSharp
{

    /// <summary>
    /// Provides a synchronization context for the efl application.
    /// </summary>
    public class EcoreSynchronizationContext : SynchronizationContext
    {
        /// <summary>
        /// Initializes a new instance of the EcoreSynchronizationContext class.
        /// </summary>
        public EcoreSynchronizationContext()
        {
        }

        /// <summary>
        /// Initilizes a new EcoreSynchronizationContext and install into current thread
        /// </summary>
        /// <remarks>
        /// It is equivalent
        /// <code>
        /// SetSynchronizationContext(new EcoreSynchronizationContext());
        /// </code>
        /// </remarks>
        public static void Initialize()
        {
            SetSynchronizationContext(new EcoreSynchronizationContext());
        }

        /// <summary>
        /// Dispatches an asynchronous message to a Ecore main loop.
        /// </summary>
        /// <param name="d"><see cref="System.Threading.SendOrPostCallback"/>The SendOrPostCallback delegate to call.</param>
        /// <param name="state"><see cref="System.Object"/>The object passed to the delegate.</param>
        /// <remarks>The Post method starts an asynchronous request to post a message.</remarks>
        public override void Post(SendOrPostCallback d, object state)
        {
            EcoreMainloop.PostAndWakeUp(() =>
            {
                d(state);
            });
        }

        /// <summary>
        /// Dispatches a synchronous message to a Ecore main loop
        /// </summary>
        /// <param name="d"><see cref="System.Threading.SendOrPostCallback"/>The SendOrPostCallback delegate to call.</param>
        /// <param name="state"><see cref="System.Object"/>The object passed to the delegate.</param>
        /// <remarks>
        /// The Send method starts a synchronous request to send a message.</remarks>
        public override void Send(SendOrPostCallback d, object state)
        {
            EcoreMainloop.Send(() =>
            {
                d(state);
            });
        }
    }
}
