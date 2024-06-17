using System.Numerics;
using UnityEngine;

public class BigIntegerText : MonoBehaviour
{
    public string ToStringBigInteger(BigInteger bigInteger)
    {
        string result = "";

        // 1000이하이면 
        if (BigInteger.Compare(bigInteger, new BigInteger(1000)) == -1)
        {
            result = bigInteger.ToString();
        }
        else if (BigInteger.Compare(bigInteger, new BigInteger(1000000)) == -1)
        {
            string strTmp = bigInteger.ToString();
            result = strTmp.Substring(0, strTmp.Length - 3) + "K";
        }
        else if (BigInteger.Compare(bigInteger, new BigInteger(1000000000)) == -1)
        {
            string strTmp = bigInteger.ToString();
            result = strTmp.Substring(0, strTmp.Length - 6) + "M";
        }

        return result;
    }

}
