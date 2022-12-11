using DoQL.Controls.ERD;
using DoQL.Utilities;

namespace DoQL.Interfaces
{
    public interface IConnectable
    {
        Point[] GetConnectablePoints();
        ErdSymbol[] GetSupportedSymbols();
        void Connect(IConnectable connectableControl);
    }
}
