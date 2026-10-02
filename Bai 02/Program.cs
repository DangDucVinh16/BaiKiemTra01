using System;
using System.Collections.Generic;
using System.Linq;

namespace LogisticsAutoSpeed
{
    public abstract class PhuongTien
    {
        private string _maPT;
        private string _tenHang;
        private int _namSanXuat;
        private decimal _giaGoc;
        public string MaPT
        {
            get => _maPT;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    _maPT = "PT000";
                else
                    _maPT = value.Trim();
            }
        }

        public string TenHang
        {
            get => _tenHang;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Tên hãng không được để trống!");
                _tenHang = value.Trim();
            }
        }

        public int NamSanXuat
        {
            get => _namSanXuat;
            set
            {
                int currentYear = DateTime.Now.Year;
                if (value < 1900 || value > currentYear)
                    throw new ArgumentException($"Năm sản xuất phải từ 1900 đến năm hiện tại ({currentYear})!");
                _namSanXuat = value;
            }
        }

        public decimal GiaGoc
        {
            get => _giaGoc;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Giá gốc phải lớn hơn 0!");
                _giaGoc = value;
            }
        }
        protected PhuongTien(string maPT, string tenHang, int namSanXuat, decimal giaGoc)
        {
            MaPT = maPT;
            TenHang = tenHang;
            NamSanXuat = namSanXuat;
            GiaGoc = giaGoc;
        }
        public abstract decimal TinhGiaLanBanh();

        public virtual string GetInfo()
        {
            return $"[Mã PT: {MaPT}] | Hãng: {TenHang} | Năm SX: {NamSanXuat} | Giá gốc: {GiaGoc:N0} VNĐ";
        }
    }
    public class OTo : PhuongTien
    {
        private int _soChoNgoi;
        private double _dungTichDongCo;

        public int SoChoNgoi
        {
            get => _soChoNgoi;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Số chỗ ngồi phải lớn hơn 0!");
                _soChoNgoi = value;
            }
        }

        public double DungTichDongCo
        {
            get => _dungTichDongCo;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Dung tích động cơ phải lớn hơn 0!");
                _dungTichDongCo = value;
            }
        }

        public OTo(string maPT, string tenHang, int namSanXuat, decimal giaGoc, int soChoNgoi, double dungTichDongCo)
            : base(maPT, tenHang, namSanXuat, giaGoc)
        {
            SoChoNgoi = soChoNgoi;
            DungTichDongCo = dungTichDongCo;
        }

        public override decimal TinhGiaLanBanh()
        {
            if (SoChoNgoi <= 9)
            {
                decimal lePhiTruocBa = GiaGoc * 0.12m;
                decimal thueTieuThuDacBiet = GiaGoc * 0.30m;
                return GiaGoc + lePhiTruocBa + thueTieuThuDacBiet;
            }
            else
            {
                decimal lePhiTruocBa = GiaGoc * 0.10m;
                return GiaGoc + lePhiTruocBa;
            }
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $" | Ô tô ({SoChoNgoi} chỗ, {DungTichDongCo:F1}L)";
        }
    }
    public class XeMay : PhuongTien
    {
        private int _dungTichXylanh;

        public int DungTichXylanh
        {
            get => _dungTichXylanh;
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Dung tích xylanh phải lớn hơn 0 cc!");
                _dungTichXylanh = value;
            }
        }

        public XeMay(string maPT, string tenHang, int namSanXuat, decimal giaGoc, int dungTichXylanh)
            : base(maPT, tenHang, namSanXuat, giaGoc)
        {
            DungTichXylanh = dungTichXylanh;
        }

        public override decimal TinhGiaLanBanh()
        {
            decimal thueTruocBa = DungTichXylanh < 175 ? GiaGoc * 0.02m : GiaGoc * 0.05m;
            return GiaGoc + thueTruocBa;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $" | Xe máy ({DungTichXylanh} cc)";
        }
    }
    public class QuanLyPhuongTien
    {
        private readonly List<PhuongTien> _danhSach = new();

        public void AddPhuongTien(PhuongTien pt)
        {
            if (pt != null)
            {
                _danhSach.Add(pt);
                Console.WriteLine("=> Thêm phương tiện thành công!");
            }
        }

        public void DisplayAll()
        {
            if (_danhSach.Count == 0)
            {
                Console.WriteLine("Danh sách phương tiện đang trống.");
                return;
            }

            Console.WriteLine("\n--- DANH SÁCH TOÀN BỘ PHƯƠNG TIỆN ---");
            foreach (var pt in _danhSach)
            {
                Console.WriteLine($"{pt.GetInfo()} => Giá lăn bánh: {pt.TinhGiaLanBanh():N0} VNĐ");
            }
        }

        public PhuongTien FindMaxGiaLanBanh()
        {
            if (_danhSach.Count == 0) return null;
            return _danhSach.MaxBy(pt => pt.TinhGiaLanBanh());
        }

        public List<PhuongTien> SearchByName(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword)) return new List<PhuongTien>();
            return _danhSach
                .Where(pt => pt.TenHang.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
    internal class Program
    {
        private static readonly QuanLyPhuongTien Ql = new();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("\n================ HỆ THỐNG LOGISTICS AUTOSPEED ================");
                Console.WriteLine("1. Nhập thông tin Ô tô mới");
                Console.WriteLine("2. Nhập thông tin Xe máy mới");
                Console.WriteLine("3. Hiển thị danh sách toàn bộ phương tiện");
                Console.WriteLine("4. Tìm phương tiện có giá lăn bánh cao nhất");
                Console.WriteLine("5. Tìm kiếm phương tiện theo tên hãng");
                Console.WriteLine("0. Thoát chương trình");
                Console.WriteLine("==============================================================");
                Console.Write("Chọn chức năng (0-5): ");

                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        NhapOTo();
                        break;
                    case "2":
                        NhapXeMay();
                        break;
                    case "3":
                        Ql.DisplayAll();
                        break;
                    case "4":
                        TimGiaLanBanhCaoNhat();
                        break;
                    case "5":
                        TimKiemTheoTen();
                        break;
                    case "0":
                        Console.WriteLine("Cảm ơn bạn đã sử dụng hệ thống!");
                        return;
                    default:
                        Console.WriteLine("Lựa chọn không hợp lệ, vui lòng thử lại.");
                        break;
                }
            }
        }
        private static void NhapOTo()
        {
            Console.WriteLine("\n--- NHẬP THÔNG TIN Ô TÔ ---");
            while (true)
            {
                try
                {
                    string maPT = ReadString("Nhập mã phương tiện (để trống sẽ lấy mặc định PT000): ");
                    string tenHang = ReadString("Nhập tên hãng: ");
                    int namSX = ReadInt("Nhập năm sản xuất: ");
                    decimal giaGoc = ReadDecimal("Nhập giá gốc (VNĐ): ");
                    int soCho = ReadInt("Nhập số chỗ ngồi: ");
                    double dungTich = ReadDouble("Nhập dung tích động cơ (lít): ");

                    OTo oto = new OTo(maPT, tenHang, namSX, giaGoc, soCho, dungTich);
                    Ql.AddPhuongTien(oto);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"[Lỗi dữ liệu]: {ex.Message}. Vui lòng nhập lại!");
                }
            }
        }
        private static void NhapXeMay()
        {
            Console.WriteLine("\n--- NHẬP THÔNG TIN XE MÁY ---");
            while (true)
            {
                try
                {
                    string maPT = ReadString("Nhập mã phương tiện (để trống sẽ lấy mặc định PT000): ");
                    string tenHang = ReadString("Nhập tên hãng: ");
                    int namSX = ReadInt("Nhập năm sản xuất: ");
                    decimal giaGoc = ReadDecimal("Nhập giá gốc (VNĐ): ");
                    int dungTichCc = ReadInt("Nhập dung tích xylanh (cc): ");

                    XeMay xeMay = new XeMay(maPT, tenHang, namSX, giaGoc, dungTichCc);
                    Ql.AddPhuongTien(xeMay);
                    break;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"[Lỗi dữ liệu]: {ex.Message}. Vui lòng nhập lại!");
                }
            }
        }

        private static void TimGiaLanBanhCaoNhat()
        {
            var maxPt = Ql.FindMaxGiaLanBanh();
            if (maxPt == null)
            {
                Console.WriteLine("Danh sách đang trống.");
            }
            else
            {
                Console.WriteLine("\n--- PHƯƠNG TIỆN CÓ GIÁ LĂN BÁNH CAO NHẤT ---");
                Console.WriteLine($"{maxPt.GetInfo()} => Giá lăn bánh: {maxPt.TinhGiaLanBanh():N0} VNĐ");
            }
        }

        private static void TimKiemTheoTen()
        {
            Console.Write("\nNhập từ khóa hãng cần tìm (vd: Toyota, Honda): ");
            string kw = Console.ReadLine();
            var results = Ql.SearchByName(kw);

            if (results.Count == 0)
            {
                Console.WriteLine($"Không tìm thấy phương tiện nào của hãng '{kw}'.");
            }
            else
            {
                Console.WriteLine($"\n--- KẾT QUẢ TÌM KIẾM THEO HÃNG '{kw}' ({results.Count} kết quả) ---");
                foreach (var pt in results)
                {
                    Console.WriteLine($"{pt.GetInfo()} => Giá lăn bánh: {pt.TinhGiaLanBanh():N0} VNĐ");
                }
            }
        }
        private static string ReadString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        private static int ReadInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out int val))
                    return val;
                Console.WriteLine("[Lỗi định dạng]: Vui lòng nhập số nguyên hợp lệ!");
            }
        }

        private static decimal ReadDecimal(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (decimal.TryParse(Console.ReadLine(), out decimal val))
                    return val;
                Console.WriteLine("[Lỗi định dạng]: Vui lòng nhập số thực decimal hợp lệ!");
            }
        }

        private static double ReadDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (double.TryParse(Console.ReadLine(), out double val))
                    return val;
                Console.WriteLine("[Lỗi định dạng]: Vui lòng nhập số thực double hợp lệ!");
            }
        }
    }
}