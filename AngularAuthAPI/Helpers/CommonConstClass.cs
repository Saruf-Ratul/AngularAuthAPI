using System.Collections.Generic;
using System.Linq;

namespace Common.Helpers
{
    public static class NRTDebitType
    {
        public const string consolidate = "00",
            Single = "01";
    }

    public static class ActionConst
    {
        public const string Authorize = "A",
            Pending = "P",
            Cancel = "C",
            Decline = "D",
            Verify = "V",
            Stop = "S",
            Reverse = "R";
    }

    public static class ActionMethodConst
    {
        public const string Approve = "approve",
            Amend = "amend",
            Edit = "edit";
    }
    public static class ConstantValue
    {
        public const string
            CompanyCode = "200";
    }
    public static class MessageConst
    {
        public const string
            Insert = "Record has been inserted",
            Update = "Record has been updated",
            Cancel = "Record has been canceled",
            Delete = "Record has been deleted",
            Fetch = "Record fetched successfully",
            InsertError = "Error to insert data",
            UpdateError = "Error to update data",
            DeleteError = "Error to delete data",
            getError = "Error to get data",
            countError = "Count problem",
            SystemError = "System error",
            IsExist = "Already Exists",
            Decline = "Record has been declined",
            Verify = "Record has been verified",
            InActive = "Record has been InActivated",
            Active = "Record has been Activated",
            Stop = "Record has been stopped",
            NotFound = "No record found",
            Found = "Record found",
            Failed = "Failed",
            SendToBEFTN = "Send To BEFTN",
            Paid = "Paid",
            Success = "Success",
            AccountTitleMismatch = "Account Title Mismatch",
            InvalidAccountNo = "Invalid Account Number !",
            TemplateNotFound = "Transaction Template Not Found.",
            AlreadyPaid = "Already Paid",
            CancelPayment = "Payment is Cancelled",
            FileUpload = "File was uploaded successfully",
            Payment = "Payment Successful.",
            NotStop = "Can't Stop. Payment already complete.",
            NotVerified = "Not Verified Yet.",
            NotPaid = "Not Paid Yet.",
            RoutingNumberMissing = "Routing number is missing !",
            InvalidSecurityCode = "Invalid Security Code !",
            HoldForNRTBalance = "Hold for NRT Balance",
            NRTToGLForAPI = "NRT to GL for API",
            AlreadyCancel = "Already Cancelled",
            TooManyRecord = "Too many records found",
            TooManyPreviousRecord = "Too many previous records found",
            DocumentGenerteError = "Error to generte document no.",
            MonthEndNotProcessed = "Pay cycle month not end yet",
            NotFoundSpecific = "Not Found",
            NoSalarySetupFound = "No setup found for this designation",
            NoIncrementSetupFound = "No increment setup found for this designation",
            HigherDocumentDateFound = "Higher document date found",
            GLProcessSuccess = "GL Processed successfully",
            GLPostedSuccess = "GL Posted successfully",
            SalaryPostSuccess = "Salary Posted successfully",
            ReverseSuccess = "History Reversed successfully",
            ReverseError = "Error To Reverse Hisotry Data",
            NothingToProcess = "No data found for processing"
            ;
    }

    public static class MessageCodeConst
    {
        public const string Insert = "00",

            Verify = "01",
            Cancel = "02",
            SystemError = "03",
            IsExist = "04",
            Decline = "05",
            Update = "06",
            Stop = "07",
            NotFound = "08",
            Found = "09",
            NotStop = "10",
             AlreadyPaid = "11",
            CancelPayment = "12",
            AMLProcessing = "13",
            MakerVerify = "14",
            SendToBEFTN = "15",
            ReturnFromBEFTN = "16",
            Hold = "20",
            HoldToAmend = "21",
            Paid = "99",
            Failed = "100",
            AlreadyCancel = "17",
            AccountTitleMismatch = "18",
            InvalidAccount = "19",
            TemplateNotFound = "22",
            RoutingNumberMissing = "23",
            InvalidSecurityCode = "24",
            InvalidPaymentType = "25",
            NRTToGL = "26",
            ReturnFromAML = "27",
            InvalidPINLength = "28",
             InvalidTransactionNo = "29",
            HoldForNRTBalance = "30",
              NRTToGLForAPI = "31"
            ;
    }

    public static class RouteType
    {
        public const string Action = "action",
            Controller = "controller";
    }

    public static class ControllerType
    {
        public const string Controller = "Controller",
            ControllerBase = "ControllerBase";
    }

    public static class MethodType
    {
        public const string HttpPost = "HttpPostAttribute",
            HttpGet = "HttpGetAttribute";
    }

    public static class TypeConst
    {
        public const string String = "String",
            Decimal = "Decimal",
            Long = "Long",
            Int = "Int",
            DateTime = "DateTime";
    }

    public static class PaymentTypeConst
    {
        public const string Cash = "CASH",
             ACTRF = "ACTRF",
            BEFTN = "BEFTN",
             TRANS = "TRANS"
            ;
    }

    public static class OrgDeprtTypeCode
    {
        public const string BA = "BA",
             BR = "BR",
            EX = "EX"
            ;
    }

    public static class YesNoConst
    {
        public const string Yes = "Y",
             No = "N"
            ;
    }

    public static class ServiceNameConst
    {
        public const string ExchangeHouseToRemit = "ExchangeHouseToRemit",
            eRemitToAML = "eRemitToAML",
            eRemitToBatch = "eRemitToBatch",
            eRemitToAgent = "eRemitToAgent",
            eRemitToCBS = "eRemitToCBS",
            JavaAPIToeRemit = "JavaAPIToeRemit";

    }
    public static class EventTypeConst
    {
        public const string NostroToNrd = "00",
            NrdToNrt = "01",
            NrtToCustomer = "02",
            NrtToACTRFForCBS = "03",
            NrtToBEFTNGL = "04",
            NrtToFrdGLForCash = "05",
            BranchGLToCash = "06",
            NrtToGLForAgentBanking = "07",
            SendFromGLToBEFTN = "08",
            NrtToFrdGLForACTRF = "09",
            FrdGLToAccountForACTRF = "10"
            ;
    }
    public static class BranchCodeConst
    {
        public const string Dynamic = "D";
        public const string FRD = "111";
        public const string BankCode = "070";
    }
    public static class RequestTypeConst
    {
        public const string Website = "Website";
        public const string F = "F";
        public const string API = "API";
        public const string GenericApi = "Generic API";
        public const string JavaApi = "JavaAPI";
    }
    public static class AccountNumberConst
    {
        public const string BankAsia = "14100-",
                            FRDCash = "20750-48",
                            FRDACTRT = "20750-49",
                            FRDBEFTN = "20750-30",
                            FRDIncentive = "24100-79",
                            BEFTNClearing = "20750-37"
            ;

    }

    public static class CommonTypeConst
    {
        public const string RemittanceStatus = "RemittanceStatus"
            ;

    }

    public static class NRTToGLPaymentConst
    {
        public const string Sum = "00",
                            Single = "01"
            ;

    }

    public static class VoucherTypeConst
    {
        public const string Credit = "C",
            Debit = "D";
    }

    public static class AmountTypeConst
    {
        public const int PRINCIPAL = 1,
            INCENTIVE = 2,
            TOTAL = 3,
            TOTAL_PAYOUT_AMOUNT = 4,
            PAYOUT_PRINCIPAL = 5,
            TAX = 6,
            VAT = 7,
            COMMISSION = 8,
            FEE = 9,
            FC_TOTAL = 10,
            FC_PRINCIPAL = 11;
    }

    public static class AccountPrefixConst
    {
        public const string AgentBanking = "108",
            HikmahAgent = "508";
    }

    public class ApiReturnModel
    {
        public string YesNo { get; set; }
        public string MessageCode { get; set; }
        public string Message { get; set; }
    }

    public class BeftnReturnModel
    {
        public string YesNo { get; set; }
        public string MessageCode { get; set; }
        public string Message { get; set; }
        public string RRN { get; set; }
    }

    public static class TransactionStatusForEurogiro
    {
        public const string ReadyForPhysicalPayout = "ReadyForPhysicalPayout",
            Paid = "Paid";
    }

    public class RESULT_STATUS
    {
        public string Name { get; set; }
        public bool Status { get; set; }
    }
    public class CustomMsgLib
    {
        private List<MessageBox> Messages = new List<MessageBox>();
        private int successCode = 0;

        private string successMsg = string.Empty;

        public CustomMsgLib()
        {
            this.SetCustomMsg();
        }

        public string GetSuccessMsg(string codeNo)
        {
            var message = Messages.FirstOrDefault(m => m.MsgCode == codeNo);

            if (message == null)
            {
                return codeNo;
            }

            return message.Message;
        }

        private void SetCustomMsg()
        {

            this.Messages.Add(new MessageBox() { MsgCode = "00", Message = "Received" });
            this.Messages.Add(new MessageBox() { MsgCode = "01", Message = "Approved" });
            this.Messages.Add(new MessageBox() { MsgCode = "02", Message = "Canceled" });
            this.Messages.Add(new MessageBox() { MsgCode = "03", Message = "System error." });
            this.Messages.Add(new MessageBox() { MsgCode = "04", Message = "The transaction already exist in the system." });
            this.Messages.Add(new MessageBox() { MsgCode = "05", Message = "Decline" });
            this.Messages.Add(new MessageBox() { MsgCode = "06", Message = "Update" });
            this.Messages.Add(new MessageBox() { MsgCode = "07", Message = "Stop" });
            this.Messages.Add(new MessageBox() { MsgCode = "08", Message = "The transaction is not found in the system." });
            this.Messages.Add(new MessageBox() { MsgCode = "09", Message = "Transaction found in the system." });
            this.Messages.Add(new MessageBox() { MsgCode = "10", Message = "The transaction is not stop." });
            this.Messages.Add(new MessageBox() { MsgCode = "11", Message = "The transaction already paid." });
            this.Messages.Add(new MessageBox() { MsgCode = "12", Message = "Payment is Cancelled" });
            this.Messages.Add(new MessageBox() { MsgCode = "13", Message = "AML processing" });
            this.Messages.Add(new MessageBox() { MsgCode = "14", Message = "Maker Verify" });
            this.Messages.Add(new MessageBox() { MsgCode = "15", Message = "Send to BEFTN" });
            this.Messages.Add(new MessageBox() { MsgCode = "16", Message = "Return from BEFTN" });
            this.Messages.Add(new MessageBox() { MsgCode = "17", Message = "Already Cancelled." });
            this.Messages.Add(new MessageBox() { MsgCode = "18", Message = "Account title mismatch." });
            this.Messages.Add(new MessageBox() { MsgCode = "19", Message = "Invalid Account." });
            this.Messages.Add(new MessageBox() { MsgCode = "20", Message = "Hold" });
            this.Messages.Add(new MessageBox() { MsgCode = "21", Message = "Hold to amendment" });
            this.Messages.Add(new MessageBox() { MsgCode = "22", Message = "Transaction template not found." });
            this.Messages.Add(new MessageBox() { MsgCode = "23", Message = "Routing number missing !" });
            this.Messages.Add(new MessageBox() { MsgCode = "24", Message = "Invalid security code !" });
            this.Messages.Add(new MessageBox() { MsgCode = "25", Message = "Invalid payment type" });
            this.Messages.Add(new MessageBox() { MsgCode = "26", Message = "NRT to GL" });
            this.Messages.Add(new MessageBox() { MsgCode = "99", Message = "Paid" });
            this.Messages.Add(new MessageBox() { MsgCode = "100", Message = "Failed" });
            this.Messages.Add(new MessageBox() { MsgCode = "27", Message = "Return from AML" });
            this.Messages.Add(new MessageBox() { MsgCode = "28", Message = "Invalid PIN length" });
            this.Messages.Add(new MessageBox() { MsgCode = "29", Message = "Invalid transaction number." });
            this.Messages.Add(new MessageBox() { MsgCode = "30", Message = "Hold for NRT Balance" });
            this.Messages.Add(new MessageBox() { MsgCode = "31", Message = "NRT to GL for API" });
        }
    }

    public class MessageBox
    {
        public string MsgCode { get; set; }
        public string Message { get; set; }
    }

    public static class BankPolicyConst
    {
        public const int AccountMismatch = 60;
    }

    public static class ResponseCodeConst
    {
        public const string NoResponseAML = "OFF",

            NoResponseReturn = "N/F",
            AMLOFF = "AML Service Off."
            ;
    }

    public static class AML_STATUS
    {
        public const string Good = "GUD",
            Bad = "BAD",
            Pending = "PEN"
            ;
    }

    public static class SearchStringType
    {
        public const string
            _string = "string",
            _date = "date",
            _int = "int";
    }

    public static class APIResponse
    {
        public const string Downloaded = "00",
            PaidInformed = "01";
    }
}
