using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECC
{
    public class ExceptionHandleASCII
    {
        public static bool checkException(char s)
        {
            if (s == 'ẹ' || s == 'ệ' ||
                s == 'ụ' || s == 'ự' ||
                s == 'ị' ||
                s == 'ọ' || s == 'ộ' || s == 'ợ' ||
                s == 'ạ' || s == 'ậ' || s == 'ặ')
            {
                return true;
            }
            return false;
        }
        public static int ConvertToInt(char s)
        {
            switch (s)
            {
                case 'ẹ': return 256;
                case 'ệ': return 257;
                case 'ụ': return 258;
                case 'ự': return 259;
                case 'ị': return 260;
                case 'ọ': return 261;
                case 'ộ': return 262;
                case 'ợ': return 263;
                case 'ạ': return 264;
                case 'ậ': return 265;
                case 'ặ': return 266;
                case 'ỵ': return 267;

                case 'ẽ': return 268;
                case 'ễ': return 269;
                case 'ũ': return 270;
                case 'ữ': return 271;
                case 'ĩ': return 272;
                //case 'õ': return 273;
                case 'ỗ': return 274;
                case 'ỡ': return 275;
                //case 'ã': return 276;
                case 'ẫ': return 277;
                case 'ẵ': return 278;
                case 'ỹ': return 279;

                case 'ẻ': return 280;
                case 'ể': return 281;
                case 'ủ': return 282;
                case 'ử': return 283;
                case 'ỉ': return 284;
                case 'ỏ': return 285;
                case 'ổ': return 286;
                case 'ở': return 287;
                case 'ả': return 288;
                case 'ẩ': return 289;
                case 'ẳ': return 290;
                case 'ỷ': return 291;

                case 'ế': return 292;
                case 'ứ': return 293;
                case 'ố': return 294;
                case 'ớ': return 295;
                case 'ấ': return 296;
                case 'ắ': return 297;

                case 'ề': return 298;
                case 'ừ': return 299;
                case 'ồ': return 300;
                case 'ờ': return 301;
                case 'ầ': return 302;
                case 'ằ': return 303;

                default: return (int) s;
            }
        }
        public static char ConverToChar(int i)
        {
            switch (i)
            {
                case 256: return 'ẹ';
                case 257: return 'ệ';
                case 258: return 'ụ';
                case 259: return 'ự';
                case 260: return 'ị';
                case 261: return 'ọ';
                case 262: return 'ộ';
                case 263: return 'ợ';
                case 264: return 'ạ';
                case 265: return 'ậ';
                case 266: return 'ặ';
                case 267: return 'ỵ';

                case 268: return 'ẽ';
                case 269: return 'ễ';
                case 270: return 'ũ';
                case 271: return 'ữ';
                case 272: return 'ĩ';
                //case 273: return 'õ';
                case 274: return 'ỗ';
                case 275: return 'ỡ';
                //case 276: return 'ã';
                case 277: return 'ẫ';
                case 278: return 'ẵ';
                case 279: return 'ỹ';

                case 280: return 'ẻ';
                case 281: return 'ể';
                case 282: return 'ủ';
                case 283: return 'ử';
                case 284: return 'ỉ';
                case 285: return 'ỏ';
                case 286: return 'ổ';
                case 287: return 'ở';
                case 288: return 'ả';
                case 289: return 'ẩ';
                case 290: return 'ẳ';
                case 291: return 'ỷ';

                case 292: return 'ế';
                case 293: return 'ứ';
                case 294: return 'ố';
                case 295: return 'ớ';
                case 296: return 'ấ';
                case 297: return 'ắ';

                case 298: return 'ề';
                case 299: return 'ừ';
                case 300: return 'ồ';
                case 301: return 'ờ';
                case 302: return 'ầ';
                case 303: return 'ằ';

                default: return (char)i;
            }
        }
    }
}
