using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace Quanlykhachsan3lop
{
    public partial class FormPhong : Form
    {
        public FormPhong()
        {
            InitializeComponent();
        }
         private void FormPhong_Load(object sender, EventArgs e)
        {
            show_cmb_loaiphong();
            Show_phong();
            Show_loaiphong();
        }
         public void show_cmb_loaiphong()
         {
             lpBUS = new LoaiPhongBUS();
             IList<LoaiPhongDTO> listDTO = lpBUS.getListLoaiPhongAll();
             cmbTenLoaiPhong.DataSource = listDTO;
             cmbTenLoaiPhong.DisplayMember = "Maloai";
             cmbTenLoaiPhong.ValueMember = "Maloai";
         }
        public void Show_phong()
        {
            pBUS = new PhongBUS();
            lsvPhong.Items.Clear();
            IList<PhongDTO> listPDTO = pBUS.getListPhongAll();
            foreach (PhongDTO p in listPDTO)
            {
                int i = lsvPhong.Items.Count;
                lsvPhong.Items.Add(p.Maphong);
                LoaiPhongDTO lpdto = lpBUS.getLoaiPhongByID(p.Maloai);
                lsvPhong.Items[i].SubItems.Add(lpdto.Maloai);
                lsvPhong.Items[i].SubItems.Add(lpdto.Songuoi.ToString());
                lsvPhong.Items[i].SubItems.Add(lpdto.Gia.ToString("0,0"));
            }
        }
        private void lsvLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvLoaiPhong.SelectedItems.Count <= 0) return;
            txtMaloai.Clear();
            txtGia.Text = lsvLoaiPhong.SelectedItems[0].SubItems[1].Text;
            txtSonguoi.Text = lsvLoaiPhong.SelectedItems[0].SubItems[2].Text;
        }

        private void btnThemPhong_Click(object sender, EventArgs e)
        {
            if (txtPhong.Text == "")
            {
                MessageBox.Show("Mã phòng không được để trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtPhong.Focus();
                return;
            }
            pBUS = new PhongBUS();
            pDTO = new PhongDTO();
            pDTO.Maphong = txtPhong.Text;
            pDTO.Maloai = cmbTenLoaiPhong.SelectedValue.ToString();
            if (pBUS.insertPhong(pDTO) == 1)
            {
                Show_phong();
            }
            else
            {
                MessageBox.Show("Phòng đã có!");
                txtPhong.SelectAll();
                txtPhong.Focus();
                return;
            }
        }

        private void btnXoaPhong_Click(object sender, EventArgs e)
        {
            if (lsvPhong.SelectedItems.Count <= 0)
            {
                return;
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc thực hiện việc này không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                        pBUS = new PhongBUS();
                        string fe = lsvPhong.SelectedItems[0].SubItems[0].Text;
                        if (pBUS.deletePhong(fe) == 1)
                        {
                            Show_phong();
                            txtPhong.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Không thể xóa vì nó đang được tham chiếu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                else
                {
                    lsvPhong.SelectedItems.Clear();
                }
            }
        }

        private void btnSuaPhong_Click(object sender, EventArgs e)
        {
            if (lsvPhong.SelectedItems.Count <= 0) return;
            pBUS = new PhongBUS();
            pDTO = new PhongDTO();
            pDTO.Maphong = lsvPhong.SelectedItems[0].SubItems[0].Text;
            pDTO.Maloai = cmbTenLoaiPhong.Text;
            pBUS.updatePhong(pDTO);
            Show_phong();
        }

        private void lsvLoaiPhong_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string maloai = lsvLoaiPhong.SelectedItems[0].SubItems[0].Text;

            frmVT = new FormVatTu();
            frmVT.frmPhong = this;
            frmVT.frmMain = frmMain;
            frmVT.maloai = maloai;
            frmVT.ShowDialog();
        }

        private void button1_VatTu_Click(object sender, EventArgs e)
        {
            if (lsvLoaiPhong.SelectedItems.Count <= 0)
            {
                MessageBox.Show("chọn 1 dòng");
                return;
            }
            else
            {
                string maloai = lsvLoaiPhong.SelectedItems[0].SubItems[0].Text;
                frmVT = new FormVatTu();
                frmVT.frmPhong = this;
                frmVT.frmMain = frmMain;
                frmVT.maloai = maloai;
                frmVT.ShowDialog();
            }
            /*frmVattu = new FormVatTu();
            frmVattu.frmPhong = this;
            frmVattu.frmMain = frmMain;
            frmVattu.ShowDialog();
            */
        }

        private void btnQLVT_Click(object sender, EventArgs e)
        {
            if (lsvLoaiPhong.SelectedItems.Count <= 0)
            {
                MessageBox.Show("chọn 1 dòng");
                return;
            }
            else
            {
                string maloai = lsvLoaiPhong.SelectedItems[0].SubItems[0].Text;
                frmVT = new FormVatTu();
                frmVT.frmPhong = this;
                frmVT.frmMain = frmMain;
                frmVT.maloai = maloai;
                frmVT.ShowDialog();
            }
        }
       
      

        //Loại Phòng-----------------------------------------------------------
        private void Show_loaiphong()
        {
            lpBUS = new LoaiPhongBUS();
            lsvLoaiPhong.Items.Clear();
            IList<LoaiPhongDTO> listpDTO = lpBUS.getListLoaiPhongAll();
            foreach (LoaiPhongDTO read in listpDTO)
            {
                int i = lsvLoaiPhong.Items.Count;
                lsvLoaiPhong.Items.Add(read.Maloai.ToString());
                lsvLoaiPhong.Items[i].SubItems.Add(read.Gia.ToString("0,0"));
                lsvLoaiPhong.Items[i].SubItems.Add(read.Songuoi.ToString());

                //combobox loaiphong
                //cmbTenLoaiPhong.Items.Add(read["tenloai"].ToString());
            }
        }
   
        private void lsvPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnThemLoaiPhong_Click(object sender, EventArgs e)
        {
            
            if (kiemtra())
            {
                    lpDTO = new LoaiPhongDTO();
                    lpDTO.Maloai = txtMaloai.Text;
                    lpDTO.Gia = decimal.Parse(txtGia.Text);
                    lpDTO.Songuoi = int.Parse(txtSonguoi.Text);
                    lpBUS = new LoaiPhongBUS();
                    if (lpBUS.insertLoaiPhong(lpDTO)==1)
                    {
                        Show_loaiphong();
                        txtMaloai.Clear();
                        txtGia.Clear();
                        txtSonguoi.Clear();
                    }
                    else
                    {
                        MessageBox.Show("Mã loại phòng đã có!");
                        txtMaloai.SelectAll();
                        txtMaloai.Focus();
                        return;
                    }
            }
        }

        private void btnXoaLoaiPhong_Click(object sender, EventArgs e)
        {
            if (lsvLoaiPhong.SelectedItems.Count <= 0)
            {
                return;
            }
            else
            {
                if (MessageBox.Show("Bạn có chắc thực hiện việc này không", "Thông Báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    for (int i = 0; i < lsvLoaiPhong.SelectedItems.Count; i++)
                    {
                        lpBUS = new LoaiPhongBUS();
                        string fe = lsvLoaiPhong.SelectedItems[i].SubItems[0].Text;
                        if (lpBUS.deleteLoaiPhong(fe) == 1)
                        {
                            Show_loaiphong();
                            txtMaloai.Clear();
                            txtGia.Clear();
                            txtSonguoi.Clear();
                        }
                        else 
                        {
                            MessageBox.Show("Không thể xóa vì nó đang được tham chiếu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
                else
                {
                    lsvLoaiPhong.SelectedItems.Clear();
                    txtMaloai.Clear();
                    txtGia.Clear();
                    txtSonguoi.Clear();
                }
            }
        }

        private void btnSuaLoaiPhong_Click(object sender, EventArgs e)
        {
            if (lsvLoaiPhong.SelectedItems.Count <= 0)
                return;
            if (gia() && songuoi())
            {
                lpBUS = new LoaiPhongBUS();
                lpDTO = new LoaiPhongDTO();
                lpDTO.Maloai = lsvLoaiPhong.SelectedItems[0].SubItems[0].Text;
                lpDTO.Gia =decimal.Parse( txtGia.Text);
                lpDTO.Songuoi = int.Parse(txtSonguoi.Text);
                lpBUS.updateLoaiPhong(lpDTO);
                Show_loaiphong();
                txtMaloai.Clear();
                txtGia.Clear();
                txtSonguoi.Clear();
            }
        }

        private void txtGia_KeyDown(object sender, KeyEventArgs e)
        {
            frmMain.KTChiSo(sender, e, txtGia, loi);
        }

        private void txtGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            frmMain.KoNhapChu(sender, e);
        }


        private bool maloai()
        {
            if (txtMaloai.Text == "")
            {
                MessageBox.Show("Mã loại phòng không được để trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMaloai.Focus();
                return false;
            }
            return true;
        }
   
        private bool gia()
        {
            if (txtGia.Text == "")
            {
                MessageBox.Show("Giá phòng không được để trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGia.Focus();
                return false;
            }
            return true;
        }
        private bool songuoi()
        {
            if (txtSonguoi.Text == "")
            {
                MessageBox.Show("Số người không được để trống", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSonguoi.Focus();
                return false;
            }
            return true;
        }
        private bool kiemtra()
        {
            if (maloai() && gia() && songuoi())
            {
                return true;
            }
            return false;
        }

        private void txtSonguoi_KeyDown(object sender, KeyEventArgs e)
        {
            frmMain.KTChiSo(sender, e, txtSonguoi, loi);
        }

        private void txtSonguoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            frmMain.KoNhapChu(sender, e);
        }

        private void tabLoaiphong_MouseClick(object sender, MouseEventArgs e)
        {
            Show_loaiphong();
        }

        private void tabctrPhong_MouseClick(object sender, MouseEventArgs e)
        {
            show_cmb_loaiphong();
            Show_loaiphong();
            Show_phong();
        }

        private void tabLoaiphong_Click(object sender, EventArgs e)
        {

        }

        private void lsvPhong_Click(object sender, EventArgs e)
        {
            if (lsvPhong.SelectedItems.Count <= 0) return;
            txtPhong.Clear();
            cmbTenLoaiPhong.Text = lsvPhong.SelectedItems[0].SubItems[1].Text;
        }
    }
}
