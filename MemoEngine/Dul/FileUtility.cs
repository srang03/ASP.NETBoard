using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dul
{
    public class FileUtility
    {
        #region 중복된 파일명 뒤에 번호 붙이는 메서드
        public static string GetFileNameWithNumbering(string dir, string filename)
        {
            string strName = Path.GetFileNameWithoutExtension(filename);        

            string strExtension = Path.GetExtension(filename);

            bool blnExists = true;
            int i = 0;
            while (blnExists)
            {
                if(File.Exists(Path.Combine(dir, filename)))
                {
                    filename = strName + "_" + (++i) + strExtension;
                }
                else
                {
                    blnExists = false;
                }
            }
            return filename;
        }
        #endregion
    }
}
