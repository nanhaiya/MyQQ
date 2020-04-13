using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace myqq
{
    public partial class FaceChoose : Form
    {
        public FaceChoose()
        {
            InitializeComponent();
        }
        public int x;
        public int y;
        SqlConnection c;
        private void Qian()
        {
            String s = "server=.;uid=sa;pwd=123;database=MyQQ";
            c = new SqlConnection(s);
            c.Open();
        }

        private void FaceChoose_Load(object sender, EventArgs e)
        {
            this.Left = x;
            this.Top = y;
            //把所有头像添加到白道
            for (int i = 0; i < imageList_face.Images.Count; i++)
            {
                ListViewItem item = new ListViewItem();
                item.ImageIndex = i;
                listView.Items.Add(item);
            }
        }

        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            int faceId = listView.SelectedItems[0].ImageIndex;
            Console.WriteLine(faceId);
            Qian();
            String sql = String.Format("update Users set FaceId={0} where Id={1}", faceId, QQuser.userId);
            SqlCommand cmd = new SqlCommand(sql, c);
            cmd.ExecuteNonQuery();
            c.Close();

            this.Close();

        }

    }
}
