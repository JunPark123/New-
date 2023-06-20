using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New_검사_프로그램_화면_구성
{
    public partial class Form1 : Form
    {
        private DataTable testtable;

        public Form1()
        {
            InitializeComponent();
            var myTitleBinding = new BindingSource();
            show_dataview();

            insert_dataview();
            insert_dataview2();
        }

        public void show_dataview()
        {
            testtable = new DataTable();

            // Column 생성 과 동시에 컬럼명 과 타입을 준다.
            testtable.Columns.Add(new DataColumn { ColumnName = "순서", DataType = typeof(int) });
            testtable.Columns.Add(new DataColumn { ColumnName = "검사 항목", DataType = typeof(string) });
            testtable.Columns.Add(new DataColumn { ColumnName = "검사 결과", DataType = typeof(string) });

            dataGridView2.DataSource = testtable;

            dataGridView2.RowTemplate.Height = 35; // 셀 높이 결정        
            dataGridView2.Columns[0].Width = 70;
            dataGridView2.Columns[1].Width = 200;
            dataGridView2.Columns[2].Width = 100;

        }
        public void insert_dataview2()
        {
            DataRow newRow = testtable.NewRow();
            newRow["순서"] = 1;
            newRow["검사 항목"] = "ignition 검사입니다.";
            newRow["검사 결과"] = "Pass";
            testtable.Rows.Add(newRow);
            for (int i = 0; i < 50; i++)
            {
                testtable.Rows.Add(i + 1, "Boot 검사입니다", "Pass");
            }
        }

        public void insert_dataview()
        {
            List<Donation> donationList = new List<Donation>();
            Donation d1 = new Donation { Name = "GPIB Adrrss", Item = 1, Unit = "mA" };
            Donation d2 = new Donation { Name = "CAN Baudrate", Item = 2, Unit = "mA" };
            Donation d3 = new Donation { Name = "RS232 Port", Item = 3, Unit = "mA" };

            donationList.Add(d1);
            donationList.Add(d2);
            donationList.Add(d3);

            // DataGridView의 DataSource 속성에 Donation 리스트 (컬렉션)을 지정하여
            // 데이타 바인딩을 수행한다
            dataGridView1.DataSource = donationList;
        }
    }

    class Donation
    {
        public string Name { get; set; } //Name
        public int Item { get; set; } //Item
        public string Unit { get; set; } //unit
    }
}
