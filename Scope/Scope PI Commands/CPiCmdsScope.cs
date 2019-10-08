

namespace AwgTestFramework
{
    public partial class CPiScopeCmds : IPiCmdsScope
    {
        private readonly TekVISANet.VISA _mScopeVisaSession;
        private readonly VisaExtensions _mVISAExt;
        private readonly UTILS _mPiUtility = new UTILS();
        private uint _mDefaultVISATimeout = 10000;

        public CPiScopeCmds(TekVISANet.VISA scopeVisaSession, VisaExtensions visaExt)
        {
            _mScopeVisaSession = scopeVisaSession;
            _mVISAExt = visaExt;
        }

        public uint DefaultVisaTimeout
        {
            get { return _mDefaultVISATimeout; }
            set { _mDefaultVISATimeout = value; }
        }
    }
}
