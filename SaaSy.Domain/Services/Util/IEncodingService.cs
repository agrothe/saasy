namespace SaaSy.Domain.Services.Util
{
    public interface IEncodingService
    {
        int AlphaToInt(string value);
        string Base64Decode(string base64EncodedData);
        string Base64Encode(string plainText);
        string IntToAlpha(int value);
    }
}