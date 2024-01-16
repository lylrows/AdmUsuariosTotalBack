using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

using System.IO;

namespace HumanManagement.ExactusImport.FromFile
{
    public class FileExcelNpoi
    {
        private string filePath;
        private int sheetNumber;
        public FileExcelNpoi(string filePath, int sheetNumber)
        {
            this.filePath = filePath;
            this.sheetNumber = sheetNumber;
        }
        public ISheet ReadFile()
        {
            string extension = Path.GetExtension(filePath).ToUpper();
            ISheet sheet = null;
            if (extension == ".XLS")
            {
                sheet = ReedFileXls();
            }
            else if (extension == ".XLSX")
            {
                sheet = ReadFileXlsx();
            }
            return sheet;
        }
        private ISheet ReedFileXls()
        {
            HSSFWorkbook hssfwb;
            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                hssfwb = new HSSFWorkbook(file);
            }
            ISheet sheet = hssfwb.GetSheetAt(sheetNumber);
            return sheet;
        }
        private ISheet ReadFileXlsx()
        {
            
            XSSFWorkbook xssfwb;
            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                xssfwb = new XSSFWorkbook(file);
            }

            ISheet sheet = xssfwb.GetSheetAt(sheetNumber);
            return sheet;
        }
    }
}
