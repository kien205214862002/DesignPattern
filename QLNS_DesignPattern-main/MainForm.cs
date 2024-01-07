using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using CNPM.DataAccessTier;

namespace CNPM
{
   
    public partial class MainForm : Form
    {
        private ILogin loginService;
        private ILogin loginProxy;
        public MainForm()
        {
            InitializeComponent();
            //form f = new sachform();
            //f.show();
            loginService = new LoginService();
            loginProxy = new LoginProxy(loginService);
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Blah<KhachHangForm>();
        }

        private void sáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Blah<SachForm>();
        }

        private void lậpPhiếuNhậpSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Blah<PhieuNhapSach>();
        }

        private void lậpHóaĐơnBánSáchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Blah<LapHoaDon>();
        }

        private void thayĐổiQuyĐịnhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new QuiDinh();
            f.ShowDialog();
        }

        public void Blah<T>() where T: Form, new()
        {
            if (Application.OpenForms.OfType<T>().Any())
            {
                Application.OpenForms.OfType<T>().First().WindowState = FormWindowState.Normal;
                Application.OpenForms.OfType<T>().First().Focus();
            }
            else
            {
                Form f = new T();
                f.MaximizeBox = false;
                f.Show();
            }
        }

        private void thoátToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lậpPhiếuThuTiềnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Blah<PhieuThuTien>();
        }

        private void báoCáoTồnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Blah<BaoCaoTon>();
        }

        private void báoCáoCôngNợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Blah<BaoCaoCongNo>();
        }

        private void login_btn_Click(object sender, EventArgs e)
        {
            string username = account.Text;
            string password1 = password.Text;
            bool isLoggedIn = loginProxy.Login(username, password1);
            if (isLoggedIn)
            {
                MessageBox.Show("Login Sucessfully");
                //kokok
                sáchToolStripMenuItem.Visible=true;
                kháchHàngToolStripMenuItem.Visible=true;
                nghiệpVụToolStripMenuItem.Visible=true;
                tổChứcToolStripMenuItem.Visible=true;
                label1.Visible = false;
                label2.Visible = false;
                account.Visible = false;
                password.Visible = false;
                login_btn.Visible = false;
                Title.Text = "Chào mừng bạn";
            }
            else
            {
                MessageBox.Show("Fail!");
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            account.Text = string.Empty;
            password.Text = string.Empty;
            sáchToolStripMenuItem.Visible = false;
            kháchHàngToolStripMenuItem.Visible = false;
            nghiệpVụToolStripMenuItem.Visible = false;
            tổChứcToolStripMenuItem.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            account.Visible = true;
            password.Visible = true;
            login_btn.Visible = true;
            Title.Text = "Đăng nhập";
        }
    }
    public interface ILogin
    {
        bool Login(string username, string password);
    }
    public class LoginService : ILogin
    {

        public LoginService()
        {

        }
        public bool Login(string username, string password)
        {
            AccountDAT accountDAT = new AccountDAT();
            return accountDAT.GetUserByUsernameAndPassword(username, password);
        }
    }

    public class LoginProxy : ILogin
    {
        private ILogin loginService;
        public LoginProxy(ILogin loginService)
        {
            this.loginService = loginService;
        }

        public bool Login(string username, string password)
        {
            if (CanLogin(username,password))
            {
                return loginService.Login(username, password);
            }

            return false;
        }

        private bool CanLogin(string username,string password)
        {
            
            var withoutSpecial = new string(password.Where(c => Char.IsLetterOrDigit(c)
                                                        || Char.IsWhiteSpace(c)).ToArray());
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            foreach (var item in specialChar)
            {
                if (username.Contains(item)) return false;
            }

            if (password != withoutSpecial)
            {
                return false;
            }
            return true;
        }
    }

}
