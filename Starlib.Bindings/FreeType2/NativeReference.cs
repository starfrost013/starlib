namespace Starlib.Bindings
{
    /// <summary>
    /// Struct NativeReference
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [StructLayout(LayoutKind.Sequential)]
    public struct NativeReference<T> where T : NativeObject
    {
        private readonly nint memoryPtr;

        /// <summary>
        /// Initializes a new instance of the <see cref="NativeReference{T}"/> struct.
        /// </summary>
        /// <param name="memoryPtr">The memory PTR.</param>
        public NativeReference(nint memoryPtr)
        {
            this.memoryPtr = memoryPtr;
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="Memory"/> to <see cref="NativeReference{T}"/>.
        /// </summary>
        /// <param name="memory">The memory.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator NativeReference<T>(T memory)
        {
            return new NativeReference<T>(memory.Reference);
        }
    }
}