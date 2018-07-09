using System;
using Sdl.FileTypeSupport.Framework;
using Sdl.FileTypeSupport.Framework.IntegrationApi;
using Sdl.FileTypeSupport.Framework.NativeApi;

namespace Sdl.Sdk.FileTypeSupport.Samples.SimpleText.Preview
{
    class InternalPreviewController : ISingleFilePreviewControl, INavigablePreview, IPreviewUpdatedViaRefresh, IDisposable
    {
        #region "global"
        InternalPreviewControl _control; // the actual control object
        private bool disposed = false; // used for properly disposing of the control        
        FileId _fileId; // the actual file ID

        // indicates whether a file has already been opened in the preview, 
        // so we know if we should close it during a Refresh()  
        bool _isFileOpen = false;
        #endregion

        #region "init"
        /// <summary>
        /// initialize the preview controller and preview control
        /// </summary>
        public InternalPreviewController()
        {
            _control = new InternalPreviewControl();
        }

        /// <summary>
        /// used for disposing of the control
        /// </summary>
        ~InternalPreviewController()
        {
            Dispose(false);
        }
        #endregion


        #region "IAbstractPreviewControl Members"
        /// <summary>
        /// return a preview control
        /// </summary>
        public System.Windows.Forms.Control Control
        {
            get { return _control; }
        }

        /// <summary>
        /// handler for the WindowSelectionChanged event from the preview control,
        /// raises the corresponding event on the INavigablePreview interface.
        /// </summary>
        /// <param name="component"></param>
        void _Control_WindowSelectionChanged(IInteractivePreviewComponent component)
        {
            var marker = _control.GetSelectedSegment();
            SegmentReference selectedSegment = new SegmentReference(_fileId, marker.ParagraphUnitId, marker.SegmentId);

            // raise the event
            OnSegmentSelected(this, new SegmentSelectedEventArgs(this, selectedSegment));
        }

        /// <summary>
        /// refresh the file in the preview control
        /// </summary>
        public void Refresh()
        {
            if (_isFileOpen)
            {
                _control.WindowSelectionChanged -= new PreviewControlHandler(_Control_WindowSelectionChanged);
                _control.Close();
            }

            // show the preview file in the control
            _control.OpenTarget(PreviewFile.FilePath);

            // attach event handler
            _control.WindowSelectionChanged += new PreviewControlHandler(_Control_WindowSelectionChanged);

            _isFileOpen = true;
        }
        #endregion

        #region "Temp File Manager"
        /// <summary>
        /// access to the temporary preview file
        /// </summary>
        public TempFileManager PreviewFile
        {
            get;
            set;
        }


        #endregion


        #region "INavigablePreview Members"
        /// <summary>
        /// reference to the current segment
        /// </summary>
        /// <param name="segment"></param>
        public void NavigateToSegment(SegmentReference segment)
        {
            _fileId = segment.FileId;
            _control.ScrollToSegment(segment);
        }

        /// <summary>
        /// communicates the preferred highlighting in the control
        /// not used in this implementation
        /// </summary>
        public System.Drawing.Color PreferredHighlightColor
        {
            get;
            set;
        }

        public event EventHandler<SegmentSelectedEventArgs> SegmentSelected;

        /// <summary>
        /// custom implementaton - raise the <see cref="SegmentSelected"/> event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        public virtual void OnSegmentSelected(object sender, SegmentSelectedEventArgs args)
        {
            if (SegmentSelected != null)
            {
                SegmentSelected(sender, args);
            }
        }
        #endregion

        #region "IDisposable Members"
        /// <summary>
        /// deletes the preview file, if it exists.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        /// <summary>
        /// implementation of the recommended dispose protocol
        /// deletes the file if possible.
        /// </summary>
        /// <param name="disposing">true if this method is called from IDisposable.Dispose() and false if called from Finalizer</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                try
                {
                    if (disposing)
                    {
                        PreviewFile.Dispose();
                    }
                    // release the native unmanaged resources you added
                    // in this derived class here.

                    this.disposed = true;
                }
                finally
                {
                }
            }
        }
        #endregion

        #region "IPreviewUpdatedViaRefresh Members"
        public void AfterFileRefresh()
        {
            Refresh();
            ((InternalPreviewControl)Control).JumpToActiveElement();
        }

        public void BeforeFileRefresh()
        {
            // no action required here
        }


        /// <summary>
        /// returns the file for preview
        /// </summary>
        public TempFileManager TargetFilePath
        {
            get;
            set;
        }
        #endregion
    }
}
