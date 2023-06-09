namespace Starlib.Bindings
{
    /// <summary>
    /// A structure used to hold a single list element.
    /// </summary>
    public class FT_ListNode : NativeObject
    {
        #region Fields

        private FT_ListNodeRec rec;

        #endregion

        #region Constructors

        public FT_ListNode(nint reference) : base(reference)
        {
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the previous element in the list. NULL if first.
        /// </summary>
        public FT_ListNode Previous
        {
            get
            {
                if (rec.prev == nint.Zero)
                    return null;

                return new FT_ListNode(rec.prev);
            }
        }

        /// <summary>
        /// Gets the next element in the list. NULL if last.
        /// </summary>
        public FT_ListNode Next
        {
            get
            {
                if (rec.next == nint.Zero)
                    return null;

                return new FT_ListNode(rec.next);
            }
        }

        /// <summary>
        /// Gets a typeless pointer to the listed object.
        /// </summary>
        public nint Data
        {
            get
            {
                return rec.data;
            }
        }

        public override nint Reference
        {
            get
            {
                return base.Reference;
            }

            set
            {
                base.Reference = value;
                rec = PInvokeHelper.PtrToStructure<FT_ListNodeRec>(value);
            }
        }

        #endregion
    }
}
