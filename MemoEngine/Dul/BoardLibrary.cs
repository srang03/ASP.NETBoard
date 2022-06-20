using System;
using System.Collections.Generic;
using System.IO;

namespace Dul
{
    public class BoardLibrary
    {
        #region 각 글의 Step별로 들여쓰기 처리
        public static string FuncStep(object objStep)
        {
            if (int.TryParse(objStep.ToString(), out int intStep))
            {
                string strTemp = string.Empty;

                if (intStep == 0)
                {
                    strTemp = String.Empty;
                }
                else
                {
                    for (int i = 0; i < intStep; i++)
                    {
                        strTemp = String.Format(
                            "<img src=\"{0}\" height=\"{1}\" width=\"{2}\">",
                            "/images/dnn/blank.gif", "0", (intStep * 15));
                    }
                    strTemp += "<img src=\"/images/dnn/re.gif\">";
                }
                return strTemp;
            }

            return string.Empty;
        }
        #endregion

        #region 댓글 개수를 표현하는 메서드
        public static string ShowCommentCount(object objCommentCount)
        {
            string strTemp = string.Empty;

            try
            {
                if (int.TryParse(objCommentCount.ToString(), out int count))
                {
                    strTemp = "<img src=\"/images/dnn/commentCount.gif\" />";
                    strTemp += "(" + objCommentCount.ToString() + ")";
                }
            }
            catch (Exception ex)
            {
                strTemp = string.Empty;
            }
            return strTemp;
        }
        #endregion

        #region 24시간 이내에 올라온 글 new 이미지 표시하기
        public static string FuncNew(object strDate)
        {
            if (strDate != null)
            {
                if (!String.IsNullOrEmpty(strDate.ToString()))
                {
                    DateTime originDate = Convert.ToDateTime(strDate);

                    TimeSpan objTs = DateTime.Now - originDate;
                    string newImage = "";
                    if (objTs.TotalMinutes < 1440)
                    {
                        newImage = "<img src=\"/images/dnn/new.gif\">";
                    }
                    return newImage;
                }
            }
            return string.Empty;
        }
        #endregion

        #region 넘겨온 날짜 형식이 오늘 날짜면 시간 표시
        public static string FuncShowTime(object date)
        {
            if (date != null)
            {
                if (DateTime.TryParse(date.ToString(), out DateTime PostDate))
                {
                    string strPostDate = PostDate.ToString("yyyy-MM-dd");
                    if (strPostDate == DateTime.Now.ToString("yyyy-mm-dd"))
                    {
                        return PostDate.ToString("hh:mm:ss");
                    }
                    else
                    {
                        return strPostDate;
                    }
                }
            }
            return string.Empty;
        }
        #endregion

        #region ConvertToFileSize() 함수
        // 파일 크기를 계산해서 알맞은 단위로 변환한다.
        public static string ConvertToFileZise(int intByte)
        {
            string strResult = string.Empty;
            if (intByte >= 1048576)
            {
                strResult = string.Format("{0:F} MB", (intByte / 1048576));
            }
            else
            {
                if (intByte >= 1024)
                {
                    strResult = string.Format("{0} KB", (intByte / 1024));
                }
                else
                {
                    strResult = intByte + "Byte(s)";
                }
            }
            return strResult;
        }
        #endregion

        #region IsPhoto() 함수
        // 파일 확장자를 확인해서 이미지 파일인지 아닌지 검사
        public static bool IsPhoto(string strFileNameTemp)
        {
            string ext = Path.GetExtension(strFileNameTemp).Replace(".", "").ToLower();
            bool blnResult = false;
            List<string> imgExtList = new List<string> { "gif", "jpg", "jpeg", "png" };
            imgExtList.ForEach(i =>
            {
                if (ext == i)
                {
                    blnResult = true;
                }
            });
            return blnResult;
        }
        #endregion

        #region 파일 다운로드 기능
        // 파일 다운로드 기능
        // 주의 : 각 필드에 NULL 값이 있다면 에러 발생
        public static string FuncFileDownSingle(
           int id, string strFileName, string strFileSize)
        {
            if (strFileName.Length > 0)
            {
                return "< a href =\"/ DotNetNote / BoardDown.aspx ? Id ="
                  + id.ToString() + "\">"
                  + "파일 다운로드"
                  + "</a>";
            }
            else
            {
                return "-";
            }
        }
        #endregion

        #region
        public static string DownloadType(string strFileName, string altString)
        {
            string strFileExt = Path.GetExtension(strFileName).Replace(".", "").ToLower();
            string res = string.Empty;
            switch (strFileExt)
            {
                case "bmp":
                    res = "<img src='/images/ext/ext_bmp.gif' border='0' alt='"
                    + altString + "'>";
                break;

                case "css" :
                   res = "<img src='/images/ext/ext_css.gif' border='0' alt='"
                        + altString + "'>";
                break;

                case "gif" :
                    res = "<img src='/images/ext/ext_gif.gif' border='0' alt='"
                    + altString + "'>";
                    break;

                case "htm":
                res = "<img src='/images/ext/ext_htm.gif' border='0' alt='"
                    + altString + "'>";
                    break;

                case "html":
                    res = "<img src='/images/ext/ext_html.gif' border='0' alt='"
                    + altString + "'>";
                    break;

                case "jpg":
                    res = "<img src='/images/ext/ext_jpg.gif' border='0' alt='"
                    + altString + "'>";
                    break;

                case "jpeg" :
                    res = "<img src='/images/ext/ext_jpeg.gif' border='0' alt='"
                    + altString + "'>";
                    break;

                case "js" :
                    res = "<img src='/images/ext/ext_js.gif' border='0' alt='"
                    + altString + "'>";
                    break;

                case "":
                    res = "<img src='/images/ext/ext_none.gif' border='0' alt='"
                    + altString + "'>";
                    break;

                case "png":
                    res = "<img src='/images/ext/ext_png.gif' border='0' alt='"
                    + altString + "'>";
                    break;

                case "sql":
                    res = "<img src='/images/ext/ext_sql.gif' border='0' alt='"
                    + altString + "'>";
                    break;

                case "txt" :
                    res = "<img src='/images/ext/ext_txt.gif' border='0' alt='"
                    + altString + "'>";
                    break;

                case "zip" :
                    res = "<img src='/images/ext/ext_zip.gif' border='0' alt='"
                    + altString + "'>";
                    break;

                default:
                    res = "<img src='/images/ext/ext_unknown.gif' border='0' alt='"
                    + altString + "'>";
                    break;
            }
        return res;

        }
        #endregion
    }
}
