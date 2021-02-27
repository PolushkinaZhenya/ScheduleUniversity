using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace ScheduleView
{
    public partial class FormMain : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public FormMain()
        {
            InitializeComponent();
        }

        private void типыАудиторийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormTypeOfAudiences>();
            form.ShowDialog();
        }

        private void типыКафедрToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormTypeOfDepartments>();
            form.ShowDialog();
        }

        private void кафедрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormDepartments>();
            form.ShowDialog();
        }
    }
}
