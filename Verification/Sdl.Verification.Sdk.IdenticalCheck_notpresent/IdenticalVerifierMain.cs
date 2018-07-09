using Sdl.Core.Settings;
using Sdl.FileTypeSupport.Framework.BilingualApi;
using Sdl.FileTypeSupport.Framework.NativeApi;
using Sdl.Verification.Api;
using System;
using System.Collections.Generic;

namespace Sdl.Verification.Sdk.IdenticalCheck
{
    /// <summary>
    /// Required annotation for declaring the extension class.
    /// </summary>
    #region "Declaration"
    [GlobalVerifier("Identical Segments Verifier", "Plugin_Name", "Plugin_Description")]
    #endregion
    public class IdenticalVerifierMain : IGlobalVerifier, IBilingualVerifier, ISharedObjectsAware
    {
        #region "PrivateMembers"
        private ISharedObjects _sharedObjects;
        private IdenticalVerifierSettings _verificationSettings;
        #endregion

        /// <summary>
        /// Initializes the settings bundle object from which to retrieve the setting(s)
        /// to be used in the verification logic, e.g. the context display code to
        /// which the verification should be applied.
        /// </summary>
        #region Settings Bundle
        internal IdenticalVerifierSettings VerificationSettings
        {
            get
            {
                if (_verificationSettings == null && _sharedObjects != null)
                {
                    ISettingsBundle bundle = _sharedObjects.GetSharedObject<ISettingsBundle>("SettingsBundle");
                    if (bundle != null)
                    {
                        _verificationSettings = bundle.GetSettingsGroup<IdenticalVerifierSettings>();
                    }
                }
                return _verificationSettings;
            }
        }
        #endregion


        #region "ISharedObjectsAware Members"
        public void SetSharedObjects(ISharedObjects sharedObjects)
        {
            _sharedObjects = sharedObjects;
        }
        #endregion

        #region Members of IGlobalVerifier
        /// <summary>
        /// The following members set some general properties of the verification plug-in,
        /// e.g. the plug-in name and the icon that are displayed in the user interface of SDL Trados Studio. 
        /// </summary>
        #region "DescriptionNameIcon"
        public string Description
        {
            get { return PluginResources.Verifier_Description; }
        }
        public System.Drawing.Icon Icon
        {
            get { return PluginResources.icon; }
        }

        public string Name
        {
            get { return PluginResources.Plugin_Name; }
        }
        #endregion
        public IList<string> GetSettingsPageExtensionIds()
        {
            IList<string> list = new List<string>();

            list.Add("Identical Settings Definition ID");

            return list;
        }

        public string SettingsId
        {
            get { return "Identical Verifier"; }
        }

        public string HelpTopic
        {
            get { return String.Empty; }
        }

        public Type SettingsType
        {
            get { return typeof(IdenticalVerifierSettings); }
        }
        #endregion

        #region IBilingualFilterComponent Members
        #region "ItemFactory"
        public IDocumentItemFactory ItemFactory
        {
            get;
            set;
        }
        #endregion

        /// <summary>
        /// This member is used to output any verification messages in the user interface of SDL Trados Studio.
        /// </summary>
        #region "MessageReporter"
        public IBilingualContentMessageReporter MessageReporter
        {
            get;
            set;
        }
        #endregion
        #endregion

        #region IBilingualContentHandler Members
        public void Complete()
        {
            // Not required for this implementation.
        }

        public void FileComplete()
        {
            // Not required for this implementation.
        }

        public void SetFileProperties(IFileProperties fileInfo)
        {
            // Not required for this implementation.
        }

        public void Initialize(IDocumentProperties documentInfo)
        {
            // Not required for this implementation.
        }
        #endregion

        #region "process"
        public void ProcessParagraphUnit(IParagraphUnit paragraphUnit)
        {
            // Apply the verification logic.
            CheckParagraphUnit(paragraphUnit);
        }
        #endregion

        /// <summary>
        /// The following member performs the actual verification. It traverses the segment pairs of the current document,
        /// and checks whether a particular segment has any context information (count > 0). It then determines whether
        /// the display code is identical to the display code entered in the plug-in settings.
        /// If this is the case, it determines whether the target segment is actually identical to the source segment.
        /// If not, a warning message will be generated, which is then displayed between the source and target segments,
        /// and in the Messages window of SDL Trados Studio.
        /// </summary>
        /// <param name="paragraphUnit"></param>
        #region "verify"
        private void CheckParagraphUnit(IParagraphUnit paragraphUnit)
        {
            // loop through the whole paragraph unit
            foreach (ISegmentPair segmentPair in paragraphUnit.SegmentPairs)
            {
                // Determine if context information is available,
                // and if the context equals the one specified in the user interface.
                if (paragraphUnit.Properties.Contexts.Contexts.Count > 0 &&
                    paragraphUnit.Properties.Contexts.Contexts[0].DisplayCode == VerificationSettings.CheckContext.Value)
                {

                    // Check whether target differs from source.
                    // If this is the case, then output a warning message
                    if (segmentPair.Source.ToString() != segmentPair.Target.ToString())
                    {
                        MessageReporter.ReportMessage(this, PluginResources.Plugin_Name,
                            ErrorLevel.Warning, PluginResources.Error_NotIdentical,
                            new TextLocation(new Location(segmentPair.Target, true), 0),
                            new TextLocation(new Location(segmentPair.Target, false), segmentPair.Target.ToString().Length - 1));
                    }
                }
            }
        }
        #endregion


    }
}
