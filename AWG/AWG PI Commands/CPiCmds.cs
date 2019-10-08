

namespace AwgTestFramework
{
    public partial class CPi70KCmds : IPiCmds
    {
        private readonly TekVISANet.VISA _mAWGVisaSession;
        private readonly VisaExtensions _mVISAExt;
        private readonly UTILS _mPiUtility = new UTILS();
        private uint _mDefaultVISATimeout = 10000;

        public CPi70KCmds(TekVISANet.VISA awgVisaSession, VisaExtensions visaExt)
        {
            _mAWGVisaSession = awgVisaSession;
            _mVISAExt = visaExt;
        }

        public uint DefaultVisaTimeout
        {
            get { return _mDefaultVISATimeout; }
            set { _mDefaultVISATimeout = value; }
        }
    }
}
