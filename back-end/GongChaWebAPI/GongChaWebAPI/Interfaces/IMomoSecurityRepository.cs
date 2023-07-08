namespace GongChaWebAPI.Interfaces
{
    public interface IMomoSecurityRepository
    {
        string getHash(string partnerCode, string merchantRefId, string amount, string paymentCode, string storeId, string storeName, string publicKeyXML);
        string buildQueryHash(string partnerCode, string merchantRefId, string requestid, string publicKey);
        string buildRefundHash(string partnerCode, string merchantRefId, string momoTranId, long amount, string description, string publicKey);
        string signSHA256(string message, string key);
    }
}
