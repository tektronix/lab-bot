

namespace AwgTestFramework
{
    public partial class CPiExtSourceCmds : IPiCmdsExtSource
    {
        private readonly TekVISANet.VISA _mExtSourceVisaSession;
        private readonly VisaExtensions _mVISAExt;
        private readonly UTILS _mPiUtility = new UTILS();
        private uint _mDefaultVISATimeout = 10000;

        public CPiExtSourceCmds(TekVISANet.VISA extSourceVisaSession, VisaExtensions visaExt)
        {
            _mExtSourceVisaSession = extSourceVisaSession;
            _mVISAExt = visaExt;
        }

        public uint DefaultVisaTimeout
        {
            get { return _mDefaultVISATimeout; }
            set { _mDefaultVISATimeout = value; }
        }
    }
}
