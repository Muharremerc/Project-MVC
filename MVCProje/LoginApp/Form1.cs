using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RFID;
using ProjeDB;


namespace LoginApp
{
    public partial class Form1 : Form
    {
        RFID.NFCReader r = new RFID.NFCReader();
        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                using (var db = new ProjeEntities())
                {
                    if(label1.Text!=null)
                    {
                        label1.Text = null;
                        label2.Text = null;
                        label3.Text = null;
                        label4.Text = null;
                    }
                    r.Connect();

                    var id = r.GetCardUID();
                   var emp = db.Employees.FirstOrDefault(x => x.CardNumber == id);
                   if(emp != null)
                    {
                        label1.Text = emp.Name;
                        label2.Text = emp.Surname;
                        label3.Text = emp.CardNumber;
                        LoginEmployee l = new LoginEmployee();
                        l.EmployeeId = emp.Id;
                        DateTime localDate = DateTime.Now;
                        l.Date =Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss").ToString());
                        label4.Text = Convert.ToString(Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss").ToString()));
                        var s= r.Watch();
                        label4.Text = s;
                        var sname = db.Shifts.Where(x => x.ShiftNumber == s).FirstOrDefault();
                        l.Shiftname = sname.Name;
                        
                        db.LoginEmployees.Add(l);
                        db.SaveChanges();
                    }
                   
                   
                }
            }
              
            catch (Exception)
            {

                throw;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
           

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
