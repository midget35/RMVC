using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RMVC {
    public static class REnum {

        public enum RMessageBoxIcon {
            None
            , Default
            , Information
            , Question
            , Warning
            , Error
        }

        public enum RMessageBoxType {
            OK
            , OKCancel
            , YesNo
            , YesNoCancel
            , RetryCancel
            , AbortRetryIgnore
        }

        public enum RMessageBoxResult {
            OK
            , Cancel
            , Yes
            , No
            , Retry
            , Abort
            , Ignore
        }
    }
}
