using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HintChatGreenPro
{
    class Program
    {
        public class CommandChat
        {
            public string Command;

            public string Parameters;

            public string Description;

            public bool IsPro;

            public CommandChat(string c, string p, string d, bool isPro = false)
            {
                Command = c;
                Parameters = p;
                Description = d;
                IsPro = isPro;
            }

            public CommandChat(string c, string d, bool isPro = false)
            {
                Command = c;
                Parameters = "";
                Description = d;
                IsPro = isPro;
            }

            public string GetHint()
            {
                return string.Format("{0}{1}: {2}", Command, Parameters, Description);
            }
        }

        public static List<CommandChat> CommandChats;

        public static void loadinfo()
        {
            CommandChats = new List<CommandChat>();
            /// FREE
            CommandChats.Add(new CommandChat("help", "Mở web hướng dẫn sử dụng"));
            // Hiển Thị
            CommandChats.Add(new CommandChat("minimap", "Bật/Tắt hiển thị minimap"));
            CommandChats.Add(new CommandChat("schar", "Bật/Tắt hiển thị danh sách người chơi trong map"));
            CommandChats.Add(new CommandChat("sinfo", "Bật/Tắt hiển thị thông tin sư phụ - đệ tử"));
            CommandChats.Add(new CommandChat("mshow", "Bật/Tắt hiển thị thông tin"));
            CommandChats.Add(new CommandChat("khoakhu", "Bật/Tắt khoá chuyển khu"));
            CommandChats.Add(new CommandChat("unikey", "Bật/Tắt gõ tiếng việt (Tắt phần mềm gõ tiếng việt trước khi dùng)"));
            CommandChats.Add(new CommandChat("lgoto", "Dịch chuyển lại tới đối tượng đã dịch chuyển trước đó"));
            // Săn boss
            CommandChats.Add(new CommandChat("sboss", "Bật/Tắt hiển thị thông báo boss"));
            CommandChats.Add(new CommandChat("onlyboss", "Bật/Tắt chỉ hiển thị boss trong map"));
            CommandChats.Add(new CommandChat("showhp", "Bật/Tắt hiển thị HP boss và người chơi trong map"));
            CommandChats.Add(new CommandChat("fboss ", "X", "Tìm boss có tên X"));
            CommandChats.Add(new CommandChat("clfboss", "Xoá danh sách tìm boss"));
            CommandChats.Add(new CommandChat("vfboss", "Xem danh sách tìm boss"));
            // Ẩn thông tin
            CommandChats.Add(new CommandChat("antk", "Ẩn thông tin tài khoản, hiện Chưa đăng ký"));
            CommandChats.Add(new CommandChat("hskill", "Bật/Tắt hiển thị thời gian hồi skill"));
            CommandChats.Add(new CommandChat("annguoi", "Bật/Tắt hiển thị người chơi trong map"));
            CommandChats.Add(new CommandChat("anquai", "Bật/Tắt hiển thị quái trong map"));
            CommandChats.Add(new CommandChat("anitem", "Bật/Tắt hiển thị item trong map"));
            CommandChats.Add(new CommandChat("xhq", "Bật/Tắt hiển thị hào quang"));
            CommandChats.Add(new CommandChat("xht", "Bật/Tắt hiển thị hiệu ứng hợp thể"));
            // Chức năng hỗ trợ
            CommandChats.Add(new CommandChat("s", "X", "Chỉnh tốc độ giày X"));
            CommandChats.Add(new CommandChat("speed", "X", "Cheat tốc độ game X"));
            CommandChats.Add(new CommandChat("ak", "Bật/Tắt tự đánh (Với các đối tượng gây được sát thương)"));
            CommandChats.Add(new CommandChat("xak", "Bật/Tắt tự đánh (Với tất cả đối tượng được trỏ)"));
            CommandChats.Add(new CommandChat("ak", "X", "Bật/Tắt theo Xmilis"));
            CommandChats.Add(new CommandChat("tl", "Gọi Calic qua tương lai"));
            CommandChats.Add(new CommandChat("night", "Đổi màu trời tối (Chỉ bật ở cấu hình cao)"));
            CommandChats.Add(new CommandChat("hsme", "Tự hồi sinh dành cho namec"));
            CommandChats.Add(new CommandChat("ahs", "Bật/Tắt auto hồi sinh bằng ngọc"));
            CommandChats.Add(new CommandChat("gmt", "Bật/Tắt khoá mục tiêu đang chọn"));
            // Auto Khu
            CommandChats.Add(new CommandChat("k", "X", "Đổi khu X"));
            // Auto đệ tử
            CommandChats.Add(new CommandChat("udt", "Bật/Tắt hiển thị chỉ số đệ tử real-time"));
            CommandChats.Add(new CommandChat("csdt", "Mở chỉ số đệ tử"));
            // Auto Đậu
            CommandChats.Add(new CommandChat("chodau", "Bật/Tắt cho đậu"));
            CommandChats.Add(new CommandChat("xindau", "Bật/Tắt xin đậu"));
            CommandChats.Add(new CommandChat("thudau", "Bật/Tắt thu đậu (Nhân vật phải đứng ở nhà)"));
            CommandChats.Add(new CommandChat("spean ", "X", "Thêm nhân vật X vào danh sách được cho đậu (Chỉ định nhân vật nhận đậu thần)"));
            CommandChats.Add(new CommandChat("clspean", "Xoá danh sách nhân vật nhận đậu thần"));
            CommandChats.Add(new CommandChat("vspean", "Hiển thị danh sách nhận đậu thần"));
            // Auto Skill
            CommandChats.Add(new CommandChat("askillX", "Bật/Tắt auto skill X"));
            // Auto Chat
            CommandChats.Add(new CommandChat("atc", "Bật/Tắt auto chat"));
            CommandChats.Add(new CommandChat("atc ", "X", "Thay đổi nội dung auto chat thành X"));
            CommandChats.Add(new CommandChat("actg", "Bật/Tắt auto chat thế giới"));
            CommandChats.Add(new CommandChat("tatcg", "X", "Set thời gian giữa mỗi lần chat thế giới X giây"));
            CommandChats.Add(new CommandChat("actg ", "X", "Thay đổi nội dung auto chat thế giới thành X"));
            // Fake thông tin
            CommandChats.Add(new CommandChat("vang", "X", "Fake vàng ảo X"));
            CommandChats.Add(new CommandChat("ngoc", "X", "Fake ngọc xanh ảo X"));
            CommandChats.Add(new CommandChat("hngoc", "X", "Fake ngọc hồng ảo X"));
            CommandChats.Add(new CommandChat("sm", "X", "Fake sức mạnh ảo X"));
            CommandChats.Add(new CommandChat("tn", "X", "Fake tiềm năng ảo X"));
            CommandChats.Add(new CommandChat("fname ", "X", "Fake tên nhân vật ảo X"));
            // Di chuyển
            CommandChats.Add(new CommandChat("u", "Khinh công"));
            CommandChats.Add(new CommandChat("d", "Độn thổ"));
            CommandChats.Add(new CommandChat("r", "Dịch phải"));
            CommandChats.Add(new CommandChat("l", "Dịch trái"));
            CommandChats.Add(new CommandChat("u", "X", "Khinh công X"));
            CommandChats.Add(new CommandChat("d", "X", "Độn thổ X"));
            CommandChats.Add(new CommandChat("l", "X", "Dịch trái X"));
            CommandChats.Add(new CommandChat("r", "X", "Dịch phải X"));
            // Tính năng khác
            CommandChats.Add(new CommandChat("chantn", "Bật/Tắt chặn tin nhắn riêng"));
            CommandChats.Add(new CommandChat("confirm", "Mở menu vừa xác nhận"));
            CommandChats.Add(new CommandChat("szone", "Mở bảng đổi khu"));
            CommandChats.Add(new CommandChat("friend", "Mở bảng bạn bè"));
            CommandChats.Add(new CommandChat("flag", "Mở bảng đổi cờ"));
            CommandChats.Add(new CommandChat("enemy", "Mở bảng kẻ thù"));
            CommandChats.Add(new CommandChat("petinfo", "Mở thông tin đệ tử"));
            CommandChats.Add(new CommandChat("scsbX", "Sử dụng menu X capsule bay"));
            CommandChats.Add(new CommandChat("ucapsule", "Sử dụng capsule (Ưu tiên capsule đặc biệt)"));
            CommandChats.Add(new CommandChat("dbdctt", "Nhấp đôi chuột dịch chuyển tới đối tượng đang chọn"));
            CommandChats.Add(new CommandChat("copy", "Bật/Tắt copy cải trang của nhân vật hoặc Npc được trỏ"));
            CommandChats.Add(new CommandChat("kvt", "Bật/Tắt khoá vị trí"));
            CommandChats.Add(new CommandChat("c", "Đóng băng skill hiện tại"));
            CommandChats.Add(new CommandChat("uitem", "X", "Sử dụng itemID X"));
            CommandChats.Add(new CommandChat("gofocus", "Dịch đến đối tượng đang trỏ"));
            // Né Boss Up Đệ
            CommandChats.Add(new CommandChat("maxchar", "X", "Thiết lập số người tối đa trong khu là X"));
            CommandChats.Add(new CommandChat("neboss", "Bật/Tắt né boss up đệ"));
            // Auto Login
            CommandChats.Add(new CommandChat("alogin", "Bật/Tắt auto login khi mất kết nối"));
            CommandChats.Add(new CommandChat("akhu", "Bật/Tắt vào khu cũ khi auto login"));
            // Xmap
            CommandChats.Add(new CommandChat("xmp", "Mở menu xmap"));
            CommandChats.Add(new CommandChat("xmp", "X", "Dùng xmap tới map có id X"));
            CommandChats.Add(new CommandChat("csb", "Dùng capsule thường xmap"));
            CommandChats.Add(new CommandChat("csdb", "Dùng capsule đặc biệt xmap"));
            
            // Tự động đánh quái
            CommandChats.Add(new CommandChat("add", "Thêm/Xoá quái hoặc vật phẩm ở danh sách tương ứng"));
            CommandChats.Add(new CommandChat("addt", "Thêm/Xoá loại quái hoặc loại vật phẩm ở danh sách tương ứng"));
            CommandChats.Add(new CommandChat("ts", "Bật/Tắt tự động đánh quái"));
            CommandChats.Add(new CommandChat("nsq", "Bật/Tắt né siêu quái khi tự động đánh quái (Mặc định bật)"));
            CommandChats.Add(new CommandChat("addm", "X", "Thêm vào/Xoá khỏi danh sách đánh quái id X (X là id quái)"));
            CommandChats.Add(new CommandChat("addtm", "Thêm vào/Xoá khỏi danh sách đánh loại quái id X (X là id loại quái)"));
            CommandChats.Add(new CommandChat("clrm", "Xoá danh sách tàn sát"));
            CommandChats.Add(new CommandChat("skill", "Thêm vào/Xoá khỏi danh sách skill sử dụng tự động đánh quái"));
            CommandChats.Add(new CommandChat("skill", "X", "Thêm vào/Xoá khỏi danh sách skill sử dụng tự động đánh quái skill thứ X (X là thứ tự skill)"));
            CommandChats.Add(new CommandChat("skillid", "X", "Thêm vào/Xoá khỏi danh sách skill sử dụng tự động đánh quái skill id X ( là id skill)"));
            CommandChats.Add(new CommandChat("clrs", "Đặt danh sách skill sử dụng tự động đánh quái về mặc định"));
            CommandChats.Add(new CommandChat("abf", "Bật/Tắt tự động sử dụng đậu thần (KI, HP dưới 20%)"));
            CommandChats.Add(new CommandChat("abf", "X", "Bật tự động sử dụng đậu thần khi HP dưới X%"));
            CommandChats.Add(new CommandChat("abf", "X_Y", "Bật tự động sử dụng đậu thần khi HP dưới X%, KI dưới Y%"));
            CommandChats.Add(new CommandChat("vdh", "Bật/Tắt vượt địa hình (mặc định Bật)"));
            // Lệnh tự động nhặt vật phẩm
            CommandChats.Add(new CommandChat("anhat", "Bật/Tắt tự động nhặt vật phẩm (Mặc định bật)"));
            CommandChats.Add(new CommandChat("itm", "Bật/Tắt lọc không nhặt vật phẩm của người khác (Mặc định bật)"));
            CommandChats.Add(new CommandChat("sln", "Bật/Tắt giới hạn số lần tự động nhặt một vật phẩm (Mặc định bật)"));
            CommandChats.Add(new CommandChat("sln", "X", "Thay đổi giới hạn số lần nhặt là X (Mặc định X = 7)"));
            CommandChats.Add(new CommandChat("addi", "X", "Thêm vào/Xoá khỏi danh sách chỉ tự động nhặt vật phẩm id X (X là id vật phẩm)"));
            CommandChats.Add(new CommandChat("blocki", "Thêm vào/Xoá khỏi danh sách không tự động nhặt vật phẩm đang trỏ"));
            CommandChats.Add(new CommandChat("blocki", "X", "Thêm vào/Xoá khỏi danh sách không tự động nhặt vật phẩm id X"));
            CommandChats.Add(new CommandChat("addti", "X", "Thêm vào/Xoá khỏi danh sách chỉ tự động nhặt loại vật phẩm id X(X là id loại vật phẩm)"));
            CommandChats.Add(new CommandChat("blockti", "X", "Thêm vào/Xoá khỏi danh sách không tự động nhặt loại vật phẩm id X"));
            CommandChats.Add(new CommandChat("clri", "Cài đặt lại danh sách lọc vật phẩm vể mặc định (danh sách chỉ nhặt và danh sách chặn)"));
            CommandChats.Add(new CommandChat("cnn", "Cài đặt nhanh chỉ nhặt ngọc (tương ứng lệnh chat \"clri\"và \"addi77\")"));


            /// PRO
            // Auto Item
            CommandChats.Add(new CommandChat("aitem", "Bật/Tắt auto item có đếm ngược thời gian", true));
            CommandChats.Add(new CommandChat("clitem", "Xoá danh sách Auto Item", true));
            // Auto Item Theo Thời Gian
            CommandChats.Add(new CommandChat("aitemt", "Bật/Tắt auto dùng item theo thời gian (Mặc định 5 giây)", true));
            CommandChats.Add(new CommandChat("aitemt", "X", "Thiết lập thời gian mỗi lần dùng item là X giây", true));
            // Auto Cộng Chỉ Số
            CommandChats.Add(new CommandChat("autocs", "Auto cộng chỉ số (Mặc định HP: 1000 – KI: 500 – SĐ: 60)", true));
            CommandChats.Add(new CommandChat("setcs", "X_Y_Z", "Thiếp lập chỉ số HP MP SĐ", true));
            // Auto khu
            CommandChats.Add(new CommandChat("kvip", "Bật/Tắt xem khu real-time", true));
            CommandChats.Add(new CommandChat("kz", "X", "Vào khu X khi khu còn chỗ trống (kvip)", true));
            CommandChats.Add(new CommandChat("kmin", "Vào khu ít người nhất (kvip)", true));
            CommandChats.Add(new CommandChat("kmin ", "X", "Vào khu ít người ít hơn X, ưu tiên ít nhất (kvip)", true));
            CommandChats.Add(new CommandChat("kmax", "Vào khu đông người nhất (kvip)", true));
            CommandChats.Add(new CommandChat("kmax ", "X", "Vào khu có số người đông hơn X, ưu tiên đông nhất (kvip)", true));
            CommandChats.Add(new CommandChat("kmm", "X", "Vào khu có số người đông hơn X, ưu tiên ít nhất (kvip)", true));
            CommandChats.Add(new CommandChat("kxx", "Huỷ đổi khu lập tức", true));
            CommandChats.Add(new CommandChat("rlz", "X_Y", "Bật/Tắt reload lại khu X (X=999 là chuyển khu ngẫu nhiên, Y số giây mỗi lần reload)", true));
            CommandChats.Add(new CommandChat("rlz", "Tắt reload khu", true));
            // Auto ĐKB
            CommandChats.Add(new CommandChat("adkb", "Bật/Tắt auto vào đảo kho báu", true));
            // Auto Hợp Thể
            CommandChats.Add(new CommandChat("fusion", "Bật/Tắt auto hợp thể", true));
            CommandChats.Add(new CommandChat("fusion", "X", "Thiết lập thời gian X giữa mỗi lần hợp thể", true));
            // Auto CSKB
            CommandChats.Add(new CommandChat("upcskb", "Bật/Tắt auto dùng máy dò up capsule kì bí", true));
            CommandChats.Add(new CommandChat("upcskb", "X", "Bật/Tắt auto dùng máy dò up capsule kì bí khi CSKB < X", true));
            CommandChats.Add(new CommandChat("mocskb", "Bật/Tắt auto mở cskb", true));
            CommandChats.Add(new CommandChat("mocskb", "X", "Bật/Tắt mở cskb mỗi Xmilis", true));
            // Auto Capsule về nhà thu đậu
            CommandChats.Add(new CommandChat("abp", "Bật/Tắt auto capsule về nhà thu đậu", true));
            // GoBack
            CommandChats.Add(new CommandChat("goback", "Bật/Tắt goback khi chết", true));
            // Kết nối đồng bộ dữ liệu QLTK
            CommandChats.Add(new CommandChat("oclient", "Kết nối với QLTK", true));
            CommandChats.Add(new CommandChat("qclient", "Thoát kết nối với QLTK", true));
            CommandChats.Add(new CommandChat("iclient", "Trạng thái kết nối với QLTK", true));


        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            //var st = File.OpenText("help.txt");
            //string sLine;
            //while ((sLine = st.ReadLine()) != null)
            //{
            //    string[] vs = sLine.Split(':');
            //    StringBuilder stringBuilder = new StringBuilder();
            //    stringBuilder.Append("CommandChats.Add(new CommandChat(\"");
            //    stringBuilder.Append(vs[0]);
            //    stringBuilder.Append("\", \"");
            //    stringBuilder.Append(vs[1]);
            //    stringBuilder.Append("\"));");
            //    Console.WriteLine(stringBuilder.ToString());

            //    //StringBuilder stringBuilder = new StringBuilder();
            //    //stringBuilder.Append("CommandChats.Add(");
            //    //stringBuilder.Append(sLine.Substring(0, sLine.Length - 1));
            //    //stringBuilder.Append(");");
            //    //Console.WriteLine(stringBuilder.ToString());
            //}
            //Console.ReadLine();

            loadinfo();
            File.WriteAllText("ChatCommands.json", LitJson.JsonMapper.ToJson(CommandChats));
        }
    }
}
